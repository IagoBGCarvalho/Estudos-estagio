using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Models
{
    public class PromocaoProduto
    {
        // Classe que representa a tabela intermediária da relação N:M entre Promocao e Produto
        public int ProdutoId { get; set; }
        public int PromocaoId { get; set; }
        public Produto Produto { get; set; } // Propriedade que aponta para uma referência de Produto
        public Promocao Promocao { get; set; } // Propriedade que aponta para uma referência de Promocao
    }
}
