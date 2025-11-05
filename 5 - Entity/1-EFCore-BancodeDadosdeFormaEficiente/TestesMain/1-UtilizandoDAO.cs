// // Utilizando o contexto diretamente (não recomendado):
// using Alura.Loja.Testes.Data;
// using Alura.Loja.Testes.Models;

// using (var contexto = new LojaContext())
// {
//     var produtos = contexto.Produtos.ToList();

//     var p1 = produtos.First();
//     p1.Nome = "008"; // Apenas mudar uma propriedade do objeto já faz com que o Entity entenda que deve dar um UPDATE no banco
//                      // Isso acontece pois o Entity possui o ChangeTracker, que é uma propriedade responsável por rastrear todas as mudanças que estão acontecendo na instância do contexto.
//     contexto.SaveChanges();

//     produtos = contexto.Produtos.ToList();
//     foreach (var p in produtos)
//     {
//         Console.WriteLine(p);
//     }

//     // O ChangeTracker possui uma lista de todas as entidades gerenciadas no contexto:
//     var entidades = contexto.ChangeTracker.Entries();
//     Console.WriteLine("====================");
//     foreach (var entidade in entidades)
//     {
//         Console.WriteLine(entidade.Entity.ToString() + " - " + entidade.State); // O método ToString das entidade retorna o nome da tabela, o ID e o estado do objeto (se foi alterado ou não)
//     }
// }

// // Utilizando o DAO:

// // Pegando dados de input do usuário para adicionar um produto na tabela
// Console.WriteLine("\nDeseja adicionar um produto na tabela? Digite 'S' para SIM e 'N' para NÃO:");
// var decisaoUsuario = (Console.ReadLine() ?? "").ToUpper();

// if (decisaoUsuario == "S")
// {
//     Console.WriteLine("Digite o nome do produto:");
//     var nomeProduto = Console.ReadLine() ?? "";

//     Console.WriteLine("Digite a categoria do produto:");
//     var categoriaProduto = Console.ReadLine() ?? "";

//     Console.WriteLine("Digite o preço do produto:");
//     var precoProduto = Console.ReadLine() ?? "";
//     var precoProdutoDouble = Double.Parse(precoProduto);

//     Console.WriteLine("Digite a unidade do produto:");
//     var unidadeProduto = Console.ReadLine() ?? "";

//     // Declaração e mapemanto do objeto que será utilizado para inserir os dados na tabela:

//     // Utiliza-se o modelo (Produto) referente a tabela (Produtos) para criar uma variável que fará o mapeamento dos parâmetros para um objeto que representará os dados gravados na tabela.
//     // Cada propriedade do objeto deve ser preenchida de acordo com as especificações das colunas da tabela
//     Produto novoProduto = new Produto();
//     novoProduto.Nome = nomeProduto;
//     novoProduto.Categoria = categoriaProduto;
//     novoProduto.PrecoUnitario = precoProdutoDouble;
//     novoProduto.Unidade = unidadeProduto;

//     using (var contexto = new ProdutoDAOEntity())
//     {
//         contexto.Adicionar(novoProduto); // O using é utilizado para inicar a conexão, realizar os processamentos e depois encerra-lá utilizando o dispose()
//     }
// }

// // Listando os produtos no banco:
// using (var contexto = new ProdutoDAOEntity())
// {
//     Console.WriteLine("============================");
//     Console.WriteLine("Produtos no banco:");
//     var produtos = contexto.Produtos();
//     foreach (var p in produtos)
//     {
//         Console.WriteLine(p);
//     }
// }