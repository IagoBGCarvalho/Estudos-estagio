using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace _9_C2_ColecoesOrdenadasArrayMultidimensionaisELinq
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Coleções ordenadas:
            Console.WriteLine("COLEÇÕES ORDENADAS:\n");

            // Coleções ordenadas se tratam de estruturas que organizam os próprios items conforme são adicionados

            /// Sorted List
            Console.WriteLine("Sorted List:\n");

            Console.WriteLine("---Adicionando e removendo itens de um dicionário normal---\n");

            IDictionary<string, Aluno> alunos = new Dictionary<string, Aluno>(); // Dicionário que recebe uma sigla como chave (string) e um objeto Aluno como valor (que possui nome e matrícula)

            alunos.Add("VT", new Aluno("Vanessa", 34672));
            alunos.Add("AL", new Aluno("Ana", 5617));
            alunos.Add("RN", new Aluno("Rafael", 17645));
            alunos.Add("WM", new Aluno("Wanderson", 11287));

            // Imprimindo:
            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
            Console.WriteLine();

            alunos.Remove("AL");
            alunos.Add("MO", new Aluno("Marcelo", 12345));

            foreach (var aluno in alunos)
            {
                Console.WriteLine(aluno);
            }
            Console.WriteLine();

            Console.WriteLine("Como visto, é difícil rastrear a posição de cada item. As chaves de um dicionário são armazenadas como um conjunto (de maneira não ordenada), ou seja, dependem do hash e da tebela de espalhamento para serem alocadas na memória.\n");

            Console.WriteLine("É possível utilizar uma Sorted List para resolver isso, que se trata da implementação de um IDictionary onde as chaves e os valores são armazenados em listas ordenadas.\n");

            Console.WriteLine("---Utilizando uma sorted list---\n");

            IDictionary<string, Aluno> sortedList = new SortedList<string, Aluno>(); // A interface IDictionary recebe uma instância de SorteList, que trasnforma as chaves do dicionário em uma lista ordenada

            sortedList.Add("VT", new Aluno("Vanessa", 34672));
            sortedList.Add("AL", new Aluno("Ana", 5617));
            sortedList.Add("RN", new Aluno("Rafael", 17645));
            sortedList.Add("WM", new Aluno("Wanderson", 11287));

            foreach (var item in sortedList)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.ReadLine();

            /// Sorted Dictionary
            Console.WriteLine("Sorted Dictionary:\n");

            Console.WriteLine("O SortedDictionary apenas é diferente em relaçao a SortedList em relação a implementação. No fim, ambos retornam a mesma coisa, um dicionário ordenado.\n");

            Console.WriteLine("No SortedDictionary, ao invés de uma lista ordenada, as chaves e valores são armazenados, respectivamente, como 'KeyCollection' e 'ValueCollection'. O KeyCollection se trata de uma árvore binária, onde cada elemento aponta para o elemento que vem antes dele, estabelecendo uma ordem de chaves.\n");

            Console.WriteLine("A árvore binária implementada possui um algoritmo que reajusta a sua estrutura conforme mais elementos são adicionados, tornando ela mais larga do que profunda, consequentemente, exigindo menos passos para se chegar a um elemento.\n");

            IDictionary<string, Aluno> sortedDictionary = new SortedDictionary<string, Aluno>();

            sortedDictionary.Add("VT", new Aluno("Vanessa", 34672));
            sortedDictionary.Add("AL", new Aluno("Ana", 5617));
            sortedDictionary.Add("RN", new Aluno("Rafael", 17645));
            sortedDictionary.Add("WM", new Aluno("Wanderson", 11287));

            Console.WriteLine("---Utilizando um sorted Dictionary---\n");

            foreach (var item in sortedDictionary)
            {
                Console.WriteLine(item);
            }
            Console.WriteLine();

            Console.ReadLine();

            /// Sorted Set
            Console.WriteLine("Sorted Set:\n");

            Console.WriteLine("Um conjunto normal não possui ordenação nenhuma e nem consegue entender que a mesma string em maiúsculo se trata de outra instância.\n");

            Console.WriteLine("---Criando um conjunto ordenado de alunos---\n");

            ISet<string> alunosSet = new SortedSet<string>(new ComparadorMinusculo())
            {
                "Vanessa Tonini", "Ana Losnak", "Rafel Nercessian", "Priscila Stuani"
            };

            alunosSet.Add("Rafael Rollo");
            alunosSet.Add("Fabio Gushiken");
            alunosSet.Add("Fabio Gushiken");
            alunosSet.Add("FABIO GUSHIKEN");

            foreach (var aluno in alunosSet)
            {
                Console.WriteLine(aluno);
            }

            Console.WriteLine("O SortedSet utiliza o mesmo princípio de árvore binária balançeada do SortedDictionary para armazenar os seus valores e ordena-los.\n");

            Console.WriteLine("---Operações utilizando conjuntos---\n");

            ISet<string> outroConjunto = new HashSet<string>();

            Console.WriteLine("C1 é subconjunto de C2?\n");

            Console.WriteLine(alunosSet.IsSubsetOf(outroConjunto) + "\n");

            Console.WriteLine("C1 é superconjunto de C2? (O outro conjunto está contido neste conjunto)\n");

            Console.WriteLine(alunosSet.IsSupersetOf(outroConjunto) + "\n");

            Console.WriteLine("Os conjunto contêm os mesmos elementos?\n");

            Console.WriteLine(alunosSet.SetEquals(outroConjunto) + "\n");

            Console.WriteLine("Como remover tudo o que faz parte do outro conjunto neste conjunto?\n");

            alunosSet.ExceptWith(outroConjunto);

            Console.WriteLine("Qual a intersecção dos conjuntos?\n");

            alunosSet.IntersectWith(outroConjunto);

            Console.WriteLine("Quais os elementos que não estão na intersecção?\n");

            alunosSet.SymmetricExceptWith(outroConjunto);

            Console.WriteLine("Qual a união dos elementos dos dois conjuntos?\n");

            alunosSet.UnionWith(outroConjunto);

            Console.ReadLine();

            /// Arrays Multidimensionais
            Console.WriteLine("Arrays multidimensionais:\n");

            Console.WriteLine("Arrays multidimensionais se tratam de arrays que podem receber mais dimensões, possibilitando simular estruturas como tabelas, cubos etc.\n");

            // Array multidimensional que vai representar uma tabela com os 3 finalistas das últimas 3 copas do mundo:

            string[,] resultadosArray = new string[4, 3]; // A primeira vírgula representa as duas dimensões e os dois 3 representam a quantidade de elementos por dimensão
            //{
            //    {"Alemanha", "Espanha", "Itália"}, // Cada linha da tabela deve estar entre chaves
            //    {"Argentina", "Holanda", "França"},
            //    { "Holanda", "Alemanha", "Alemanha"}
            //};

            // Populando utilizando índice:
            resultadosArray[0, 0] = "Alemanha"; // Linha 0 da coluna 0
            resultadosArray[1, 0] = "Argentina"; // Linha 1 da coluna 0
            resultadosArray[2, 0] = "Holanda";
            resultadosArray[3, 0] = "Brasil";

            resultadosArray[0, 1] = "Espanha"; // Linha 0 da coluna 1
            resultadosArray[1, 1] = "Holanda"; // ...
            resultadosArray[2, 1] = "Alemanha";
            resultadosArray[3, 1] = "Uruguai";

            resultadosArray[0, 2] = "Itália";
            resultadosArray[1, 2] = "França";
            resultadosArray[2, 2] = "Alemanha";
            resultadosArray[3, 2] = "Portugal";

            Console.WriteLine("---Imprimindo a tabela---\n");

            //Imprimindo os elementos do array multidimensional em sequência:

            //foreach (var selecao in resultadosArray)
            //{
            //    Console.WriteLine(selecao);
            //}

            // Imprimindo o cabeçalho:
            for (int copa = 0; copa <= resultadosArray.GetUpperBound(1); copa++)
            {
                int ano = 2014 - copa * 4;
                Console.Write(ano.ToString().PadRight(12)); // ToString trasnforma o ano em string e PadRight tabula com o número de espaços fornecidos
            }
            Console.WriteLine();

            // Imprimindo valores:

            //for (int copa = 0; copa < 3; copa++)
            //{
            //    Console.Write(resultadosArray[0, copa].PadRight(12)); // Apenas imprime todos elementos da linha 0
            //}

            for (int posicao = 0; posicao <= resultadosArray.GetUpperBound(0); posicao++) // GetUpperBound retorna o maior índice da dimensão, retirando o trabalho de alterar o for a cada adição de linha
            {
                for (int copa = 0; copa <= resultadosArray.GetUpperBound(1); copa++)
                {
                    Console.Write(resultadosArray[posicao, copa].PadRight(12)); // Com um for dentro de um for é possível imprimir, de uma vez, todos os elementos de todas as linhas. A cada loop for de posição, a variável "posição" dentro do for menor vai mudar, imprimindo todos os elementos da linha especificada.
                }
                Console.WriteLine(); // Pula uma linha após a impressão de três valores para manter a formatação
            }
          
            Console.ReadLine();

            /// Jagged Arrays
            Console.WriteLine("Jagged Arrays:\n");

            Console.WriteLine("O Jagged Array se trata de um array denteado (ou serrilhado), ou seja, um array que não precisa saber o número exato de elementos por linha.\n");

            string[][] familiasArray = new string[3][]; // Como se sabe o número de linhas, mas não de colunas, cria-se um colchetes vazio para representar a nova dimensão
            //{
            //    { "Fred", "Wilma", "Pedrita"}, 
            //    { "Homer", "Marge", "Lisa", "Bart", "Maggie" }, // Não é possível declarar um jagged array assim
            //    { "Florinda", "Kiko" }
            //};

            familiasArray[0] = new string[] { "Fred", "Wilma", "Pedrita" }; // Na linha 0, os elementos serão...
            familiasArray[1] = new string[] { "Homer", "Marge", "Lisa", "Bart", "Maggie" }; 
            familiasArray[2] = new string[] { "Florinda", "Kiko" };

            Console.WriteLine("---Imprimindo as famílias---\n");


            foreach (var familia in familiasArray)
            {
                Console.WriteLine(string.Join(",", familia));
            }
            Console.WriteLine();

            Console.ReadLine();

            /// Consultando coleções
            Console.WriteLine("Consultando coleções:\n");

            Console.WriteLine("Problema a resolver: Obter os nomes dos meses do ano que tem 31 dias, em maiúsculo e em ordem alfabética.\n");

            List<Mes> meses = new List<Mes>
            {
                new Mes("Janeiro", 31),
                new Mes("Fevereiro", 28),
                new Mes("Março", 31),
                new Mes("Abril", 30),
                new Mes("Maio", 31),
                new Mes("Junho", 30),
                new Mes("Julho", 31),
                new Mes("Agosto", 31),
                new Mes("Setembro", 30),
                new Mes("Outubro", 31),
                new Mes("Novembro", 30),
                new Mes("Dezembro", 31)
            };

            Console.WriteLine("Fazendo no braço:\n");

            meses.Sort();

            foreach (var mes in meses)
            {
                if (mes.Dias == 31)
                {
                    Console.WriteLine(mes.Nome.ToUpper());
                }
            }
            Console.WriteLine();

            Console.WriteLine("Usando LINQ:\n");

            Console.WriteLine("LINQ é a consulta integrada à linguagem, permitindo utilizar expressões lambda com diversas ferramentas (como Where, Count, OrderBy, etc) para fazer consultas.\n");

            // Montagem da consulta:
            IEnumerable<string> consulta = meses // Necessário "Mês" para "string" no tipo, pois o Select será utilizado
                                        .Where(m => (m.Dias == 31)) // Where retorna um INumberable<T> com os elementos que cumprem a exigência da operação lambda
                                        .OrderBy(m => (m.Nome)) // OrderBy ordena com base no parâmetro informado
                                        .Select(m => (m.Nome.ToUpper())); // Select modifica alguma informação da coleção original

            // Utilização da consulta:
            foreach (var mes in consulta)
            {
                Console.WriteLine(mes);
            }
            Console.WriteLine();

            Console.ReadLine();

            /// Outros operadores LINQ
            Console.WriteLine("Outros operadores LINQ:\n");

            Console.ReadLine();
        }
    }

    class Mes : IComparable
    {
        public string Nome { get; private set; }
        public int Dias { get; private set; }

        public override string ToString()
        {
            return $"Mês: {Nome}, Dias: {Dias}";
        }

        public int CompareTo(object? obj)
        {
            Mes outro = obj as Mes;

            return this.Nome.CompareTo(outro.Nome);
        }

        public Mes(string nome, int dias)
        {
            Nome = nome;
            Dias = dias;
        }
    }

    internal class ComparadorMinusculo : IComparer<string>
    {
        public int Compare(string? x, string? y)
        {
            return string.Compare(x, y, StringComparison.InvariantCultureIgnoreCase); // Utiliza o método Compare da classe String para comparar as letras maiúsculas e minúsculas e retornar true se forem o mesmo caractere
        }
    }
}