var titulo = document.querySelector(".titulo");
titulo.textContent = "Aparecida Nutricionista";

var pacientes = document.querySelectorAll(".paciente");

for(var i = 0;i < pacientes.length; i++){

    var paciente = pacientes[i];

    var peso = paciente.querySelector(".info-peso").textContent;
    var altura = paciente.querySelector(".info-altura").textContent;7
    var tdImc = paciente.querySelector(".info-imc");

    var pesoEhValido = validaPeso(peso);
    var alturaEhValida = validaAltura(altura);

    if(!pesoEhValido){
        tdImc.textContent = "Peso inválido!";
    }
    if(!alturaEhValida){
        tdImc.textContent = "Altura inválida!";
    }

    if(pesoEhValido && alturaEhValida){
        var imc = calculaImc(peso,altura);
        tdImc.textContent = imc;
    }else{
        paciente.classList.add("paciente-invalido");
    }
}

function calculaImc(peso,altura){
    var imc = 0;
    imc = peso / (altura*altura);
    return imc.toFixed(2);
}

function validaPeso(peso){
    return (peso >= 0 && peso < 1000);
}

function validaAltura(altura){
    return (altura >= 0 && altura < 3);
}