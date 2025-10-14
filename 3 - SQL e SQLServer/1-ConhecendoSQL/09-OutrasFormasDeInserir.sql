-- No INSERT normal, é necessário especificar os campos a serem preenchidos e os valores a serem alocados (não precisam estar, necessariamente, na ordem da tabela)
-- Mas quando os valores a serem inseridos estão, no campo VALUES, na mesma ordem que os campos da tabela, é possível omitir os campos:
INSERT INTO TABELA_DE_PRODUTOS
VALUES
(
'1004327',
'Videira do Campo - 1,5 Litros - Melância',
'PET',
'1.5 Litros',
'Melância',
19.51
);

-- Também é possível aninhar inserções no mesmo insert, casa possua a correspondência de ordem:
INSERT INTO TABELA_DE_PRODUTOS
VALUES
(
'1088126',
'Liha Citros - 1 Litro - Limão',
'PET',
'1 Litro',
'Limão',
7
), -- O parêntese é seguido por uma vírgula e pelo novo parêntese que representa a próxima inserção
(
'544931',
'Frescor do Verão - 350 ml - Limão',
'Lata',
'350 ml',
'Limão',
2.46
);