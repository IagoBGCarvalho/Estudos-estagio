-- LIKE é utilizado para buscar um padrão de texto dentro de uma string, como um sobrenome específico dentro de um número
-- A sintaxe é: SELECT * FROM TABELA_DE_CLIENTES WHERE LIKE '%TESTE%';

-- A porcentagem no LIKE é o caractere coringa e possui comportamentos diferentes:
-- '%teste': Começa com qualquer texto, mas TERMINA com "teste"
-- 'teste%': Começa com "teste" mas termina com qualquer coisa
-- '%teste%': Começa com qualquer texto, tem "teste" no meio e termina com qualquer texto

SELECT * FROM TABELA_DE_CLIENTES WHERE ENDERECO1 LIKE 'Rua%'; -- Retorna todos os endereços que começam com "Rua" mas que terminam com qualquer texto