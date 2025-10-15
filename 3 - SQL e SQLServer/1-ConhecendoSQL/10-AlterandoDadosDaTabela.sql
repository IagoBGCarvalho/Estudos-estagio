UPDATE TABELA_DE_PRODUTOS -- Update é o comando para fazer a alteração e recebe o nome da tabela alvo
SET PRECO_DE_LISTA = 3 -- Set recebe o nome do campo e o novo valor que irá receber
WHERE CODIGO_DO_PRODUTO = '544931'; -- Where indica a condição que a linha deve ter para que o seu campo alterado. Neste caso, a linha a ser alterada é a que contém o código "544931"

-- Também é possível fazer mais de uma alteração ao mesmo tempo utilizando vírgula para separar os parâmetros do set ou do where:
UPDATE TABELA_DE_PRODUTOS
SET PRECO_DE_LISTA = 7.50, EMBALAGEM = 'Garrafa' -- Faz duas alterações na linha de código 1088126
WHERE CODIGO_DO_PRODUTO = '1088126';

-- Para alterar mais de uma linha ao mesmo tempo, basta utilizar o próprio campo como parâmetro:
UPDATE TABELA_DE_PRODUTOS SET PRECO_DE_LISTA = PRECO_DE_LISTA * 1.1 WHERE EMBALAGEM = 'Lata'; -- Faz um aumento de 10% no preço de todos os produtos que utilizam a lata de embalagem