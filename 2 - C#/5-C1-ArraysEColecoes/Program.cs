using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes
{
    internal class Program
    {
        static void TestarBuscarPalavra()
        {
            // Cria um array, preenche ele e, com base no input, procura por ele dentro do array.
            bool flagPalavraEncontrada = false;
            string[] arrayDePalavras = new string[5]; // Está instanciando um array de strings e está definindo o tamanho como 5
            for (int i = 0; i < arrayDePalavras.Length; i++)
            {
                Console.Write($"Digite {i+1}a palavra: ");
                arrayDePalavras[i] = Console.ReadLine(); // Está passando o input do usuário para o array de índice i
            }

            Console.Write("Digite a palavra a ser encontrada: ");
            var busca = Console.ReadLine();

            foreach (var palavra in arrayDePalavras)
            {
                // Para cada item (palavra) no array de palavras, verifica se é o número buscado
                if (palavra.Equals(busca))
                {
                    Console.WriteLine($"Palavra encontrada = {busca}");
                    flagPalavraEncontrada = true;
                    break;
                }
            }
            if (!flagPalavraEncontrada)
            {
                Console.WriteLine("A palavra não foi encontrada no banco.");
            }
        }

        static void TestaMediana(Array array)
        {
            if((array == null) || (array.Length == 0))
            {
                Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
            }

            double[] numerosOrdenados = (double [])array.Clone(); // Está criando um clone do array. Como clone retorna um objeto, é necessário fazer o cast para um array de double

            Array.Sort(numerosOrdenados); // Método da classe Array que ordena os itens de forma crescente
            // [1,8] [5,9] [6,9] [7,1] [10]

            // Cálculo da mediana:
            int tamanho = numerosOrdenados.Length;
            int meio = tamanho / 2;
            double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2; // É possível utilizar o operador ternário para realizar operações condicionais dentro de outras operações. O "?" é o if (se), se o que estiver antes dele for True, faz o que está a frente. O ":" se trata do else (se não), que executa o que está a frente caso o if não receba True. Sintaxe: (condição) ? valor_se_verdadeiro : valor_se_falso;
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Boas vindas ao Bytebank, Atendimento.");
            Array amostra = Array.CreateInstance(typeof(double), 5); // É possível utilizar a classe Array do dotnet para instanciar novos arrays. Todos os arrays criados no programa vão herdar desta classe. CreateInstance pede o tipo de dado e o tamanho.
            amostra.SetValue(5.9, 0); // SetValue recebe o valor e a posição do índice a ser setado
            amostra.SetValue(1.8, 1);
            amostra.SetValue(7.1, 2);
            amostra.SetValue(10, 3);
            amostra.SetValue(6.9, 4);
            // [5,9] [1,8] [7,1] [10] [6,9]

            TestarBuscarPalavra();

            Console.ReadLine();
        }
    }
}