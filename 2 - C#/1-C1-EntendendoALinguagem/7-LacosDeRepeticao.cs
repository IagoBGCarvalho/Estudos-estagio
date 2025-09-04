using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    internal class LacosDeRepeticao
    {
        public void ExemplosLacos()
        {
            Console.WriteLine("7 - Laços de repetição: \n");

            Console.WriteLine("Simulação de investimento com rendimento de 0.5% ao mês durante 12 meses utilizando diferentes laços de repetição.\n");

            double investimento = 1000;

            // Sem usar laço de repetição:
            investimento = investimento + (investimento * 0.005); // Rendimento de 0.5% (0.005) ao mês
            Console.WriteLine(investimento + "(Sem o laço de repetição)\n"); // Mês 1

            Console.WriteLine("Laço while: \n");

            double investimentoWhile = 1000;
            int mes = 1; // Variável do tipo contador
            while (mes <= 12) // Enquanto o mês for menor ou igual a 12, o laço continua
            {
                investimentoWhile = investimentoWhile + (investimentoWhile * 0.005);
                Console.WriteLine("No mês " + mes + " o rendimento foi de: R$" + investimentoWhile);
                mes++; // Incrementa o mês em 1 a cada repetição, também pode ser escrito como "mes = mes + 1" ou "mes += 1";
            }
            Console.WriteLine("\nFim do laço while.\n");

            Console.WriteLine("Laço for: \n");

            double investimentoFor = 1000;

            for (int mesFor = 1; mesFor <= 12; mesFor++) // Sintaxe: for (inicialização; condição; incremento)
            {
                investimentoFor = investimentoFor + (investimentoFor * 0.005);
                Console.WriteLine("No mês " + mesFor + " o rendimento foi de: R$" + investimentoFor);

            }
            Console.WriteLine("\nFim do laço for.\n");
        }
    }
}
