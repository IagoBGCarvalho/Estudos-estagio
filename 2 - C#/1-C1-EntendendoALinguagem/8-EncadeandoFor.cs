using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    internal class EncadeandoFor
    {
        public void ExemplosEncadeandoFor()
        {
            Console.WriteLine("8 - Encadeando laços for: \n");
            Console.WriteLine("Simulação de investimento com rendimento que aumenta a longo prazo utilizando o encadeamento de laços de repetição.\n");

            double investimento = 1000;
            double fatorRendimento = 1.005;

            for (int anos = 1; anos <= 5; anos++)
            {
                for (int mesFor = 1; mesFor <= 12; mesFor++) // Calcula o rendimento mensal
                {
                    investimento *= fatorRendimento; // Mesma coisa que investimento = investimento * fatorRendimento
                }
                fatorRendimento += 0.001; // A cada ano, o fator de rendimento aumenta em 0.1% (0.001)
            }
            Console.WriteLine("Após 5 anos, o investimento rendeu: R$" + investimento + "\n");

            Console.WriteLine("Criando um desenho de triângulo retângulo utilizando encadeamento de for \n");
            // Exemplo:
            //*
            //**
            //***
            //****
            //*****

            Console.WriteLine("Utilizando break: ");
            for (int contadorLinhas = 0; contadorLinhas <= 9; contadorLinhas++)
            {
                Console.WriteLine(); // Pula uma linha a cada repetição do laço externo
                for (int contadorColunas = 0; contadorColunas <= 9; contadorColunas++)
                {
                    Console.Write("*"); // Imprime os asteriscos na mesma linha
                    if (contadorColunas >= contadorLinhas)
                    {
                        break; // Interrompe o laço interno quando o número de colunas for igual ao número de linhas
                    }
                }
            }

            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Utilizando condições: ");
            for (int contadorLinhas = 0; contadorLinhas <= 9; contadorLinhas++)
            {
                Console.WriteLine();
                for (int contadorColunas = 0; contadorColunas <= contadorLinhas; contadorColunas++)
                {
                    Console.Write("*");
                }
            }
        }
    }
}
