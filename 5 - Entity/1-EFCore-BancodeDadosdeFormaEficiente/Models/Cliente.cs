using System.ComponentModel.DataAnnotations;

namespace Alura.Loja.Testes.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public Endereco EnderecoDeEntrega { get; set; } // Propriedade de navegação, 1
    }
}