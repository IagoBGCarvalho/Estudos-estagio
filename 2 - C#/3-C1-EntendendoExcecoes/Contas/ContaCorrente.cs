using _3_C1_EntendendoExcecoes.Titular;
using _3_C1_EntendendoExcecoes.Excecoes;

namespace _3_C1_EntendendoExcecoes.Contas
{
    public class ContaCorrente
    {
        /// Classe que representa uma conta corrente do banco Bytebank.
        // Atributos:
        public Cliente Titular { get; set; } = new();

        public static int TotalDeContasCriadas { get; private set; } // O private set está impedindo que alguém sem acesso a classe altere o valor do contador.

        private int _agencia;

        public int Numero { get; set; }

        private double _saldo = 100;

        public static float TaxaOperacao { get; private set; }

        // Getters e Setters com lógica adicional:
        public double Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                {
                    return;
                }

                _saldo = value;
            }
        }

        public int Agencia
        {
            get
            {
                return _agencia;
            }
            set
            {
                if (value <= 0)
                {
                    return;
                }

                _agencia = value;
            }
        }

        // Métodos:
        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                throw new SaldoInsuficienteException("Saldo insuficiente para a operação.");
            }

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Transferir(double valor, ContaCorrente contaDestino)
        {
            if (_saldo < valor)
            {
                return false;
            }

            _saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }

        // Construtor da classe:
        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero; // "tipo.Parse" faz o casting de uma string para o tipo especificado

            // Ao lidar com uma exceção em uma função, é interessante implementar um if com uma condição de parada utilizando o throw new exception para lançar uma mensagem e parar a função e um try e catch para capturar os erros e implementar uma lógica adicional para evitar a parada do código.
            
            if (agencia <= 0)
            {
                throw new ArgumentException("Número de agência menor ou igual a 0!", nameof(agencia)); // Lança o objeto de exceção e para a criação do objeto caso a exceção não seja tratada, podendo receber uma mensagem de exceção customizada e o parâmetro que ocasiono a exceção. O "ArgumentException" é uma classe usada quando o erro é causado por um argumento ou parâmetro inválido.
            }

            // Para evitar a parada abrupta do programa, é utilizado try e catch para capturar erros previsíveis, no caso, o cálculo da taxa de operação utilizar o número 0 como dividendo
            try
            {
                // "Tente executar o código que está aqui dentro, mas fique atento, pois exceção pode acontecer"
                TaxaOperacao = 30 / TotalDeContasCriadas;
            }
            catch (DivideByZeroException)
            {
                // Apenas acontece caso uma exceção no try tenha acontecido. No caso, apenas captura exceções de um tipo específico
                Console.WriteLine("Ocorreu um erro! Não é possível fazer uma divisão por zero");
            }

            TotalDeContasCriadas++; // Executa um incremento no contador de contas criadas toda vez que um objeto é instanciado
        }
    }
}