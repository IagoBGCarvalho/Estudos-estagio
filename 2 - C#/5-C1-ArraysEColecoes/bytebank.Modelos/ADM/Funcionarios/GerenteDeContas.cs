using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios
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
