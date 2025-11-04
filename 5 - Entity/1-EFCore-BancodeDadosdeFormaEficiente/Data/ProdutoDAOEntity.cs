using Alura.Loja.Testes.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Data
{
    internal class ProdutoDAOEntity : IDisposable, IProdutoDAO
    {
        // Uma classe DAO (Data Access Object) é um padrão de projeto que isola a lógica de acesso a dados, como as operações CRUD da lógica de negócio.
        // Funciona como uma ponte entre a aplicação e o banco de dados, encapsulando as regras de negócio.

        // Esta classe está responsável, exclusivamente,  por conter a interface com a declaração das funções do CRUD e a lógica de cada um utilizando o Entity para acesso aos dados.

        // O entity permite fazer todas as operações CRUD (Create, Read, Update e Delete)

        private LojaContext contexto;
        public ProdutoDAOEntity()
        {
            this.contexto = new LojaContext(); // É necessário usar o construtor para criar uma instância de LojaContext que será utilizada toda vez que a classe for chamada
        }
        
        public void Adicionar(Produto p)
        {
            // Create (está criando um novo dado no sistema)
            contexto.Produtos.Add(p); // Para dar um insert no banco, utiliza-se a propriedade que representa a tabela e o método Add que fará toda a formatação do insert automaticamente
            contexto.SaveChanges(); // SaveChanges sempre deve ser utilizado para implementar as alterações solicitadas no banco
        }

        public void Atualizar(Produto p)
        {
            // Update (está atualizando partes de um dado no sistema ou ele todo)
            contexto.Produtos.Update(p); // Chama o Update do entity que automaticamente cria um comando SQL UPDATE com as alterações realizadas previamente no objeto
            contexto.SaveChanges();
        }

        public IList<Produto> Produtos()
        {
            // Read (está lendo os dados já existentes no sistema)
            var produtos = contexto.Produtos.ToList();
            Console.WriteLine("\nForam encontrados {0} produto(s).", produtos.Count);
            return produtos; // Para dar um SELECT, simplesmente retorna uma lista da propriedade DbSet Produtos do contexto.
        }

        public void Remover(Produto p)
        {
            // Delete (está removendo um dado do sistema)
            contexto.Produtos.Remove(p); // Utiliza os produtos encontrados pelo select para remover eles da propriedade do contexto, consequentemente, da tabela do banco de dados.
            contexto.SaveChanges();
        }

        public void Dispose()
        {
            contexto.Dispose(); // Dispose serve para dar um "free" no contexto quando o using da main terminar
        }
    }
}
