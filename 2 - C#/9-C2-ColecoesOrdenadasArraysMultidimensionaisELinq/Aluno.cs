using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _9_C2_ColecoesOrdenadasArrayMultidimensionaisELinq
{
    public class Aluno
    {
		private string nome;
        private int numeroMatricula;

        public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		public int NumeroMatricula
		{
			get { return numeroMatricula; }
			set { numeroMatricula = value; }
		}

        public override string ToString()
        {
            return $"[Nome: {nome}, Matrícula: {numeroMatricula}]";
        }

        public override bool Equals(object? obj)
        {
            Aluno objAluno = obj as Aluno;

            if (objAluno == null)
            {
                return false;
            }

            return this.nome.Equals(objAluno.nome);
        }

        public override int GetHashCode()
        {
            // É um método de espalhamento, converte os itens de uma coleção em códigos que ficam em uma tabela de dispersão (Hash Table) que diz em qual "caixa" os códigos irão ficar. Quando mais de um código é dispersado na mesma caixa, ocorre uma colisão, sendo necessário percorrer todos os elementos da caixa

            // A rapidez da busca depende do algoritmo de dispersão utilizado.

            // Doi objetos que são iguais possuem o mesmo hash code, MAS dois objetos com mesmo hash não são necessariamente iguais (colisão).
            return this.nome.GetHashCode();
        }

        public Aluno(string nome, int numeroMatricula)
        {
            this.nome = nome;
            this.numeroMatricula = numeroMatricula;
        }
    }
}
