using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _5_C1_ArraysEColecoes.bytebank.Modelos.Conta;

namespace _5_C1_ArraysEColecoes.bytebank.Util
{
    public class ListaDeContasCorrentes
    {
        private ContaCorrente[] _itens = null;
        private int _proximaPosicao = 0;

        // Construtor
        public ListaDeContasCorrentes(int tamanho_inicial = 5) // Caso nada seja passado como parâmetro, o valor padrão será 5
        {
            _itens = new ContaCorrente[tamanho_inicial];   
        }

        public void Adicionar(ContaCorrente item)
        {
            Console.WriteLine("Adicionando item na posição: " + _proximaPosicao);
            VerificarCapacidade(_proximaPosicao + 1);
            _itens[_proximaPosicao] = item;
            _proximaPosicao++; // Incrementa a posição para que a próxima conta não seja armazenada novamente no índice 0
        }

        private void VerificarCapacidade(int tamanhoNecessario)
        {
            if (_itens.Length >= tamanhoNecessario)
            {
                return;
            }

            Console.WriteLine("Aumentando a capacidade da lista...");

            ContaCorrente[] novoArray = new ContaCorrente[tamanhoNecessario]; // Caso o tamanho atual do array não seja o suficiente, cria um novo que toma como parâmetro o tamanho necessário, impedindo o IndexOutofRange

            for (int i = 0; i < _itens.Length; i++)
            {
                // Atribui todos os itens do array antigo para o array novo
                novoArray[i] = _itens[i];
            }

            _itens = novoArray; // _itens agora aponta para o novo array
        }

        public void Remover(ContaCorrente conta)
        {
            int indiceItem = -1;
            for (int i = 0; i < _proximaPosicao; i++)
            {
                ContaCorrente contaAtual = _itens[i];
                if (contaAtual == conta)
                {
                    // Faz uma busca para encontrar o índice da conta que se quer apagar e o atribui a variável "indiceItem"
                    indiceItem = i;
                    break;
                }
            }

            for (int i = indiceItem; i < _proximaPosicao-1; i++)
            {
                // Coloca, no lugar do índice encontrado, o valor do próximo índice, até quando não tiverem mais índices sobrando. Após isso, diminui em 1 o valor da proxima posição e o atribui como nulo
                _itens[i] = _itens[i + 1];
            }
            _proximaPosicao--;
            _itens[_proximaPosicao] = null;
        }

        public void ExibeLista()
        {
            for (int i = 0; i < _itens.Length; i++)
            {
                if (_itens[i] != null)
                {
                    var conta = _itens[i];
                    Console.WriteLine($"Indice [{i}] = Conta: {conta.Conta} - Número da Agência: {conta.Agencia}");
                }
            }
        }
    }
}
