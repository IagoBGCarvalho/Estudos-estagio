using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _7_C1_StringsExpressoesRegularesClasseObject
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Profissao { get; set; }

        public override string ToString()
        {
            // É possível formatar uma string utilizando $"" e {} para especificar o nome das variáveis.
            // Também é possível realizar contas matemáticas utilizando as chaves, como: {12345 + 12345 * 2}
            return $"Executando ToString sobrescrito!! Nome: {Nome} CPF: {CPF} e Profissão: {Profissao}";
        }

        public override bool Equals(object? obj)
        {
            // Pessoa outraPessoa = (Pessoa)obj; Conversão explícita, retorna InvalidCastException caso a conversão não ocorra. É usado quando se tem certeza de que a variável pode ser convertida.
            Pessoa outraPessoa = obj as Pessoa; // Conversão segura de object para Pessoa (somente para tipos de referência ou anuláveis). "as" tenta fazer a conversão, mas caso dê erro, retorna null.

            if (outraPessoa == null)
            {
                return false;
            }

            return CPF == outraPessoa.CPF; // Compara o CPF de cada objeto para inferir se deve retornar True ou False
        }

        public Pessoa(string nome, string cpf, string profissao)
        {
            Nome = nome;
            CPF = cpf;
            Profissao = profissao;
        }

    }
}
