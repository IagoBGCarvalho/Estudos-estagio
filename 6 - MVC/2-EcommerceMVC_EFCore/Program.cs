// Como o curso foi ministrado com o .NET 6 e hoje em dia ele praticamente não é mais utilizado, iniciei uma jornada para conseguir aprender MVC,
// mas utilizando a versão mais nova da tecnologia, pois ela possui algumas diferenças significativas, como a ausência do arquivo de Startup.

// Criei um projeto MVC com .NET 8, copiei os arquivos de recurso do professor (.css, .cshtml, imagens, etc...) que foram criados em um projeto mais
// antigo (.NET 6) e o resultado foi uma página quebrada, com elementos desalinhados, sem header/footer e sem carrossel, indicando que o HTML do
// _Layout.cshtml estava sendo carregado, mas o CSS não.

// Tentei refazer o projeto e copiar e colar novamente os arquivos, acreditando que tinha sido algum erro humano, mas nada adiantou. Ao analisar os
// arquivos, notei que o arquivo de layout referenciava versões mais antigas do bootstrap e do jquery, como em: href="...bootstrap/3.3.7/..." e
// src=".../jquery/jquery-2.2.0...". O modelo de MVC do .NET 8 cria uma pasta lib em wwwroot com os pacotes do bootstrap 5, gerando o conflito.

// Para resolver isso, instalei uma biblioteca chamada libman (Library Manager) utilizando: "dotnet tool install -g Microsoft.Web.LibraryManager.Cli"
// que permite substituir bibliotecas instaladas em um projeto por outras versões. Para substituir as libs do Bootstrap 5 pelo 3, criei o arquivo
// "libman.json" na raiz do projeto e lá especifiquei as versões do Bootstrap e do Jquery que estavam expressas no arquivo de layout e também as
// localizações de onde cada pasta/arquivo deveria ficar (levando em consideração as linhas do _Layout.cshtml que fazem a requisição desses arquivos).
// Depois de criar o arquivo, apenas tive que apagar o diretório wwwroot/lib e dar um "libman restore" para criar novamente, mas com as especificações
// do libman.json.

// Após isso tudo, a página piorou, ficou sem estilização alguma (antes existia, mas era quebrada), o que me levou a outra investigação. Utilizei as
// ferramentas de desenvolvedor do navegador, entrei na área de rede, desativei o cache e atualizei a página para verificar os arquivos que o navegador
// estava tentando carregar, se ele conseguia e, se não (404) qual era o caminho pelo qual ele estava tentando requisitar esses arquivos. A primeira prova
// foi que o navegador estava tentando solicitar os arquivos "bootstrap.min.css", "site.min.css" e "bootstrap.bundle.min.js" mas estava recebendo um 404. 

// Ao dar um "tree wwwroot /f" no projeto, percebi que esses arquivos existiam (bootstrap.css e site.css), mas não em forma em forma minificada, já o
// bootstrap.bundle é um arquivo que está presente apenas no bootstrap 4 para cima, não no baixado pelo libman (3). Ou seja, juntando todas as pistas,
// cheguei a conclusão de que se tratava de uma maré de conflitos: o layout que o servidor estava usando era do .NET 8, então pedia os arquivos do
// bootstrap 5, estava rodando em modo de produção (pois estava pedindo os arquivos .min) e o libman apenas tinha criado os arquivos normais.

// Para resolver definitivamente, forcei o modo de desenvolvimento no Program.cs, entrei em um repositório qualquer do github que versionou o projeto
// da aula para copiar o conteúdo do _Layout.cshtml e colar no meu e limpei o cache do servidor com "dotnet clean" e "dotnet build".

using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;
using _1_EcommerceMVC_EFCore.Repositories;
using Microsoft.EntityFrameworkCore;

// REGISTRO DE SERVIÇOS NO CONTAINER
var builder = WebApplication.CreateBuilder(args);

builder.Environment.EnvironmentName = Environments.Development; // Força o programa a rodar em modo de desenvolvimento

builder.Services.AddControllersWithViews();

builder.Services.AddDistributedMemoryCache(); // Serviço responsável por guardar as informações da nevegação da memória
builder.Services.AddSession(); // Ativa os cookies

builder.Services.AddHttpContextAccessor();

//var connectionString = builder.Configuration.GetConnectionString("Default"); 
var configuration = Configuracao.LoadConfiguration(); 
var connectionString = configuration.GetConnectionString("Default");

builder.Services.AddDbContext<ApplicationContext>(options =>
    options.UseSqlServer(connectionString)
); // Adiciona o contexto da aplicação como serviço e define o SqlServer como DB

builder.Services.AddTransient<IDataService, DataService>(); // Registrando o serviço do data service para utilizar a injeção de dependências
builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
builder.Services.AddTransient<IPedidoRepository, PedidoRepository>();
builder.Services.AddTransient<IItemPedidoRepository, ItemPedidoRepository>();
builder.Services.AddTransient<ICadastroRepository, CadastroRepository>();

builder.Services.Configure<AppSettings>(configuration.GetSection("AppSettings"));

// CONFIGURAÇÃO DO PIPELINE DO HTTP
var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    // Este using serve para criar o banco de dados na primeira inicialização da aplicação.
    // É utilizado em um using para garantir que o contexto será utilizado com segurança.
    var services = scope.ServiceProvider;
    var context = services.GetRequiredService<IDataService>();

    context.InicializaDB(); // Cria o banco e garante que todas as migrations pendentes serão aplicadas
}

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.UseSession(); // Habilitando a sessão. o ASP.NET Core passa a ler e gravar o cookie de sessão em cada requisição e a propriedade HttpContext.Session passa a funcionar

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Pedido}/{action=Carrossel}/{codigo?}")
    .WithStaticAssets();

app.Run();
