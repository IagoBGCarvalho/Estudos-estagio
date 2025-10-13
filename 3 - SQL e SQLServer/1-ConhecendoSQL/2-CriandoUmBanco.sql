--CREATE DATABASE SUCOS_VENDAS; -- Cria um banco de dados. Quando um comando SQL é utilizado, é necessário atualizar a árvore de arquivos para que as alterações fiquem à mostra

-- Utilizando o CREATE DATABASE sem mais informaçoes, o sistema operacional utiliza a localização padrão para alocar ele.
-- Ao instanciar o banco de dados pelo SQLServer, dois arquivos são criados, um .mdf e um log.ldf. O mdf se trata do arquivo de dados e o ldf é o arquivo de trasnsações. 
-- Transações são comandos que são registrados caso se queira recuperar um estado do banco

-- Para criar o bd em outro diretório:

CREATE DATABASE SUCOS_VENDAS -- Para mudar o diretório, é necessário inserir uma série de argumentos:
ON (NAME = 'SUCOS_VENDAS.DAT', -- Nome interno do bd no sistema
	FILENAME = 'C:\Users\iago.carvalho.REDEMPM\Downloads\temp\SUCOS_VENDAS.mdf', -- Caminho do diretório + nome do arquivo do banco
	SIZE = 10MB, -- Tamanho inicial do banco
	MAXSIZE = 50MB, -- Tamanho máximo que pode chegar
	FILEGROWTH = 5MB) -- Tamanho que ele ganha ao ultrapassar o tamanho inicial
LOG ON -- Agora são as especificações do que estará registrado no arquivo de log
(NAME = 'SUCOS_VENDAS.LOG',
	FILENAME = 'C:\Users\iago.carvalho.REDEMPM\Downloads\temp\SUCOS_VENDAS_log.ldf', -- Alteração de mdf para ldf
	SIZE = 10MB,
	MAXSIZE = 50MB,
	FILEGROWTH = 5MB);