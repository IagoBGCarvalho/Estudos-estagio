using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections; // Possui métodos prontos, como adicionar, modificar e remover itens do array (ArrayList)
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
        // Listas com ContasCorrentes para teste
        static List<ContaCorrente> _lista = new List<ContaCorrente>() // Criando uma lista genérica. Possui mais desempenho e segurança do que um ArrayList.
        {
            new ContaCorrente(95, "123456-X") {Saldo=100},
            new ContaCorrente(95, "951258-X") {Saldo=200},
            new ContaCorrente(94, "987321-W") {Saldo=60}
        };

        static List<ContaCorrente> _lista2 = new List<ContaCorrente>() // Criando uma lista genérica. Possui mais desempenho e segurança do que um ArrayList.
        {
            new ContaCorrente(95, "5679789-A") {Saldo=100}, // Valores default para teste
            new ContaCorrente(95, "4456668-B") {Saldo=200},
            new ContaCorrente(94, "7781438-C") {Saldo=60}
        };

        static List<ContaCorrente> _lista3 = new List<ContaCorrente>() // Criando uma lista genérica. Possui mais desempenho e segurança do que um ArrayList.
        {
            new ContaCorrente(95, "5679787-E") {Saldo=100}, // Valores default para teste
            new ContaCorrente(95, "4456668-F") {Saldo=200},
            new ContaCorrente(94, "7781438-G") {Saldo=60}
        };

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
            //lista.Adicionar(contaDoAndre);
            //lista.ExibeLista();
            //Console.WriteLine("==================");
            //lista.Remover(contaDoAndre);
            //lista.ExibeLista();

            for (int i = 0; i < lista.Tamanho; i++)
            {
                ContaCorrente conta = lista[i];
                Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Agencia}");
            }

        }
        static void ListarContas()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===    Lista de contas   ===");
            Console.WriteLine("============================");
            Console.WriteLine("\n");

            if (_lista.Count <= 0)
            {
                // Caso o número de elementos do arraylist seja menor ou igual a 0...
                Console.WriteLine("Não há contas cadastradas.");
                Console.ReadKey();
                return;
            }

            foreach (ContaCorrente item in _lista)
            {
                // Para cada item do array de contas correntes, imprime as suas informações
                Console.WriteLine("===    Dados da conta    ===");
                Console.WriteLine("Número da conta: " + item.Conta);
                Console.WriteLine("Saldo da conta: " + item.Saldo);
                Console.WriteLine("Titular da conta: " + item.Titular.Nome);
                Console.WriteLine("CPF do titular: " + item.Titular.CPF);
                Console.WriteLine("Profissão do titular: " + item.Titular.Profissao);
                Console.WriteLine("============================");
                Console.ReadKey();
            }
        }
        static void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===  Cadastro de contas  ===");
            Console.WriteLine("============================");
            Console.WriteLine("\n");
            Console.WriteLine("===Informe dados da conta===");

            // Atribuições
            Console.Write("Número da conta: ");
            string numeroConta = Console.ReadLine();

            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

            Console.Write("Informe o saldo inicial: ");
            conta.Saldo = double.Parse(Console.ReadLine());

            Console.Write("Informe o nome do titular: ");
            conta.Titular.Nome = Console.ReadLine();

            Console.Write("Informe o CPF do titular: ");
            conta.Titular.CPF = Console.ReadLine();

            Console.Write("Informe a profissão do titular: ");
            conta.Titular.Profissao = Console.ReadLine();

            _lista.Add(conta);
            Console.WriteLine("Conta cadastrada com sucesso!");
            Console.ReadKey();
        }
        static void RemoverContas()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===    Remover contas    ===");
            Console.WriteLine("============================");
            Console.WriteLine("\n");

            Console.Write("Informe o número da conta: ");
            string numeroConta = Console.ReadLine();

            ContaCorrente conta = null;
            foreach (var item in _lista)
            {
                if (item.Conta.Equals(numeroConta))
                {
                    conta = item;
                }
            }

            if (conta != null)
            {
                _lista.Remove(conta);
                Console.WriteLine("Conta removida da lista.");
            }
            else
            {
                Console.WriteLine("Conta para remoção não encontrada.");
            }
            Console.ReadKey();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Boas vindas ao atendimento do Bytebank!\n");

            #region Exemplos Arrays em C#
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

            //ArrayDeContasCorrentes();
            #endregion

            #region usando métodos da classe List
            //_lista2.AddRange(_lista3); // Adiciona, no range da lista2, o range da lista3
            //_lista2.Reverse(); // Inverte a ordem dos elementos da lista

            //for (int i = 0; i < _lista2.Count; i++)
            //{
            //    Console.WriteLine($"Indice[{i}] = Conta [{_lista2[i].Conta}]");
            //}

            //Console.WriteLine("\n\n");

            //var range = _lista3.GetRange(0, 1); // Cria uma cópia do range dos elementos em uma lista, especificando o índice inicial e o índice final

            //for (int i = 0; i < range.Count; i++)
            //{
            //    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
            //}

            //Console.WriteLine("\n\n");

            //_lista3.Clear(); // Remove todos os elementos da lista

            //for (int i = 0; i < _lista3.Count; i++)
            //{
            //    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
            //}
            #endregion

            void AtendimentoCliente()
            {
                try
                {
                    char opcao = '0';
                    while (opcao != 0)
                    {
                        Console.Clear();
                        Console.WriteLine("============================");
                        Console.WriteLine("===      Atendimento     ===");
                        Console.WriteLine("===  1 - Cadastrar Conta ===");
                        Console.WriteLine("===  2 - Listar Contas   ===");
                        Console.WriteLine("===  3 - Remover Conta   ===");
                        Console.WriteLine("===  4 - Ordenar Contas  ===");
                        Console.WriteLine("===  5 - Pesquisar Conta ===");
                        Console.WriteLine("===  6 - Sair do sistema ===");
                        Console.WriteLine("============================");
                        Console.WriteLine("\n\n");
                        Console.Write("Digite a opção desejada: ");
                        try
                        {
                            opcao = Console.ReadLine()[0];
                        }
                        catch (Exception excecao)
                        {
                            throw new BytebankException(excecao.Message);
                        }

                        switch (opcao)
                        {
                            case '1':
                                CadastrarConta();
                                break;
                            case '2':
                                ListarContas();
                                break;
                            case '3':
                                RemoverContas();
                                break;
                            default:
                                Console.WriteLine("Opção não implementada.");
                                break;
                        }
                    }
                }
                catch (BytebankException excecao)
                {
                    Console.WriteLine(excecao.Message);
                }
            }
            AtendimentoCliente();
        }
    }
}