internal class Program
{
    static void Main(string[] args)
    {
        int numero_elementos = 0;
        int numero = 0;
        int numero_busca = 0;
        int numeros_encontrados = 0;

        List<int> lista_int = new List<int>();

        Console.WriteLine("Digite o número de elementos da lista: ");
        numero_elementos = Convert.ToInt32(Console.ReadLine());

        for (int i = 0; i < numero_elementos; i++)
        {
            Console.WriteLine($"Digite o número a ser digitado no índice {i}: ");
            numero = Convert.ToInt32(Console.ReadLine());
            lista_int.Add(numero);
        }

        Console.WriteLine(" ");

        Console.WriteLine("Digite o número que se quer pesquisar na lista: ");
        numero_busca = Convert.ToInt32(Console.ReadLine());

        // Busca do jeito antigo: 
        foreach (var item in lista_int)
        {
            if (item == numero_busca)
            {
                numeros_encontrados++;
            }
        }

        if (numeros_encontrados == 1)
        {
            Console.WriteLine($"Encontrei 1 número igual!\n");
        }
        else if (numeros_encontrados > 1)
        {
            Console.WriteLine($"Encontrei {numeros_encontrados} números iguais!\n");
        }
        else
        {
            Console.WriteLine("Nenhum número foi encontrado.\n");
        }

        Console.WriteLine("Busca utilizando lambda: \n");

        Console.WriteLine("Digite o número que se quer pesquisar na lista: ");
        numero_busca = Convert.ToInt32(Console.ReadLine());
        // Busca utilizando lambda:
        
        // lambda é uma forma curta de escrever uma função anônima, ou seja, uma função que faz uma única tarefa, uma única vez.
        // Sintaxe: variavel = coleção.Método(parametro => condição);
        // Ou: (parametro) => {condição};
        // A lambda é universal, funciona com qualquer tipo de dado.
        // O LINQ - Language-Integrated Query (Consulta Integrada à Linguagem) possui diversos métodos que operam em coleçoes e que fazem diferentes coisas utilizando expressões lambda, como:
        // .Where: Filtra uma coleçao "List, Array etc..." e retorna uma nova lista contendo apenas os items que satisfazem a condição
        // .Count: Faz uma contagem dos itens que satisfazem a condição
        // .Select: Transforma cada elemento de uma coleção em um novo formulário
        var resultado_pesquisa = lista_int.Count(i => i == numero_busca); // Pegue um item i da lista e verifique se ele é igual ao número buscado, caso faz, adicione 1 a contagem

        if (resultado_pesquisa == 1)
        {
            Console.WriteLine($"Lambda: Encontrei 1 número igual!\n");
        }
        else if (resultado_pesquisa > 1)
        {
            Console.WriteLine($"Lambda: Encontrei {resultado_pesquisa} números iguais!\n");
        }
        else
        {
            Console.WriteLine("Lambda: Nenhum número foi encontrado.\n");
        }

        Console.WriteLine("Números da lista:");

        for (int i = 0; i < numero_elementos; i++)
        {
            Console.WriteLine(lista_int[i]);
        }
    }
}