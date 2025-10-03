namespace _11_C2_TrabalhandoComArquivos.Conta
{
    public class ContaCorrente : IComparable<ContaCorrente> // Interface que permite comparar elementos dessa classe (ContaCorrente)
    {
        /// Classe que representa uma conta corrente do banco Bytebank.
        // Atributos e propriedades:
        public Cliente Titular { get; set; } = new();

        public static int TotalDeContasCriadas { get; private set; }

        private int _agencia;

        public string _conta;

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

        public string Conta
        {
            get
            {
                return _conta;
            }
            set
            {
                if (value != null)
                {
                    _conta = value;
                }
            }
        }

        // Métodos:
        public bool Sacar(double valor)
        {
            if (_saldo < valor)
            {
                throw new Exception("Saldo insuficiente para a operação.");
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

        public int CompareTo(ContaCorrente? other)
        {
            // CompareTo é o método presente no "contrato" da interface Icomparable. Se o this for antes, retorna -1, se forem iguais, retorna 0, e se o other vier antes, retorna 1.
            if (other == null)
            {
                return 1;
            }
            else
            {
                return this.Agencia.CompareTo(other.Agencia);
            }

        }

        public override string ToString()
        {
            // Retorna os dados da própria conta
            return $"===    Dados da conta    ===\n"+
                   $"Número da conta: {this.Conta}\n" +
                   $"Saldo da conta: {this.Saldo}\n" +
                   $"Titular da conta: {this.Titular.Nome}\n" +
                   $"CPF do titular: {this.Titular.CPF}\n" +
                   $"Profissão do titular: {this.Titular.Profissao}\n" +
                   $"============================";
        }

        // Construtores da classe:
        public ContaCorrente(int agencia, string conta)
        {
            Agencia = agencia;
            Conta = conta;
            Titular = new Cliente();
            
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
                //Console.WriteLine("Ocorreu um erro! Não é possível fazer uma divisão por zero");
            }

            TotalDeContasCriadas++;
        }
        public ContaCorrente(int agencia)
        {
            Agencia = agencia;
            Conta = Guid.NewGuid().ToString().Substring(0, 8); // Gera uma string aleatória de até 8 caracteres
            Titular = new Cliente();

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
                //Console.WriteLine("Ocorreu um erro! Não é possível fazer uma divisão por zero");
            }

            TotalDeContasCriadas++;
        }
    }
}