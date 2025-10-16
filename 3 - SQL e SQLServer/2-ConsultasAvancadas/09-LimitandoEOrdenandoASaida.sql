-- TOP X é utilizado para retornar apenas as primeiras "X" linhas de uma tabela

SELECT TOP 4 * FROM TABELA_DE_CLIENTES; -- Retorna as primeiras 4 linhas da tabela de clientes e com todas as colunas

-- É possível ordenar consultas a partir da declaração de campos e da direção da ordenação
-- O comando utilizado para fazer essa ordenação é o ORDER BY

-- Sintaxe: SELECT * FROM... ORDER NY <LISTA DE CAMPOS> (ASC OU DESC) 

SELECT * FROM TABELA_DE_CLIENTES ORDER BY IDADE; -- Por padrão, o ORDER BY sempre retorna a ordenação ascendente (do menor pro maior)

SELECT * FROM TABELA_DE_CLIENTES ORDER BY LIMITE_DE_CREDITO DESC; -- Retorna os funcionários ordenados a partir do MAIOR limite de crédito

SELECT * FROM TABELA_DE_CLIENTES ORDER BY CIDADE, BAIRRO DESC; -- Ordena toda a lista de cidade e, para cada cidade, ordena os respectivos bairros

-- Por fim, é possível juntar o TOP com o ORDER BY para retornar apenas o topo de uma consulta ordenada:

SELECT top 3 * FROM TABELA_DE_CLIENTES ORDER BY LIMITE_DE_CREDITO DESC; -- Retorna os 3 clientes com mais limite de crédito