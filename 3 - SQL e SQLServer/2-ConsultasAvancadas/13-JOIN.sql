-- Quando se quer consultar campos diferentes de tabelas diferentes, é necessário criar uma tabela que contenha os campos de ambas as tabelas desejadas
-- Para criar uma tabela lógica que desempenha essa função, utiliza-se o JOIN 

-- INNERs possuem mais desempenho quando associados a índices, e já que as chaves primárias geram índices na sua criação, fazer um INNER com chaves otimiza muito o trabalho

SELECT * FROM TABELA_DE_VENDEDORES;
SELECT * FROM NOTAS_FISCAIS; -- A tabelas de notas possui uma chave estrangeira MATRICULA_VENDEDOR que aponta para a chave primária MATRICULA da tabela de vendedores, logo serão os campos utilizados no J0IN

SELECT MATRICULA_VENDEDOR, COUNT(*) AS NUMERO_NOTAS FROM NOTAS_FISCAIS GROUP BY MATRICULA_VENDEDOR; -- Retorna o número de notas emitidas por vendedor, mas não possui campos comoo nome, pois esses dados estão em TABELA_VENDEDORES e não em NOTAS_FISCAIS...

-- Pra resolver isso, utiliza-se uma view, que cria uma tabela lógica que junta outras duas tabelas, tornando possível retornar diferentes colunas de diferentes tabelas na mesma consulta:

SELECT NOTAS_FISCAIS.MATRICULA_VENDEDOR, TABELA_DE_VENDEDORES.NOME, COUNT(*) AS NUMERO_DE_NOTAS_EMITIDAS 
FROM NOTAS_FISCAIS 
INNER JOIN TABELA_DE_VENDEDORES -- Começa a fazer o JOIN a partir da tabela de vendedores (tanto faz...)
ON NOTAS_FISCAIS.MATRICULA_VENDEDOR = TABELA_DE_VENDEDORES.MATRICULA -- É necessário especificar qual campo será o campo de junção das tabelas, que deve ser um campo do mesmo tipo em ambas as tabelas (no caso, a chave primária da tabela de vendedores que é uma chave estrangeira na tabela de notas)
GROUP BY MATRICULA_VENDEDOR, NOME;

-- É possível utilizar a renomeação temporária de tabelas para deixar o join mais limpo:
SELECT NF.MATRICULA_VENDEDOR, TV.NOME, COUNT(*) AS NUMERO_DE_NOTAS_EMITIDAS 
FROM NOTAS_FISCAIS NF -- NOTAS_FISCAIS renomeada para NF
INNER JOIN TABELA_DE_VENDEDORES TV -- TABELA_DE_VENDEDORES renomeada para TV
ON NF.MATRICULA_VENDEDOR = TV.MATRICULA 
GROUP BY MATRICULA_VENDEDOR, NOME;