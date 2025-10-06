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
        static void CriandoArquivoCsv()
        {
            CriarArquivoCsv();

            // Para verificar se os dados foram escritos corretamente:
            //var caminho = "contasExportadas.csv";

            //using (var fluxo = new FileStream(caminho, FileMode.Open))
            //{
            //    var leitor = new StreamReader(fluxo);
            //    while (!leitor.EndOfStream)
            //    {
            //        var linha = leitor.ReadLine();
            //        Console.WriteLine(linha);
            //    }
            //}
            Console.ReadLine();
        }

        static void CriarArquivoCsv()
        {
            /// Função que cria um arquivo csv com os dados de uma conta corrente
            /// Não está formatando corretamente no excel!!!
            var caminhoNovoArquivo = "contasExportadas.csv";

            // Aninhando usings:
            // O using de dentro (escritor) terminará primeiro, garantindo que o fluxo de arquivo será fechado apenas após
            // o esccritor terminar de escrever
            using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.Create)) // Create é o modo de abertura que cria um arquivo novo ou, caso já exista, sobreescreve o conteúdo
            using (var escritor = new StreamWriter(fluxoDeArquivo)) // Classe irmã do StreamReade, que permite escrever um fluxo de dados)
            {
                // Criando contas apenas para exemplificar a escrita
                ContaCorrente conta = new ContaCorrente(800, "54654-X");
                conta.Titular = new Cliente { Nome = "Pedro" };
                conta.Depositar(500.50);

                escritor.WriteLine($"{conta.Agencia},{conta.Conta},{conta.Saldo},{conta.Titular.Nome}");
                Console.WriteLine("\nArquivo contasExportadas.csv criado com sucesso!");
            }
        }
    }
}