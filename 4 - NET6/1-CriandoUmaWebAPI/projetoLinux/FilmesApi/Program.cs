// Uma API se trata de uma interface que faz a ponte entre diversos clientes e um mesmo banco de dados.
// Ou seja, evita a implementação da lógica de persistência para cada cliente diferente, facilitando o desenvolvimento.
using FilmesApi.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("FilmeConnection"); // Método GetConnectionString que retorna a string de conexão do campo "ConnectionStrings" do arquivo appsettings.json

builder.Services.AddDbContext<FilmeContext>(opts => opts.UseSqlServer(connectionString)); 
// A linha anterior Utiliza os serviços da classe WebApplication para criar uma "receita" que ensina ao .NET que, sempre que alguém pedir um FilmeContext,
// deve criar uma instância utilizando as opções (UseSqlServer e a connectionString), abrir uma conexão e entregá-la.

// Usando um controlador de exemplo, ao usar a instância do FilmeContext e retornar ualguma Ação (como Ok(), CreatedAtAction(), NotFound()...) a instância e conexão serão descartadas.
// Este padrão de design se e chama "Escopo por Requisição".

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies()); // Registra a interface IMapper e escaneia as classes que herdam de AutoMapper.Profile
var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
