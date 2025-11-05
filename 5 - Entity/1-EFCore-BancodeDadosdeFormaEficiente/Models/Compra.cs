// O Microsoft Entity Framework Core é uma ferramenta multiplataforma utilizada para realizar operações em bancos de dados sem precisar formular todas os comandos SQL de manipulação de dados na mão

namespace Alura.Loja.Testes.Models
{
    internal class Compra
    {
        public int Id { get; set; }
        public int Quantidade { get; internal set; }
        public int ProdutoID { get; set; } // Precisa ter o Id da tabela que se está relacionando para que a relação seja obrigatória
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
    }
}