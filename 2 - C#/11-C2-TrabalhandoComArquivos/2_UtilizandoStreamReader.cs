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
        static void UtilizandoStreamReader()
        {
            var enderecoDoArquivo = "contas.txt";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo)) // StreamReader é uma classe intermediária que faz todo o trabalho da leitura do arquivo e da manipulação de bytes
            {
                //var linha = leitor.ReadLine(); // Lê uma linha do arquivo

                //var texto = leitor.ReadToEnd(); // Lê o arquivo inteiro. CUIDADO!! Utilizar isso com arquivos muito grandes pode gerar uma vazamento de memórial.

                //int numero = leitor.Read(); // Retorna o primeiro byte do arquivo

                while (!leitor.EndOfStream) // Enquanto não for o fim do fluxo de dados do arquivo
                {
                    // Imprime o código linha a linha, até o fim do arquivo, preservando o conceito de fluxo de dados e prevenindo vazamento de memória
                    var linha = leitor.ReadLine();
                    Console.WriteLine(linha);
                }
                ;
            }
            Console.ReadLine();
        }
    }
}