namespace Alura.Loja.Testes.Models
{
    public class Compra
    {
        public int Id { get; set; }
        public int Quantidade { get; internal set; }
        public int ProdutoID { get; set; } // Precisa ter o Id da tabela que se está relacionando para que a relação seja obrigatória
        public Produto Produto { get; internal set; }
        public double Preco { get; internal set; }
        public override string ToString()
        {
            return $"Compra de {this.Quantidade} {Produto.Unidade}(s) do produto {this.Produto.Nome}";
        }
    }
}