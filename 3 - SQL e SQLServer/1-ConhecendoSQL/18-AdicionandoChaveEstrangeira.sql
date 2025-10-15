-- Para implementar a chave estrangeira, é necessário criar uma tabela adicional que irá representar os pedidos feitos por clientes específicos:

DROP TABLE TABELA_DE_PEDIDOS;

CREATE TABLE TABELA_DE_PEDIDOS (
    ID_PEDIDO INT IDENTITY(1,1) PRIMARY KEY, -- A chave primária ID_PEDIDO está utilizando a propriedade IDENTITY para gerar automaticamente números sequenciais para cada nova linha da tabela, começando em 1 e incrementando de 1 em 1 a cada registro (1,1)
    CPF_CLIENTE CHAR(11) NOT NULL,
    CODIGO_PRODUTO VARCHAR(10) NOT NULL,
    DATA_DO_PEDIDO DATE NOT NULL,
    QUANTIDADE INT NOT NULL,
    VALOR_TOTAL MONEY NULL,
-- Chaves estrangeiras:
CONSTRAINT FK_PEDIDOS_CLIENTES FOREIGN KEY (CPF_CLIENTE) REFERENCES TABELA_DE_CLIENTES (CPF), -- Adiciona a CONSTRAINT FOREIGN KEY a coluna (CPF_CLIENTE) que deverá referenciar a coluna CPF da tabela de clientes
CONSTRAINT FK_PEDIDOS_PRODUTOS FOREIGN KEY (CODIGO_PRODUTO) REFERENCES TABELA_DE_PRODUTOS (CODIGO_DO_PRODUTO)); -- Adiciona outra chave estrangeira que irá referenciar ao código do produto da tabela de produtos.

-- Exemplos de inserção de dados na tabela:

-- ATENÇÃO!! Caso os valores inseridos nos campos de chave estrangeira NÃO estejam na chave primária das tabelas referenciadas, o SQL Server retornará ERRO!

INSERT INTO TABELA_DE_PEDIDOS VALUES
('11223344556', '1001', '2025-10-14', 3, 16.50),
('23456789012', '1005', '2025-10-13', 2, 6.40);

SELECT * FROM TABELA_DE_PEDIDOS; -- Esta nova tabela cria um novo relacionamento com TABELA_DE_CLIENTES e TABELA_DE_PRODUTOS.

-- No relacionamento entre TABELA_DE_CLIENTES e TABELA_DE_PEDIDOS: Um cliente pode fazer vários pedidos, mas um pedido pertence a um único cliente (1:N)
-- E no relacionamento entre TABELA_DE_PRODUTOS e TABELA_DE_PEDIDOS: Um produto pode aparecer em vários pedidos, mas cada linha da tabela de pedidos representa um único produto comprado (1:N)