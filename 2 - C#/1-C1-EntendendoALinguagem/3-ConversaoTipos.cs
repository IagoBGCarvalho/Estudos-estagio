using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    internal class ConversaoTipos
    {
        public void ExemplosConversao()
        {
            Console.WriteLine("3 - Conversão de tipos: \n");
            // Cada tipo de dado em C# tem um tamanho fixo na memória e regras específicas para conversão entre tipos
            // short -> 2 bytes ou 16 bits (decimais)
            // int -> 4 bytes ou 32 bits (decimais)
            // long -> 8 bytes ou 64 bits (decimais)
            // float -> 4 bytes ou 32 bits (reais)
            // double -> 8 bytes ou 64 bits (reais)
            double salario = 3000.15;
            Console.WriteLine("Salário (double): " + salario);

            int salarioInteiro;
            // salarioInteiro = salario; Resultaria em erro de compilação, pois não é possível converter implicitamente um double em int 
            salarioInteiro = (int)salario; // Conversão explícita (cast)
            Console.WriteLine("Salário convertido (int): " + salarioInteiro);

            float altura = 1.62f; // O f serve para explicitar ao compilador que a variável altura está perdendo precisão e resultará em um float
            Console.WriteLine("Altura (float): " + altura);

            short preco = 1000;
            Console.WriteLine("Preço (short): " + preco);

            long premio = 1_000_000_000_000_000; // O _ serve para melhorar a legibilidade de números grandes
            Console.WriteLine("Prêmio (long): " + premio + "\n");
        }
    }
}
