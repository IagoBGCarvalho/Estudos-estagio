-- Criação da tabela "TABELA_DE_CLIENTES" que será implementada no banco "SUCOS_VENDAS"
-- Terá os campos: CPF, Nome Completo, Endereço completo, Data de nascimento, idade, gênero, limite de crédito, volume mínimo de compra de produtos e se já realizou alguma compra na empresa

-- É necessário adequar cada campo ao tipo de dado mais apropriado

USE SUCOS_VENDAS; -- Garante que o comando será executado no banco especificado

CREATE TABLE TABELA_DE_CLIENTES
(
CPF CHAR(11), -- Sintaxe: NOME_DO_CAMPO TIPO
NOME VARCHAR(100),
ENDERECO1 VARCHAR(150), -- Apenas os tipos que envolvem texto precisam que o espaço alocado seja informado 
ENDERECO2 VARCHAR(150),
BAIRRO VARCHAR(50),
CIDADE VARCHAR(50),
ESTADO CHAR(2),
CEP CHAR(8),
DATA_DE_NASCIMENTO DATE,
IDADE SMALLINT,
GENERO CHAR(1),
LIMITE_DE_CREDITO MONEY,
VOLUME_DE_COMPRA FLOAT,
PRIMEIRA_COMPRA BIT,
);

-- A segunda tabela será a "CADASTRO_PRODUTOS"
-- Os campos serão: Código do produto, nome do produto, embalagem, tamanho, sabor

CREATE TABLE TABELA_DE_PRODUTOS
(
CODIGO_DO_PRODUTO VARCHAR(20),
NOME_DO_PRODUTO VARCHAR(150),
EMBALAGEM VARCHAR(50),
TAMANHO VARCHAR(50),
SABOR VARCHAR(50),
PRECO_DE_LISTA SMALLMONEY
);