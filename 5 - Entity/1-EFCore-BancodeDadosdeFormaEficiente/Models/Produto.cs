using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Models
{
    public class Produto
    {
        // Sempre que alterações são feitas na estrutura do código, é necessário sincronizar essas alterações no banco.
        // O Entity permite fazer isso através de de uma Migration, que é um comando da CLI do dotnet que gera, automaticamente, código SQL para fazer alterações na estrutura do banco de dados.
        // Ao dar uma migration, exemplo: "dotnet ef migrations add NomeMigration", é necessário utilizar "dotnet ef update database" para aplicar as alterações
        public int Id { get; set; }
        public string? Nome { get; set; }
        public string? Categoria { get; set; }
        public double PrecoUnitario { get; set; }
        public string Unidade { get; set; }
        public IList<PromocaoProduto> Promocoes { get; set; } // Definindo relação N:M entre Produto e Promoção, sendo necessária a criação de uma tabela intermediária, que é representada pela classe PromocaoProduto
        public IList<Compra> Compras { get; set; }
        public override string ToString()
        {
            return $"Produto: {this.Id}, {this.Nome}, {this.Categoria}, {this.PrecoUnitario}";
        }
    }
}
