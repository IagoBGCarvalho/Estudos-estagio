using _1_EcommerceMVC_EFCore.Models;
using _1_EcommerceMVC_EFCore.Models.ViewModels;
using _1_EcommerceMVC_EFCore.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CasaDoCodigo.Controllers
{
    public class PedidoController : Controller // Deve herdar da classe Controller do AspNet
    {
        // O controlador é a tecnologia intermediária que junta as views com os dados brutos (models) para gerar a página HTML.

        // Para localizar o controlador, a action e a view, o ASP.NET pega o complemento da URL (o que vem depois do domínio e da porta) e procura no diretório
        // do projeto por um arquivo com o nome do complemento (por exemplo: Home) e "Controller" logo em seguida (como: HomeController).

        // Após isso, irá analisar a action, ou seja, a partícula que vem após o complemento da URL (como: .../home/privacy) e irá procurar por um método
        // no controlador que corresponda a este nome. Este método deve ter uma IActionResult como devolução e deve retornar o método View() que irá acionar
        // o arquivo cshtml com o mesmo nome do método.
        private readonly ILogger<PedidoController> _logger;
        private readonly IProdutoRepository _produtoRepository;
        private readonly IPedidoRepository _pedidoRepository;
        private readonly IItemPedidoRepository _itemPedidoRepository;

        public PedidoController(ILogger<PedidoController> logger, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository, IItemPedidoRepository itemPedidoRepository)
        {
            _logger = logger;
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
            this._itemPedidoRepository = itemPedidoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(_produtoRepository.GetProdutos()); // Retorna o arquivo cshtml com o nome do método, no caso "Carrossel.cshtml"
        }
        public IActionResult Carrinho(string codigo)
        {
            // Pega o Id do pedido da sessão e passa os itens do pedido para a view do carrinho
            if (!string.IsNullOrEmpty(codigo))
            {
                _pedidoRepository.AddItem(codigo);
            }
            List<ItemPedido> itens = _pedidoRepository.GetPedido().Itens;
            CarrinhoViewModel carrinhoViewModel = new CarrinhoViewModel(itens);
            return base.View(carrinhoViewModel); 
        }
        public IActionResult Cadastro()
        {
            var pedido = _pedidoRepository.GetPedido();

            if (pedido == null)
            {
                return RedirectToAction("Carrossel"); // Método que redireciona o usuário para uma outra action/view
            }

            return View(pedido.Cadastro);
        }

        [HttpPost] // Impede que a página seja solicitada diretamente pelo browser, pois não faz sentido poder ir para a tela de resumo sem um pedido e sem cadastro
        [ValidateAntiForgeryToken] // Utiliza o token criptografado do navegador para prevenir ataques Cross-site Request Forgery
        public IActionResult Resumo(Cadastro cadastro) // Precisa receber os dados do formulário em forma de objeto Cadastro
        {
            if (ModelState.IsValid) // Objeto que possui propriedades para inferir se o modelo é valido ou não
            {
                return View(_pedidoRepository.UpdateCadastro(cadastro));
            }

            return RedirectToAction("Cadastro");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public UpdateQuantidadeResponse UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {
            return _pedidoRepository.UpdateQuantidade(itemPedido); 
        }
    }
}
