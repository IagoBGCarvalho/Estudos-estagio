SELECT * FROM TABELA_DE_PRODUTOS WHERE 1=1; -- Não faz a menor diferença na consulta, pois a condição será sempre negativa!

SELECT * FROM TABELA_DE_PRODUTOS WHERE 1=0; -- Não irá retornar nada, pois a condição sempre será falsa!

SELECT * FROM TABELA_DE_PRODUTOS WHERE CODIGO_DO_PRODUTO = 'PRD001'; -- Retorna apenas o produto com o código especificado 

SELECT * FROM TABELA_DE_PRODUTOS WHERE TAMANHO = '1L'; -- Retorna TODOS os produtos que tem 1 litro de tamanho

-- Outros operadores que podem ser utilizados nas consultas:
-- (>) MAIOR
-- (<) MENOR
-- (>=) MAIOR OU IGUAL
-- (<=) MENOR OU IGUAL
-- (<>) DIFERENTE
-- e BETWEEN

SELECT * FROM TABELA_DE_CLIENTES WHERE IDADE > 40; -- Retorna os clientes que tem mais do que 40 anos

SELECT * FROM TABELA_DE_CLIENTES WHERE IDADE <= 30; -- Retorna os clientes que tem 30 anos ou menos

SELECT * FROM TABELA_DE_CLIENTES WHERE IDADE <> 20; -- Retorna os clientes que tem mais do que 20 anos

SELECT * FROM TABELA_DE_CLIENTES WHERE GENERO <> 'M'; -- Retorna apenas as clientes mulheres, pois o select retorna tudo o que é DIFERENTE de "M"

SELECT * FROM TABELA_DE_CLIENTES WHERE DATA_DE_NASCIMENTO > '1985-05-10'; -- Retorna todos os clientes que nasceram depois de 1985

SELECT * FROM TABELA_DE_CLIENTES WHERE BAIRRO > 'Centro'; -- Retorna os clientes onde o bairro começa com uma letra que vem depois do C no alfabeto (ou ce, cen,...)