// Um controlador é uma classe que lida com as requisições HTTP recebidas de um cliente (como um navegador).
// Ele funciona como um intermediário entre a interface do usuário e a lógica de negócios no padrão de arquitetura Model-View-Controller (MVC). 

using FilmesApi.Data;
using FilmesApi.Models;
using Microsoft.AspNetCore.Mvc; // Biblioteca do C# para implementar uma API

namespace FilmesApi.Controllers;

[ApiController] // Anotação que indica que este documento é um controlador (recebe e processa as requisições do usuário)
[Route("[controller]")] // Anotação que traça a rota da requisição para algum lugar, neste caso, para o próprio controlador

public class FilmeController : ControllerBase // É necessário herdar da classe de controladores da microsoft
{
    private FilmeContext _context; // Carregando o contexto do bd para que o controlador agora faça as operações diretamente no banco de dados

    public FilmeController(FilmeContext context)
    {
        _context = context; // Com o construtor declarado, _context se torna, efetivamente, o contexto de conexão
    }

    // Método para cadastrar um filme:
    [HttpPost] // Operação que cria um recurso novo no sistema
    public IActionResult AdicionaFilmes([FromBody] Filme filme) // FromBody especifica que o parâmetro se trata de um conjectura de valores, no caso, todas as propriedades da classe Filme
    {
        _context.Filmes.Add(filme); // Utiliza a propriedade Filmes que se trata da coleção de filmes gerenciada pelo cérebro do entity para adicionar (Add) o filme desejado no banco de dados. Add, por trás dos panos, se tratar de um INSERT INTO.
        _context.SaveChanges(); // Após utilizar qualquer comando de alteração no banco, é necessário utilizar SaveChanges() para implementar elas de fato

        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id}, filme); // Retorna para o usuário o objeto criado. Recebe como parâmetro uma função GET que recebe como parâmetro o id que acabou de ser criado e retorna, finalmente, o filme com um status 201 (created)
        // Para testar no Postman: POST -> https://localhost:porta/Filme -> Body -> RAW -> JSON e formatar a inserção no JSON.
    }

    // Método para retornar todos os filmes:
    [HttpGet] // Operação que retorna recursos
    public IEnumerable<Filme> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50) // FromQuery especifica que os dados dos parâmetros serão fornecidos explicitamente pelo usuário
    {
        return _context.Filmes.Skip(skip).Take(take);
        // Para testar no Postman: GET -> https://localhost:porta/Filme?skip=numero_de_filmes_pulados&take=numero_de_filmes_pegos ("?" é o caractere que indica passagem de parâmetros)
        // Como valores padrão foram definidos nos parâmetros, utilizar apenas .../Filme não vai gerar erros, mas retornar os primeiros 50 filmes.
    }

    // Método para retornar um filme pelo seu id:
    [HttpGet("{id}")] // É possível ter mais de um GET em um controlador desde que possuam parâmetros diferentes.
    public IActionResult RecuperaFilmePorId(int id)
    {
        // IActionResult é uma interface que retorna StatusCodes HTTP para determinados resultados. !!! Faz parte da arquitetura REST !!!
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // Retorna o primeiro filme onde o id dele é igual ao id fornecido pelo parâmetro ou nulo caso não encontre
        if (filme == null) return NotFound(); // Caso o filme não exita, retorna 404 (NotFound)
        return Ok(filme); // Caso exista, retorna um 200 (Ok) e as informações do filme
        // Para testar no Postman: GET ->  https://localhost:porta/Filme/numero_id
    }
}
