using _1_EcommerceMVC_EFCore.Models.ViewModels;

namespace _1_EcommerceMVC_EFCore.Models
{
    public class UpdateQuantidadeResponse
    {
        public UpdateQuantidadeResponse(ItemPedido itemPedido, CarrinhoViewModel carrinhoViewModel)
        {
            ItemPedido = itemPedido;
            CarrinhoViewModel = carrinhoViewModel;
        }

        public ItemPedido ItemPedido { get; } = null!;
        public CarrinhoViewModel CarrinhoViewModel { get; } = null!;

    }
}
