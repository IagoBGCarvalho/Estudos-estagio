using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics;
using _11_C2_TrabalhandoComArquivos.Conta;

namespace _11_C2_TrabalhandoComArquivos
{
    partial class Program // Partial faz com que a classe possa ser dividida em vários arquivos, contanto que estejam no mesmo namespace
    {
        static void LidandoComFileStreamDiretamente()
        {
            // EXTRAINDO BYTES:

            // Para trabalhar com arquivos, é necessário entender o conceito de fluxo de dados. Ao invés de carregar o arquivo inteiro na memória,
            // é possível ler o arquivo em partes, como um fluxo contínuo de dados. Os bytes são percorridos um a um, ou em blocos, dependendo do tipo de fluxo.
            var enderecoDoArquivo = "contas.txt"; // Normalmente utiliza-se o caminho completo do arquivos na hierarquia do sistema operacional, mas coloquei o arquivo na pasta do executável, permitindo chamá-lo diretamente pelo nome

            using (var fluxoDoArquivo = new FileStream(enderecoDoArquivo, FileMode.Open)) // O using se trata de um pacto de segurança. Não importando o que acontece dentro do {}, assim que a execução sair de lá, o fluxoDoArquivo será fechado.

            // FileStream é a classe do .NET que representa um fluxo de dados a partir de um arquivo. Ele recebe, como argumentos, o endereço do arquivo, o modo de abertura (FileMode) e o tipo acesso (FileAccess).
            {
                var numeroDeBytesLidos = -1; // Recebe -1 pois os bytes apenas podem ser iguais ou maiores que 0.

                // Após definir o caminho do arquivo e o fluxo, é necessário recuperar os bytes.

                // Isso é feito urilizando Read, que é um método do FileStream e possui a seguinte estrutura:
                // public override int Read(byte[] array, int offset, int count);

                // Os argumentos são:
                // array: um array de bytes que irá receber os bytes lidos do arquivo
                // offset: Delimita o índice do início da escrita do array
                // count: Informa quantas posições do array devem ser preenchidas

                // E ele retorna:
                // O número total de bytes lidos do buffer. Isso poderá ser menor que o número de bytes solicitado se esse número de bytes não estiver
                // disponível no momento, ou zero, se o final do fluxo for atingido

                // O array dentro da função se trata de um buffer, que é um array que pode ser utilizado para guardar informações temporárias.
                // O buffer é necessário pois o Read não lê o arquivo inteiro de uma vez, ele lê em partes, e o buffer é utilizado para guardar essas partes.

                var buffer = new byte[1024]; // Cria um buffer com 1024 posições (1KB de memória)

                while (numeroDeBytesLidos != 0) // Enquanto o número de bytes for maior do que 0, continua lendo o arquivo
                {
                    numeroDeBytesLidos = fluxoDoArquivo.Read(buffer, 0, 1024); // Está utilizando um buffer com 1024 posições, escrevendo o fluxo de dados a partir do índice 0, preenchendo todas as posições
                    Console.WriteLine($"Bytes lidos: {numeroDeBytesLidos}");
                    EscreverBuffer(buffer, numeroDeBytesLidos); // Função que decodifica e imprime o buffer
                }
            }
            Console.ReadLine();
        }
        static void EscreverBuffer(byte[] buffer, int bytesLidos)
        {
            /// Decodifica e escreve o conteúdo do buffer na tela

            // DECODIFICAÇÃO:

            // O byte possui um valor que pode variar de 0 a 255. Cada valor representa um caractere diferente, e essa relação entre valor e caractere é chamada de tabela de codificação.

            // A classe Encoding (e suas derivadas) é utilizada para fazer a codificação e decodificação de strings. Possui diversos métodos, como: GetString, GetBytes, GetCharCount, etc...

            var utf8 = new UTF8Encoding(); // Cria um objeto da classe UTF8Encoding que é responsável por fazer a codificação e decodificação de strings

            // Sintaxe do GetString: public virtual string GetString(byte[] bytes, int indx, int count) Recebe o buffer, o índice de início e a quantidade de bytes a serem convertidos. Amteriormente, apenas o buffer era passado como argumento, e isso causava a impressão de caracteres repetidos, visto que o buffer não estava sendo reescrito completamente.

            var texto = utf8.GetString(buffer, 0, bytesLidos); // Converte o array de bytes em string utilizando o método GetString da classe UTF8Encoding
            Console.Write(texto);
            //foreach (var meuByte in buffer)
            //{
            //    Console.Write(meuByte);
            //    Console.Write(" ");
            //}
        }

    }
}