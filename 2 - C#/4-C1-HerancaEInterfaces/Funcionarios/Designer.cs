using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces.Funcionarios
{
    public class Designer : Funcionario
    {
        // Métodos substituídos:
        public override double GetBonificacao()
        {
            return this.Salario * 0.17;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.11;
        }

        // Construtor
        public Designer(string cpf) : base(cpf, 3000)
        {
        }
    }
}
