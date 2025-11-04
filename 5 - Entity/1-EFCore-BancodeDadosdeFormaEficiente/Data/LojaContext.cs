using Alura.Loja.Testes.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Alura.Loja.Testes.Data
{
    internal class LojaContext : DbContext // Deve herdar da classe DbContext da API do Entity que contém os principais métodos para manipular um bd
    {
        // O contexto se trata da classe .NET que irá liderar a lógica de implementação, manipulação e manutenção do banco de dados.

        // O contexto deve definir 3 coisas:

        // 1 - Classes a serem persistidas:
        public DbSet<Produto> Produtos { get; set; } // DbSet se trata da classe que faz o mapemanto de uma propriedade para uma tabela do banco de dados. Por isso, deve mapear uma classe que representa, diretamente, uma tabela do banco

        // 2 - O banco de dados (qual é o banco de dados e onde ele fica) e 3 - a string de conexão indicando o servidor:

        // Para fazer isso, é necessário sobreescrever o método de configuração da classe DbContext:
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // O método recebe como parâmetro o construtor de opções, que pode ser utilizado para definir propriedades específicas do contexto.
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=LojaDB;Trusted_Connection=True;TrustServerCertificate=True"); // Utilizando as opções para definir que o SqlServer é o banco utilizado e também especificar a string de conexão, que deve conter o servidor e o nome do banco.
        }
    }
}
