using FilmesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FilmesApi.Data
{
    public class FilmeContext : DbContext // FilmeContext herda da classe do Entity utilizada para criar uma conexão com o banco de dados, permitindo realizar consultas e manipulações de dados, se tornando o "cérebro" do processo
    {
        // Classe que servirá como contexto para o banco de dados
        public FilmeContext(DbContextOptions<FilmeContext> opts) : base(opts) // Recebe as opções de acesso ao banco de dados (configurações)
        {
            // O construtor do "cérebro", onde o Program.cs irá injetar as configurações, como a string de conexão que ele irá utilizar
        }

        public DbSet<Filme> Filmes { get; set; } // Esta linha diz ao "cérebro": Gerencie uma coleção de objetos Filme, acessando esses objetos através da propriedade Filmes e mapeando para uma tabela no banco de dados (e consequentemente tornando cada propriedade de Filmes em uma coluna da tabela).
    }
}
