using System.ComponentModel.DataAnnotations; // Biblioteca das anotações

namespace FilmesApi.Models; // Pasta responsável por conter os modelos mapeados do mundo real para o .net

public class Filme
{
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
}