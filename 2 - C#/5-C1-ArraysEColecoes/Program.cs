using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios;
using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.ParceriaComercial;
using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.SistemaInterno_;
using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Utilitario;
using _5_C1_ArraysEColecoes.bytebank.Modelos.Conta;
using _5_C1_ArraysEColecoes.Excecoes;
using _5_C1_ArraysEColecoes.bytebank.Util;

namespace _5_C1_ArraysEColecoes
{
    internal class Program
    {
        static void TestaArrayInt()
        {
            int acumulador = 0;
            int[] idades = new int[5];
            idades[0] = 30; // Preenchendo o array utilizando o índice
            idades[1] = 40;
            idades[2] = 17;
            idades[3] = 21;
            idades[4] = 18;

            Console.WriteLine($"Tamanho do array: {idades.Length}");

            for (int i = 0; i < idades.Length; i++)
            {
                Console.WriteLine($"A idade {i} é: {idades[i]}");
                acumulador += idades[i];
            }

            int media_final = acumulador / idades.Length;
            Console.WriteLine($"A média de todas as idades é: {media_final}");
        }
        static void TestaBuscarPalavra()
        {
            // Cria um array, preenche ele e, com base no input, procura por ele dentro do array.
            bool flagPalavraEncontrada = false;
            string[] arrayDePalavras = new string[5]; // Está instanciando um array de strings e está definindo o tamanho como 5
            for (int i = 0; i < arrayDePalavras.Length; i++)
            {
                Console.Write($"Digite a {i + 1}a palavra: ");
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
            if ((array == null) || (array.Length == 0))
            {
                Console.WriteLine("Array para cálculo da mediana está vazio ou nulo.");
            }

            double[] numerosOrdenados = (double[])array.Clone(); // Está criando um clone do array. Como clone retorna um objeto, é necessário fazer o cast para um array de double

            Array.Sort(numerosOrdenados); // Método da classe Array que ordena os itens de forma crescente
                                          // [1,8] [5,9] [6,9] [7,1] [10]

            // Cálculo da mediana:
            int tamanho = numerosOrdenados.Length;
            int meio = tamanho / 2;
            double mediana = (tamanho % 2 != 0) ? numerosOrdenados[meio] : (numerosOrdenados[meio] + numerosOrdenados[meio - 1]) / 2; // É possível utilizar o operador ternário para realizar operações condicionais dentro de outras operações. O "?" é o if (se), se o que estiver antes dele for True, faz o que está a frente. O ":" se trata do else (se não), que executa o que está a frente caso o if não receba True. Sintaxe: (condição) ? valor_se_verdadeiro : valor_se_falso;

            Console.WriteLine($"Com base na amostra, a mediana é = {mediana}");
        }
        static void TestaArrayDeContasCorrentes()
        {
            ContaCorrente[] listaDeContas = new ContaCorrente[]
            {
                    // Esta é a sintaxe para declarar um array de objetos. Apesar de não receber tamanho, continua alocando estáticamente a partir da quantidade de objetos colocados dentro das chaves.
                    new ContaCorrente(874, "5679787-A"), // Cria uma instância e a coloca no array
                    new ContaCorrente(874, "4456389-B"),
                    new ContaCorrente(874, "7781474-C")
            };

            for (int i = 0; i < listaDeContas.Length; i++) 
            {
                ContaCorrente contaAtual = listaDeContas[i];
                Console.WriteLine($"Índice [{i}] - Conta: {contaAtual.Conta}");
            }
        }
        static void ArrayDeContasCorrentes()
        {
            ListaDeContasCorrentes lista = new ListaDeContasCorrentes();
            lista.Adicionar(new ContaCorrente(874, "5679787-A"));
            lista.Adicionar(new ContaCorrente(874, "4456389-B"));
            lista.Adicionar(new ContaCorrente(874, "7781474-C"));
            lista.Adicionar(new ContaCorrente(874, "7781474-C"));
            lista.Adicionar(new ContaCorrente(874, "7781474-C"));
            lista.Adicionar(new ContaCorrente(874, "7781474-C"));
            var contaDoAndre = new ContaCorrente(963, "1234567-x");
            lista.Adicionar(contaDoAndre);
            lista.ExibeLista();
            Console.WriteLine("==================");
            lista.Remover(contaDoAndre);
            lista.ExibeLista();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Boas vindas ao atendimento do Bytebank!\n");

            //TestaArrayInt();

            // Outras Formas de criar um array:
            Array amostra_ = new double[5]; // É possível utilizar a classe Array do dotnet para instanciar novos arrays. Todos os arrays criados no programa vão herdar desta classe.
            Array amostra = Array.CreateInstance(typeof(double), 5); // CreateInstance pede o tipo de dado e o tamanho.

            amostra.SetValue(5.9, 0); // SetValue recebe o valor e a posição do índice a ser setado
            amostra.SetValue(1.8, 1);
            amostra.SetValue(7.1, 2);
            amostra.SetValue(10, 3);
            amostra.SetValue(6.9, 4);

            // [5,9] [1,8] [7,1] [10] [6,9]

            //TestaMediana(amostra);

            //TestaArrayDeContasCorrentes();

            ArrayDeContasCorrentes();

            Console.ReadLine();
        }
    }
}