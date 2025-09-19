using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _7_C1_StringsExpressoesRegularesClasseObject
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url;
            // Páginas usam formatações específicas para tratarem de páginas dinâmicas, por exemplo:
            // https://www.cptm.sp.gov.br/cptm/sua-viagem/para-onde-voce-vai?para=974&de=3151&acessibilidade=false
            // A "?" separa a porção da URL que contém a página dos argumentos passados
            // O "&" separa os argumentos entre si
            url = "https://www.bytebank.com.br/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            Console.WriteLine(url);
        }
    }
}