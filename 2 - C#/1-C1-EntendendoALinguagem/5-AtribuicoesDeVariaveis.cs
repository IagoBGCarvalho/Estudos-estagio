using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    internal class AtribuicoesDeVariaveis
    {
        public void ExemplosAtribuicoes()
        {
            Console.WriteLine("5 - Atribuições de variáveis: \n");

            int idade = 30;
            int idadeAna = idade; // A variável idadeAna recebe uma cópia do valor da variável idade

            Console.WriteLine("Idade da Ana: " + idade);

            idade = 20;
            Console.WriteLine("Idade da Ana após alterar a idade: " + idadeAna + "\n"); // A variável idadeAna não é alterada, pois ela recebeu uma cópia do valor da variável idade
        }
    }
}
