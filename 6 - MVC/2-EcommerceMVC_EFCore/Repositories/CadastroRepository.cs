using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public interface ICadastroRepository
    {
        Cadastro Update(int cadastroId, Cadastro novoCadastro);
    }
    public class CadastroRepository : BaseRepository<Cadastro>, ICadastroRepository
    {
        public CadastroRepository(ApplicationContext contexto) : base(contexto)
        {
        }

        public Cadastro Update(int cadastroId, Cadastro novoCadastro)
        {
            var cadastroDB = dbset.Where(c => c.Id == cadastroId).SingleOrDefault();

            if (cadastroDB == null)
            {
                throw new ArgumentException("cadastro");
            }

            cadastroDB.Update(novoCadastro);
            contexto.SaveChanges();
            return cadastroDB;
        }
    }
}
