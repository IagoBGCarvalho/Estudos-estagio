-- Filtros compostos são filtros que utilizam mais de uma condição

-- Para fazer essas junções, é necessário utilizar os símbolos lógicos AND e OR

SELECT * FROM TABELA_DE_CLIENTES WHERE DAY(DATA_DE_NASCIMENTO) = 12 AND BAIRRO = 'Jardim'; -- Retorna o cliente que nasceu no dia 12 E mora no bairro Jardim
SELECT * FROM TABELA_DE_CLIENTES WHERE BAIRRO = 'Centro' OR BAIRRO = 'Jardim'; -- Retorna o cliente que mora no bairro centro OU no jardim