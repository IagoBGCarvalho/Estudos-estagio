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
using _12_C3_RefatorancoCodigo.Conta;

namespace _12_C3_RefatorandoCodigo
{
    partial class Program
    {
        static void Main(string[] args)
        {
            // Refatoração de código se trata da prática de melhorar a estrutura do código sem alterar o seu comportamento padrão.

            // Um conceito importante da refatoração que ajuda a saber quando o código deve ser refatorado é o Code Smells.
            // Code Smells são "cheiros" que indicam que o código pode ser melhorado, ou seja, refatorado.

            // Situações comuns de Code Smells:

            // 1 - Código duplicado: Viola o princípio DRY (Don't Repeat Yourself). Se o mesmo código aparece em mais de um lugar,
            // é um sinal de que ele deve ser extraído para um método próprio.

            // 2 - Método longo: Viola o Princípio de Responsabilidade ÚNICA (SRP - Simple Responsability Principle) que diz que um método deve
            // fazer somente uma coisa. Além disso, é difícil de ler e entender.

            // 3 - Comentários: Podem não explicar direito o código devido a mudanças posteriores, enganando o desenvolvedor e inibindo a refatoração.

            /// Métodos de refatoração:

            // 1 - Extrair método (Extract Method)

            // Se trata de pegar um trecho de código que está dentro de um método e extrair para um novo método, deixando o código mais legível.

            // Exemplo (Funcionalidade que permite a um funcionário ver o salário que será pago até o momento, mas que exige autenticação):

            /// Implementação SEM extração de método:
            int GetSalario(string funcionario, int senha, Dictionary<string, int> dados)
            {
                // Verifica se o funcionário está autenticado
                bool autenticado = false;
                try
                {
                    if (dados[funcionario] == senha)
                    {
                        autenticado = true;
                    }
                }
                catch (KeyNotFoundException)
                {
                    autenticado = false;
                }

                // Retorna ou não o salário
                if (autenticado == true)
                {
                    return 1000;
                }
                else
                {
                    Console.WriteLine("Usuário não está autenticado.");
                    return 0;
                }
            }

            /// Implementação COM extração de método:
            int GetSalarioRefatorada(string funcionario, int senha, Dictionary<string, int> dados)
            {
                bool autenticado = FuncionarioAutenticado(funcionario, senha, dados); // Extraiu a implementação da autenticação para um método próprio, eliminando 11 linhas de código no processo

                if (autenticado == true)
                {
                    return 1000;
                }
                else
                {
                    Console.WriteLine("Usuário não está autenticado.");
                    return 0;
                }
            }

            bool FuncionarioAutenticado(string funcionario, int senha, Dictionary<string, int> dados)
            {
                // Classe responsável, unicamente, por verificar se o usuário está autenticado, facilitando a manutenção do código
                bool autenticado = false;
                try
                {
                    if (dados[funcionario] == senha)
                    {
                        autenticado = true;
                    }
                }
                catch (KeyNotFoundException)
                {
                    autenticado = false;
                }

                return autenticado;
            }

            // 2 - Incorporar método (Inline Method)

            // Incorporar método se trata do caminho inverso do extrair método
            // Ou seja, identificar um método que não é utilizado demasiadamente e incorporar o seu código no local onde é chamado

            // Exemplo (Função que retorna se a meta de vendas do mês foi batida, mas que utiliza outra função que retorna se foram feitas mais de 10 vendas no mês):

            /// Implementação SEM incorporação de método:
            bool MetaFoiBatida()
            {
                int vendasEsteMes = 11;
                return (ForamFeitasMaisDeDezVendas(vendasEsteMes)) ? true : false;
            }

            bool ForamFeitasMaisDeDezVendas(int qtdVendas)
            {
                return qtdVendas > 10; // A função faz exatamente o que o nome diz, apenas uma linha de código que faz uma única verificação e que não será utilizada em mais de um lugar
            }

            /// Implementação COM incorporação de método:
            bool MetaFoiBatidaRefatorada(int qtdVendas)
            {
                return (qtdVendas > 10) ? true : false; // Código limpo e prático, utilizando menos linhas para fazer a mesma coisa e sem prejudicar o entendimento
            }

            // 3 - Extrair Variável (Extract Variable):

            // Quando expressões muito grandes são utilizadas dentro de outras expressões, é interessante extrair essas expressões para
            // variáveis locais com nomes significativos, facilitando o entendimento do código.

            // Exemplo (Função valida um CPF verificando o tamanho e se contém apenas números):


            /// Implementação SEM extração de variável:
            int ValidaERetornaCPF(string cpf)
            {
                if (cpf.Replace(".", "").Replace("-", "").Length == 11 && long.TryParse(cpf.Replace(".", "").Replace("-", ""), out long cpfNumerico)) // Expressão repetida e complexa de ler
                {
                    return (int)(cpfNumerico % 1000); // Retorna os últimos 3 dígitos do CPF
                }
                else
                {
                    Console.WriteLine("CPF inválido.");
                    return -1;
                }
            }

            /// Implementação COM extração de variável:
            int ValidaERetornaCPFRefatorada(string cpf)
            {
                string cpfNumeros = cpf.Replace(".", "").Replace("-", ""); // Variável extraída com nome claro

                if (cpfNumeros.Length == 11 && long.TryParse(cpfNumeros, out long cpfNumerico))
                {
                    return (int)(cpfNumerico % 1000); // Retorna os últimos 3 dígitos do CPF
                }
                else
                {
                    Console.WriteLine("CPF inválido.");
                    return -1;
                }
            }

            // 4 - Incorporar variável temporária (Inline Temp):

            // Contrário do extrair variável, se trata de incorporar uma variável temporária que é utilizada apenas uma vez.
            // Ou seja, variáveis que armazenam expressões que são tão óbvias quanto o seu próprio nome podem ser incorporadas.

            // Exemplo (Função que verifica se um produto tem desconto baseado no seu preço):

            /// Implementação SEM incorporação de variável temporária:
            bool TemDesconto(PrecosProdutos produto)
            {
                decimal valorProduto = (decimal)(int)produto; // A variável é utilizada apenas uma vez, então pode ser incorporada

                return valorProduto > 30;
            }

            /// Implementação COM incorporação de variável temporária:
            bool TemDescontoRefatorada(PrecosProdutos produto)
            {
                return ((decimal)(int)produto > 30); // Código mais limpo e prático
            }

            // 5 - Substituir variável por consulta

            // As vezes é necessário utilizar uma mesma expressão repetidas vezes, mas se uma variável em uma função receber essa expressão, 
            // ela não será mais disponível para ninguém fora do escopo da função.
            // Por causa disso, é interessante formular métodos que obtém um valor, chamados de consulta (query).

            // Exemplo (função que calcula o valor final de um pedido, com impostos):

            /// Implementação SEM substituição de variável por consulta:
            decimal CalculaValorFinalPedido()
            {
                decimal precoBase = 100m;
                decimal taxaImposto = 0.1m;   // 10%
                decimal desconto = 0.05m;     // 5%

                decimal precoComImposto = precoBase + (precoBase * taxaImposto); // Variáveis inacessíveis fora da função e que possuem lógica importante que pode ser reutilizada
                decimal precoFinal = precoComImposto - (precoComImposto * desconto);

                return precoFinal;
            }

            /// Implementação COM substituição de variável por consulta:
            decimal precoBase;
            decimal taxaImposto;
            decimal desconto;

            decimal PrecoComImposto() => precoBase + (precoBase * taxaImposto); // Consultas que podem ser reutilizadas em outras partes do código
            decimal PrecoComDesconto() => PrecoComImposto() - (PrecoComImposto() * desconto); // Como têm lógica pequena, pode ser declarada com lambda

            decimal CalculaValorFinalPedidoRefatorada()
            {
                decimal precoBase = 100m;
                decimal taxaImposto = 0.1m;
                decimal desconto = 0.05m;     

                return PrecoComDesconto(); // Apenas chama a consulta
            }

            // 6 - Quebrar variável em 2 ou mais

            // Quando a mesma variável em uma função realiza dois trabalhos computacionais diferentes
            // muitos problemas ocorrem, ela pode não documentar corretamente a sua funcionalidade,
            // está acumulando tarefas e trechos de códigos independentes se tornam dependentes.
            // Por isso, é interessante quebrar essa variável em duas ou mais, especializando cada uma.

            // Exemplo (uma função que calcula o perímetro e a área de um retângulo):

            /// Implementação SEM quebra de variável em duas ou mais:
            void PerimetroAreaRetangulo(double altura, double largura)
            {
                double temp = 2 * (altura + largura);
                Console.WriteLine($"Perímetro: {temp}");

                temp = altura * altura; // A mesma variável recebe dois processamento diferentes na função
                Console.WriteLine($"Área: {temp}");
            }

            /// Implementação COM quebra de variável em duas ou mais:
            void PerimetroAreaRetanguloRefatorada(double altura, double largura)
            {
                double perimetro = 2 * (altura + largura); // Agora cada variável documenta o que faz e é independente de outros trechos de código
                Console.WriteLine($"Perímetro: {perimetro}");

                double area = altura * altura; 
                Console.WriteLine($"Área: {area}");
            }

            // 7 - Remover atribuições a parâmetros:

            // Quando um parâmetro é utilizado dentro da função como uma variável local (recebendo valores e funções),
            // diversos problemas surgem, pois o princípio da única responsabilidade é quebrado.
            // Além disso, a mensagem (valor original do parâmetro) é perdida.
            // Para resolver isso, é mecessário introduzir variáveis locais e de retorno na função,
            // aposentando o parâmetro das suas funções.

            // Exemplo(Função que calcula o desconto de um cliente fiel):

            /// Implementação SEM remoção de atribuições ao parâmetro:
            decimal GetDescontoClienteFiel(decimal descontoInicial, int quantidade, int clienteHaQuantosAnos)
            {
                if (descontoInicial > 50m)
                {
                    descontoInicial = 50;
                }
                if (quantidade > 100)
                {
                    descontoInicial += 15; // O parâmetro está sendo utilizado tanto para receber um valor de fora, quanto variável local, fazendo ele acumular funções
                }
                if (clienteHaQuantosAnos > 4)
                {
                    descontoInicial += 10;
                }

                return descontoInicial;
            }

            /// Implementação COM remoção de atribuições ao parâmetro:
            decimal GetDescontoClienteFielRefatorada(decimal descontoInicial, int quantidade, int clienteHaQuantosAnos)
            {
                decimal resultado = descontoInicial; // Variável local para armazenar o valor do parâmetro e receber valores, preservando o valor do parâmetro

                if (descontoInicial > 50m)
                {
                    resultado = 50;
                }
                if (quantidade > 100)
                {
                    resultado += 15;
                }
                if (clienteHaQuantosAnos > 4)
                {
                    resultado += 10;
                }

                return resultado;
            }

            // 8 - Substituir método por método-objeto

            // Quando uma classe está sobrecarregada de funções, é uma boa prática pegar uma funioanlidade
            // difícil e trasnportá-la para outra classe.

            // Exemplo (função que calcula o preço de um produto):

            /// Implementação SEM substituição de método por método-objeto:
            decimal Preco(decimal precoBase, decimal acrescimo, decimal desconto)
            {
                if (desconto > 20)
                {
                    desconto = 20;
                }
                if (acrescimo > 15)
                {
                    acrescimo = 15;
                }

                var resultado = precoBase + precoBase * (acrescimo - desconto);

                return resultado;
            }

            /// Implementação COM substituição de método por método-objeto:
            decimal PrecoRefatorada(decimal precoBase, decimal acrescimo, decimal desconto)
            {
                decimal resultado = 0m;

                // return new CalculadoraDePrecos(this, precoBase, acrescimo, desconto); // Método de outra classe que utiliza os parâmetros de produto para calcular o preço final
                return resultado;
            }

            // 9 - Substituir algoritmos

            // As vezes, após implementar uma função e ela funcionar, ainda existem maneiras de tornar o algoritmo
            // mais claro, simples e funcional.

            // Exemplo (função que registra e calcula o número de alunos em uma matéria)

            /// Implementação SEM substituição de algoritmo:
            int CalculaNumeroAlunos()
            {
                int totalAlunos = 0;

                while (true) // Funciona, mas a lógica é pouco elegante e pode trazer problemas
                {
                    Console.WriteLine("Digite o nome do aluno: ");
                    var nomeAluno = Console.ReadLine();
                    totalAlunos++;

                    Console.WriteLine("Tem mais alunos? <S> para SIM e <N> para NÃO:");
                    var decisao = Console.ReadLine();

                    if (decisao.ToUpper() == "N")
                    {
                        break;
                    }
                }
                return totalAlunos;
            }

            /// Implementação COM substituição de algoritmo:
            int CalculaNumeroAlunosRefatorada()
            {
                int totalAlunos = 0;
                string decisao;

                do
                {
                    Console.WriteLine("Digite o nome do aluno: ");
                    var nomeAluno = Console.ReadLine();
                    totalAlunos++;
                    do
                    {
                        Console.WriteLine("Tem mais alunos? <S> para SIM e <N> para NÃO:");
                        decisao = Console.ReadLine().ToUpper();
                    } 
                    while (decisao != "S" && decisao != "N");
                } 
                while (decisao == "S"); // Agora o algoritmo é mais claro e elegante
                return totalAlunos;
            }
            Console.ReadLine();
        }
        enum PrecosProdutos
        {
            Arroz = 20,
            Feijao = 10,
            Macarrao = 15,
            Carne = 50,
            Frango = 30
        }
    }
}