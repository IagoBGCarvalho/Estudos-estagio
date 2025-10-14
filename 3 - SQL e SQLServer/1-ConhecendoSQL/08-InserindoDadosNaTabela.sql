-- Inserindo dados na tabela de produtos:
INSERT INTO TABELA_DE_PRODUTOS -- Especificação da tabela na qual os dados serão inseridos
(
CODIGO_DO_PRODUTO, -- Primeiro é necessário listar o nome dos campos em que os dados serão inseridos
NOME_DO_PRODUTO,
EMBALAGEM,
TAMANHO,
SABOR,
PRECO_DE_LISTA
)
VALUES
(
'1040107', -- Depois, a partir do comando VALUES, é necessário informar, na mesma ordem em que as colunas foram informadas no INSERT INTO, os dados que serão incluídos em cada campo
'Light - 350 ml - Melância', -- Os campos de texto devem ser especificados entre aspas simples
'Lata',
'350 ml',
'Melância',
4.56
);

-- Também poderia estar formatado como:
-- INSERT INTO TABELA_DE_PRODUTOS(CODIGO_DO_PRODUTO,NOME_DO_PRODUTO,EMBALAGEM,TAMANHO,SABOR,PRECO_DE_LISTA)VALUES('1040107','Light - 350 ml - Melância','Lata','350 ml','Melância',4.56);

-- É possível fazer diversas inserções na mesma consulta:
INSERT INTO TABELA_DE_PRODUTOS
(
CODIGO_DO_PRODUTO,
NOME_DO_PRODUTO,
EMBALAGEM,
TAMANHO,
SABOR,
PRECO_DE_LISTA
)
VALUES
(
'1037797',
'Clean - 2 Litros - Laranja',
'PET',
'2 Litros',
'Laranja',
16.01
);

INSERT INTO TABELA_DE_PRODUTOS
(
CODIGO_DO_PRODUTO,
NOME_DO_PRODUTO,
EMBALAGEM,
TAMANHO,
SABOR,
PRECO_DE_LISTA
)
VALUES
(
'1000889',
'Sabor da Montanha - 700 ml - Uva',
'Garrafa',
'700 ml',
'Uva',
6.31
);