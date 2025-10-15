-- O comando de consulta é o SELECT e permite pesonalizar a consulta utilizando palavras chaves:

-- Retornando todos os dados da tabela:
SELECT * FROM TABELA_DE_CLIENTES;
SELECT * FROM TABELA_DE_PRODUTOS;

-- Retornando colunas específicas em ordem específicas
SELECT NOME, CPF FROM TABELA_DE_CLIENTES; 

-- Dando nomes fantasia para colunas ao serem consultadas:
SELECT NOME AS NOME_DO_CLIENTE, CPF AS IDENTIFICADOR FROM TABELA_DE_CLIENTES;

-- Utilizando condições/filtros (where) na pesquisa:
SELECT * FROM TABELA_DE_PRODUTOS WHERE CODIGO_DO_PRODUTO = '1002';

-- Outros exemplos utilizando outras colunas e retornando mais de uma linha:
SELECT * FROM TABELA_DE_PRODUTOS WHERE EMBALAGEM = 'Lata';

-- Utilizando outros operadores na condição:
SELECT * FROM TABELA_DE_PRODUTOS WHERE PRECO_DE_LISTA > 5; -- Apenas retornas os produtos em que o preço é MAIOR do que 5 reais
SELECT * FROM TABELA_DE_PRODUTOS WHERE PRECO_DE_LISTA < 5; -- Retorna os produtos com preço MENOR do que 5
SELECT * FROM TABELA_DE_PRODUTOS WHERE PRECO_DE_LISTA <> 4; -- Retorna os produtos com preço DIFERENTE de 4 reais
SELECT * FROM TABELA_DE_PRODUTOS WHERE PRECO_DE_LISTA >= 5; -- Apenas retornas os produtos em que o preço é MAIOR ou IGUAL do que 5 reais
SELECT * FROM TABELA_DE_PRODUTOS WHERE PRECO_DE_LISTA <= 4; -- Apenas retornas os produtos em que o preço é MENOR ou IGUAL do que 5 reais
SELECT * FROM TABELA_DE_CLIENTES WHERE NOME >= 'Kleber Andrade'; -- Utilizando o maior com texto, funciona com base na ordem alfabeto, retornando campos que começam com letras que vem DEPOIS do texto informado
SELECT * FROM TABELA_DE_CLIENTES WHERE NOME >= 'Kleber Andrade'; -- Utilizando o menor, retorna os textos em que a letras começam antes do que as informadas
SELECT * FROM TABELA_DE_CLIENTES WHERE DATA_DE_NASCIMENTO > '1985-03-15'; -- Utilizando o maior com datas, retorna as datas que vem posteriormente à informada
SELECT * FROM TABELA_DE_CLIENTES WHERE DATA_DE_NASCIMENTO < '1985-03-15'; -- Utilizando o menor, retorna as datas que vem anteriormente à informada

-- Em relação a datas, é possível utilizar funções que facilitam a comparação de dados

SELECT * FROM TABELA_DE_CLIENTES WHERE YEAR(DATA_DE_NASCIMENTO) = 1990; -- Com a função YEAR, é possível especificar apenas um ano na comparação, e não um dia em específico
SELECT NOME, ESTADO, DATA_DE_NASCIMENTO, YEAR(DATA_DE_NASCIMENTO) AS ANO, MONTH(DATA_DE_NASCIMENTO) AS MES, DAY(DATA_DE_NASCIMENTO) AS DIA FROM TABELA_DE_CLIENTES; -- Retorna todos os dados da coluna nome, estado, data de nascimento e usa os nomes fantasias "ANO", "MES" e "DIA"  para retornar a função YEAR, MONTH e DAY como colunas



