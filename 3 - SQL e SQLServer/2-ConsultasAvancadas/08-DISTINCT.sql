-- O comando DISTINCT é utilizado para apenas retornar registros com campos diferentes, nunca iguais

SELECT DISTINCT EMBALAGEM FROM TABELA_DE_PRODUTOS; -- Irá apenas retornar as 3 linhas que são diferentes (Caixa, Garrafa e Lata)

SELECT DISTINCT EMBALAGEM FROM TABELA_DE_PRODUTOS WHERE SABOR = 'Maçã'; -- Retorna apenas as embalagem em que algum produto seja do sabor Maçâ

SELECT DISTINCT EMBALAGEM, SABOR FROM TABELA_DE_PRODUTOS; -- Retorna as combinações onde a embalagem e o sabor são diferentes