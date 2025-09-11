using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _4_C1_HerancaEInterfaces.Funcionarios;
using _4_C1_HerancaEInterfaces.Parceria;

namespace _4_C1_HerancaEInterfaces.SistemaInterno_
{
    public class SistemaInterno
    {
        public bool Logar(IAutenticavel funcionario, string senha)
        {
            // Funciona que utiliza o método autenticar da classe Funcionário para informar se o usuário logou ou não no sistema
            bool usuarioAutenticado = funcionario.Autenticar(senha);

            if (usuarioAutenticado)
            {
                Console.WriteLine("Bem vindo ao sistema.");
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta.");
                return false;
            }
        }
    }
}
