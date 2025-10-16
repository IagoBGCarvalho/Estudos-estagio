-- As vezes é necessário usar condições no GROUP BY (caso não se queira ordenar por TODOS os elementos), por cuassa disso, existe o HAVING, que funcionna como um WHERE do GROUP BY

-- Sintaxe: SELECT ESTADO, SUM(N) FROM CLIENTE GROUP BY ESTADO HAVING SUM(N) > 60;

SELECT ESTADO, SUM(LIMITE_DE_CREDITO) AS CREDITO FROM TABELA_DE_CLIENTES GROUP BY ESTADO; -- Retorna cada estado e o somatório do limite de crédito de seus clientes

-- E se eu só quisesse agrupar os estados onde o somatório do limite de crédito é maior do que 6200,00?

SELECT ESTADO, SUM(LIMITE_DE_CREDITO) AS CREDITO FROM TABELA_DE_CLIENTES GROUP BY ESTADO HAVING SUM(LIMITE_DE_CREDITO) > 6200; -- Diferente do WHERE, HAVING pode receber funções como parâmetros