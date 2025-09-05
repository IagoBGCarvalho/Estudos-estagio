using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2_C1_EntendendoAOrientacaoAObjetos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ContaCorrente contaGabriela = new ContaCorrente(); // Instanciação da classe ContaCorrente no objeto contaGabriela

            contaGabriela.titular = "Gabriela"; // Atribuição do valor "Gabriela" ao atributo titular do objeto contaGabriela
            contaGabriela.agencia = 863;
            contaGabriela.numero = 863452;

            ContaCorrente contaGabrielaCosta = new ContaCorrente(); // Instanciação da classe ContaCorrente no objeto contaGabriela

            contaGabrielaCosta.titular = "Gabriela";
            contaGabrielaCosta.agencia = 863;
            contaGabrielaCosta.numero = 863452;

            Console.WriteLine("Nome do titular: " + contaGabriela.titular);
            Console.WriteLine("Agência: " + contaGabriela.agencia);
            Console.WriteLine("Número da conta: " + contaGabriela.numero);
            Console.WriteLine("Saldo disponível: " + contaGabriela.saldo);

            Console.WriteLine("Igualdade entre objetos diferentes: " + (contaGabriela == contaGabrielaCosta)); // False, pois são objetos diferentes na memória, mesmo com os mesmos valores

            int idade = 10;
            int idadeDenovo = 10;
            Console.WriteLine("Igualdade entre variáveis diferentes com o mesmo valor: " + (idade == idadeDenovo)); // True, pois são tipos primitivos com o mesmo valor

            Console.ReadLine();
        }
    }
}