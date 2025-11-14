using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        // Repository se trata de um design de acesso a dados

        public IList<Produto> GetProdutos()
        {
            return dbset.ToList();
        }

        public void SaveProdutos(List<Livro>? livros)
        {
            foreach (var livro in livros)
            {
                
                if (!dbset.Where(p => p.Codigo == livro.Codigo).Any()) // Se o produto NÃO existir no banco, será adicionado
                {
                    dbset.Add(new Produto(livro.Codigo, livro.Nome, livro.Preco)); // Adicionando cada livro na tabela de produtos do banco de dados
                }
            }
            contexto.SaveChanges();
        }
    }
}
