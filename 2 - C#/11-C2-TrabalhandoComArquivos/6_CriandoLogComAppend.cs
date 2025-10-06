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
        static void CriandoLogComAppend()
        {
            CriandoEAumentandoLogComAppend(); // A cada vez que o script for rodado, será criada uma linha nova no arquivo de log
            Console.ReadLine();
        }
        static void CriandoEAumentandoLogComAppend()
        {
            var caminhoDoArquivo = "log.txt";

            using (var fluxoDeArquivo = new FileStream(caminhoDoArquivo, FileMode.Append))
            using (var escritor = new StreamWriter(fluxoDeArquivo))
            {
                escritor.WriteLine($"Log de evento às {DateTime.Now}");
            }
        }
    }
}