using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5_C1_ArraysEColecoes.Excecoes
{
    // exception + tab + tab gera o modelo de uma classe de exceções

    [Serializable]
	public class BytebankException : Exception
	{
		public BytebankException() { }
		public BytebankException(string message) : base("Houve uma exceção -> " + message) { }
		public BytebankException(string message, Exception inner) : base(message, inner) { }
		protected BytebankException(
		  System.Runtime.Serialization.SerializationInfo info,
		  System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
	}

}
