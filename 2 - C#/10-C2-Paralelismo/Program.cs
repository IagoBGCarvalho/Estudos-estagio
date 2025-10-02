using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics; // Namespace do Stopwatch

namespace _10_C2_Paralelismo
{
    internal class Program
    {
        private static int _numeroContas = 0;
        static async Task Main(string[] args)
        {
            Console.WriteLine("Processadores com mais de um core (núcleo) podem utilizar cores diferentes para realizar atividades diferentes (como executar aplicativos diferentes). Normalmente isso é organizado pelo sistema operacional.\n");

            Console.WriteLine("Se o processador tiver apenas uma aplicação rodando por core, essas aplicações são executadas linearmente, mas caso uma outra aplicação seja aberta, o sistema operacional precisa intermediar o tempo de uso de cada aplicação. Executa uma aplicação, para, executa a outra aplicação, para, e por aí segue. Por acontecer em milésimos de segundo, não é perceptível pelo usuário.\n");

            Console.WriteLine("Quando uma aplicação tem muitas tarefas, como a de abrir várias abas em um navegador, as tarefas são divididas entre os núcleos, equilibrando o uso de CPU para cada tarefa, mantendo a constância da aplicação e permitindo ao usuário realizar diversas atividades ao mesmo tempo sem perca aparente de desempenho.\n");

            Console.WriteLine("Quando a compra de hardware novo não resolve um problema de desepempenho, geralmente é o software que não está dividindo as tarefas para diferentes núcleos, independente da existência deles no hardware. O paralelismo se trata disso, quebrar a aplicação em pedaços menores para que o uso do processador seja otimizado.\n");

            Console.WriteLine("Estruturas como o foreach que executam diversas vezes a mesma linha de código, geralmente, são o melhor lugar para aplicar o paralelismo, visto que o processo pode ser dividido em diversos núcleos.\n");

            Console.WriteLine("No entando, é necessário avaliar quando a tecnologia deve ser realmente utilizada. O custo de utilizar o paralelismo se chama 'overhead', que se trata das exigências da utilização de novas linhas de execução, como pedir para o OS alocar memória e recursos para as novas linhas, a troca de contexto do processador (o ato de pausar, salvar seu estado e carregar um estado novo), e a sincronização (a thread principal esperando as novas threads terminarem as suas atividades).\n");

            Console.WriteLine("Ou seja, o paralelismo só compensa quando o trabalho a ser feito é significativamente mais pesado e demorado do que o custo de gerenciar o paralelismo.\n");

            Console.WriteLine("Uma Thread se trata de uma linha de execução de uma aplicação. Ou seja, se a aplicação é um trem, a Thread é o trilho por onde as instruções do programa andam. Normalmente um programa apenas possui uma Thread, ou seja, faz uma operação de cada vez, mas é possível adicionar várias linhas de execução, permitindo que várias operações sejam realizadas ao mesmo tempo, acelerando o processo geral.\n");

            Console.WriteLine("As Threads compartilham, entre si, memória, variáveis e recursos.\n");

            Console.WriteLine("Aperte qualquer tecla para começar a simulação:");
            Console.ReadLine();

            var contas = Enumerable.Range(0, 1000).ToList(); // Cria uma lista contas com 10.000 itens

            Console.WriteLine("---Execução Sequencial---\n");

            var stopwatch = Stopwatch.StartNew(); // Stopwatch é uma class que possui diversos métodos para medir a performance de um código (benchmarking), é mais confiável do que o DateTime. StartNew começa a contagem
            _numeroContas = 0;

            foreach (var conta in contas)
            {
                ProcessarConta(conta);
            }

            stopwatch.Stop(); // Encerra a contagem do cronômetro

            Console.WriteLine($"Número total de contas: {_numeroContas}\n");
            MostrarTempoDecorrido(stopwatch.Elapsed); // Elapsed retorna um TimeSpan com a mensuração total do tempo percorrido

            Console.WriteLine("---Utilizando Threads---\n");

            stopwatch.Restart(); // Recomeça a contagem do stopwatch do zero

            _numeroContas = 0;

            var numeroContasPorThread = contas.Count() / 4; // Variável que define a quantidade de contas processadas por cada Thread. Como serão 4, então é a quantidade de contas dividado por 4

            var contas_parte1 = contas.Take(numeroContasPorThread); // O take está pegando a metade dos números da lista
            var contas_parte2 = contas.Skip(numeroContasPorThread).Take(numeroContasPorThread); // O skip está pegando a segunda metade dos números
            var contas_parte3 = contas.Skip(numeroContasPorThread * 2).Take(numeroContasPorThread);
            var contas_parte4 = contas.Skip(numeroContasPorThread * 3);

            Thread thread_parte1 = new Thread(() =>
            {
                // O processamento feito pela função anônima (lambda) agora é realizado em outra linha de execução, utilizando outro núcleo do processador
                foreach (var conta in contas_parte1)
                {
                    ProcessarConta(conta);
                }
            });

            Thread thread_parte2 = new Thread(() =>
            {
                // Linha de execução completamente diferente da thread_parte1
                foreach (var conta in contas_parte2)
                {
                    ProcessarConta(conta);
                }
            });

            Thread thread_parte3 = new Thread(() =>
            {
                foreach (var conta in contas_parte3)
                {
                    ProcessarConta(conta);
                }
            });

            Thread thread_parte4 = new Thread(() =>
            {
                foreach (var conta in contas_parte4)
                {
                    ProcessarConta(conta);
                }
            });

            // Com 4 threads, o tempo de execução foi diminuido em 4 vezes

            // Depois de criar as linhas de execução, é necessário chama-las:

            thread_parte1.Start(); // Começa o trabalho da thread
            thread_parte2.Start();
            thread_parte3.Start();
            thread_parte4.Start();

            // Depois de chama-las, é necessário esperar o tempo necessário para que o processamento de ambas acabem, se não a linha de execução principal irá ficar dessincronizada em relação a elas:

            thread_parte1.Join(); // A thread principal espera o processamento da thread especificada terminar
            thread_parte2.Join();
            thread_parte3.Join();
            thread_parte4.Join();

            stopwatch.Stop();

            Console.WriteLine($"Número total de contas: {_numeroContas}\n");

            MostrarTempoDecorrido(stopwatch.Elapsed);

            Console.WriteLine("---Utilizando Tasks---\n");

            Console.WriteLine("Como visto, utilizar Threads é muito eficiente para ganho de desempenho, mas exige um trabalho de manuntenção constante, visto que é necessário criar variáveis para separar as coleções, criar as Threads com lambda, dar start, join, etc...\n");

            Console.WriteLine("Para diminuir esse trabalho, é interessante utilizar um Gestor de Tarefas (tasks). O gestor recebe as tarefas e tem uma quantidade de 'funcionários' (que são Threads) que o auxiliam a manter tudo funcionando sem a necessidade de alterações.\n");

            Console.WriteLine("Aperte qualquer tecla para continuar:");
            Console.ReadLine();

            stopwatch.Restart();
            _numeroContas = 0;

            // A divisão do trabalho nesta abordagem ainda é manual, então seguirei utilizando as variáveis contas_parte1, contas_parte2...

            Task tarefa1 = Task.Factory.StartNew(() => // Factory se trata de uma propriedade Get da classe Task que permite utilizar métodos de criação e configuração de Tasks. StartNew pega uma Thread do ThreadPool e já a inicia com a tarefa, sem a necessidade do Start().
            {
                foreach (var conta in contas_parte1) ProcessarConta(conta);
            });

            Task tarefa2 = Task.Factory.StartNew(() =>
            {
                foreach (var conta in contas_parte2) ProcessarConta(conta);
            });

            Task tarefa3 = Task.Factory.StartNew(() =>
            {
                foreach (var conta in contas_parte3) ProcessarConta(conta);
            });

            Task tarefa4 = Task.Factory.StartNew(() =>
            {
                foreach (var conta in contas_parte4) ProcessarConta(conta);
            });

            Task.WaitAll(tarefa1, tarefa2, tarefa3, tarefa4); // Espera as tarefas terminarem para que a linha principal de execução continue

            stopwatch.Stop();
            Console.WriteLine($"Número total de contas: {_numeroContas}\n");
            MostrarTempoDecorrido(stopwatch.Elapsed);

            Console.WriteLine("---Utilizando Parallel.ForEach---\n");

            Console.WriteLine("Utilizar Tasks já é uma grande melhoria, as Threads já são automaticamente instanciadas e iniciadas, mas ainda é necessário dividir a lista, criar tarefas, esperar as tarefas terminarem etc...\n");

            Console.WriteLine("Subindo mais um nível na abstração do paralelismo, está o Parallel.ForEach, que se trata de um loop foreach sequencial trasnformado em um loop paralelo otimizado. Ele faz todo o trabalho manual necessário automaticamente, analisa a coleção fornecida, analisa o hardware para identificar quantos núcleos a CPU tem e faz todo o gerenciamento das Tasks automaticamente. 20 linhas de código se tornam 3.\n");

            Console.WriteLine("Aperte qualquer tecla para continuar:");
            Console.ReadLine();

            stopwatch.Restart();
            _numeroContas = 0;

            Parallel.ForEach(contas, (conta) =>
            {
                ProcessarConta(conta); // Olhou para a lista contas, olhou para o processador e viu quantas Threads pode usar de forma eficiente, dividiu a lista em partes de forma otimizada (melhor do que a divisão manual), distribui essas partes para as Threads e esperou todas terminarem para passar para próxima linha.
            });

            stopwatch.Stop();
            Console.WriteLine($"Número total de contas: {_numeroContas}\n");
            MostrarTempoDecorrido(stopwatch.Elapsed);

            Console.WriteLine("---Utilizando async/await---\n");

            Console.WriteLine("Relembrando, o Paralelismo se trata da utilização de vários núcleos de CPU ao mesmo tempo para terminar um trabalho pesado mais rápido. Analogia: Vários conzinheiros (Threads) cortando vegetais ao mesmo tempo para entregar um prato mais rapidamente. Agora será implementada a Assincronia.\n");

            Console.WriteLine("Assincronia se trata da habilidade de uma Thread iniciar uma operação demorada (que envolve espera) e, ao invés de ficar parada, é liberada para fazer outras coisas. Analogia: Um cozinheiro que precisa fazer uma sopa que na receita pede para ferver a água por 10 minutos. Ao invés de ficar parado esperando o tempo da água ferver, ele coloca um timer (await) e vai cortar os vegetais. Quando o timer apita, ele volta para a água.\n");

            Console.WriteLine("async/await é ideal para operações input/output, como: resposta de uma API, consulta no banco de dados, leitura de um arquivo grande no disco, etc. Em apps de UI, isso impede que a tela congele. Em servidores, permite atender a milhares de requisições simultaneamente.\n");

            Console.WriteLine("Para utilizar a palavra chave 'await' na Main, é necessário marcá-la como async e mudar o retorno para Task.\n");

            Console.WriteLine("Aperte qualquer tecla para continuar:");
            Console.ReadLine();

            stopwatch.Restart();
            _numeroContas = 0;

            var tarefas = contas.Select(conta => ProcessarContaAsync(conta)); // Transforma cada item da coleção em uma Task utilizando o método Async

            // Por se tratar de um método assíncrono, ao final do Select, não se tem a transformação em si, mas a PROMESSA de cada uma (await). O preparo foi iniciado e está sendo executado em segundo plano.

            await Task.WhenAll(tarefas); // Cria uma única Task que só termina quando todas as outras acabarem
            // O 'await' pausa o método Main, mas de forma não-bloqueante, e só continua quando todas as tarefas terminarem.

            stopwatch.Stop();
            Console.WriteLine($"Número total de contas: {_numeroContas}\n");
            MostrarTempoDecorrido(stopwatch.Elapsed);

            Console.WriteLine("A diferença absurda de tempo entre o uso Parallel.ForEach e do async/await acontece por causa da natureza do assincronia. Ao invés da Thread se deparar com uma atividade de processamento e ficar 100% ocupado com ela, ela liga o timer que indica quando o processamento vai acabar (await), se declara livre e já inicia a próxima atividade. Ou seja, em poucos milisegundos, todas as atividades já foram ao menos iniciadas, mesmo que não tenham terminado. O 'await Task.WhenAll(tarefas)' simplesmente aguarda todas os timers acabarem para continuar o fluxo da Main.\n");

            Console.WriteLine("A diferença de performance não foi o async/await sendo magicamente mais rápido para trabalho de CPU, mas a diferença entre simular um trabalho bloqueante (CPU) e um não bloqueante (I/O). Ou seja, o Parallel.ForEach deve ser utilizado para CPU-Bound (trabalos de cpu envolvendo cálculos, processamento de imagens, etc.) e quando se quer usar todos os núcleos para terminar mais rápido, enquanto o async/await em trabalhos que envolvem espera obrigatória, como espera por rede, disco, banco de dados, etc...\n");

            Console.WriteLine("!!!FIM DA SIMULAÇÃO!!!\n");

            Console.ReadLine();
        }
        static void ProcessarConta(int numeroConta)
        {
            Thread.Sleep(1); // Simulando um trabalho "pesado" de 1 milisegundo por conta

            // numeroContas++; Pode causar race condition!!
            Interlocked.Increment(ref _numeroContas); // Interlocked é uma classe que possui operações atômicas (indivisível), impedindo a race condition
        }
        static async Task ProcessarContaAsync(int numeroConta) // É necessário assinalar funções assíncronas como async e especificar o retorno como uma Task
        {
            // Quando um método é marcado como 'async Task', ele começa a executar e retorna uma Task<T> imediatamente quando encontra o primeiro await de uma operação não concluída. Ou seja, ele retorna a promessa e executa o processamento em segundo plano até conseguir terminar a tarefa.

            // Fluxo da função:

            // 1 - O select pega o primeiro int da lista contas (0)
            // 2 - Chama o método ProcessarContaAsync
            // 3 - Entra no método
            // 4 - Chega na linha 'await Task.Delay(1)'
            // 5 - O Task.Delay inicia um timer de 1ms simulando um processamento extremo
            // 6 - O await faz duas coisas: Agenda o restante do método (no caso, o Interlocked) para ser executado como continuação quando o Delay acabar e retorna IMEDIATAMENTE o controle para quem o chamou (o select), entregando um objeto Task que representa toda a operação que está em andamento.
            // 7 - O select, em posse do primeiro objeto Task, o adiciona à coleção de resultados (tarefas)
            // 8 - O select, sem bloqueio, passa para o próximo item da lista (1) e repete todo o processo novamente
            // 9 - A variável tarefas se torna um array de Tasks, onde cada task representa uma operação ProcessarContaAsync, que está cozinhando em segundo plano.
            // 10 - Por fim, a linha 'await Task.WhenAll(tarefas)' aguarda todos os processamentos terminarem e segue o fluxo da Main

            await Task.Delay(1); // Ao invés de botar a Thread principal para dormir (bloqueada) o await libera ela para fazer outras coisas
            Interlocked.Increment(ref _numeroContas);
        }
        static void MostrarTempoDecorrido(TimeSpan tempo)
        {
            Console.WriteLine($"Tempo decorrido: {tempo.TotalMilliseconds} milisegundos.\n");
        }
    }   
}