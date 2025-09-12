using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios;
using _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.SistemaInterno_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.bytebank.Modelos.ADM.Funcionarios
{
    public abstract class FuncionarioAutenticavel : Funcionario, IAutenticavel
    {
        // Classe que informa se o usuário é autenticável e que implementa a interface Autenticavel (que possui o atributo de senha e o método para autenticar)
        public string Senha { get; set; }

        public bool Autenticar(string senha)
        {
            return this.Senha.Equals(senha);
        }

        // Construtor:
        protected FuncionarioAutenticavel(string cpf, double salario) : base(cpf, salario)
        {
        }
    }
}
