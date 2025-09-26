using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _8_C2_ListasListasLigadasDicionariosEConjuntos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /// Arrays: 

            // Um array se trata da coleção mais primitiva de todas, deve ser declarado informando o número de espaços a serem alocados, armazena elementos em índices e todos os elementos devem possui o mesmo tipo
            Console.WriteLine("Arrays:\n");
            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a classe Aula";
            string aulaSets = "Trabalhando com Conjuntos";

            // Caso saiba os elementos previamente:
            string[] aulasArray = new string[]
            {
                aulaIntro, aulaModelando, aulaSets
            };

            // Caso apenas se saiba o número de elementos:
            string[] aulasArray2 = new string[3];

            // Para adicionar itens:
            aulasArray2[0] = aulaIntro;
            aulasArray2[1] = aulaModelando;
            aulasArray2[2] = aulaSets;

            // Imprimindo o primeiro e o último elemento do array:
            Console.WriteLine("---Primeiro elemento do array---");
            Console.WriteLine($"[{aulasArray2[0]}]\n");

            Console.WriteLine("---Último elemento do array---");
            Console.WriteLine($"[{aulasArray2[aulasArray2.Length - 1]}]\n"); // Tamanho total do array - 1 = última posição

            Console.WriteLine("---Imprimindo um array---\n");
            ImprimirArray(aulasArray2);

            // Trocando elementos do array: 

            aulaIntro = "Trabalhando com arrays"; // Não vai funcionar pois o array recebe uma cópia dos valores das variáveis, não elas em si

            aulasArray2[0] = "Trabalhando com arrays"; // É necessário acessar o elemento e alterá-lo

            Console.WriteLine("---Trocando elementos do array---\n");

            ImprimirArray(aulasArray2);

            // Procurando itens em um array: 

            Console.WriteLine("---Procurando itens em um array---\n");

            Console.WriteLine("A aula modelando está no índice " + Array.IndexOf(aulasArray2, aulaModelando)); // É possível utilizar a classe Array para usar o método "IndexOf" que retorna o índice do que se espera buscar. Recebe o array alvo da busca e uma variável com o valor do que se quer buscar.
            Console.WriteLine("A última instância da aula modelando está no índice " + Array.LastIndexOf(aulasArray2, aulaModelando) + "\n");

            // Trocando a ordem dos elementos

            Console.WriteLine("---Trocando a ordem dos elementos---\n");
            Array.Reverse(aulasArray2); // Inverte a ordem dos elementos no array
            ImprimirArray(aulasArray2);

            // Alterando o tamanho do array:

            Console.WriteLine("---Reduzindo o tamanho do array---\n");
            Array.Resize(ref aulasArray2, 2); // Tamanho alterado de 3 para 2
            ImprimirArray(aulasArray2);

            Console.WriteLine("---Aumentando o tamanho do array:---\n");
            Array.Resize(ref aulasArray2, 3); // Tamanho alterado de 2 para 3
            aulasArray2[aulasArray2.Length - 1] = "Trabalhando com arrays";
            ImprimirArray(aulasArray2);

            // Ordenando o array:

            Console.WriteLine("---Ordenando o array---\n");
            Array.Sort(aulasArray2); // Uma vez utilizado, não é possível desfazer o método sort
            ImprimirArray(aulasArray2);

            // Copiando o array:

            Console.WriteLine("---Copiando o array---\n");

            string[] copiaArray = new string[2];

            Array.Copy(aulasArray2, 1, copiaArray, 0, 2); // Sintaxe do Copy: (array_a_ser_copiado, índice_inicial, array_destino, índice_inicial, numero_de_elementos_a_serem_copiados);
            ImprimirArray(copiaArray);

            // Clonando o array:

            Console.WriteLine("---Clonando o array---\n");
            string[] cloneArray = aulasArray2.Clone() as string[]; // É necessário fazer o casting de aulasArray2 que é um objeto para um array de strings
            ImprimirArray(cloneArray);

            // Limpando o array:

            Console.WriteLine("---Limpando o array---\n");
            Array.Clear(cloneArray, 1, 2); // Recebe como parâmetro o array, o elemento em que se vai começar e a quantidade de elementos a serem limpados
            ImprimirArray(cloneArray);

            Console.ReadLine();

            /// Listas:

            // Uma lista se trata de um Array dinâmico, pois armazena items conforme for solicitado, diferente do Array, onde é necessário especificar a quantidade de espaços na memória.

            // Ao invés de usar métodos estáticos (como os da classe Array) utiliza-se diretamente do objeto

            //List<string> aulas = new List<string>() // List<tipo> nome_variavel = new List<tipo>();
            //{
            //    aulaIntro, aulaModelando, aulaSets // É possível adicionar itens já na declaração da lista
            //};

            Console.WriteLine("Listas:\n");

            List<string> aulasLista = new List<string>();
            aulasLista.Add(aulaIntro);
            aulasLista.Add(aulaModelando);
            aulasLista.Add(aulaSets);

            // Imprimindo o primeiro e o último elemento da lista: 

            Console.WriteLine("---Imprimindo o primeiro e o último elemento da lista---\n");

            Console.WriteLine("A primeira aula é: " + aulasLista.First()); // Faz a mesma coisa que a linha anterior

            Console.WriteLine("A última aula é: " + aulasLista.Last() + "\n"); // Faz a mesma coisa que a linha anterior

            // Imprimindo a lista:

            Console.WriteLine("---Imprimindo uma lista---\n");
            ImprimirLista(aulasLista);

            // Trocando um elemento da lista:

            Console.WriteLine("---Trocando um elemento da lista---\n");

            aulasLista[0] = "Trabalhando com Listas";
            ImprimirLista(aulasLista);

            // Procurando um elemento em uma lista

            Console.WriteLine("---Procurando um elemento da lista---\n");

            Console.WriteLine("A primeira aula 'Trabalhando' é: " + aulasLista.FirstOrDefault(aula => aula.Contains("Trabalhando"))); // Utilizando uma expressão lambda para retornar a primeira instância da aula que contém a palavra "Trabalhando"

            Console.WriteLine("A última aula 'Trabalhando' é: " + aulasLista.LastOrDefault(aula => aula.Contains("Trabalhando")));
            Console.WriteLine("\n");

            Console.WriteLine("---Revertendo os elementos da lista---\n");

            aulasLista.Reverse();
            ImprimirLista(aulasLista);
            aulasLista.Reverse();

            Console.WriteLine("---Removendo um elemento da lista---\n");

            aulasLista.RemoveAt(aulasLista.Count - 1);
            ImprimirLista(aulasLista);

            Console.WriteLine("---Adicionando elementos na lista---\n");

            aulasLista.Add("Conclusão");
            ImprimirLista(aulasLista);

            Console.WriteLine("---Ordenando elementos na lista---\n");

            aulasLista.Sort();
            ImprimirLista(aulasLista);

            Console.WriteLine("---Copiando uma lista---\n");

            List<string> copiaLista = aulasLista.GetRange(aulasLista.Count - 2, 2); // Cria uma cópia de uma lista, recebe como parâmetros o índice e o número de elementos a serem copiados
            ImprimirLista(copiaLista);

            Console.WriteLine("---Clonando uma lista---\n");

            List<string> cloneLista = new List<string>(aulasLista); // A partir da sobrecarga do construtor do List, é possível utilizar uma lista como parâmetro para um gerar uma outra lista igual a ela
            ImprimirLista(cloneLista);

            Console.ReadLine();

            /// Listas de objetos

            Console.WriteLine("Listas de objetos:\n");

            var aulaIntro2 = new Aula("Introdução às Coleções", 20);
            var aulaModelando2 = new Aula("Modelando a classe aula", 18);
            var aulaSets2 = new Aula("Trabalhando com conjuntos", 16);

            List<Aula> aulasListaObjetos = new List<Aula>(); // Cria uma lista de objetos do tipo Aula

            aulasListaObjetos.Add(aulaIntro2);
            aulasListaObjetos.Add(aulaModelando2);
            aulasListaObjetos.Add(aulaSets2);

            Console.WriteLine("---Imprimindo uma lista de objetos---\n");

            ImprimirListaObjetos(aulasListaObjetos);

            Console.WriteLine("---Ordenando uma lista de objetos---\n");

            aulasListaObjetos.Sort();
            ImprimirListaObjetos(aulasListaObjetos);

            aulasListaObjetos.Sort((este, outro) => este.Tempo.CompareTo(outro.Tempo)); // Ordenando pelo tempo
            ImprimirListaObjetos(aulasListaObjetos);

            Console.ReadLine();

            /// Lista somente leitura
            Console.WriteLine("Lista somente leitura:\n");

            Curso csharpColecoes = new Curso("C# Collectins", "Marcelo Oliveira");

            Console.WriteLine("---Adicionando itens na lista somente leitura---\n");

            csharpColecoes.Adiciona(new Aula("Trabalhando com Listas", 21)); // A lista readonly apenas pode ser alterada utilizando um método encapsulado da classe Curso, mantendo a segurança do código
            csharpColecoes.Adiciona(new Aula("Criando uma aula", 20));
            csharpColecoes.Adiciona(new Aula("Modelando com Coleções", 24));

            ImprimirListaReadOnly(csharpColecoes.Aulas);

            Console.WriteLine("---Ordenando a lista somente leitura---\n");

            //csharpColecoes.Aulas.Sort(); Como IList não possui uma especificação para o sort, é necessário copiar a lista para outra lista (que não seja readonly) e usar o sort nela

            List<Aula> aulasCopiadas = new List<Aula>(csharpColecoes.Aulas);

            aulasCopiadas.Sort();

            ImprimirListaReadOnly(aulasCopiadas);

            Console.WriteLine("---Totalizando o tempo do curso---\n");

            // Como cada aula tem uma duração, é possível fazer um somatório deste tempo para calcular o tempo total do curso
            Console.WriteLine($"Tempo total do curso em minutos: {csharpColecoes.TempoTotal}"); // Propriedade calculada e encapsulada pela classe Curso

            Console.WriteLine("---Imprimindo detalhes do curso---\n");

            Console.WriteLine(csharpColecoes); // Retorna o ToString reescrito com override

            Console.ReadLine();

            /// Conjuntos (sets)
            Console.WriteLine("Conjuntos (sets):\n");

            // Propriedades dos conjuntos:

            // 1 - Não permite duplicidade (1 elemento contido 2 vezes no mesmo conjunto)
            // 2 - Os elementos não são mantidos em uma ordem específica

            // Vantagens:

            // A principal vantagem de utilizar conjuntos é a maior velocidade para realizar alguns algoritmos, como a busca, por exemplo.
            // A sua escalabilidade permite tratar grandes amontes de elementos com maior performance

            // Desvantagens:

            // Por utilizar uma tabela de espalhamento, acaba consumindo mais memória

            // Declaração do conjunto alunos:
            ISet<string> alunos = new HashSet<string>();

            // Adicionando elementos no conjunto:
            alunos.Add("Vanessa Tonini");
            alunos.Add("Ana Losnak");
            alunos.Add("Rafael Nercessian");

            Console.WriteLine("---Imprimindo um conjunto---\n");

            Console.WriteLine(string.Join(",", alunos) + "\n");

            // Adicionando mais elementos:
            alunos.Add("Priscila Stuani");
            alunos.Add("Rollo Rollo");
            alunos.Add("Fabio Gushiken");

            Console.WriteLine(string.Join(",", alunos) + "\n");

            Console.WriteLine("---Removendo um elemento---\n");

            alunos.Remove("Ana Losnak");
            alunos.Add("Marcelo Oliveira");

            // Diferente de uma lista, um conjunto não implica saber exatamente onde cada elemento vai estar

            Console.WriteLine(string.Join(",", alunos) + "\n");

            Console.WriteLine("---Checando a duplicidade---\n");

            alunos.Add("Fabio Gushiken"); // Este elemento já existe no conjunto, então nada irá acontecer além de o conjunto manter uma instância do Fabio

            Console.WriteLine(string.Join(",", alunos) + "\n");

            Console.WriteLine("---Ordenando um conjunto---\n");

            // Como o ISet não possui uma definição para sort, é necessário fazer uma cópia do conjunto para uma lista

            List<string> alunosEmLista = new List<string>(alunos); // Criando uma lista que recebe o conjunto no construtor

            alunosEmLista.Sort();

            Console.WriteLine(string.Join(",", alunosEmLista) + "\n");

            Console.WriteLine("---Adicionando alunos no curso---\n");

            // Aulas já foram adicionadas na linha 224

            // Instanciando alunos com suas matrículas:
            Aluno a1 = new Aluno("Vanessa Tonini", 34672);
            Aluno a2 = new Aluno("Ana Losnak", 5617);
            Aluno a3 = new Aluno("Rafael Nercessian", 17645);

            csharpColecoes.Matricula(a1);
            csharpColecoes.Matricula(a2);
            csharpColecoes.Matricula(a3);

            foreach (var aluno in csharpColecoes.Alunos)
            {
                Console.WriteLine(aluno);
            }
            Console.WriteLine("\n");

            Console.WriteLine("---Verificando se um aluno está matriculado no curso---\n");

            Console.WriteLine($"O aluno a1 {a1.Nome} está matriculado?" + " " + csharpColecoes.EstaMatriculado(a1));

            Console.WriteLine("---Comparando alunos---\n");

            Aluno tonini = new Aluno("Vanessa Tonini", 34672);

            Console.WriteLine("a1 é equals a Tonini?" + " " + a1.Equals(tonini));

            Console.ReadLine();

            /// Dicionários:
            Console.WriteLine("Dicionários:\n");

            Console.WriteLine("---Procurando alunos em um dicionário---\n");

            Console.WriteLine("Quem é o aluno com matrícula 5617?\n");

            Console.WriteLine("Utilizando lista e for: ");

            Aluno aluno5617 = csharpColecoes.BuscaMatriculado(5617);

            Console.WriteLine(aluno5617); // Essa busca usando for funciona, mas não é eficiente, pois precisa de muito processamento.
            Console.WriteLine("\n");

            // Um dicionário permite associar uma chave (no caso, o campo matrícula), a um valor (5617), tornando a busca mais rápida

            Console.WriteLine("Utilizando dicionário:");

            Aluno aluno5617Dicionario = csharpColecoes.BuscaMatriculadoDicionario(5617);

            Console.WriteLine(aluno5617Dicionario);

            // Exceções:
            Console.WriteLine("\n");
            Console.WriteLine("Quem é o aluno com matrícula 5618?\n");
            Console.WriteLine(csharpColecoes.BuscaMatriculadoDicionario(5618) + "NULL\n");

            Aluno fabio = new Aluno("Fabio Gushiken", 5617);
            //csharpColecoes.Matricula(fabio); Isso não daria certo, visto que as chaves são únicas, não permitindo mais de um valor para a mesma chave

            Console.WriteLine("---Substituindo valores---\n");

            csharpColecoes.SubstituiAluno(fabio);

            Console.WriteLine("Quem é o aluno 5617 agora?\n");
            Console.WriteLine(csharpColecoes.BuscaMatriculadoDicionario(5617) + "\n");

            Console.ReadLine();

            /// Listas ligadas:
            Console.WriteLine("Listas ligadas:\n");

            // Imagine uma lista de frutas...
            List<string> frutas = new List<string>
            {
                "Abacate", "Banana", "Caqui", "Damasco", "Figo"
            };

            // Imprimindo:
            foreach (var fruta in frutas)
            {
                Console.WriteLine(fruta);
            }
            Console.WriteLine("\n");

            // Pelo fato de que, quanto mais elementos existirem em uma lista, mais poder computacional é necessário para fazer operações como adição e remoção, é necessárui utilizar uma LISTA LIGADA (Linked List).

            // Uma lista ligada não armazena elementos na memória em sequência, então cada elemento contém a posição do elemento anterior e a do elemento seguinte (nó), como uma lista duplamente encadeada em C.

            // A ordem dos elementos é mantida usando ponteiros, onde cada elemento tem um ponteiro que aponta para o elemento seguinte

            Console.WriteLine("---Criando uma lista ligada---\n");

            LinkedList<string> dias = new LinkedList<string>(); // Não é possível já inicializar os elementos na declaração

            Console.WriteLine("---Adicionando elementos em uma lista ligada---\n");

            var d4 = dias.AddFirst("Quarta"); // Especificamente adiciona o primeiro elemento da lista ligada, não precisando, necessariamente, ser o primeiro em relação a ordem da lista. Retorna um nó chamado "LinkedListNode"

            // Cada elemento da lista ligada é um nó, que se trata do objeto LinkedListNode<T> que possui ponteiros que apontam para o elemento anterior e para o próximo

            // Para acessar o valor:
            Console.WriteLine("d4.Value: " + d4.Value + "\n");

            // É possível adicionar valores de 4 formas:
            // 1 - Como o primeiro nó "AddFirst"
            // 2 - Como o último nó "AddLast"
            // 3 - Como o anterior a um nó conhecido "AddBefore"
            // 4 - Como o próximo de um nó conhecido "AddAfter"

            // Adicionando mais dias:
            var d2 = dias.AddBefore(d4, "Segunda"); // AddBefore recebe o item posterior e o valor. A partir disso, d2 e d4 estão ligados.
            // d2.Next é igual a d4 e d4.Previous é igual a d2

            var d3 = dias.AddAfter(d2, "Terça");

            var d6 = dias.AddAfter(d4, "Sexta");

            var d7 = dias.AddAfter(d6, "Sábado");

            var d5 = dias.AddBefore(d6, "Quinta");

            var d1 = dias.AddBefore(d2, "Domingo");

            Console.WriteLine("---Imprimindo uma lista ligada---\n");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
            Console.WriteLine("\n");

            Console.WriteLine("---Fazendo uma busca em uma lista ligada---\n");

            var quarta = dias.Find("Quarta");  // A Linked List é eficiente na adição e remoção de itens, mas ineficiente na busca
            Console.WriteLine(quarta.Value + "\n");

            Console.WriteLine("---Removendo itens da lista ligada---\n");

            // Para remover um elemento da lista igada, pode-se utilizar o nome do nó ou a referência dele.

            // dias.Remove("quarta") ou dias.Remove(d4);

            dias.Remove("Quarta");

            foreach (var dia in dias)
            {
                Console.WriteLine(dia);
            }
            Console.WriteLine("\n");

            Console.ReadLine();

            /// Pilha:
            Console.WriteLine("Pilha:\n");

            // Miniprojeto que se trata da simulação da ferramenta de "voltar" do navegador, permitindo retornar a páginas já visitadas 

            var navegador = new Navegador();

            navegador.NavegarPara("google.com");
            navegador.NavegarPara("caelum.com.br");
            navegador.NavegarPara("alura.com.br");

            navegador.Anterior();
            navegador.Anterior();
            navegador.Anterior();

            navegador.Proximo();
            navegador.Proximo();
            navegador.Proximo();

            Console.ReadLine();

            /// Fila:
            Console.WriteLine("Fila:\n");

            // Miniprojeto que se trata de uma fila de pedágio

            Queue<string> pedagio = new Queue<string>();

            Console.WriteLine("---Adcionando e imprimindo elementos na pilha---\n");

            Enfileirar(pedagio, "Van");
            Enfileirar(pedagio, "Kombi");
            Enfileirar(pedagio, "Guincho");
            Enfileirar(pedagio, "Pickup");

            Console.WriteLine("---Retirando elementos na pilha---\n");

            // Para liberar os carros:
            Desenfileirar(pedagio);
            Desenfileirar(pedagio);
            Desenfileirar(pedagio);

            Console.ReadLine();

            /// Guia de collections

            // Guia feito para indicar qual coleção é mais apropriada para cada situação.

            /// O primeiro que entra é o primeiro que sai? (Como uma fila de pedágio)

            // Então use uma fila!!!
            // Para adicionar elementos: "Enqueue()" e para remover: "Dequeue()"

            /// O último que entre é o primeiro que sai? (Como uma pilha de pratos ou a funcionalidade de "voltar" de um navegador)

            // Então use uma pilha!!!
            // Para adicionar elementos: "Push()" e para remover: "Pop()"

            /// Precisa de uma coleção flexível? (Como poder inserir elementos em qualquer posição, limpar, reverter, ordenar...)

            // Então use uma lista!!!
            // Para adicionar elementos no final: "Add()", para remover: "Remove()", para inserir em qualquer lugar: "Insert()", para limpar: "Clear()", para reverter: "Reverse()" e para ordenar: "Sort()".

            /// Uma coleção de tamanho fixo para tratar com baixo nível? (Como pixels ou bytes)
            
            // Então use um array!!!
            // Pode ser acessado pelo métodos da lista e pelo índice

            /// Precisa de uma coleção com inserção e remoção rápida?
            
            // Então use uma lista ligada!!!
            // Para inserir o primeiro item: "AddFirst()", o último: "AddLast()", antes de um item já conhecido: "AddBefore()" e depois de um item já conhecido: "AddAfter()"

            /// Precisa fazer operações com conjuntos? (Como saber se um elemento está contido em uma ou mais coleções)
            
            // Então use um conjunto!!!
            
            /// Precisa fazer uma busca rapidamente? (Como um cliente por seu CPF)
      
            // Então use um aidiconário! 
            // Ele armazena dados na forma do nó "[Chave]: Valor" onde é possível buscar rapidamente um valor específico a partir da sua chave
        }

        private static void Desenfileirar(Queue<string> pedagio)
        {
            if (pedagio.Any()) // Se tiver algum carro na fila...
            {
                if (pedagio.Peek() == "Guincho") // Peek() permite olhar quem é o próximo a sair da fila
                {
                    Console.WriteLine("Guincho está fazendo o pagamento.");
                }
                string veiculo = pedagio.Dequeue();
                Console.WriteLine($"{veiculo} saiu da fila.\n");

                ImprimirFila(pedagio);
            }
        }

        private static void Enfileirar(Queue<string> pedagio, string veiculo)
        {
            Console.WriteLine($"Entrou na fila: {veiculo}\n");

            pedagio.Enqueue(veiculo); // O método Enqueue "Enfileirar" adiciona um item na fila

            ImprimirFila(pedagio);
        }

        private static void ImprimirFila(Queue<string> pedagio)
        {
            Console.WriteLine("Fila:");

            foreach (var v in pedagio)
            {
                Console.WriteLine(v);
            }
            Console.WriteLine("\n");
        }

        private static void ImprimirArray(string[] aulas)
        {
            // Formas de imprimir um array:

            /// foreach:
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}
            //Console.WriteLine("\n");

            /// for:
            for (int i = 0; i < aulas.Length; i++) // Length é a propriedade que corresponde ao tamanho do array
            {
                Console.WriteLine(aulas[i]);
            }
            Console.WriteLine("\n");
        }

        private static void ImprimirLista(List<string> aulas)
        {
            // Formas de imprimir uma lista:

            /// foreach:
            //foreach (var aula in aulas)
            //{
            //    Console.WriteLine(aula);
            //}

            /// for:
            //for (int i = 0; i < aulas.Count; i++) // Length é a propriedade que corresponde ao tamanho do array
            //{
            //    Console.WriteLine(aulas[i]);
            //}

            /// lambda:
            aulas.ForEach(aula => {Console.WriteLine(aula);});
            Console.WriteLine("\n");
        }

        private static void ImprimirListaObjetos(List<Aula> aulasListaObjetos)
        {
            foreach (var aula in aulasListaObjetos)
            {
                Console.WriteLine(aula);
            }
            Console.WriteLine("\n");
        }

        private static void ImprimirListaReadOnly(IList<Aula> aulas)
        {
            foreach (var aula in aulas)
            {
                Console.WriteLine(aula);
            }
            Console.WriteLine("\n");
        }
    }
}