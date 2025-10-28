using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Data.DTOs
{
    public class CreateEnderecoDto
    {
        public string Logradouro { get; set; }
        public int Numero { get; set; }
    }
}
