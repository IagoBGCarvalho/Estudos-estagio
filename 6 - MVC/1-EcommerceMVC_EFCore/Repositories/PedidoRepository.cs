using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public class PedidoRepository : BaseRepository<Pedido>
    {
        public PedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
