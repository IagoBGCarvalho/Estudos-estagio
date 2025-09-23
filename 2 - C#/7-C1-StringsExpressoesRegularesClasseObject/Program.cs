using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using _7_C1_StringsExpressoesRegularesClasseObject;
using System.Text.RegularExpressions;

namespace _7_C1_StringsExpressoesRegularesClasseObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Strings:

            string _url;
            // Páginas usam formatações específicas para tratarem de páginas dinâmicas, por exemplo:
            // https://www.cptm.sp.gov.br/cptm/sua-viagem/para-onde-voce-vai?para=974&de=3151&acessibilidade=false
            // A "?" separa a porção da URL que contém a página dos argumentos passados
            // O "&" separa os argumentos entre si
            _url = "https://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            string url = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            Console.WriteLine(url);

            // Usando a classe ExtratorValorDeArgumentosURL:
            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(url);

            Console.WriteLine($"Valor da moeda de origem: {extratorDeValores.GetValor("moedaOrigem")}");
            Console.WriteLine($"Valor da moeda destino: {extratorDeValores.GetValor("moedaDestino")}");
            Console.WriteLine($"Valor: {extratorDeValores.GetValor("VALOR")}");

            Console.ReadLine();

            // Testando o StartsWith, EndsWith e o Contains:
            string urlTeste = "https://www.bytebank.com/cambio";
            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com")); // Verifica se a url se trata de um domínio do bytebank, ou seja, se a string começa com os mesmos caracteres indicados

            Console.WriteLine(urlTeste.EndsWith("https://www.bytebank.com")); // Faz a mesma coisa que o método anterior, mas olhando para o final da string

            Console.WriteLine(urlTeste.Contains("bytebank")); // Retorna true caso a string informada esteja contida na string de referência

            Console.ReadLine();

            // Expressões Regulares:

            string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]"; // Expressão regular que define o padrão de uma string referente a um número de telefone

            string padraoFormatado = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]"; // Mesmo padrão, mas de forma simplificada, indicando que os números padrões estão entre o código ASCII do número 0 até o do 9

            string padraoFormatado2 = "[0-9]{4}[-][0-9]{4}"; // Para quantificar as vezes em que um padrão específico ocorre, utiliza-se chaves. 

            string padraoFormatado3 = "[0-9]{4,5}-{0,1}[0-9]{4}"; // É possível colocar mais de um número entre chaves para especificar até quantas vezes o padrão pode ocorrer. Também é possível retirar os colchetes dos padrões que apenas possuem 1 caractere.

            string padraoFormatado4 = "[0-9]{4,5}-?[0-9]{4}"; // Ao invés de utilizar {0,1} para padrões que podem ou não aparecer, é possível utilizar o caractere coringa "?".

            string textoDeTeste = "Meu nome é Iago, me ligue em 99835-7901";

            Console.WriteLine(Regex.IsMatch(textoDeTeste, padraoFormatado4)); // Método da classe Regex (Regular expressions) que verifica se uma string qualquer combina com o padrão definido. Recebe como parâmetros a string a ser testada e o padrão, que deve ser formatado com: "[valores_permitidos][valores_permitidos][valores_permitidos]";

            Match resultado = Regex.Match(textoDeTeste, padraoFormatado4); // Ao invés de retornar apenas True ou False, retorna um objeto com as propriedades do texto que respeita o padrão informado.
            Console.WriteLine(resultado.Value); // Retora o valor do objeto Match, no caso, o número.

            Console.ReadLine();

            // Classe object:
            Pessoa iago1 = new Pessoa("Iago", "777.777.777-77", "Dev");
            Pessoa iago2 = new Pessoa("Iago", "777.777.777-77", "Dev");

            Console.WriteLine("Olá, mundo!");
            Console.WriteLine(123);
            Console.WriteLine(10.5);
            Console.WriteLine(true);
            //Console.WriteLine(iago); Retorna o ToString() da classe

            string pessoaToString = iago1.ToString();
            Console.WriteLine(pessoaToString);

            // (iago1 == iago2)... Como são objetos que apontam para endereços diferentes, não serão iguais, mesmo possuindo os mesmos valores para as mesmas propriedades. A mesma coisa aconteceria ao utilizar o método .Equals() que recebe um objeto.
            // Para resolver isso, é necessário sobrescrever o método .Equals() da classe object.

            if (iago1.Equals(iago2)) 
            {
                Console.WriteLine("São iguais!");
            }
            else
            {
                Console.WriteLine("Não são iguais.");
            }

            Console.ReadLine();
        }
    }
}