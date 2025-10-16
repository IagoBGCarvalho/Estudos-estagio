-- É possível realizar testes lógicos a partir de condicionais no SQL. O comando que faz isso é o CASE!

-- Sintaxe: CASE WHEN <CONDIÇÃO> THEN <VALOR>
--               WHEN <CONDIÇÃO> THEN <VALOR
--               ELSE <VALOR> END -- Se nenhuma condição for alcançada, então este será o valor final

SELECT NOME_DO_PRODUTO, PRECO_DE_LISTA, -- Retotna o nome, o preço e mais uma coluna para representar o CASE
(CASE WHEN PRECO_DE_LISTA >= 6 THEN 'Produto caro' -- Se o preço do produto for maior ou igual a 6, o campo do case dele estará preenchido como "Produto caro"
      WHEN PRECO_DE_LISTA >= 4 AND PRECO_DE_LISTA < 6 THEN 'Produto em conta'
      ELSE 'Produto barato' END) AS CLASSIFICACAO_PRECO -- Dá um nome personalizado a coluna do case, que será "CLASSIFICACAO_PRECO"
FROM TABELA_DE_PRODUTOS ORDER BY PRECO_DE_LISTA; 