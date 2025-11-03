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

// O entity permite fazer todas as operações CRUD (Create, Read, Update e Delete)

using Alura.Loja.Testes.Data;
using Alura.Loja.Testes.Models;

namespace Alura.Loja.Testes {
    class Program
    {
        static void Main(string[] args)
        {
            //GravarUsandoEntity();
            //RecuperarProdutos();
            //ExcluirProdutos();
            //RecuperarProdutos();
            //AtualizarProduto();
        }

        private static void GravarUsandoEntity()
        {
            // Create (está criando um novo dado no sistema)

            // Utiliza-se o modelo referente a tabela para criar uma variável que fará o mapeamento dos parâmetros para um ojeto que representará os dados gravados na tabela.
            // Cada propriedade do objeto deve ser preenchida de acordo com as especificações das colunas da tabela
            Produto p = new Produto();
            p.Nome = "Harry Potter e a Ordem da Fênix";
            p.Categoria = "Livros";
            p.Preco = 19.89;

            // O using é utilizado para ininicar a conexão, realizar os processamentos e depois encerra-lá utilizando o dispose():
            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Add(p); // Para dar um insert no banco, utiliza-se a propriedade que representa a tabela e o método Add que fará toda a formatação do insert automaticamente
                contexto.SaveChanges(); // SaveChanges sempre deve ser utilizado para implementar as alterações
            }
        }

        private static void RecuperarProdutos()
        {
            // Read (está lendo os dados já existentes no sistema)

            using (var contexto = new LojaContext())
            {
                // Para retornar um SELECT, é necessário converter a propriedade que representa o banco em uma lista e
                // depois atribuir o resultado a uma variável que implementa uma interface IList do modelo que
                // representa a tabela.
                IList<Produto> produtos = contexto.Produtos.ToList();
                Console.WriteLine("\nForam encontrados {0} produto(s).", produtos.Count);
                foreach (var item in produtos)
                {
                    Console.WriteLine(item.Nome);
                }
            }
        }

        private static void AtualizarProduto()
        {
            // Update (está atualizando partes de um dado no sistema ou ele todo)

            // Incluir um produto
            GravarUsandoEntity(); // Gravando um produto para teste
            RecuperarProdutos();

            // Atualizar o produto
            using (var contexto = new LojaContext())
            {
                Produto primeiro = contexto.Produtos.First(); // Para teste, pegando o primeiro produto, mas poderia ser outra condição
                primeiro.Nome = "Harry Potter - Editado"; // Alterando a propriedade do objeto que representa a coluna do registro a ser alterada
                contexto.Produtos.Update(primeiro); // Chama o Update do entity que automaticamente cria um comando SQL UPDATE com as alterações realizadas previamente no objeto
                contexto.SaveChanges();
            }
            RecuperarProdutos();
        }

        private static void ExcluirProdutos()
        {
            // Delete (está removendo um dado do sistema)

            using (var contexto = new LojaContext())
            {
                IList<Produto> produtos = contexto.Produtos.ToList();
                foreach (var item in produtos)
                {
                    contexto.Produtos.Remove(item); // Utiliza os produtos encontrados pelo select para remover eles da propriedade do contexto, consequentemente, da tabela do banco de dados.
                }
                contexto.SaveChanges(); // É necessário salvar as mudanças depois que todas as remoções são feitas na propriedade
            }
        }
    }
}