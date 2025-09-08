using _3_C1_EntendendoExcecoes.Titular;

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
                return false;
            }

            _saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            _saldo += valor;
        }

        public bool Trasnferir(double valor, ContaCorrente contaDestino)
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
        public ContaCorrente(int agencia, string numero)
        {
            Agencia = agencia;
            Numero = int.Parse(numero); // "tipo.Parse" faz o casting de uma string para o tipo especificado
            TaxaOperacao = 30 / TotalDeContasCriadas;
            TotalDeContasCriadas++; // Executa um incremento no contador de contas criadas toda vez que um objeto é instanciado
        }
    }
}