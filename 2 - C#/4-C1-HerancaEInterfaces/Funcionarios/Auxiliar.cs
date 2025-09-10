using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces.Funcionarios
{
    public class Auxiliar : Funcionario
    {
        // Métodos substituídos:
        public override double GetBonificacao()
        {
            return this.Salario * 0.2;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.1;
        }

        // Construtor
        public Auxiliar(string cpf) : base(cpf, 2000)
        {
        }
    }
}
