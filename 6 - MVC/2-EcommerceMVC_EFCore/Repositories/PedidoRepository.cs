using _1_EcommerceMVC_EFCore.Data;
using _1_EcommerceMVC_EFCore.Models;
using _1_EcommerceMVC_EFCore.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace _1_EcommerceMVC_EFCore.Repositories
{
    public interface IPedidoRepository
    {
        void AddItem(string codigo);
        Pedido GetPedido();
        UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido);
    }
    public class PedidoRepository : BaseRepository<Pedido>, IPedidoRepository
    {
        private readonly IHttpContextAccessor _contextAccessor;
        private readonly IItemPedidoRepository _itemPedidoRepository;
        public PedidoRepository(ApplicationContext contexto, IHttpContextAccessor contextAccessor, IItemPedidoRepository itemPedidoRepository) : base(contexto)
        {
            this._contextAccessor = contextAccessor;
            this._itemPedidoRepository = itemPedidoRepository;
        }

        public void AddItem(string codigo)
        {
            var produto = contexto.Set<Produto>().Where(p => p.Codigo == codigo).SingleOrDefault();

            if (produto == null)
            {
                throw new ArgumentException("Produto não encontrado.");
            }

            var pedido = GetPedido();

            var itemPedido = contexto.Set<ItemPedido>().Where(i => i.Produto.Codigo == codigo && i.Pedido.Id == pedido.Id).SingleOrDefault();

            if (itemPedido == null)
            {
                itemPedido = new ItemPedido(pedido, produto, 1, produto.Preco);
                contexto.Set<ItemPedido>().Add(itemPedido);
                contexto.SaveChanges();
            }
        }

        public Pedido GetPedido()
        {
            var pedidoId = GetPedidoId();
            var pedido = dbset
                .Include(p => p.Itens) // Incluindo vários itens no pedido
                .ThenInclude(i => i.Produto) // Incluindo o "molde" de cada item
                .Where(p => p.Id == pedidoId)
                .SingleOrDefault(); // verifica se o produto existe na tabela e retornando o encontrado ou null

            if (pedido == null)
            {
                pedido = new Pedido();
                dbset.Add(pedido);
                contexto.SaveChanges();
                SetPedidoId(pedido.Id); // Gravando na sessão
            }

            return pedido;
        }

        private int? GetPedidoId()
        {
            /// Função que pega o Id do pedido que estará armazenado na sessão
            // O objeto da sessão é fornecido por um componente chamado HttpContextAccessor
            return _contextAccessor.HttpContext.Session.GetInt32("pedidoId");
        }

        private void SetPedidoId(int pedidoId)
        {
            /// Função que seta o pedidoId da sessão
            _contextAccessor.HttpContext.Session.SetInt32("pedidoId", pedidoId);
        }

        public UpdateQuantidadeResponse UpdateQuantidade(ItemPedido itemPedido)
        {
            var itemPedidoDB = _itemPedidoRepository.GetItemPedido(itemPedido.Id);

            if (itemPedidoDB != null)
            {
                itemPedidoDB.AtualizaQuantidade(itemPedido.Quantidade);
                contexto.SaveChanges();

                var carrinhoViewModel = new CarrinhoViewModel(GetPedido().Itens);
                return new UpdateQuantidadeResponse(itemPedidoDB, carrinhoViewModel);
            }

            throw new ArgumentException("ItemPedido não encontrado.");
        }
    }
}