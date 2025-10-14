-- Tornando CPF não nulo e depois atribuindo a ele a constraint chave primária:
ALTER TABLE TABELA_DE_CLIENTES ALTER COLUMN CPF CHAR(11) NOT NULL;

ALTER TABLE TABELA_DE_CLIENTES ADD CONSTRAINT PK_TABELA_DE_CLIENTES
PRIMARY KEY CLUSTERED(CPF);

-- Inserindo dados na tabela de clientes:
INSERT INTO TABELA_DE_CLIENTES
VALUES
('00384393431','Joâo da Silva','Rua Projetada A','Numero 233','Copacabana',
'Rio de Janeiro','RJ','20000000','1965-03-21', -- Datas devem respeitar o formato AAAA-MM-DD e devem estar entre aspas simples
57,'M',20000,3000.30,1);