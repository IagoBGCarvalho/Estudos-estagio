using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Linq.Expressions;
using System.Diagnostics;
using _11_C2_TrabalhandoComArquivos.Conta;

namespace _11_C2_TrabalhandoComArquivos
{
    partial class Program
    {
        static void ConvertendoTextoParaConta()
        {
            // É necessário ler linha por linha do arquivo para converter cada uma em um objeto ContaCorrente
            // Por isso, será utilizado o StreamReader, que já faz o trabalho de ler e decodificar o arquivo,
            // com o método ReadLine, que lê o arquivo linha por linha, junto com o método ConverterStringParaContaCorrente

            var enderecoDoArquivo = "contas.csv";

            using (var fluxoDeArquivo = new FileStream(enderecoDoArquivo, FileMode.Open))
            using (var leitor = new StreamReader(fluxoDeArquivo))
            {
                Console.WriteLine("---Contas carregadas do arquivo contas.csv---\n");

                while (!leitor.EndOfStream)
                {
                    var linha = leitor.ReadLine();
                    var contaCorrente = ConverterStringParaContaCorrente(linha);

                    Console.WriteLine($"Conta: {contaCorrente.Conta}, Agência: {contaCorrente.Agencia}, Saldo: {contaCorrente.Saldo}, Titular: {contaCorrente.Titular.Nome}.");
                }
            }
            Console.ReadLine();
        }

        static ContaCorrente ConverterStringParaContaCorrente(string linha)
        {
            /// Função que obtém os dados de uma linha do arquivo csv e converte para um objeto ContaCorrente
            string[] campos = linha.Split(','); // Quebra a string em um array de strings, utilizando a vírgula como delimitador

            var agencia = int.Parse(campos[0]); // Converte o primeiro campo (no caso, agência) para int e armazena na variável
            var numeroConta = campos[1];

            var saldo = double.Parse(campos[2].Replace('.', ',')); // Converte o terrceiro campo (saldo) para double e tiliza o replace para trocar o ponto por vírgula, já que o C# utiliza vírgula para separação decimal
            var nomeTitular = campos[3];

            var titular = new Cliente(); // Cria um objeto Cliente que será utilizado no construtor da conta
            titular.Nome = nomeTitular;

            var resultado = new ContaCorrente(agencia, numeroConta); // Instancia um objeto ContaCorrente utilizando os dados obtidos na linha
            resultado.Depositar(saldo); // Deposita o saldo na conta
            resultado.Titular = titular; // Atribui o titular à conta

            return resultado;
        }
    }
}