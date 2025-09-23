using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace _8_C2_ListasListasLigadasDicionariosEConjuntos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Listas:

            // Uma lista se trata de um Array dinâmico, pois armazena items conforme for solicitado, diferente do Array, onde é necessário especificar a quantidade de espaços na memória.

            string aulaIntro = "Introdução às Coleções";
            string aulaModelando = "Modelando a classe Aula";
            string aulaSets = "Trabalhando com Conjuntos";

            //List<string> aulas = new List<string>() // List<tipo> nome_variavel = new List<tipo>();
            //{
            //    aulaIntro, aulaModelando, aulaSets // É possível adicionar itens já na declaração da lista
            //};

            List<string> aulas = new List<string>();
            aulas.Add(aulaIntro);
            aulas.Add(aulaModelando);
            aulas.Add(aulaSets);

            Imprimir(aulas);

            Console.WriteLine("A primeira aula é: " + aulas[0]);
            Console.WriteLine("A primeira aula é: " + aulas.First()); // Faz a mesma coisa que a linha anterior

            Console.WriteLine("A última aula é: " + aulas[aulas.Count - 1]);
            Console.WriteLine("A última aula é: " + aulas.Last()); // Faz a mesma coisa que a linha anterior

            Console.ReadLine();
        }

        private static void Imprimir(List<string> aulas)
        {
            // Formas de imprimir uma lista:

            //foreach (var item in aulas)
            //{
            //    Console.WriteLine(item);
            //}

            //for (int i = 0; i < aulas.Count; i++)
            //{
            //    Console.WriteLine(aulas[i]);
            //}

            aulas.ForEach(aula => {Console.WriteLine(aula);});
        }
    }
}