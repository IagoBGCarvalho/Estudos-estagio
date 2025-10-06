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
        static void EscrevendoELendoEmBinario()
        {
            // O WriteLine possui sobrecarga para diversos tipos de dados, como string, int, double, bool, etc...
            // Tipo diferentes ocupam espaços diferentes. Um bool apenas ocupa 1 byte, enquanto um int ocupa 4.
            // Mas em certos casos, o WriteLine converte o dado para string antes de escrever no arquivo.

            // Para otimizar o espaço, é possível escrever os dados em binário, utilizando a classe BinaryWrite, evitando
            // o desperdício de espaço com a conversão para string.

            // Em arquivos muito grandes, essa prática faz muita diferença.
            EscritaBinaria();
            LeituraBinaria();
            Console.WriteLine("\nAplicação finalizada.");
            Console.ReadLine();
        }
        static void EscritaBinaria()
        {
            /// Função que cria um arquivo binário com os dados de uma conta corrente
            using (var fluxoDeArquivo = new FileStream("contaCorrente.txt", FileMode.Create)) // Criando o arquivo no construtor do FileStream
            using (var escritorBinario = new BinaryWriter(fluxoDeArquivo)) // BinaryWrite é a classe que escrever dados em binário
            {
                // BinaryWrite não possui WriteLine!
                escritorBinario.Write(456); // Agência
                escritorBinario.Write(546544); // Número da conta
                escritorBinario.Write(4000.50); // Saldo
                escritorBinario.Write("Gustavo Braga"); // Titular
            }
            // No final, gera um arquivo quase ilegível, mas que ocupa muito menos espaço
        }
        static void LeituraBinaria()
        {
            using (var fluxoDeArquivo = new FileStream("contaCorrente.txt", FileMode.Open))
            using (var leitorBinario = new BinaryReader(fluxoDeArquivo)) // BinaryReade é a classe que lê dados em binário
            {
                var agencia = leitorBinario.ReadInt32(); // Método do binaryReader específico para ler int
                var numeroConta = leitorBinario.ReadInt32();
                var saldo = leitorBinario.ReadDouble();
                var titular = leitorBinario.ReadString();
                Console.WriteLine($"{agencia}/{numeroConta} {titular} {saldo}");
            }
        }
    }
}