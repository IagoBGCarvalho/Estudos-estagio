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
        static void CapturandoDadosDoConsole()
        {
            CapturaInputConsole();
            Console.ReadLine();
        }
        static void CapturaInputConsole()
        {
            /// Função que captura o input do console como um fluxo de dados e a atribui para um arquivo
            using (var fluxoDeEntrada = Console.OpenStandardInput()) // Está capturando a stream interna do input do console
            using (var fs = new FileStream("entradaConsole.txt", FileMode.Create))
            {
                var buffer = new byte[1024];

                while (true)
                {
                    var byteslidos = fluxoDeEntrada.Read(buffer, 0, 1024);

                    fs.Write(buffer); // Atribui o conteúdo do buffer ao arquivo entradaConsole
                    fs.Flush(); // Despeja o buffer no arquivo imediatamente

                    Console.WriteLine($"Bytes lidos no console: {byteslidos}");
                }
            }
        }
    }
}