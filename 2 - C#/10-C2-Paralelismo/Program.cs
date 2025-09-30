using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;

namespace _10_C2_Paralelismo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Processadores com mais de um core (núcleo) podem utilizar cores diferentes para realizar atividades diferentes (como executar aplicativos diferentes). Normalmente isso é organizado pelo sistema operacional.\n");

            Console.WriteLine("Se o processador tiver apenas uma aplicação rodando por core, essas aplicações são executadas linerarmente, mas caso uma outra aplicação seja aberta, o sistemas operacional precisa intermediar o tempo de uso de cada aplicação. Executa uma aplicação, para, executa a outra aplicação, para, e por aí segue. Por acontecer em milésimos de segundo, não é perceptível pelo usuário.\n");

            Console.WriteLine("Quando uma aplicação tem muitas tarefas, como a de abrir várias abas em um navegador, as tarefas são divididas entre os núcleos, equilibrando o uso de CPU para cada tarefa, mantendo a constância da aplicação e permitindo ao usuário realizar diversas atividades ao mesmo tempo sem perca aparente de desempenho.\n");

            Console.WriteLine("Quando a compra de hardware novo não resolve um problema de desepempenho, geralmente é o software que não está dividindo as tarefas para diferentes núcleos, independente da existência deles no hardware. O paralelismo se trata disso, quebrar a aplicação em pedaços menores para que o uso do processador seja otimizado.\n");

            Console.WriteLine("Estruturas como o foreach que executam diversas vezes a mesma linha de código, geralmente, são o melhor lugar para aplicar o paralelismo, visto que o processo pode ser dividido em diversos núcleos.\n");

            Console.WriteLine("Uma Thread se trata de uma linha de execução de uma aplicação. Ou seja, se a aplicação é um trem, a Thread é o trilho por onde as instruções do programa andam. Normalmente um programa apenas possui uma Thread, ou seja, faz uma operação de cada vez, mas é possível adicionar várias linhas de execução, permitindo que várias operações sejam realizadas ao mesmo tempo, acelerando o processo geral.\n");

            Console.WriteLine("As Threads compartilham, entre si, memória, variáveis e recursos.\n");

            List<int> contas = new List<int>
            {
                1, 2, 3, 4, 5, 6, 7, 8, 9, 11, 22, 33, 44, 55, 66, 77, 88, 99, 111, 222, 333, 444, 555, 666, 777, 888, 999, 
            };

            var contas_parte1 = contas.Take(contas.Count() / 2); // O take está pegando a metade dos números da lista
            var contas_parte2 = contas.Skip(contas.Count() / 2); // O skip está pegando a segunda metade dos números

            var numeroContas = new List<int>();

            var inicio = DateTime.Now;

            foreach (var conta in contas)
            {
                numeroContas.Add(conta);
            }

            var fim = DateTime.Now;


            Console.ReadLine();
        }
    }   
}