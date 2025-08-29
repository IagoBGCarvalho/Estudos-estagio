console.log(document); // Imprime o DOM (Document Object Model) no console. O DOM se trata de uma variável que contém os elementos dos arquivos HTML e CSS e que pode ser acessada e manipulada pelo js.

var titulo = document.querySelector(".titulo");// Seleciona o primeiro elemento que possui a classe "titulo" e o salva como uma variável chamada "título"
console.log(titulo.textContent); // Imprime o texto contido no elemento h1

titulo.textContent = "Aparecida Nutrição e Saúde"; // Altera o texto do elemento h1

/*IMC*/
var pacientes = document.querySelectorAll/*Seleciona todos os elementos com a mesma classe*/(".paciente");

for (var i = 0; i < pacientes.length; i++) {
    var paciente = pacientes[i];

    var tdPeso = paciente.querySelector(".info-peso");
    var peso = tdPeso.textContent;

    var tdAltura = paciente.querySelector(".info-altura");
    var altura = tdAltura.textContent;

    var tdImc = paciente.querySelector(".info-imc");

    var pesoEhValido = true;
    var alturaEhValida = true;

    // Tratamento de exceção
    if (peso <= 0 || /*or*/ peso >= 1000) {
        console.log("Peso inválido");
        pesoEhValido = false;
        tdImc.textContent = "Peso inválido";
        paciente.classList.add("paciente-invalido"); // Adiciona a classe "paciente-invalido" ao elemento paciente
    }

    if (altura <= 0 || altura >= 3.00) {
        console.log("Altura inválida");
        alturaEhValida = false;
        tdImc.textContent = "Altura inválida";
        paciente.classList.add("paciente-invalido");
    }

    if (pesoEhValido && /*and*/ alturaEhValida) {
        var imc = calculaImc(peso, altura);
        tdImc.textContent = imc; //toFixed(2) limita o número de casas decimais
    }
}

function calculaImc(peso, altura) {
    /**
     * Calcula o IMC de um paciente
     */
    var imc = 0;

    imc = peso / (altura * altura);
    return imc.toFixed(2);
}