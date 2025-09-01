var botaoAdicionar = document.querySelector("#adicionar-paciente");

botaoAdicionar.addEventListener("click", function () {
    event.preventDefault(); // Previne o comportamento padrão do botão (recarregar a página)

    var form = document.querySelector("#form-adiciona"); // O query selector consegue retornar os inputs do formulário
    var paciente = obtemPacienteDoFormulario(form); // Declara uma variável paciente que recebe o objeto paciente

    // Cria a tr e as tds do paciente
    var pacienteTr = montaTr(paciente);

    // Faz a validação do paciente
    var erros = validaPaciente(paciente);
    console.log(erros);
    if (erros.length > 0) {
        exibeMensagensDeErro(erros);
        return; // Sai da função sem adicionar o paciente na tabela
    } 

    // Adicionando paciente na tabela
    var tabela = document.querySelector("#tabela-pacientes"); // Seleciona a tabela
    tabela.appendChild(pacienteTr); // Adiciona a nova linha na tabela

    form.reset(); // Limpa o formulário após adicionar o paciente
    document.querySelector("#mensagens-erro").innerHTML = ""; // Limpa as mensagens de erro após adicionar o paciente
});

function exibeMensagensDeErro(erros) {
    /**
     * Adiciona as lis na ul de mensagens de erro utilizando a array de erros
     */
    var ul = document.querySelector("#mensagens-erro"); // Seleciona a ul onde as mensagens de erro serão exibidas
    ul.innerHTML = ""; // Permite controlar o html interno de um elemento. Está limpando a ul antes de adicionar as novas mensagens de erro
    erros.forEach(function(erro) { // Para cada erro na array de erros, executa a função anônima
        var li = document.createElement("li");
        li.textContent = erro;
        ul.appendChild(li);
    })
}

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
     * Monta a tr (table row) do paciente e adiciona a sua respectiva classe para que ela possa ser adicionada na tabela.
     */
    var pacienteTr = document.createElement("tr"); // Cria um elemento tr (table row) que representa uma linha da tabela
    pacienteTr.classList.add("paciente"); // Adiciona a classe "paciente" à trs

    pacienteTr.appendChild(montaTd(paciente.nome, "info-nome")); // Cria um elemento td (table data) que representa uma célula da tabela e torna as tags td filhas da tag tr
    pacienteTr.appendChild(montaTd(paciente.peso, "info-peso"));
    pacienteTr.appendChild(montaTd(paciente.altura, "info-altura"));
    pacienteTr.appendChild(montaTd(paciente.gordura, "info-gordura"));
    pacienteTr.appendChild(montaTd(paciente.imc, "info-imc"));

    return pacienteTr;
}

function montaTd(dado, classe) {
    /**
     * Cria uma td (table data) e adiciona o dado de input e a classe passados como parâmetro
     */
    var td = document.createElement("td");
    td.textContent = dado;
    td.classList.add(classe);

    return td;
}

function validaPaciente(paciente) {
    /**
     * Valida os dados do paciente
     */
    var erros = []; // Declaração de uma lista ou array

    if (paciente.nome.length == 0) {
        erros.push("O nome não pode estar em branco");
    }

    if (!validaPeso(paciente.peso)) {
        erros.push("Peso é inválido"); // Adiciona a mensagem de erro ao array erros
    }

    if (paciente.peso.length == 0) {
        erros.push("O peso não pode estar em branco");
    }

    if (!validaAltura(paciente.altura)) {
        erros.push("Altura é inválida");
    }

    if (paciente.altura.length == 0) {
        erros.push("A altura não pode estar em branco");
    }

    if (paciente.gordura.length == 0) {
        erros.push("A gordura não pode estar em branco");
    }

    return erros;
}