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
        static void UtilizandoFlush()
        {
            // Durante o processamento do StreamWriter, o fluxo de dados não é inserido imediatamente no arquivo, mas sim armazenado
            // em um buffer que, após o fechamento do escritor, é despejado no arquivo. Para forçar a escrita imediata, pode-se utilizar o método Flush.
            SalvandoLogRapidamenteComFlush();
            Console.ReadLine();
        }
        static void SalvandoLogRapidamenteComFlush()
        {
            var caminhoDoArquivo = "log.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoDoArquivo, FileMode.Append))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.WriteLine($"Log de evento às {DateTime.Now}");
                escritor.Flush(); // Despeja o buffer para o arquivo imediatamente
                Console.ReadLine(); // ReadLine para abrir o documento durante a execução do programa para realizar a verificação do log
            }
        }
    }
}