-- O comando que altera propriedades do banco é o ALTER, então para alterar propriedades da tabela, é necessário utilizar ALTER TABLE, que recebe o nome da tabela.
-- A chaves primária possui regras específicas sobre a inserção de dados na tabela, pois ela não permite que mais de uma linha com a mesma chave seja inserida na tabela (visto que a chave primária é o identificador de cada linha)
-- Essas regras, em banco de dados, se chamam de "CONSTRAINT", e é, justamente, uma constraint que o ALTER TABLE irá adicionar na tabela:

--ALTER TABLE TABELA_DE_PRODUTOS ADD CONSTRAINT PK_TABELA_DE_PRODUTOS
--PRIMARY KEY CLUSTERED(CODIGO_DO_PRODUTO); 

-- Quando o campo não recebe 'NOT NULL' na sua definição, ele se trata de um campo ANULÁVEL (que pode receber nulo como dado) e a constraint chave primária NÃO PODE ser utilizada em campos anuláveis

-- Então é necessário alterar a coluna para ela não aceitar nulos e, depois, tentar novamente alterar a chave primária.

ALTER TABLE TABELA_DE_PRODUTOS ALTER COLUMN CODIGO_DO_PRODUTO VARCHAR(20) NOT NULL; -- Alter table para acessar as propriedades da tabela, depois alter column para as propriedades das colunas da tabela e depois o nome da coluna, seguido pelo seu tipo (que pode permanecer o mesmo) e demais alterações (no caso, a alteração para NOT NULL).

-- Depois do ALTER COLUMN a coluna CODIGO_DO_PRODUTO já está preparada para receber a CONSTRAINT Primary Key:

ALTER TABLE TABELA_DE_PRODUTOS ADD CONSTRAINT PK_TABELA_DE_PRODUTOS -- É convenção utilizar "PK_NOME_TABELA" como nome da constraint chave primária
PRIMARY KEY CLUSTERED(CODIGO_DO_PRODUTO); -- Definindo o TIPO da CONSTRAINT, que é uma chave primária, e informando qual campo QUE JÁ EXISTE irá utilizar a restrição determinada

-- A partir de agora, sempre que um item com o mesmo código de um item já existente for ser inserido, a inserção será barrada pela regra da chave primária inserida no campo CODIGO_DO_PRODUTO