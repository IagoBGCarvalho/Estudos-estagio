using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4_C1_HerancaEInterfaces.Excecoes
{
    public class SaldoInsuficienteException : OperacaoFinanceiraException
    {
        // Classe referente a uma exceção personalizada para o método de sacar da classe ContaCorrente. É uma classe filha (herança) da classe OperacaoFinanceiraException, que é filha da classe Exception, que já vem pronta no .NET.

        // Construtor
        public SaldoInsuficienteException(string mensagem) : base(mensagem)
        {
            // "base()" se refere ao construtor da classe pai, ou seja, pega a mensagem como parâmetro e a passa para o construtor da classe pai, Exception, que vai armazenar a mensagem corretamente na propriedade Message
        }

    }
}
