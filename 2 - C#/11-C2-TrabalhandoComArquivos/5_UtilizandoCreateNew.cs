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
    partial class Program
    {
        static void UtilizandoCreateNew()
        {
            // O FileMode é um enum que é passado ao FileStream para definir o modo de abertura do arquivo
            // Os mais importantes são:

            // FileMode.Open: Abre um arquivo. Se não existir, lamça uma exceção.
            // FileMode.Create: Se o arquivo não existe, cria um novo, mas se já existe, sobreescreve completamente o conteúdo.
            // FileMode.CreateNew: Mais seguro. Cria um novo arquivo, mas se ele já existir, lança uma exceção IOException.
            // FileMode.Append: Abre o arquivo e posiciona o cursor no final do arquivo, permitindo adicionar mais conteúdo. Se não existe, ele cria. (bom para arquivos de log).
            CriarArquivoCsvComCreateNew();
            Console.ReadLine();
        }

        static void CriarArquivoCsvComCreateNew()
        {
            var caminhoNovoArquivo = "contasExportadas2.csv";

            try
            {
                using (var fluxoDeArquivo = new FileStream(caminhoNovoArquivo, FileMode.CreateNew))
                // IMPORTANTE!!
                // É necessário prevenir o paradoxo aqui. Até agora, apenas o construtor "simples" estava sendo usado.
                // Ao tentar utilizar o modo avançado (CreateNew) dois fluxos são criados. Caso ambos os fluxos tentem criar o arquivo
                // ao mesmo tempo, um deles será barrado de fazer isso. Por causa disso, é necessário crar um fluxo com o FileStream
                // e dar esse fluxo de argumento para o StreamWrite
                // Ou seja, utiliza-se o construtor avançado quando utiliza-se o CreateNew e o Append, visto que ambos precisam fazerum controle fino sobre como o arquivo é aberto.
                using (var escritor = new StreamWriter(fluxoDeArquivo))
                {
                    escritor.WriteLine("801,1111-Y,1500,0,Ana");
                    Console.WriteLine($"\nArquivo {caminhoNovoArquivo} criado com FileMode.CreateNew!");
                }
            }
            catch (IOException)
            {
                Console.WriteLine($"\nErro: O arquivo {caminhoNovoArquivo} já existe.");
            }
        }

    }
}