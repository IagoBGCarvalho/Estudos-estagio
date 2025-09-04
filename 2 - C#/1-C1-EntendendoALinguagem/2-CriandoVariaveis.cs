using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    public class CriandoVariaveis
    {
        public void Declaracoes()
        {
            Console.WriteLine("2 - Criando variáveis: \n");

            int idade; // Em C#, as variáveis são declaradas com um tipo específico
            idade = 27; // Após declarar, é possível atribuir um valor
            Console.WriteLine("Idade (int) antes do processamento: " + idade);

            idade = idade - (7 * 2);
            Console.WriteLine("Idade (int) depois do processamento: " + idade + "\n");

            double salario; // Double é um tipo de dado para números com ponto flutuante (números reais) com maior precisão
            salario = 1250.10;
            Console.WriteLine("Salário (double): " + salario + "\n");

            double divisao;
            divisao = 5 / 2; // Divisão entre inteiros resulta em inteiro
            Console.WriteLine("(5 / 2) armazenado em double: " + divisao);

            divisao = 5.0 / 2; // Para resultar em número real, um dos números deve ser real
            Console.WriteLine("(5.0 / 2) armazenado em double: " + divisao + "\n");
        }
    }
}
