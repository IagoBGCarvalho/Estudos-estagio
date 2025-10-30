using System.ComponentModel.DataAnnotations; // Biblioteca das anotações

namespace FilmesApi.Models; // Pasta responsável por conter os modelos mapeados do mundo real para o .net

public class Filme
{
    [Key] // Informa que a propriedade ID será utilizada como CHAVE PRIMÁRIA da tabela Filme
    [Required]
    public int Id { get; set; }

    // Os Data Anotations (ou anotações) são classes especiais que podem ser aplicadas em classes, métodos ou propriedades para fornecer informações extras sobre o comportamento do código.
    // Ou seja, podem ser utilizadas para fazer a validação de dados de forma clara e organizada.

    [Required(ErrorMessage = "O título do filme é obrigatório.")] // Required torna o atributo obrigatório na inserção e pode receber uma mensagem de erro padrão.
    public required string Titulo { get; set; }

    [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres.")] // MaxLength especifica o tamanho máximo da string
    public required string Genero { get; set; }

    [Required(ErrorMessage = "A duração do filme é obrigatória.")]
    [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")] // Range define o escopo de números recebidos, no caso, sendo de 70 minutos até 600.
    public int Duracao { get; set; }
    public virtual ICollection<Sessao> Sessoes { get; set; } // Uma IColecction indica que esta entidade receberá várias sessões.

    // Para fazer o mapemanto final da classe um uma tabela, é necessário utilizar o comando: "dotnet ef migrations add Nome_Migration" para realizar a build (ou "Add-Migration CriandoTabelaDeFilme" no PowerShell do Windows).

    // Depois de fazer a build, irá criar um arquivo na pasta "Migrations" que explicita a lógica de criação.

    // Por fim, para criar um banco de dados com as tabelas mapeadas, basta digitar o comando: "dotnet ef database update" (ou Update-Database no Windows)
}