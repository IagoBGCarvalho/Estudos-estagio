using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_C2_ListasListasLigadasDicionariosEConjuntos
{
    public class Curso
    {
		private List<Aula> aulas;
        private string nome;
        private string instrutor;
		private ISet<Aluno> alunos = new HashSet<Aluno>(); // Conjunto de alunos
		private IDictionary<int, Aluno> dicionarioAlunos = new Dictionary<int, Aluno>(); // A interface IDictionary recebe o tipo da chave e do valor
		public IList<Aluno> Alunos
		{
			get
			{
				return new ReadOnlyCollection<Aluno>(alunos.ToList()); // Propriedade que bloqueia o set do conjunto, retornando apenas uma lista
			}
		}

        public IList<Aula> Aulas
		{
			get { return new ReadOnlyCollection<Aula>(aulas); }
			// Agora a lista "Aulas" apenas é visível mas não alterável por outra classe que não seja a Curso
		}

		public string Nome
		{
			get { return nome; }
			set { nome = value; }
		}

		public string Instrutor
		{
			get { return instrutor; }
			set { instrutor = value; }
		}

		public int TempoTotal
		{
			get
			{
				int total = 0;

				// Versão tradicional: 

				//foreach (var aula in aulas)
				//{
				//	// Usa a variável acumuladora "total" para acumular o valor da propriedade tempo de cada aula na lista de aulas
				//	total += aula.Tempo;
				//}

				// Usando LINQ (Language Integrated Query):
				return aulas.Sum(aula => aula.Tempo); // Retorne, a partir da coleção aulas, o somatório do tempo em minutos de todas as aulas. Na expressão lambda: "Para cada aula, retorne o tempo"
			}
		}

        internal void Adiciona(Aula aula)
        {
			this.aulas.Add(aula);
        }

        internal void Matricula(Aluno aluno)
        {
			this.alunos.Add(aluno);
			this.dicionarioAlunos.Add(aluno.NumeroMatricula, aluno);
        }

		public bool EstaMatriculado(Aluno aluno)
		{
			return alunos.Contains(aluno); // O conjunto alunos contém o aluno dado como parâmetro?
		}

        public Aluno BuscaMatriculado(int numeroMatricula)
        {
			foreach (var aluno in alunos)
			{
				if (aluno.NumeroMatricula == numeroMatricula)
				{
					return aluno;
				}
			}
			throw new Exception("Matrícula não encontrada.");
        }

        public Aluno BuscaMatriculadoDicionario(int numeroMatricula)
        {
			Aluno aluno = null;
            // Normal, utilizaria-se colchetes para consultar o valor da chave especificada "return dicionarioAlunos[chave]", mas aqui se usa um Try out para colocar um valor nulo no retorno caso a busca não seja efetivada, evitando exceções
            this.dicionarioAlunos.TryGetValue(numeroMatricula, out aluno);
			return aluno;
        }

        public void SubstituiAluno(Aluno aluno)
        {
			this.dicionarioAlunos[aluno.NumeroMatricula] = aluno; // A partir da chave [] é possível alterar o seu valor utilizando o símbolo de atribuição
        }

        public override string ToString()
        {
            return $"Curso: {nome}, Tempo: {TempoTotal} minutos, Aulas: {string.Join(",", aulas)}"; // O join cria uma nova string a partir de outras strings, recebendo o separador "," e os valores como parâmetros
        }

        public Curso(string nome, string instrutor)
        {
            this.nome = nome;
            this.instrutor = instrutor;
			this.aulas = new List<Aula>();
        }
    }
}
