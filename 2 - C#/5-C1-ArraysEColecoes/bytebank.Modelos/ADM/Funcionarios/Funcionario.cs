using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios
{
    public abstract class Funcionario // Por se tratar de uma classe que serve apenas como molde para outras classes (conceito/ideia), é interessante defini-la como abstrata
    {
        // Propriedades
        public string Nome { get; set; }
        public string Cpf { get; private set; }
        public double Salario { get; protected set; } // Não foi possível manter o set salário como privado, pois é necessário acessar essa propriedade na classe Diretor. Por causa disso, utiliza-se o "protected" que faz com que a propriedade apenas seja visível para a própria classe e para as derivadas dela
        public static int TotalDeFuncionarios { get; private set; } // static declara uma propriedade que pertence ao tipo em si, permitindo que o método seja acessado através do nome da classe, sem precisar instanciar um objeto

        // Métodos
        public abstract double GetBonificacao(); // Por ter implementações concretas desse método em outras classes, agora ele serve apenas como molde, tendo que se tornar abstrato. Isso faz com que a implementação de qualquer lógica não seja possível.

        // Virtual diz ao compilador que este método pode ser reescrito por classes filhas de modo a possuir comportamentos alternativos
     
        public abstract void AumentarSalario();

        // Construtor
        public Funcionario(string cpf, double salario)
        {
            this.Cpf = cpf;
            this.Salario = salario;
            TotalDeFuncionarios++; // A contagem funciona para as outras classes filhas de Funcionario pois, quando uma classe filha é instanciada, ele é criada a partir do construtor da classe pai
        }
    }
}
