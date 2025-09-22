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
            // Expressões Regulares:
            string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]"; // Expressão regular que define o padrão de uma string referente a um número de telefone

            string textoDeTeste = "Meu nome é Iago, me ligue em 1234-1234";

            Console.WriteLine(Regex.IsMatch(textoDeTeste, padrao)); // Método da classe Regex (Regular expressions) que verifica se uma string qualquer combina com o padrão definido. Recebe como parâmetros a string a ser testada e o padrão, que deve ser formatado com: "[valores_permitidos][valores_permitidos][valores_permitidos]";

            Match resultado = Regex.Match(textoDeTeste, padrao); // Ao invés de retorar apenas True ou False, retorna um objeto com as propriedades do texto que respeita o padrão informado.
            Console.WriteLine(resultado.Value); // Retora o valor do objeto Match, no caso, o número.

            Console.ReadLine();

            // Testando o StartsWith, EndsWith e o Contains:
            string urlTeste = "https://www.bytebank.com/cambio";
            Console.WriteLine(urlTeste.StartsWith("https://www.bytebank.com")); // Verifica se a url se trata de um domínio do bytebank, ou seja, se a string começa com os mesmos caracteres indicados

            Console.WriteLine(urlTeste.EndsWith("https://www.bytebank.com")); // Faz a mesma coisa que o método anterior, mas olhando para o final da string

            Console.WriteLine(urlTeste.Contains("bytebank")); // Retorna true caso a string informada esteja contida na string de referência

            Console.ReadLine();

            // Usando a classe ExtratorValorDeArgumentosURL:
            string _url;
            // Páginas usam formatações específicas para tratarem de páginas dinâmicas, por exemplo:
            // https://www.cptm.sp.gov.br/cptm/sua-viagem/para-onde-voce-vai?para=974&de=3151&acessibilidade=false
            // A "?" separa a porção da URL que contém a página dos argumentos passados
            // O "&" separa os argumentos entre si
            _url = "https://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";

            string url = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            Console.WriteLine(url);

            ExtratorValorDeArgumentosURL extratorDeValores = new ExtratorValorDeArgumentosURL(url);

            Console.WriteLine($"Valor da moeda de origem: {extratorDeValores.GetValor("moedaOrigem")}");
            Console.WriteLine($"Valor da moeda destino: {extratorDeValores.GetValor("moedaDestino")}");
            Console.WriteLine($"Valor: {extratorDeValores.GetValor("VALOR")}");

            Console.ReadLine();

            // Testando o método Remove():
            //string testeRemocao = "primeiraParte&parteParaRemover";
            //int indiceEComercial = testeRemocao.IndexOf('&');
            //Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
            //Console.ReadLine();
        }
    }
}