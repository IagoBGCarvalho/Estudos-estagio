namespace _8_C2_ListasListasLigadasDicionariosEConjuntos
{
    public class Navegador
    {
        private readonly Stack<string> historicoAnterior = new Stack<string>(); // Pilha que armazena o histórico de páginas acessadas enteriormente
        private readonly Stack<string> historicoProximo = new Stack<string>(); // Pilha que armazena o histórico de páginas acessadas posteriormente
        private string atual = "vazia";
        
        public void NavegarPara(string url)
        {
            historicoAnterior.Push(atual); // Push adiciona um elemento na pilha. Funciona como uma pilha de pratos, o último elemento a ser adicionado sempre será em cima do penúltimo
            atual = url;
            Console.WriteLine($"Navegou para a página: {atual}");
        }

        internal void Anterior()
        {
            if (historicoAnterior.Any())
            {
                // Se tiver algum elemento na pilha, é possível retornar a ele
                historicoProximo.Push(atual); // Guarda a página atual no históricoPróximo para que seja possível retornar a ela novamente
                atual = historicoAnterior.Pop(); // Pega o próximo elemento de uma pilha (a página acessada anteriormente)
                Console.WriteLine($"Retornou a página: {atual}");
            }
        }

        internal void Proximo()
        {
            if (historicoProximo.Any())
            {
                historicoAnterior.Push(atual);
                atual = historicoProximo.Pop();
                Console.WriteLine($"Retornou novamente a página: {atual}");
            }
        }

        public Navegador()
        {
            Console.WriteLine($"Página atual: {atual}");
        }
    }
}