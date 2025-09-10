using _4_C1_HerancaEInterfaces.Contas;
using _4_C1_HerancaEInterfaces.Excecoes;
using _4_C1_HerancaEInterfaces.Titular;
using _4_C1_HerancaEInterfaces.Funcionarios;
using _4_C1_HerancaEInterfaces.Utilitario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces
{
    internal class Program
    {
        static void CalcularBonificacao()
        {
            GerenciadorDeBonificacao gerenciador = new GerenciadorDeBonificacao();

            Designer ulisses = new Designer("123456");
            ulisses.Nome = "Ulisses Souza";

            Diretor paula = new Diretor("987655");
            paula.Nome = "Paula Souza";

            Auxiliar igor = new Auxiliar("74581");
            igor.Nome = "Igor Dias";

            GerenteDeContas camila = new GerenteDeContas("85678");
            camila.Nome = "Camila Oliveira";

            gerenciador.Registrar(ulisses);
            gerenciador.Registrar(paula);
            gerenciador.Registrar(igor);
            gerenciador.Registrar(camila);

            Console.WriteLine("Total de bonificação = " + gerenciador.TotalDeBonificacao);
        }
        static void Main(string[] args)
        {
            try
            {
                #region
                //Funcionario pedro = new Funcionario("123456789", 2000);
                //pedro.Nome = "Pedro Malazartes";

                //Console.WriteLine(pedro.Nome);
                //Console.WriteLine(pedro.GetBonificacao());

                //Diretor roberta = new Diretor("987654321");
                //roberta.Nome = "Roberta Silva";

                //Console.WriteLine(roberta.Nome);
                //Console.WriteLine(roberta.GetBonificacao());

                // Bonificações:
                //GerenciadorDeBonificacao gerenciador = new GerenciadorDeBonificacao();
                //gerenciador.Registrar(pedro);
                //gerenciador.Registrar(roberta);
                //Console.WriteLine("Total de bonificações: " + gerenciador.TotalDeBonificacao);
                //Console.WriteLine("Total de funcionários: " + Funcionario.TotalDeFuncionarios);

                // Aumentando salários:
                //pedro.AumentarSalario();
                //roberta.AumentarSalario();
                //Console.WriteLine("Novo salário do(a) " + pedro.Nome + ": " + pedro.Salario);
                //Console.WriteLine("Novo salário do(a) " + roberta.Nome + ": " + roberta.Salario);
                #endregion
                CalcularBonificacao();
                Console.WriteLine("\n");
            }
            catch (ArgumentException ex) 
            {
                Console.WriteLine(ex.Message);

            }

            try
            {
                LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");
                leitor.LerProximaLinha();
                leitor.LerProximaLinha();
            }
            catch (IOException)
            {
                Console.WriteLine("Leitura de arquivo interrompida");
            }
            finally
            {
                LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");
                leitor.Fechar();
            }

            try
            {
                ContaCorrente conta1 = new ContaCorrente(10, 1234);
                /*
                conta1.Sacar(50);
                Console.WriteLine(conta1.Saldo);
                conta1.Sacar(150);
                Console.WriteLine(conta1.Saldo); */
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Parâmetro com erro: " + ex.ParamName);
                Console.WriteLine(ex.StackTrace);
            }
            catch (SaldoInsuficienteException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadLine();
        }
    }
}