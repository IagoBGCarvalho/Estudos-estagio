// Compra de 6 pães franceses
//using Alura.Loja.Testes.Data;
//using Alura.Loja.Testes.Models;
//using Microsoft.EntityFrameworkCore.ChangeTracking;

//Produto paoFrances = new Produto();
//paoFrances.Nome = "Pão Francês";
//paoFrances.PrecoUnitario = 0.40;
//paoFrances.Unidade = "Unidade";
//paoFrances.Categoria = "Padaria";

//var compra = new Compra();
//compra.Quantidade = 6;
//compra.Produto = paoFrances;
//compra.Preco = paoFrances.PrecoUnitario * compra.Quantidade;

//using (var contexto = new LojaContext())
//{
//    contexto.Compras.Add(compra);
//    ExibeEntries(contexto.ChangeTracker.Entries()); // ChangeTracker.Entries retorna todas as Entries do Entity, que são objetos que possuem informações do estado das entidades mapeadas
//    contexto.SaveChanges();
//}

//static void ExibeEntries(IEnumerable<EntityEntry> entries)
//{
//    /// Função que exibe o estado de cada entrie sendo trackeada pelo ChangeTracker
//    foreach (var e in entries)
//    {
//        Console.WriteLine(e.Entity.ToString() + " - " + e.State);
//    }

//}