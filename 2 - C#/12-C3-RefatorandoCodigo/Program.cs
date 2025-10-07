using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics;

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

            // Métodos de refatoração:

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