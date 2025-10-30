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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Sessao>().HasKey(sessao => new { sessao.FilmeId, sessao.CinemaId });

            modelBuilder.Entity<Sessao>().HasOne(sessao => sessao.Cinema).WithMany(cinema => cinema.Sessoes).HasForeignKey(sessao => sessao.CinemaId);

            modelBuilder.Entity<Sessao>().HasOne(sessao => sessao.Filme).WithMany(filme => filme.Sessoes).HasForeignKey(sessao => sessao.FilmeId);

            modelBuilder.Entity<Endereco>().HasOne(endereco => endereco.Cinema).WithOne(cinema => cinema.Endereco).OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Cinema> Cinemas { get; set; }
        public DbSet<Endereco> Enderecos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
    }
}
