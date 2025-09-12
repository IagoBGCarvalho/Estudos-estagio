using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios;

namespace _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Utilitario
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
