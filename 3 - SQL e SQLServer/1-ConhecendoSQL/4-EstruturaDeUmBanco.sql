-- Estruturas de um banco de dados

-- 1 - Tabela:

-- Uma tabela é uma estrutura que se assemelha a uma planilha e que possui regras específicas dentro de um conceito de banco de dados.
-- Ela representa um objeto do mundo real, como um cliente, e possui atributos que representam essa instância do mundo real, mas em código.

-- Uma tabela possui colunas (campos) e linhas (registros).

-- Uma tabela pode conter uma quantidade n de registros, se limitando apenas à capacidade de armazenamento do servidor.
-- Já o número de campos é determinado na definição da tabela e deve ser imutável. Cada campo deve ter um nome próprio e deve representar um atributo do objeto representado na tabela.

-- Campos possuem definições rígidas, tais como:

-- 1: O tipo de cada campo deve ser único, ou seja, todos os elementos de um mesmo campo devem possuir o mesmo tipo de dado.
-- 2: Para alguns tipos, o tamanho deve ser previamente especificado, como um campo de texto.
-- 3: Deve informar se a coluna aceita ou não valores vazios.
-- 4: Pode ter um valor padrão.

-- Chaves primárias e estrangeiras:

-- Um campo de chave se trata de um campo que é utilizado como identificador na tabela, ou seja, um campo que atribui uma identidade a um registro específico.
-- Uma chave primária se trata da identificação dos registros da tabela em si, não podendo conter valores repetidos. Dois usuários não poderiam ter o mesmo ID em um sistema, por exemplo.

-- Por se tratar de um banco relacional, as tabelas podem estabelecer relações entre si, e essas relações são estabelecidas através da chave estrangeira.
-- Ela é uma chave primária de outra tabela que é implementada para estabelecer uma relação entre dois campos de tabelas diferentes. Estes campos devem ter as mesmas propriedades.
-- Ou seja, a chave estrangeira liga o campo de uma tabela com a chave primária de outra tabela através de uma relação de cardinalidade de 1:N (1 para vários)
-- Por exemplo, uma tabela de clientes que contém um campo relacionado ao estado de origem do cliente possui uma chave estrangeira de outra tabela que trata, exclusivamente, de estados, onde a chave primária desta tabela se trata dos estados em si.
-- Isso força o campo estados da tabela cliente a ter, necessariamente, um valor que está presente como chave primária da tabela de estados.
-- Ou seja, N registros do campo estados deve estar ligado a 1 registro da chave primária da tabela de estados (1:N ou 1 para N)

-- 2 - índice:

-- O índice é uma estrutura que auxilia a fazer buscas mais rápidas associadas à coluna. Uma tabela pode ter 1 ou mais índices associados a diferentes campos.
-- Caso uma tabela não tenha um índice associado, será feito um teste para cada linha da tabela, e apenas ao final deste teste que o sql server irá retornar o resultado, consumindo muito poder computacional.
-- Toda chave primária possui, necessariamente, um índice associado.

-- 3 - Visões:

-- Se tratam de tabelas lógicas, não existem fisicamente no banco, mas é possível olhar e analisar elas como se fossem tabelas físicas
-- Uma visão é criada estando associada ao resultado de consulta (que exibe uma tabela ou informações de 1 ou mais tabelas).
-- Tudo é feito na memória RAM e está sujeito a alterações, pois primeiro o SQL resolva a consulta e depois a visão em si

-- 4 - Procedimentos ou funções:

-- O SQL, nativamente, não possui diversas ferramentas de linguagens de programação, como estruturas de repetição...
-- Porém compensaram isso juntando comandos de repetição com comandos SQL e desenvolvendo uma própria linguagem para esses fins.
-- Um exemplo de linguagem SQL com procedimentos e funções é a TRANSACT SQL

-- 5 - Gatilhos:

-- São regras criadas no banco para executar certos comandos em determinadas situações (eventos), podendo ser comandos SQL ou TRANSACT.
-- Um exemplo de evento seria: "Ao incluir dados em uma tabela, faça determinados comandos..."
