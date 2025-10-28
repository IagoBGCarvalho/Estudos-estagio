using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class CreateFilmeDto
    {
        // Um DTO (Data Trasnfer Object) se trata de um objeto que leva informações à diferentes camadas da aplicação, no caso, entre o cliente e a API.
        // Deve se tratar de um objeto "burro" que contém apenas as propriedades necessários para a operação designada (Create, Remove, Update ou Delete).
        // Este DTO apenas possui as propriedades que são necessárias para criar um novo filme

        [Required(ErrorMessage = "O título do filme é obrigatório.")]
        public required string Titulo { get; set; }

        [Required(ErrorMessage = "O gênero do filme é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho do gênero não pode exceder 50 caracteres.")] // StringLength (diferente do MaxRange) não incializa todos os espaços ao rodar, fazendo isso de forma dinâmica
        public required string Genero { get; set; }

        [Required(ErrorMessage = "A duração do filme é obrigatória.")]
        [Range(70, 600, ErrorMessage = "A duração deve ter entre 70 e 600 minutos.")]
        public int Duracao { get; set; }
    }
}
