using _3_C1_EntendendoExcecoes.Contas;
using _3_C1_EntendendoExcecoes.Excecoes;
using _3_C1_EntendendoExcecoes.Titular;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace _3_C1_EntendendoExcecoes
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Exceções

            // throw lança um objeto -> catch captura esse objeto em uma variável -> ex.Message acessa as propriedades dessa variável -> WriteLine imprime essas propriedades na tela.

            // Principais exceções já prontas no C#:
            // DivideByZeroException = Ocorre quando um processamento envolve a divisão por 0
            // ArgumentException = Ocorre quando um erro relacionado a um parâmetro ocorre
            // IOException() = Erros relacionados a entrada e saída de dados

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
                // Para evitar que códigos essenciais não sejam executados por causa das exceções, o finally executa linhas de código adicionais após a captura dos erros
                LeitorDeArquivo leitor = new LeitorDeArquivo("contas.txt");
                leitor.Fechar();
            }

           
            try
            {
                ContaCorrente conta1 = new ContaCorrente(0, 1234);
                /*
                conta1.Sacar(50);
                Console.WriteLine(conta1.Saldo);
                conta1.Sacar(150);
                Console.WriteLine(conta1.Saldo); */
            } 
            catch (ArgumentException ex) // A variável "ex" está recebendo um objeto de ArgumentExcption que está contendo a mensagem de erro lançada pelo throw no método construtor da classe. Ou seja, caso um erro ocorra, seja lançado e seja do mesmo tipo, referencia a variável "ex" para o objeto criado. 
            {
                // Tratamento para número de agência inválido
                Console.WriteLine(ex.Message); // Pega a variável ex (que contém o objeto da exceção), acessa a sua propriedade pública Message e imprime o valor dela no console.
                Console.WriteLine("Parâmetro com erro: " + ex.ParamName);
                Console.WriteLine(ex.StackTrace); // Mostra a linha em que a exceção é lançada e a em que ela está sendo tratada
            }
            catch (SaldoInsuficienteException ex)
            {
                // Tratamento para saque com saldo insuficiente
                // É possível ter diversos catchs para o mesmo bloco de try
                Console.WriteLine(ex.Message);
            }

            

            Console.ReadLine();
        } 
    }
}