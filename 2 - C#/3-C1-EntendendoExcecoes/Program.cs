using _3_C1_EntendendoExcecoes.Contas;
using _3_C1_EntendendoExcecoes.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _3_C1_EntendendoExcecoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exceções
            ContaCorrente conta1 = new ContaCorrente(283, "1234");

            Console.WriteLine(conta1.Numero);
            Console.WriteLine(ContaCorrente.TaxaOperacao);


            Console.ReadLine();
        }
    }
}