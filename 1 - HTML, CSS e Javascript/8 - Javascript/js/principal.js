console.log(document); // Imprime o DOM (Document Object Model) no console. O DOM se trata de uma variável que contém os elementos dos arquivos HTML e CSS e que pode ser acessada e manipulada pelo js.

var titulo = document.querySelector(".titulo");// Seleciona o primeiro elemento que possui a classe "titulo" e o salva como uma variável chamada "título"
console.log(titulo.textContent); // Imprime o texto contido no elemento h1

titulo.textContent = "Aparecida Nutrição e Saúde"; // Altera o texto do elemento h1

/*IMC*/

// Paulo
var paciente = document.querySelector("#primeiro-paciente");

var tdPeso = paciente.querySelector(".info-peso");
var peso = tdPeso.textContent;

var tdAltura = paciente.querySelector(".info-altura");
var altura = tdAltura.textContent;

if (peso < o) {
    console.log("Peso inválido!);
}

if (peso > 1000) {
    console.log("Peso inválido!");
}

var imc = peso / (altura * altura);

var tdImc = paciente.querySelector(".info-imc");
tdImc.textContent = imc;