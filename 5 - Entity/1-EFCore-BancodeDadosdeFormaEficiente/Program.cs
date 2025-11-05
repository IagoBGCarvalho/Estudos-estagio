// O Microsoft Entity Framework Core é uma ferramenta multiplataforma utilizada para realizar operações em bancos de dados sem precisar formular todas os comandos SQL de manipulação de dados na mão

// Script para criar a tabela utilizada:
//CREATE TABLE[dbo].[Produtos] (
//    [Id]        INT IDENTITY(1, 1) NOT NULL,
//    [Nome]      NVARCHAR (MAX) NULL,
//    [Categoria] NVARCHAR (MAX) NULL,
//    [Preco]     FLOAT (53)     NULL,
//    CONSTRAINT[PK_Produtos] PRIMARY KEY CLUSTERED ([Id] ASC)
//);

// Para utilizar o Entity em um projeto, é necessário instalar 3 pacotes (todos na versão 8.0.21 caso a versão do .NET seja a 8):
// 1 - "Microsoft.EntityFrameworkCore" que contém o motor do Entity
// 2 - "Microsoft.EntityFrameworkCore.SqlServer" que contém as injeções do SqlServer
// 3 - "Microsoft.EntityFrameworkCore.Tools" que contém as ferramentas de migração

// Para abrir o manual do Entity, basta digitar no terminal: "dotnet ef"

using Alura.Loja.Testes.Data;
using Alura.Loja.Testes.Migrations;
using Alura.Loja.Testes.Models;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace Alura.Loja.Testes
{
    class Program
    {
        static void Main(string[] args)
        {
            // Criando produtos a serem adicionados na promoção:
            var p1 = new Produto() { Nome = "Suco de Laranja", Categoria = "Bebidas", PrecoUnitario = 8.79, Unidade = "Litros" };
            var p2 = new Produto() { Nome = "Café", Categoria = "Bebidas", PrecoUnitario = 12.45, Unidade = "Gramas" };
            var p3 = new Produto() { Nome = "Macarrão", Categoria = "Alimentos", PrecoUnitario = 4.23, Unidade = "Gramas" };

            var promocaoDePascoa = new Promocao();
            promocaoDePascoa.Descricao = "Páscoa Feliz";
            promocaoDePascoa.DataInicio = DateTime.Now;
            promocaoDePascoa.DataTermino = DateTime.Now.AddMonths(3);

            // Incluindo produtos na promoção:
            promocaoDePascoa.IncluiProduto(p1);
            promocaoDePascoa.IncluiProduto(p2);
            promocaoDePascoa.IncluiProduto(p3);

            using (var contexto = new LojaContext())
            {
                // Persistindo a promoção no banco
                contexto.Promocoes.Add(promocaoDePascoa);
                ExibeEntries(contexto.ChangeTracker.Entries());
                //contexto.SaveChanges();

                // Removendo uma promoção do banco:
                // var promocao = contexto.Promocoes.First();
                // contexto.Promocoes.Remove(promocao);
                // ExibeEntries(contexto.ChangeTracker.Entries());
                // contexto.SaveChanges();
            }
        }
        private static void ExibeEntries(IEnumerable<EntityEntry> entries)
        {
            /// Função que exibe o estado de cada entrie sendo trackeada pelo ChangeTracker
            foreach (var e in entries)
            {
                Console.WriteLine(e.Entity.ToString() + " - " + e.State);
            }

        }
    }
}