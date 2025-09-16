using _5_C1_ArraysEColecoes.bytebank.Modelos.Conta;
using _5_C1_ArraysEColecoes.Excecoes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.Bytebank.Atendimento
{
    internal class BytebankAtendimento
    {
        private List<ContaCorrente> _lista = new List<ContaCorrente>() // Criando uma lista genérica. Possui mais desempenho e segurança do que um ArrayList.
        {
            new ContaCorrente(95, "123456-X") {Saldo=100, Titular = new Cliente{CPF = "11111", Nome = "Henrique"}},
            new ContaCorrente(95, "951258-X") {Saldo=200, Titular = new Cliente{CPF = "22222", Nome = "Pedro"}},
            new ContaCorrente(94, "987321-W") {Saldo=60, Titular = new Cliente{CPF = "33333", Nome = "Marisa"}}
        };
        public void AtendimentoCliente()
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
                        case '4':
                            OrdenarContas();
                            break;
                        case '5':
                            PesquisarConta();
                            break;
                        case '6':
                            EncerrarAtendimento();
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
        private void ListarContas()
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
                Console.WriteLine(item.ToString());
                Console.ReadKey();
            }
        }
        private void CadastrarConta()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===  Cadastro de contas  ===");
            Console.WriteLine("============================");
            Console.WriteLine("\n");
            Console.WriteLine("===Informe dados da conta===");

            // Atribuições
            Console.Write("Número da Agência: ");
            int numeroAgencia = int.Parse(Console.ReadLine());

            ContaCorrente conta = new ContaCorrente(numeroAgencia);
            Console.WriteLine($"Número da conta: {conta.Conta}");

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
        private void RemoverContas()
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
                    // Procura pelo número da conta passado pelo input, se achar uma igual, atribui ao objeto conta e depois o exclui
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
        private void OrdenarContas()
        {
            _lista.Sort();
            Console.WriteLine("Lista de contas ordenada.");
            Console.ReadKey();
        }
        private void PesquisarConta()
        {
            Console.Clear();
            Console.WriteLine("============================");
            Console.WriteLine("===   Pesquisar contas   ===");
            Console.WriteLine("============================");
            Console.WriteLine("\n");
            Console.Write("Deseja pesquisar pelo NÚMERO DA CONTA (1) pelo CPF (2) ou pelo NÚMERO DA AGÊNCIA (3): ");
            switch (int.Parse(Console.ReadLine()))
            {
                case 1:
                    {
                        Console.Write("Informe o número da conta: ");
                        string _numeroConta = Console.ReadLine();
                        ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                        Console.WriteLine(consultaConta.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 2:
                    {
                        Console.Write("Informe o CPF da conta: ");
                        string _cpf = Console.ReadLine();
                        ContaCorrente consultaCpf = ConsultaPorCPFTitular(_cpf);
                        Console.WriteLine(consultaCpf.ToString());
                        Console.ReadKey();
                        break;
                    }
                case 3:
                    {
                        Console.Write("Informe o número da agência: ");
                        int _agencia = int.Parse(Console.ReadLine());
                        var consultaAgencia = ConsultaPorAgencia(_agencia);
                        ExibirListaDeContas(consultaAgencia);
                        Console.ReadKey();
                        break;
                    }
                default:
                    Console.WriteLine("Opção não implementada.");
                    break;

            }
        }
        private ContaCorrente ConsultaPorCPFTitular(string cpf)
        {
            ContaCorrente conta = null;
            // Pesquisa feita na mão:
            //for (int i = 0; i < _lista.Count; i++)
            //{
            //    if (_lista[i].Titular.CPF.Equals(cpf))
            //    {
            //        conta = _lista[i];
            //    }
            //}
            //return conta;

            return _lista.Where(conta => conta.Titular.CPF == cpf).FirstOrDefault();
            // a função Where do LINQ pega todos os itens da lista _lista e compara com a lógica (conta.Titular.CPF == Cpf), se for verdadeira para aquele item, armazena ele em uma lista temporária, se não, o descarta. Ao final, retorna uma coleção de n elementos que representam todos os elementos que possuem os requisitos da busca. FirstOrDefault simplesmente retorna o primeiro elemento dessa coleção.

        }
        private ContaCorrente ConsultaPorNumeroConta(string numeroConta)
        {
            ContaCorrente conta = null;
            //for (int i = 0; i < _lista.Count; i++)
            //{
            //    if (_lista[i].Conta.Equals(numeroConta))
            //    {
            //        conta = _lista[i];
            //    }
            //}
            //return conta;
            return _lista.Where(conta => conta.Conta == numeroConta).FirstOrDefault();
        }
        private List<ContaCorrente> ConsultaPorAgencia(int agencia)
        {
            // Consulta por agência utilizando LINQ, de cada conta em _lista onde o número da agência é igual ao fornecido, seleciona esta conta e a coloca em uma lista chamada "consulta"
            var consulta = (
                from conta in _lista
                where conta.Agencia == agencia
                select conta).ToList();

            return consulta;
        }
        private void ExibirListaDeContas(List<ContaCorrente> consultaAgencia)
        {
            // Recebe a lista de contas encontradas pela pesquisa por agência e imprime cada uma na tela, caso não esteja vazia.
            if (consultaAgencia == null)
            {
                Console.WriteLine("A consulta não retornou nenhum dado.");
            }

            foreach (var item in consultaAgencia)
            {
                Console.WriteLine(item.ToString());
            }
        }
        private void EncerrarAtendimento()
        {
            Console.WriteLine("Encerrando a aplicação.");
            Console.ReadKey();
        }
    }
}
