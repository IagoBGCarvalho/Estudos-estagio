using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_C1_HerancaEInterfaces.Funcionarios;

namespace _4_C1_HerancaEInterfaces.Utilitario
{
    internal class GerenciadorDeBonificacao
    {
        //Atributos:
        public double TotalDeBonificacao { get; set; }

        //Métodos
        public void Registrar(Funcionario funcionario)
        {
            this.TotalDeBonificacao += funcionario.GetBonificacao();
        }
    }
}
