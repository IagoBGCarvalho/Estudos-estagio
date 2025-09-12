using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.SistemaInterno_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.ParceriaComercial
{
    public class ParceiroComercial : IAutenticavel
    {
        // Propriedades
        public string Senha { get; set; }

        // Métodos
        public bool Autenticar(string senha)
        {
            return this.Senha.Equals(senha); // Retorna true caso a senha seja correta
        }
    }
}
