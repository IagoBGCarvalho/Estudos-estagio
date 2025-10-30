using System.ComponentModel.DataAnnotations;

namespace FilmesApi.Models
{
    public class Sessao
    {
        public int? FilmeId { get; set; }
        public virtual Filme Filme { get; set; } // Receberá apenas um filme
        public int? CinemaId { get; set; }
        public virtual Cinema Cinema { get; set; }
    }
}
