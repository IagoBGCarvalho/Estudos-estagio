using _4_C1_HerancaEInterfaces.Titular;
using _4_C1_HerancaEInterfaces.Excecoes;

namespace _4_C1_HerancaEInterfaces.Contas
{
    public class ContaCorrente
    {
        /// Classe que representa uma conta corrente do banco Bytebank.
        // Atributos e propriedades:
        public Cliente Titular { get; set; } = new();

        public static int TotalDeContasCriadas { get; private set; }

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
            Numero = numero;
            
            if (agencia <= 0)
            {
                throw new ArgumentException("Número de agência menor ou igual a 0!", nameof(agencia));
            }

            try
            {
                TaxaOperacao = 30 / TotalDeContasCriadas;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Ocorreu um erro! Não é possível fazer uma divisão por zero");
            }

            TotalDeContasCriadas++;
        }
    }
}