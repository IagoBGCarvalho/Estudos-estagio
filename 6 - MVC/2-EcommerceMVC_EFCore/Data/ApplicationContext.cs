using _1_EcommerceMVC_EFCore.Models;
using Microsoft.EntityFrameworkCore;

namespace _1_EcommerceMVC_EFCore.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Produto>().HasKey(t => t.Id);

            modelBuilder.Entity<Pedido>().HasKey(t => t.Id);
            modelBuilder.Entity<Pedido>().HasMany(t => t.Itens).WithOne(t => t.Pedido); // Definindo o relacionamento Pedido (1) -> Itens (N)
            modelBuilder.Entity<Pedido>().HasOne(t => t.Cadastro).WithOne(t => t.Pedido).HasForeignKey<Pedido>(t => t.CadastroId).IsRequired(); // Pedido (1) -> Cadastro (1). IsRequired() garante que todo pedido tenha um cadastro

            modelBuilder.Entity<ItemPedido>().HasKey(t => t.Id);
            modelBuilder.Entity<ItemPedido>().HasOne(t => t.Produto);

            modelBuilder.Entity<Cadastro>().HasKey(t => t.Id);
        }

        // Não é necessário fazer um override de OnConfigurating pois as configurações do bd no MVC ficam em appsettings.json
    }
}
