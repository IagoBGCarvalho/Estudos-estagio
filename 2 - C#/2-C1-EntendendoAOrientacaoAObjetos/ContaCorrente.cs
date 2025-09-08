// using _2_C1_EntendendoAOrientacaoAObjetos;

namespace _2_C1_EntendendoAOrientacaoAObjetos
{
    public class ContaCorrente
    {
        /// <summary>
        /// Classe que representa uma conta corrente do banco Bytebank.
        /// </summary>
        // Atributos (características do objeto):
        public Cliente Titular { get; set; } = new(); // Como não há lógica adicional, pode-se usar a sintaxe simplificada, sem precisar definir um campo privado. O próprio compilador cria o atributo privado e os métodos de get e set implicitamente
        public static int TotalDeContasCriadas { get; private set; } // static - indica que a propriedade pertence, exclusivamente, a classe, ou seja, todos os objetos guardam a mesma informação. O private set está impedindo que alguém sem acesso a classe altere o valor do contador.
        private int _agencia; // private - só pode ser acessado dentro da própria classe
        public int Numero { get; set; }
        private double _saldo = 100;

        // Construtor da classe (define como o objeto deve ser construído):
        public ContaCorrente(int agencia, int numero)
        {
            Agencia = agencia;
            Numero = numero;
            ContaCorrente.TotalDeContasCriadas++; // Executa um incremento no contador de contas criadas toda vez que um objeto é instanciado
        }

        // Getters e Setters com lógica adicional
        public double Saldo // Propriedade que define o getter e o setter para o atributo saldo
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

                _saldo = value; // value - palavra reservada que representa o valor que está sendo atribuído
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

        // Métodos (ações que o objeto pode realizar)
        public bool Sacar(double valor)
        {
            if (this._saldo < valor) // this referencia o objeto que está executando o método
            {
                return false;
            }

            this._saldo -= valor;
            return true;
        }

        public void Depositar(double valor)
        {
            this._saldo += valor;
        }

        public bool Trasnferir(double valor, ContaCorrente contaDestino)
        {
            if (this._saldo < valor)
            {
                return false;
            }

            this._saldo -= valor;
            contaDestino.Depositar(valor);
            return true;
        }
    }
}