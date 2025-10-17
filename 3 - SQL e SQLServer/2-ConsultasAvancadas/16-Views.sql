-- Quando subqueries são muito utilizadas, é interessante armazená-las em memória e utilizá-las a partir de um nome de referência. Isso é uma view!

-- Para criar uma view, basta utilizar CREATE VIEW NOME_DA_VIEW AS e a subquerie a seguir
CREATE VIEW MEDIA_EMBALAGENS AS
SELECT EMBALAGEM, AVG(PRECO_DE_LISTA) AS PRECO_MEDIO
FROM TABELA_DE_PRODUTOS GROUP BY EMBALAGEM;

SELECT * FROM MEDIA_EMBALAGENS; -- Agora retorna a view como se fosse uma tabela