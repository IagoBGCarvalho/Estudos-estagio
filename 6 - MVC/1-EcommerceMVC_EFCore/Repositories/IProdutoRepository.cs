using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public interface IProdutoRepository
    {
        void SaveProdutos(List<Livro>? livros);
        IList<Produto> GetProdutos();
    }
}