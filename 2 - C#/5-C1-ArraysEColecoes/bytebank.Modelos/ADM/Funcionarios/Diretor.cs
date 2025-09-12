using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios
{
    public class Diretor : FuncionarioAutenticavel // Herda as características de FuncionarioAutenticado, visto que é um usuário (e precisa do nome, cpf. etc...) e pode acessar o sistema interno (precisando da senha e do método de autenticar)
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
