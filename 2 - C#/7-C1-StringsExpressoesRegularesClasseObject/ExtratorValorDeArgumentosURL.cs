using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_C1_StringsExpressoesRegularesClasseObject
{
    public class ExtratorValorDeArgumentosURL
    {
        private readonly string _argumentos;
        public string URL { get; }
        public ExtratorValorDeArgumentosURL(string url)
        {
            if(string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento url não pode ser nulo ou vazio. ", nameof(url));
            } // Estas linha de código faz o que todas as linhas a seguir fariam:
            #region
            //if (url == null)
            //{
            //    throw new ArgumentNullException(nameof(url));
            //}

            //if (url.Length == 0)
            //{
            //    throw new ArgumentException("O argumento não pode ser vazio.", nameof(url));
            //}
            #endregion

            int indiceInterrogacao = url.IndexOf('?'); // Faz uma busca na string e retorna o índice do caractere informado
            _argumentos = url.Substring(indiceInterrogacao + 1); // Retorna uma parte da string solicitada. Recebe como parâmetro o primeiro índice da string que se vai recortar. Por receber o método IndexOf + 1 (1 caractere após o "?"), sempre vai recortar corretamente.

            URL = url;
        }

        // moedaOrigem=real&moedaDestino=dolar
        public string GetValor(string nomeParametro)
        {
            nomeParametro = nomeParametro.ToUpper(); // Método que trasnforma todos os caracteres em caixa alta para evitar erros na busca pelos índices
            string argumentoEmCaixaAlta = _argumentos.ToUpper(); // MOEDAORIGEM=REAL&MOEDADESTINO=DOLAR

            // Mesmo com a imutabilidade das strings, é possível fazer atribuições como:
            // url += "sufixo"; que estaria criando uma string temporária com a união da url + "sufixo" e que depois estaria atribuindo a url o valor dessa variável temporária
            string termo = nomeParametro + '='; // Recebe "moedaOrigem" ou "moedaDestino" e adiciona um "=" para encontrat o índice da string futuramente
            int indiceTermo = argumentoEmCaixaAlta.IndexOf(termo); // pega o índice de "moedaOrigem=" ou "moedaDestino="
            string resultado = _argumentos.Substring(indiceTermo + termo.Length); // Retorna a substring que começa a partir do índice do termo + "=" somado ao valor do tamanho do próprio termo, sobrando apenas o valor "real" ou "dolar"

            int indiceEComercial = resultado.IndexOf('&');

            if (indiceEComercial == -1)
            {
                // Caso o índice do & comercial não retorne nada (ou seja, se trata de uma "moedaDestino") apenas retorna o resultado, sem remover nada e evitando erros.
                return resultado;
            }

            return resultado.Remove(indiceEComercial); 
        }
        // Testando o método Remove():
        //string testeRemocao = "primeiraParte&parteParaRemover";
        //int indiceEComercial = testeRemocao.IndexOf('&');
        //Console.WriteLine(testeRemocao.Remove(indiceEComercial, 4));
        //Console.ReadLine();
    }
}
