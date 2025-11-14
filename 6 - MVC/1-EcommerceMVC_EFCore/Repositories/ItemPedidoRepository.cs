using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public class ItemPedidoRepository : BaseRepository<ItemPedido>
    {
        public ItemPedidoRepository(ApplicationContext contexto) : base(contexto)
        {
        }
    }
}
