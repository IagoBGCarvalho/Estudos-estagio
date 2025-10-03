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
        static void Main(string[] args)
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            {
                var leitor = new StreamReader(fluxoDeArquivo); //FileStream é uma classe intermediária que faz todo o trabalho da leitura do arquivo e da manipulação de bytes

                var linha = leitor.ReadLine(); // Lê uma linha do arquivo
                Console.WriteLine(linha);
            }

                Console.ReadLine();
        }
    }
}