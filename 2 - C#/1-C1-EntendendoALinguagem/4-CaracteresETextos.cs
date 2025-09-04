using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_C1_EntendendoALinguagem
{
    internal class CaracteresETextos
    {
        public void ExemplosCaracteresETextos()
        {
            Console.WriteLine("4 - Caracteres e Texto: \n");

            char letra = 'a'; // Tipo char armazena um único caractere e é declarado com aspas simples, aspas duplas são para strings
            Console.WriteLine("Letra (char): " + letra);

            char letraASCII;
            letraASCII = (char)65; // Pode-se atribuir um valor numérico que representa o caractere na tabela ASCII
            Console.WriteLine("Letra ASCII 65 (char): " + letraASCII);

            string primeiraFrase = "Hoje é um belo dia";
            Console.WriteLine("Primeira frase (string): " + primeiraFrase);

            string segundaFrase = "pois é dia 03 de setembro de";
            Console.WriteLine("Primeira frase + segunda frase: " + primeiraFrase + " " + segundaFrase + " 2025"); // É possível concatenar strings com o operador +

            string vazia = ""; // Uma string pode ser vazia, mas uma char não

            string listaCursos = @"Cursos disponíveis:
- Go
- C# 
- Python 
- Java";
            Console.WriteLine(listaCursos + "\n"); // O @ antes das aspas duplas permite que a string contenha quebras de linha e outros caracteres especiais sem precisar de escape
        }
    }
}
