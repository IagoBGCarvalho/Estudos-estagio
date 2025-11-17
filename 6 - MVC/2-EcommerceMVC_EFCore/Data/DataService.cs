using _1_EcommerceMVC_EFCore.Models;
using _1_EcommerceMVC_EFCore.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace _1_EcommerceMVC_EFCore.Data
{
    public class DataService : IDataService
    {
        private readonly ApplicationContext contexto;
        private readonly IProdutoRepository produtoRepository;

        public DataService(ApplicationContext contexto, IProdutoRepository produtoRepository)
        {
            this.contexto = contexto; // Injeção de dependência
            this.produtoRepository = produtoRepository;
            
        }

        public void InicializaDB()
        {
            contexto.Database.Migrate();
            List<Livro>? livros = GetLivros();
            produtoRepository.SaveProdutos(livros);
        }

        private static List<Livro>? GetLivros()
        {
            var json = File.ReadAllText("C:\\Users\\iago.carvalho.REDEMPM\\source\\repos\\IagoBGCarvalho\\Estudos-estagio\\6 - MVC\\1-EcommerceMVC_EFCore\\Data\\livros.json"); // Utilizando a classe File do dotnet para ler o texto do arquivo json e armazenar em uma variável

            // Para converter o json para uma lista de objetos, será utilizada a biblioteca newtonsoft:
            var livros = JsonConvert.DeserializeObject<List<Livro>>(json); // DeserializeObject trasnforma texto em instâncias de objetos. Recebe como parâmetro a variável json e a transforma em uma lista de objetos Livro
            return livros;
        }
    }

    public class Livro
    {
        // Classe criada para ser utilizada pelo JsonConvert
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
    }
}
