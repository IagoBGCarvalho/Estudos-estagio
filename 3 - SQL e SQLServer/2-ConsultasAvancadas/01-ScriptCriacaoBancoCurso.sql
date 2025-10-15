-- Criando o arquivo do banco e de log:

ALTER DATABASE SUCOS_FRUTAS SET SINGLE_USER WITH ROLLBACK IMMEDIATE; -- Para forçar o banco de dados a encerrar todas as conexões
DROP DATABASE SUCOS_FRUTAS;

CREATE DATABASE SUCOS_FRUTAS
ON (NAME = 'SUCOS_FRUTAS.DAT',
	FILENAME = 'C:\Users\iago.carvalho.REDEMPM\Downloads\temp\SUCOS_FRUTAS.mdf',
	SIZE = 10MB,
	MAXSIZE = 50MB, 
	FILEGROWTH = 5MB) 
LOG ON 
(NAME = 'SUCOS_FRUTAS.LOG',
	FILENAME = 'C:\Users\iago.carvalho.REDEMPM\Downloads\temp\SUCOS_FRUTAS_log.ldf', 
	SIZE = 10MB,
	MAXSIZE = 50MB,
	FILEGROWTH = 5MB);