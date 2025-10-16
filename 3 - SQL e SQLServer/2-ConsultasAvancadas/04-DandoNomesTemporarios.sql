-- Quando é necessário alterar os nomes das colunas no SELECT, utiliza-se o "AS":
SELECT CPF AS IDENTIFICADOR, NOME AS NOME_DO_CLIENTE FROM TABELA_DE_CLIENTES;

-- Também é possível utilizar isso para dar nomes diferentes as tabelas:
SELECT TDC.CPF, TDC.NOME, TDC.BAIRRO FROM TABELA_DE_CLIENTES TDC;
SELECT TDC.* FROM TABELA_DE_CLIENTES TDC;

-- O as é muito útil para diferenciar campos de tabelas diferentes mas que possuem o mesmo nome, mas também é possível utilizar:
SELECT TABELA_DE_CLIENTES.CPF, TABELA_DE_CLIENTES.NOME FROM TABELA_DE_CLIENTES;