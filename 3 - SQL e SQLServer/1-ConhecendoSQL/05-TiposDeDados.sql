-- Tipos de dados em uma tabela (e seu armazenamento):

-- 1 - Números exatos: 

-- Números que não possuem casas decimais (bigint[8 bytes], int[4 bytes], smallint[2 bytes] e tinyint[1 bytes]).
-- Dentro dos números exatos, existem números que representam dinheiro (money[8 bytes] com duas casas decimais e smallmoney[4 bytes] com 4 casas decimais).
-- Não existem valores lógicos, mas bits que podem representar o sentido lógico (0 - FALSO e 1 - VERDADEIRO). O sqlserve suporta as palavras TRUE e FALSE também.

-- 2 - Números aproximados: Números com casas decimais previamente definidas

-- Ao definir números aproximados, é necessário informar o valor da precisão (P) e o valor da escala (S).
-- A precisão é o número completo. incluindo as casas decimais.
-- A escala representa somente o número de casas decimais. Ou seja, A escala é menor ou igual a precisão e maior ou igual a 0.
-- Os valores decimais são representados por float e real. Real suporta até 24 bits, já o float recebe um n que representa o número de bits.

-- 3 - Data e Hora:

-- DATE é o tipo que representa uma data em específico no banco e possui a formatação AAAA-MM-DD
-- DATETIME armazena a data (ano, mês e dia) e o horário (hora, minuto, segundo e microsegundo) e possui a formatação AAAA-MM-DD HH:MM:SS.MMM
-- TIME representa apenas a hora, mas com muito mais precisão, contendo até 7 microsegundos de precisão, possui o formato HH:MM:SS.MMMMMMM
-- DATETIMEOFFSET representa a data e hora, mas com alterações no fuso horário. O formato é AAAA-MM-DD HH:MM:SS.MMM +/- HH:MM

-- 4 - Cadeia de caracteres (Unicode e binários)

-- São textos representados dentro de uma tabela.
-- CHAR[0-8000 bytes] representa um texto com uma cadeia FIXA de caracteres. Mesmo que menos caracteres do que o limute forem informados, todos os espaços serão preenchidos.
-- VARCHAR[0-8000 bytes mas pode ser aumentado com MAX] é um char, mas com tamanho variável.
-- Os textos UNICODE são os textos que são representados utilizando a tabela de codificação UTF-16. Basta colocar um N antes do tipo para informar que ele está utilizando a codificação (NCHAR)