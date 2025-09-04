using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    internal class Condicionais
    {
        public void ExemplosCondicionais()
        {
            Console.WriteLine("6 - Condicionais: \n");
            // Operadores lógicos:
            // || -> OU
            // && -> E
            // ! -> NÃO

            // bool -> true ou false

            // Sem usar operadores:
            int idadeJoao = 16;
            int quantidadePessoas = 2;

            if (idadeJoao >= 18)
            {
                Console.WriteLine("João pode entrar.");
            } 
            else
            {
                if (quantidadePessoas >= 2)
                {
                    Console.WriteLine("João pode entrar, pois está acompanhado.");
                }
                else
                {
                    Console.WriteLine("João não pode entrar.");
                }
            }

            // Usando operadores:
            if (idadeJoao >= 18 || quantidadePessoas >= 2)
            {
                Console.WriteLine("João pode entrar. (Usando operadores lógicos)");
            }
            else
            {
                Console.WriteLine("João não pode entrar. (Usando operadores lógicos)");
            }

            // Usando boolean:
            bool acompanhado = quantidadePessoas >= 2; // Recebe true caso a quantidade de pessoas seja maior ou igual a 2
            if (idadeJoao >= 18 || acompanhado)
            {
                Console.WriteLine("João pode entrar. (Usando boolean)");
            }
            else
            {
                Console.WriteLine("João não pode entrar. (Usando boolean)");
            }

            // Escopo 
            string textoAdicional;
            if (acompanhado)
            {
                textoAdicional = "Está acompanhado.";
            }
            else
            {
                textoAdicional = "Não está acompanhado.";
            }

            if (idadeJoao >= 18 || acompanhado)
            {
                Console.WriteLine("João pode entrar. " + textoAdicional + "\n");
            }
            else
            {
                Console.WriteLine("João não pode entrar. " + textoAdicional + "\n");
            }
        }
    }
}
