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
using System.Collections.ObjectModel;

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
                const decimal ALIQUOTA_ICMS_PADRAO = 0.15m; // Constante que documenta o significado do número mágico
                const decimal ALIQUOTA_ICMS_SP = 0.18m;
                const string UF_SP = "SP";

                decimal valorFinal = 0m;

                if (valorProdutos < 0)
                {
                    throw new ArgumentOutOfRangeException("Valor não pode ser menor do que 0.");
                }

                if (uf == UF_SP)
                {
                    valorFinal = valorProdutos * ALIQUOTA_ICMS_SP;
                    return valorFinal;
                }
                valorFinal = valorProdutos * ALIQUOTA_ICMS_PADRAO;
                return valorFinal;
            }

            // 2 - Encapsular coleção

            // Ao não declarar um set para uma coleção privada, outras classes não podem alterar a lista em si,
            // mas os elemento dela sim. Por causa disso, é necessário utilizar a técnica Encapsular Coleção,
            // que se trata de criar uma outra coleção IReadOnlyCollection que recebe, no get, um construtor 
            // contendo a lista original. Ao solicitar a lista, apenas será possível consultar ela.

            // Exemplo (lista de string que armazena nomes de usuários)

            List<string> nomes = new List<string>
            {
                "Iago", "Matheus", "Guilherme"
            };

            IReadOnlyCollection<string> Nomes = new ReadOnlyCollection<string>(nomes);

            /// Simplificação de condições

            // 1 - Decompondo condições

            // Quando expressões if, then, else, switch, etc... Possuem expressões muito grandes e complexas,
            // é interessante extrair um método de cada linha, clareando a funcionalidade da condicional e
            // permitindo uma manutenção mais fácil.

            // Exemplo (função que calcula as taxas de reserva de um hotel com base na época do ano):

            DateTime INICIO_VERAO = new DateTime(2025, 12, 23);
            DateTime FIM_VERAO = new DateTime(2026, 03, 21);

            decimal taxaInverno = 200m;
            decimal taxaServicoInverno = 70m;
            decimal taxaVerao = 500m;

            decimal GetValorTotal(DateTime data, int dias)
            {
                if (data < INICIO_VERAO || data > FIM_VERAO)
                {
                    return dias * taxaInverno + taxaServicoInverno;
                }
                return dias * taxaVerao;
            }

            decimal GetValorTotalRefatorada(DateTime data, int dias)
            {
                if (ForaDoVerao(data, INICIO_VERAO, FIM_VERAO)) // Agora cada expressão é um método extraído
                {
                    return ValorTotalInverno(dias, taxaInverno, taxaServicoInverno);
                }
                return ValorTotalVerao(dias, taxaVerao);
            }

            // 2 - Remover flag de controle

            // As vezes, flagas são utilizadas em condicionais para realizar consultas, o que pode levar, em alguns casos,
            // a trechos de código duplicado. A estratégia para acabar com isso é criar uma coleção contendo a consulta
            // e utilizar early return (return, break)

            // Exemplo (Função que retorna true ou false caso encontre pessoas específicas em uma lista):

            bool EncontrarPessoaEspecial(IList<string> pessoas)
            {
                bool encontrouPessoa = false; // Flag que é ativada quando a pessoa especial é encontrada

                foreach (var pessoa in pessoas)
                {
                    if (pessoa.Equals("Diego"))
                    {
                        encontrouPessoa = true; // Linha repetitiva de código
                    }
                    if (pessoa.Equals("João"))
                    {
                        encontrouPessoa = true;
                    }
                }
                return encontrouPessoa;
            }

            bool EncontrarPessoaEspecialRefatorada(IList<string> pessoas)
            {
                var pessoasEspeciais = new List<string> { "Diego", "João" }; // Lista que armazena o nome das pessoas especiais

                foreach (var pessoa in pessoas)
                {
                    if (pessoasEspeciais.Contains(pessoa))
                    {
                        return true; // Assim que encontra alguém, já retorna true
                    }
                }
                return false; // Se ninguém foi encontrado, logo a função deve retornar false
            }

            // 3 - Condicionais aninhadas

            // Condicionais aninhadas podem gerar confusão de leitura e dificuldade de manutenção.
            // Para resolver isso, utiliza-se cláusulas guardas, que são cláusulas que fazem uma verificação
            // e imediatamente retornam um valor.

            // Exemplo (função que retorna o pagamento de um funcionário com base em algumas informações):

            double GetPagamento(bool ehFalecido, bool ehSeparado, bool ehAposentado)
            {
                double resultado;

                if (ehFalecido)
                {
                    resultado = 0;
                }
                else
                {
                    if (ehSeparado)
                    {
                        resultado = 2000;
                    }
                    else
                    {
                        if (ehAposentado) // Muitas condições aninhadas, tornando o código pouco elegante
                        {
                            resultado = 1500;
                        }
                        else
                        {
                            resultado = 2500;
                        }
                    }
                }
                return resultado;
            }

            double GetPagamentoRefatorada(bool ehFalecido, bool ehSeparado, bool ehAposentado)
            {
                if (ehFalecido)
                {
                    return 0; // Early return
                }

                if (ehSeparado)
                {
                    return 2000;
                }

                if (ehAposentado)
                {
                    return 1500;
                }

                return 2500; // As salvaguardas deixaram o código mais elegante e legível
            }
        }

        private static decimal ValorTotalVerao(int dias, decimal taxaVerao)
        {
            return dias * taxaVerao;
        }

        private static decimal ValorTotalInverno(int dias, decimal taxaInverno, decimal taxaServicoInverno)
        {
            return dias * taxaInverno + taxaServicoInverno;
        }

        private static bool ForaDoVerao(DateTime data, DateTime INICIO_VERAO, DateTime FIM_VERAO)
        {
            return data < INICIO_VERAO || data > FIM_VERAO;
        }
    }
}