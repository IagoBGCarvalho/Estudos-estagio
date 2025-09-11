using _4_C1_HerancaEInterfaces.SistemaInterno_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces.Funcionarios
{
    public class GerenteDeContas : FuncionarioAutenticavel 
    {
        // Métodos substituídos:
        public override double GetBonificacao()
        {
            return this.Salario * 0.25;
        }

        public override void AumentarSalario()
        {
            this.Salario *= 1.05;
        }

        // Construtor
        public GerenteDeContas(string cpf) : base(cpf, 4000)
        {
        }
    }
}
