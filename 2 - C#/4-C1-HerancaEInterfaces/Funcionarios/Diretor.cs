using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces.Funcionarios
{
    public class Diretor : Funcionario // Herda as características de Funcionário (nome, cpf, salario e bonificação)
    {
        // Métodos substituídos:
        public override double GetBonificacao() // override altera o funcionamento padrão da função herdada da classe pai 
        {
            return this.Salario * 0.5; // base permite acessar as propriedades e os métodos da classe pai, por isso também é usado nos construtores
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.15;
        }

        // Construtor
        public Diretor(string cpf) : base(cpf, 5000) // É necessário enviar o parâmetro recebido para o construtor da classe base, por isso utiliza-se o base, que permite acessar implementações da classe pai, no caso, o método construtor
        {

        }
    }
}
