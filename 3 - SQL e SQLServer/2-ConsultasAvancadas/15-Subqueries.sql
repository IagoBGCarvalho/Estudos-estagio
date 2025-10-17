-- Subquerie é uma consulta que utiliza outras consultas como parâmetro

SELECT DISTINCT BAIRRO FROM TABELA_DE_VENDEDORES;

SELECT * FROM TABELA_DE_CLIENTES
WHERE BAIRRO IN('Copacabana', 'Barra da Tijuca', 'Centro', 'Itaim', 'Pinheiros'); -- Exemplo sem subquerie

SELECT * FROM TABELA_DE_CLIENTES
WHERE BAIRRO IN(SELECT DISTINCT BAIRRO FROM TABELA_DE_VENDEDORES); -- Utilizando subquerie. Para usar subqueries, é necessário que a querie de dentro retorne apenas um campo

-- Outro exemplo de subquerie:

-- Consulta que utiliza uma subquerie para agrupar as embalagens pela media dos preços dos produtos e retornar apenas as embalagens cuja média de preço é menor do que 10
SELECT MEDIA_EMBALAGENS.EMBALAGEM, MEDIA_EMBALAGENS.PRECO_MEDIO
FROM
(SELECT EMBALAGEM, AVG(PRECO_DE_LISTA) AS PRECO_MEDIO
FROM TABELA_DE_PRODUTOS GROUP BY EMBALAGEM) MEDIA_EMBALAGENS
WHERE MEDIA_EMBALAGENS.PRECO_MEDIO <= 10; 