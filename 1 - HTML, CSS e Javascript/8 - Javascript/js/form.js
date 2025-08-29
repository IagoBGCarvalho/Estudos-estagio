var botaoAdicionar = document.querySelector("#adicionar-paciente");

botaoAdicionar.addEventListener("click", function () {
    event.preventDefault(); // Previne o comportamento padrão do botão (recarregar a página)

    var form = document.querySelector("#form-adiciona"); // O query selector consegue retornar os inputs do formulário
    var paciente = obtemPacienteDoFormulario(form); // Declara uma variável paciente que recebe o objeto paciente

    // Cria a tr e as tds do paciente
    var pacienteTr = montaTr(paciente);

    // Adicionando paciente na tabela
    var tabela = document.querySelector("#tabela-pacientes"); // Seleciona a tabela
    tabela.appendChild(pacienteTr); // Adiciona a nova linha na tabela
});

function obtemPacienteDoFormulario(form) {
    /**
     * Extrai as informações de input do formulário e as atribui a um objeto paciente
     */
    var paciente = { // Objeto paciente - objetos são estruturas que armazenam várias informações em uma única variável e que representam uma entidade do mundo real
        nome: form.nome.value, // Está aplicando as propriedades (nome, peso, altura e gordura) ao objeto paciente
        peso: form.peso.value,
        altura: form.altura.value,
        gordura: form.gordura.value,
        imc: calculaImc(form.peso.value, form.altura.value)
    }
    return paciente; // Retorna o objeto paciente e todas as suas propriedades
}

function montaTr(paciente) {
    /**
     * Monta a tr (table row) do paciente para que ela possa ser adicionada na tabela, assim como todas as tds (table data) que compõem a tr.
     */
    var pacienteTr = document.createElement("tr"); // Cria um elemento tr (table row) que representa uma linha da tabela

    var nomeTd = document.createElement("td"); // Cria um elemento td (table data) que representa uma célula da tabela)
    var pesoTd = document.createElement("td");
    var alturaTd = document.createElement("td");
    var gorduraTd = document.createElement("td");
    var imcTd = document.createElement("td");


    nomeTd.textContent = paciente.nome; // Adiciona o valor do input nome na célula nomeTd
    pesoTd.textContent = paciente.peso;
    alturaTd.textContent = paciente.altura;
    gorduraTd.textContent = paciente.gordura;
    imcTd.textContent = paciente.imc;

    pacienteTr.appendChild(nomeTd); // Torna as tags td filhas da tag tr
    pacienteTr.appendChild(pesoTd);
    pacienteTr.appendChild(alturaTd);
    pacienteTr.appendChild(gorduraTd);
    pacienteTr.appendChild(imcTd);

    return pacienteTr;
}