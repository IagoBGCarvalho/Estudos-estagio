// O Microsoft Entity Framework Core é uma ferramenta multiplataforma utilizada para realizar operações em bancos de dados sem precisar formular todas os comandos SQL de manipulação de dados na mão

// Script para criar a tabela utilizada:
//CREATE TABLE[dbo].[Produtos] (
//    [Id]        INT IDENTITY(1, 1) NOT NULL,
//    [Nome]      NVARCHAR (MAX) NULL,
//    [Categoria] NVARCHAR (MAX) NULL,
//    [Preco]     FLOAT (53)     NULL,
//    CONSTRAINT[PK_Produtos] PRIMARY KEY CLUSTERED ([Id] ASC)
//);

// Para utilizar o Entity em um projeto, é necessário instalar 3 pacotes (todos na versão 8.0.21 caso a versão do .NET seja a 8):
// 1 - "Microsoft.EntityFrameworkCore" que contém o motor do Entity
// 2 - "Microsoft.EntityFrameworkCore.SqlServer" que contém as injeções do SqlServer
// 3 - "Microsoft.EntityFrameworkCore.Tools" que contém as ferramentas de migração

// Para abrir o manual do Entity, basta digitar no terminal: "dotnet ef"

using Alura.Loja.Testes.Data;
using Alura.Loja.Testes.Migrations;
using Alura.Loja.Testes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Alura.Loja.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var contexto = new LojaContext())
            {
                // JOIN de relação 1:N com filtro na relação:
                var produto = contexto
                    .Produtos
                    .Where(p => p.Id == 4002)
                    .FirstOrDefault();

                // Para aplicar filtros em tabelas relacionadas, é necessário criar o filtro e carregar ele na Entry

                contexto.Entry(produto)
                    .Collection(p => p.Compras)
                    .Query() // Faz uma querie na tabela representada pela coleção Compras
                    .Where(c => c.Preco > 1) // Condição de filtragem
                    .Load(); // Carregando a querie na referência produto

                Console.WriteLine($"Mostrando as compras do produto {produto.Nome} onde o preço total é maior do que 1:\n");
                foreach (var item in produto.Compras)
                {
                    Console.WriteLine("\t" + item);
                }
            }
        }
        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            /// Função que exibe o estado de cada entrie sendo trackeada pelo ChangeTracker
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }

        }
        private static void UtilizandoDAO()
        {
            // Utilizando o contexto diretamente (não recomendado):

            using (var contexto = new LojaContext())
            {
                var produtos = contexto.Produtos.ToList();

                var p1 = produtos.First();
                p1.Nome = "008"; // Apenas mudar uma propriedade do objeto já faz com que o Entity entenda que deve dar um UPDATE no banco
                                 // Isso acontece pois o Entity possui o ChangeTracker, que é uma propriedade responsável por rastrear todas as mudanças que estão acontecendo na instância do contexto.
                contexto.SaveChanges();

                produtos = contexto.Produtos.ToList();
                foreach (var p in produtos)
                {
                    Console.WriteLine(p);
                }

                // O ChangeTracker possui uma lista de todas as entidades gerenciadas no contexto:
                var entidades = contexto.ChangeTracker.Entries();
                Console.WriteLine("====================");
                foreach (var entidade in entidades)
                {
                    Console.WriteLine(entidade.Entity.ToString() + " - " + entidade.State); // O método ToString das entidade retorna o nome da tabela, o ID e o estado do objeto (se foi alterado ou não)
                }
            }

            // Utilizando o DAO:

            // Pegando dados de input do usuário para adicionar um produto na tabela
            Console.WriteLine("\nDeseja adicionar um produto na tabela? Digite 'S' para SIM e 'N' para NÃO:");
            var decisaoUsuario = (Console.ReadLine() ?? "").ToUpper();

            if (decisaoUsuario == "S")
            {
                Console.WriteLine("Digite o nome do produto:");
                var nomeProduto = Console.ReadLine() ?? "";

                Console.WriteLine("Digite a categoria do produto:");
                var categoriaProduto = Console.ReadLine() ?? "";

                Console.WriteLine("Digite o preço do produto:");
                var precoProduto = Console.ReadLine() ?? "";
                var precoProdutoDouble = Double.Parse(precoProduto);

                Console.WriteLine("Digite a unidade do produto:");
                var unidadeProduto = Console.ReadLine() ?? "";

                // Declaração e mapemanto do objeto que será utilizado para inserir os dados na tabela:

                // Utiliza-se o modelo (Produto) referente a tabela (Produtos) para criar uma variável que fará o mapeamento dos parâmetros para um objeto que representará os dados gravados na tabela.
                // Cada propriedade do objeto deve ser preenchida de acordo com as especificações das colunas da tabela
                Produto novoProduto = new Produto();
                novoProduto.Nome = nomeProduto;
                novoProduto.Categoria = categoriaProduto;
                novoProduto.PrecoUnitario = precoProdutoDouble;
                novoProduto.Unidade = unidadeProduto;

                using (var contexto = new ProdutoDAOEntity())
                {
                    contexto.Adicionar(novoProduto); // O using é utilizado para inicar a conexão, realizar os processamentos e depois encerra-lá utilizando o dispose()
                }
            }

            // Listando os produtos no banco:
            using (var contexto = new ProdutoDAOEntity())
            {
                Console.WriteLine("============================");
                Console.WriteLine("Produtos no banco:");
                var produtos = contexto.Produtos();
                foreach (var p in produtos)
                {
                    Console.WriteLine(p);
                }
            }
        }
        private static void UtilizandoChangeTracker()
        {
            Produto paoFrances = new Produto();
            paoFrances.Nome = "Pão Francês";
            paoFrances.PrecoUnitario = 0.40;
            paoFrances.Unidade = "Unidade";
            paoFrances.Categoria = "Padaria";

            var compra = new Alura.Loja.Testes.Models.Compra();
            compra.Quantidade = 6;
            compra.Produto = paoFrances;
            compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

            using (var contexto = new LojaContext())
            {
                contexto.Compras.Add(compra);
                ExibeEntries(contexto.ChangeTracker.Entries()); // ChangeTracker.Entries retorna todas as Entries do Entity, que são objetos que possuem informações do estado das entidades mapeadas
                contexto.SaveChanges();
            }
        }
        private static void MuitosParaMuitos()
        {
            // Criando produtos a serem adicionados na promoção:
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            // Incluindo produtos na promoção:
            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                // Persistindo a promoção no banco
                //contexto.Promocoes.Add(promocaoDePascoa);
                //ExibeEntries(contexto.ChangeTracker.Entries());
                //contexto.SaveChanges();

                // Removendo uma promoção do banco:
                var promocao = contexto.Promocoes.First();
                contexto.Promocoes.Remove(promocao);
                
                contexto.SaveChanges();
            }
        }
        private static void UmParaUm()
        {
            var fulano = new Cliente();
            fulano.Nome = "Fulaninho de Tal";
            fulano.EnderecoDeEntrega = new Endereco()
            {
                Numero = 12,
                Logradouro = "Rua dos Inválidos",
                Complemento = "Sobrado",
                Bairro = "Centro",
                Cidade = "Cidade"
            };

            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Add(fulano);
                contexto.SaveChanges();
            }
        }
        private static void ArrumandoRegistrosDoBanco()
        {
            // Subi os produtos "Água" e "Energético Monster" como "Bebida" ao invés de "Bebidas", então fiz este código para resolver isso:
            using (var contexto = new LojaContext())
            {
                var produtosBebida = contexto.Produtos.Where(p => p.Categoria == "Bebida"); // Cria uma coleção contendo os produtos onde a categoria é "Bebida"
                foreach (var item in produtosBebida)
                {
                    item.Categoria = "Bebidas"; // Itera sobre a coleção criada e altera a propriedade Categoria para "Bebidas"
                }
                ExibeEntries(contexto.ChangeTracker.Entries());
                contexto.SaveChanges(); // Salva as mudanças no banco
            }
        }
        private static void IncluirPromocao()
        {
            using (var contexto = new LojaContext())
            {
                var promocao = new Promocao();
                promocao.Descricao = "Queima Total Janeiro 2025";
                promocao.DataInicio = new DateTime(2017, 1, 1);
                promocao.DataTermino = new DateTime(2017, 1, 31);

                var produtos = contexto
                    .Produtos
                    .Where(p => p.Categoria == "Bebidas") // Método LINQ que funciona como o WHERE do SQL
                    .ToList(); // ToList faz um SELECT de todos os registros de Produto

                foreach (var item in produtos)
                {
                    promocao.IncluiProduto(item);
                }

                contexto.Promocoes.Add(promocao);

                ExibeEntries(contexto.ChangeTracker.Entries());
                //contexto.SaveChanges();
            }
        }
        private static void JOINNparaM()
        {
            using (var contexto = new LojaContext())
            {
                // Criando um Join entre Produtos, Promocoes e PromocaoProduto (N:M):
                //var promocao = contexto2.Promocoes.FirstOrDefault(); // Não funciona, é necessário dizer explicitamente ao Entity a relação que ser retornar
                var promocao = contexto
                    .Promocoes // Preparando uma querie em Promocoes
                    .Include(p => p.Produtos) // Diz para o EF carregar junto a coleção Produtos (que é a lista PromocaoProduto dentro de cada promoção)
                    .ThenInclude(pp => pp.Produto) // Inclui o objeto Produto dentro de cada PromocaoProduto, trazendo os dados completos de cada produto
                    .FirstOrDefault(); // Retorna a primeira promoção encontrada

                //// O código SQL correspondente seria algo como:
                //SELECT*
                //FROM Promocoes AS p
                //LEFT JOIN PromocaoProduto AS pp ON p.Id = pp.PromocaoId
                //LEFT JOIN Produtos AS pr ON pp.ProdutoId = pr.Id


                Console.WriteLine("\nMostrando os produtos da promoção:\n");
                foreach (var item in promocao.Produtos)
                {
                    Console.WriteLine(item.Produto);
                }
            }
        }
        private static void JOIN1para1()
        {
            using (var contexto = new LojaContext())
            {
                // JOIN de relação 1:1:
                var cliente = contexto
                    .Clientes
                    .Include(c => c.EnderecoDeEntrega) // Ao pegar o cliente do banco, apenas os dados da tabela do cliente são incluídos, então para acessar dados de outra tabela relacionada a cliente (no caso, o endereço) é necessário pedir ao EF para que el INCLUA os dados da tabela Endereco
                    .FirstOrDefault(); // Atribuindo à variável o objeto que corresponde ao registro do primeiro cliente do banco

                Console.WriteLine($"Endereço de entrega: {cliente.EnderecoDeEntrega.Logradouro}");
            }
        }
    }
}