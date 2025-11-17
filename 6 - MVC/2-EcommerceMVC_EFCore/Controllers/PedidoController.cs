using _1_EcommerceMVC_EFCore.Models;
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

        public PedidoController(ILogger<PedidoController> logger, IProdutoRepository produtoRepository, IPedidoRepository pedidoRepository)
        {
            _logger = logger;
            this._produtoRepository = produtoRepository;
            this._pedidoRepository = pedidoRepository;
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

            Pedido pedido = _pedidoRepository.GetPedido();
            return View(pedido.Itens); 
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Resumo()
        {
            Pedido pedido = _pedidoRepository.GetPedido();
            return View(pedido);
        }

        [HttpPost]
        public void UpdateQuantidade([FromBody]ItemPedido itemPedido)
        {

        }
    }
}
