-- Até então, o WHERE utilizou apenas expressões lógicas simples, mas é possível juntar expressões lógicas e criar expressões lógicas compostas utilizando AND ou OR.

SELECT * FROM TABELA_DE_PRODUTOS WHERE EMBALAGEM = 'Garrafa' AND TAMANHO = '500ml'; -- Retorna os produtos que usam a embalagem garrafa E tem o tamanho de 500ml

SELECT * FROM TABELA_DE_PRODUTOS WHERE TAMANHO = '500ml' OR TAMANHO = '350ml'; -- Retorna os produtos que tem tamanho 500ml OU 350ml

SELECT * FROM TABELA_DE_PRODUTOS WHERE NOT SABOR = 'Manga'; -- Retorna todos os sabores que NÃO tem o sabor de manga
SELECT * FROM TABELA_DE_PRODUTOS WHERE NOT (SABOR = 'Manga' OR TAMANHO = '470ml'); -- Retorna todos os sabores que NÃO tem o sabor de manga e que não tem o tamanho 470ml

SELECT * FROM TABELA_DE_PRODUTOS WHERE SABOR = 'Manga' OR SABOR = 'Laranja' OR SABOR = 'Abacaxi'; -- É possível utiizar n expressões lógicas com os operadores lógicos
SELECT * FROM TABELA_DE_PRODUTOS WHERE SABOR IN ('Manga','Laranja','Abacaxi'); -- O IN serve para fazer extamente o que a linha passaqda faz, mas de forma mais organizada

SELECT * FROM TABELA_DE_CLIENTES WHERE CIDADE IN ('Rio de Janeiro','São Paulo') AND IDADE >= 30; -- Juntando a expressão lógica com uma expressão aritmética

SELECT * FROM TABELA_DE_CLIENTES WHERE CIDADE IN ('Rio de Janeiro','São Paulo') AND (IDADE BETWEEN 30 AND 40); -- Between retorna as linhas que estão no intervalo estabelecido pelo uso do AND