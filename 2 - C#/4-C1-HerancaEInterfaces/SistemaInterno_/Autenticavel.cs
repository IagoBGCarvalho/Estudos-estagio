using _4_C1_HerancaEInterfaces.Funcionarios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces.SistemaInterno_
{
    public interface IAutenticavel
    {
        // Para contornar a falta da herança múltipla, implementa-se uma interface, que serve como um contrato que obriga quem implementa ela a implementar certas propriedades e comportamento.
        // Propriedades:
        public string Senha { get; set; }

        // Comportamentos:
        public bool Autenticar(string senha);
    }
}
