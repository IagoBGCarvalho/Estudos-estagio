using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public class BaseRepository<T> where T : BaseModel
    {
        protected readonly ApplicationContext contexto;
        protected readonly DbSet<T> dbset;

        public BaseRepository(ApplicationContext contexto)
        {
            this.contexto = contexto;
            dbset = contexto.Set<T>();
        }
    }
}
