using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_C2_ListasListasLigadasDicionariosEConjuntos
{
    public class Aula : IComparable
    {
        // Atributos:
        private string _titulo;
        private int _tempo;

        // Propriedades:
        public string Titulo { get => _titulo; set => _titulo = value; }
        public int Tempo { get => _tempo; set => _tempo = value; }

        // Métodos:
        public override string ToString()
        {
            return $"[Título: {this.Titulo}, Tempo: {this.Tempo}]";
        }

        public int CompareTo(object? obj)
        {
            Aula objAula = obj as Aula;
            return this.Titulo.CompareTo(objAula.Titulo);
        }

        // Construtor:
        public Aula(string titulo, int tempo)
        {
            _titulo = titulo;
            _tempo = tempo;
        }
    }
}
