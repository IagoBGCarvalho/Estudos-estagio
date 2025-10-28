// Um controlador é uma classe que lida com as requisições HTTP recebidas de um cliente (como um navegador).
// Ele funciona como um intermediário entre a interface do usuário e a lógica de negócios no padrão de arquitetura Model-View-Controller (MVC). 

using AutoMapper;
using Azure;
using FilmesApi.Data;
using FilmesApi.Data.DTOs;
using FilmesApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints; // Biblioteca do C# para implementar uma API

namespace FilmesApi.Controllers;

[ApiController] // Anotação que indica que este documento é um controlador (recebe e processa as requisições do usuário)
[Route("[controller]")] // Anotação que traça a rota da requisição para algum lugar, neste caso, para o próprio controlador

public class FilmeController : ControllerBase // É necessário herdar da classe de controladores da microsoft
{
    private FilmeContext _context; // Carregando o contexto do bd para que o controlador agora faça as operações diretamente no banco de dados
    private IMapper _mapper;

    public FilmeController(FilmeContext context, IMapper mapper)
    {
        _context = context; // Com o construtor declarado, _context se torna, efetivamente, o contexto de conexão
        _mapper = mapper;
    }

    // Método para cadastrar um filme:
    // Documentação que aparecerá no Swagger:
    /// <summary>
    /// Adiciona um filme ao banco de dados
    /// </summary>
    /// <param name="filmeDto">Objeto com os campos necessários para criação de um filme</param>
    /// <returns>IActionResult</returns>
    /// <response code="201">Caso inserção seja feita com sucesso</response>
    [HttpPost] // Operação que cria um recurso novo no sistema
    [ProducesResponseType(StatusCodes.Status201Created)]
    public IActionResult AdicionaFilmes([FromBody] CreateFilmeDto filmeDto) // FromBody especifica que o parâmetro se trata de um conjectura de valores, no caso, todas as propriedades da classe Filme. Ao invés de receber a classe filme em si, recebe o DTO, que faz o trabalho de trasnportar os dados
    {
        Filme filme = _mapper.Map<Filme>(filmeDto);
        _context.Filmes.Add(filme); // Utiliza a propriedade Filmes que se trata da coleção de filmes gerenciada pelo cérebro do entity para adicionar (Add) o filme desejado no banco de dados. Add, por trás dos panos, se tratar de um INSERT INTO.
        _context.SaveChanges(); // Após utilizar qualquer comando de alteração no banco, é necessário utilizar SaveChanges() para implementar elas de fato

        return CreatedAtAction(nameof(RecuperaFilmePorId), new { id = filme.Id}, filme); // Retorna para o usuário o objeto criado. Recebe como parâmetro uma função GET que recebe como parâmetro o id que acabou de ser criado e retorna, finalmente, o filme com um status 201 (created)
        // Para testar no Postman: POST -> https://localhost:porta/Filme -> Body -> RAW -> JSON e formatar a inserção no JSON.
    }

    // Método para retornar todos os filmes:
    /// <summary>
    /// Retorna os filmes do banco de dados.
    /// </summary>
    /// <param name="skip">Número de filmes a serem pulados no retorno</param>
    /// <param name="take">Número de filmes a serem retornados após o skip</param>
    /// <returns>IEnumerable</returns>
    /// <response code="200">Em qualquer caso, pois retorna uma lista vazia de objetos caso não encontre nada</response>
    [HttpGet] // Operação que retorna recursos
    public IEnumerable<ReadFilmeDto> RecuperaFilmes([FromQuery]int skip = 0, [FromQuery]int take = 50) // FromQuery especifica que os dados dos parâmetros serão fornecidos explicitamente pelo usuário
    {
        return _mapper.Map<List<ReadFilmeDto>>(_context.Filmes.Skip(skip).Take(take));
        // Para testar no Postman: GET -> https://localhost:porta/Filme?skip=numero_de_filmes_pulados&take=numero_de_filmes_pegos ("?" é o caractere que indica passagem de parâmetros)
        // Como valores padrão foram definidos nos parâmetros, utilizar apenas .../Filme não vai gerar erros, mas retornar os primeiros 50 filmes.
    }

    // Método para retornar um filme pelo seu id:
    /// <summary>
    /// Retorna um filme baseado em seu id ou todos os filmes caso nenhum seja especificado
    /// </summary>
    /// <param name="id">Id do filme a ser buscado</param>
    /// <returns>IActionResult</returns>
    /// <response code="200">Caso o filme seja encontrado e retornado</response>
    /// <response code="404">Caso nenhum filme seja encontrado</response>
    [HttpGet("{id}")] // É possível ter mais de um GET em um controlador desde que possuam parâmetros diferentes. Também especifica que a propriedade id está sendo recebida via parâmetro
    public IActionResult RecuperaFilmePorId(int id)
    {
        // IActionResult é uma interface que retorna StatusCodes HTTP para determinados resultados. !!! Faz parte da arquitetura REST !!!
        var filme = _context.Filmes.FirstOrDefault(filme => filme.Id == id); // Retorna o primeiro filme onde o id dele é igual ao id fornecido pelo parâmetro ou nulo caso não encontre
        if (filme == null) return NotFound(); // Caso o filme não exita, retorna 404 (NotFound)
        var filmeDto = _mapper.Map<ReadFilmeDto>(filme);
        return Ok(filmeDto); // Caso exista, retorna um 200 (Ok) e as informações do filme
        // Para testar no Postman: GET ->  https://localhost:porta/Filme/numero_id
    }

    /// <summary>
    /// Atualiza todas as informações de um filme
    /// </summary>
    /// <param name="id">Id do filme a ser atualizado</param>
    /// <param name="filmeDto">Objeto com todos as propriedades a serem atualizadas</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o filme seja encontrado e atualizado</response>
    /// <response code="404">Caso nenhum filme seja encontrado</response>
    [HttpPut("{id}")] // Put se trata de uma atualização completa, sendo necessário inserir todos os dados do objeto para atualizar ele
    public IActionResult AtualizaFilme(int id, [FromBody] UpdateFilmeDto filmeDto)
    {
        // Função que atualiza as informações de um filme registrado
        //Filme filme = _mapper.Map<Filme>(filmeDto);

        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);

        if(filme == null) return NotFound();
        _mapper.Map(filmeDto, filme);
        _context.SaveChanges();
        return NoContent(); // 204 indica que a ação aplicada com sucesso ao recurso de destino
        // Para testar no Postman: PUT ->  https://localhost:porta/Filme/numero_id e inserir uno body um JSON RAW com as informações alteradas
    }

    /// <summary>
    /// Atualiza propriedades específicas de um filme
    /// </summary>
    /// <param name="id">Id do filme a ser atualizado</param>
    /// <param name="patch">Arquivo json que será alocado pela biblioteca e que terá todas as propriedades que podem ser atualizadas</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o filme seja encontrado e atualizado</response>
    /// <response code="400">Caso não for possível validar o modelo</response>
    /// <response code="404">Caso nenhum filme seja encontrado</response>
    [HttpPatch("{id}")] // Patch faz uma atualização parcial do objeto
    public IActionResult AtualizaFilmeParcial(int id, JsonPatchDocument<UpdateFilmeDto> patch)
    {
        // Função que atualiza as informações de um filme registrado
        //Filme filme = _mapper.Map<Filme>(filmeDto);

        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();

        var filmeParaAtualizar = _mapper.Map<UpdateFilmeDto>(filme); // filmeParaAtualizar irá carregar o filme encontrado mapeado para um UpdateFilmeDto

        patch.ApplyTo(filmeParaAtualizar, ModelState);

        if (!TryValidateModel(filmeParaAtualizar))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(filmeParaAtualizar, filme);
        _context.SaveChanges();
        return NoContent();
        // Para testar no Postman: PATCH ->  https://localhost:porta/Filme/numero_id e formatar o JSON como: [{"op": "replace", "path": "/campo_a_ser_alterado", "value": "novo_valor"}]
    }

    /// <summary>
    /// Remove um filme do banco de dados
    /// </summary>
    /// <param name="id">Id do filme a ser atualizado</param>
    /// <returns>IActionResult</returns>
    /// <response code="204">Caso o filme seja encontrado e removido</response>
    /// <response code="404">Caso nenhum filme seja encontrado</response>
    [HttpDelete("{id}")]
    public IActionResult DeletaFilme(int id)
    {
        var filme = _context.Filmes.FirstOrDefault(f => f.Id == id);
        if (filme == null) return NotFound();
        _context.Remove(filme);
        _context.SaveChanges();
        return NoContent();
    }
}
