using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public class CadastroRepository : BaseRepository<Cadastro>
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
