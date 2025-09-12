using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.Excecoes
{
    public class OperacaoFinanceiraException : Exception
    {
        // Classe referente a todas as exceções relacionadas a operações financeiras. Irá servir de molde para todas as outras exceções personalizadas.

        // Ao herdar de Exception, a classe já ganha, automaticamente, todas as funcionalidades de uma exceção, como ser lançável com o throw, capturável com o cath e ter outras propriedades, como .Message e .StackTrace

        // Construtor
        public OperacaoFinanceiraException(string mensagem) : base(mensagem)
        {

        }

        // Construtor que recebe, além da mensagem, o tipo de exceção

        public OperacaoFinanceiraException(string mensagem, Exception excecaoInterna) : base(mensagem, excecaoInterna) 
        {

        }
    }
}
