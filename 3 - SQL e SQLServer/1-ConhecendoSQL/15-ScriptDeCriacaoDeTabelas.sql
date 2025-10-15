-- Script para criar as tabelas de clientes e produtos do 0, já implementando a chave primária, e inserindo dados para teste:
USE SUCOS_VENDAS;

DROP TABLE TABELA_DE_CLIENTES;

CREATE TABLE TABELA_DE_CLIENTES(
	CPF CHAR(11) NOT NULL, -- NOT NULL pois irá receber a chave primária já na criação da tabela
	NOME VARCHAR(100) NULL,
	ENDERECO1 VARCHAR(150) NULL,
	ENDERECO2 VARCHAR(150) NULL,
	BAIRRO VARCHAR(50) NULL,
	CIDADE VARCHAR(50) NULL,
	ESTADO VARCHAR(2) NULL,
	CEP CHAR(8) NULL,
	DATA_DE_NASCIMENTO DATE NULL,
	IDADE SMALLINT NULL,
	GENERO CHAR(1) NULL,
	LIMITE_DE_CREDITO MONEY NULL,
	VOLUME_DE_COMPRA FLOAT NULL,
	PRIMEIRA_COMPRA BIT NULL,
CONSTRAINT PK_CLIENTES PRIMARY KEY CLUSTERED(CPF)); -- Já define a chave primária na criação da tabela

DROP TABLE TABELA_DE_PRODUTOS;

CREATE TABLE TABELA_DE_PRODUTOS(
	CODIGO_DO_PRODUTO VARCHAR(10) NOT NULL,
	NOME_DO_PRODUTO VARCHAR(50) NULL,
	EMBALAGEM VARCHAR(20) NULL,
	TAMANHO VARCHAR(10) NULL,
	SABOR VARCHAR(20) NULL,
	PRECO_DE_LISTA SMALLMONEY NULL,
CONSTRAINT PK_PRODUTOS PRIMARY KEY CLUSTERED(CODIGO_DO_PRODUTO));

-- Inserção de dados para teste:

INSERT INTO TABELA_DE_CLIENTES VALUES 
('12345678901', 'Ana Souza', 'Rua das Flores', NULL, 'Centro', 'São Paulo', 'SP', '01001000', '1985-03-15', 40, 'F', 5000.00, 15000.5, 1),
('23456789012', 'Bruno Lima', 'Av. Brasil', 'Ap 101', 'Copacabana', 'Rio de Janeiro', 'RJ', '22041001', '1990-07-20', 35, 'M', 3000.00, 12000.0, 0),
('34567890123', 'Carla Mendes', 'Rua A', NULL, 'Centro', 'Belo Horizonte', 'MG', '30140001', '1988-01-05', 37, 'F', 4500.00, 8000.0, 1),
('45678901234', 'Daniel Rocha', 'Rua B', NULL, 'Boa Viagem', 'Recife', 'PE', '51020010', '1975-12-12', 49, 'M', 7000.00, 9500.5, 1),
('56789012345', 'Eduardo Silva', 'Av. das Américas', NULL, 'Barra', 'Rio de Janeiro', 'RJ', '22640010', '1995-10-10', 30, 'M', 2500.00, 3000.0, 0),
('67890123456', 'Fernanda Torres', 'Rua C', 'Casa 2', 'Itaim', 'São Paulo', 'SP', '04538000', '1992-05-25', 33, 'F', 5200.00, 11000.2, 1),
('78901234567', 'Gustavo Neves', 'Rua D', NULL, 'Savassi', 'Belo Horizonte', 'MG', '30110000', '1980-09-15', 45, 'M', 6200.00, 10000.0, 1),
('89012345678', 'Helena Martins', 'Av. Paulista', 'Apto 501', 'Bela Vista', 'São Paulo', 'SP', '01310000', '1983-11-30', 41, 'F', 5500.00, 9800.0, 0),
('90123456789', 'Igor Santos', 'Rua E', NULL, 'Jardins', 'São Paulo', 'SP', '01415001', '1991-04-18', 34, 'M', 4300.00, 8700.0, 1),
('11223344556', 'Joana Prado', 'Rua F', 'Casa', 'Pinheiros', 'São Paulo', 'SP', '05422001', '1986-06-22', 39, 'F', 6000.00, 10500.0, 1),
('22334455667', 'Kleber Andrade', 'Rua G', NULL, 'Centro', 'Curitiba', 'PR', '80010000', '1987-08-08', 38, 'M', 4000.00, 6000.0, 0),
('33445566778', 'Larissa Oliveira', 'Rua H', NULL, 'Setor Bueno', 'Goiânia', 'GO', '74210020', '1993-02-01', 32, 'F', 4700.00, 9000.0, 1),
('44556677889', 'Marcos Teixeira', 'Rua I', NULL, 'Centro', 'Fortaleza', 'CE', '60060000', '1982-09-09', 43, 'M', 5200.00, 7800.0, 1),
('55667788990', 'Natália Pires', 'Rua J', 'Casa 3', 'Jardim', 'São Luís', 'MA', '65000000', '1990-12-12', 34, 'F', 4900.00, 8200.0, 0),
('66778899001', 'Otávio Reis', 'Rua K', NULL, 'Centro', 'Porto Alegre', 'RS', '90010000', '1979-03-30', 46, 'M', 6800.00, 9400.0, 1);

INSERT INTO TABELA_DE_PRODUTOS VALUES 
('1001', 'Suco de Laranja', 'Garrafa', '1L', 'Laranja', 5.50),
('1002', 'Suco de Uva', 'Caixa', '1L', 'Uva', 6.00),
('1003', 'Suco de Maçã', 'Garrafa', '500ml', 'Maçã', 4.50),
('1004', 'Suco de Abacaxi', 'Caixa', '1L', 'Abacaxi', 5.80),
('1005', 'Suco de Pêssego', 'Lata', '350ml', 'Pêssego', 3.20),
('1006', 'Suco de Manga', 'Garrafa', '1,5L', 'Manga', 6.50),
('1007', 'Suco de Limão', 'Caixa', '1L', 'Limão', 4.90),
('1008', 'Suco de Acerola', 'Garrafa', '1L', 'Acerola', 6.20),
('1009', 'Suco de Goiaba', 'Lata', '350ml', 'Goiaba', 3.70),
('1010', 'Suco de Maracujá', 'Garrafa', '1L', 'Maracujá', 5.60),
('1011', 'Suco de Frutas Vermelhas', 'Caixa', '1L', 'Frutas Vermelhas', 7.00),
('1012', 'Suco Detox', 'Garrafa', '500ml', 'Detox', 6.90),
('1013', 'Suco Verde', 'Garrafa', '1L', 'Clorofila', 7.20),
('1014', 'Suco de Melancia', 'Caixa', '1L', 'Melancia', 5.10),
('1015', 'Suco de Caju', 'Lata', '350ml', 'Caju', 3.80);