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

        public PedidoController(ILogger<PedidoController> logger, IProdutoRepository produtoRepository)
        {
            _logger = logger;
            this._produtoRepository = produtoRepository;
        }

        public IActionResult Carrossel()
        {
            return View(_produtoRepository.GetProdutos()); // Retorna o arquivo cshtml com o nome do método, no caso "Carrossel.cshtml"
        }
        public IActionResult Carrinho()
        {
            return View(); 
        }
        public IActionResult Cadastro()
        {
            return View();
        }
        public IActionResult Resumo()
        {
            return View();
        }
    }
}
