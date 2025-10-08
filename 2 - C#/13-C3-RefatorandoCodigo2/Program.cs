using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Runtime.CompilerServices;

namespace _12_C3_RefatorandoCodigo2
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Parte 2 do curso "Refatorando Código em C#". 

            // Serão abordadas 22 novas técnicas de refatoração, dividias em dois grupos:

            // 1 - Organização de dados
            // 2 - Simplificação de condições

            /// Organização de dados:
            // 1 - Substituir número mágico

            // Em processamentos específicos no código, números específicos são introduzidos sem pertencerem a
            // alguma variável e sem documentação sobre o que são, o que pode gerar confusão na leitura do código.
            // É interessante substituir o número mágico por uma constante.

            // Exemplo (função que calcula o imposto de um produto por estado):

            decimal CalculaICMS(decimal valorProdutos, string uf)
            {
                decimal valorFinal = 0m;

                if (valorProdutos < 0)
                {
                    throw new ArgumentOutOfRangeException("Valor não pode ser menor do que 0.");
                }

                if (uf == "SP")
                {
                    valorFinal = valorProdutos * 0.18m; // Números "mágicos", não demonstram claramente o seu significado
                    return valorFinal;
                }
                valorFinal = valorProdutos * 0.15m;
                return valorFinal;
            }

            decimal CalculaICMSRefatorada(decimal valorProdutos, string uf)
            {
                const decimal v = 0.15m;

                decimal valorFinal = 0m;

                if (valorProdutos < 0)
                {
                    throw new ArgumentOutOfRangeException("Valor não pode ser menor do que 0.");
                }

                if (uf == "SP")
                {
                    valorFinal = valorProdutos * 0.18m; // Números "mágicos", não demonstram claramente o seu significado
                    return valorFinal;
                }
                valorFinal = valorProdutos * 0.15m;
                return valorFinal;
            }
        }
    }
}