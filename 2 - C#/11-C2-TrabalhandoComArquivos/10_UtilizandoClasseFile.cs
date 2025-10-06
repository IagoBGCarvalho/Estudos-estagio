using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics;
using _11_C2_TrabalhandoComArquivos.Conta;

namespace _11_C2_TrabalhandoComArquivos
{
    partial class Program
    {
        static void UtilizandoClasseFile(string[] args)
        {
            //Console.WriteLine("Digite o seu nome: ");
            //var nome = Console.ReadLine(); // Usando a stream vigilnte do Console para capturar o input do usuário

            // A classe File possui diversos métodos estáticos para maanipulação de arquivos

            var linhas = File.ReadAllLines("contas.txt"); // Lê todas as linhas do arquivo e retorna um array de strings
            Console.WriteLine(linhas.Length);

            // Imprime todas as linhas, já decodificadas e formatadas:
            //foreach (var linha in linhas)
            //{
            //    Console.WriteLine(linha);
            //}

            var bytesArquivo = File.ReadAllBytes("contas.txt"); // Lê todos os bytes do arquivo e retorna um array de bytes
            Console.WriteLine($"Arquivo contas.txt possui {bytesArquivo.Length} bytes.");

            File.WriteAllText("escrevendoComAClasseFile.txt", "Testando File.WriteAllText."); // Cria um arquivo. Recebe o nome com a extensão e o conteúdo.

            Console.WriteLine("Aplicação finalizada.");

            Console.ReadLine();
        }
    }
}