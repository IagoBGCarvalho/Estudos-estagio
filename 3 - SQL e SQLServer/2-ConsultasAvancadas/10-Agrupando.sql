-- O comando utilizado para agrupar campos é o GROUP BY

-- Para que seja possível agrupar os campos é necessário qie haja, na seleção de campos, pelo menos UM campo onde é aplicado alguma função de agregação, como:

-- SUM - Soma - Retorna a soma dos itens numéricos
-- AVG - Média
-- MAX - Máximo
-- MIN - Mínimo

SELECT CIDADE, SUM(IDADE) AS SOMATORIO_IDADE FROM TABELA_DE_CLIENTES GROUP BY CIDADE; -- Irá agrupar cada cidade com o somatório das idades das pessoas que moram nela
SELECT CIDADE, SUM(IDADE) AS SOMATORIO_IDADE, sum(LIMITE_DE_CREDITO) AS CREDITO FROM TABELA_DE_CLIENTES GROUP BY CIDADE; -- Adiciona o somatório de crédito dos clientes para cada cidade

SELECT CIDADE, COUNT(*) AS NUMERO_DE_CLIENTES FROM TABELA_DE_CLIENTES GROUP BY CIDADE; -- Irá agrupar o número de clientes por cidade. Como cada liha representa um cliente, count(*) irá contar todas as linhas, logo, todos os clientes