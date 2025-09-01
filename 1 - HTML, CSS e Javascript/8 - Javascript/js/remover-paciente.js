var pacientes = document.querySelectorAll(".paciente");
var tabela = document.querySelector("#tabela-pacientes");

tabela.addEventListener("dblclick", function (event) { // Event retorna o objeto do evento que foi disparado
    var alvoEvento = event.target; // Retorna o elemento que recebeu o evento
    var paiDoAlvo = alvoEvento.parentNode; // Retorna o elemento pai do alvo (neste caso, a tr do paciente)
    paiDoAlvo.classList.add("fade-out");

    setTimeout(function () { // Define um tempo de espera para a execução da função, ou seja, para o fade out acontecer antes de remover o paciente
        paiDoAlvo.remove();
    },500); 
});