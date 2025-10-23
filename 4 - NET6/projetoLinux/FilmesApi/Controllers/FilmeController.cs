// Um controlador é uma classe que lida com as requisições HTTP recebidas de um cliente (como um navegador).
// Ele funciona como um intermediário entre a interface do usuário e a lógica de negócios no padrão de arquitetura Model-View-Controller (MVC). 

using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc; // Biblioteca do C# para implementar uma API

namespace FilmesApi.Controllers;

[ApiController] // Anotação que indica que este documento é um controlador (recebe e processa as requisições do usuário)
[Route("[controller]")] // Anotação que traça a rota da requisição para algum lugar, neste caso, para o próprio controlador

public class FilmeController : ControllerBase // É necessário herdar da classe de controladores da microsoft
{
    private static List<Filme> filmes = new List<Filme>(); // Lista que irá conter os filmes temporariamente
    private static int id = 0;

    // Método para cadastrar um filme:
    [HttpPost] // Operação que cria um recurso novo no sistema
    public void AdicionaFilmes([FromBody] Filme filme) // FromBody especifica que o parâmetro se trata de um conjectura de valores, no caso, todas as propriedades da classe Filme
    {
        filme.Id = id++; // A cada vez que um filme for adicionado, irá adicionar 1 à variável estática id e irá utilizar o valor dela como identificador
        filmes.Add(filme);
        Console.WriteLine(filme.Titulo); // WriteLines para teste
        Console.WriteLine(filme.Duracao);
        // Para testar no Postman: POST -> https://localhost:porta/Filme -> Body -> RAW -> JSON e formatar a inserção no JSON.
    }

    // Método para retornar todos os filmes:
    [HttpGet] // Operação que retorna recursos
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50) // FromQuery especifica que os dados dos parâmetros serão fornecidos explicitamente pelo usuário
    {
        return filmes.Skip(skip).Take(take);
        // Para testar no Postman: GET -> https://localhost:porta/Filme?skip=numero_de_filmes_pulados&take=numero_de_filmes_pegos ("?" é o caractere que indica passagem de parâmetros)
        // Como valores padrão foram definidos nos parâmetros, utilizar apenas .../Filme não vai gerar erros, mas retornar os primeiros 50 filmes.
    }

    // Método para retornar um filme pelo seu id:
    [HttpGet("{id}")] // É possível ter mais de um GET em um controlador desde que possuam parâmetros diferentes.
    public Filme? RecuperaFilmePorId(int id)
    {
        return filmes.FirstOrDefault(filme => filme.Id == id); // Retorna o primeiro filme onde o id dele é igual ao id fornecido pelo parâmetro ou nulo caso não encontre
        // Para testar no Postman: GET ->  https://localhost:porta/Filme/numero_id
    }
}