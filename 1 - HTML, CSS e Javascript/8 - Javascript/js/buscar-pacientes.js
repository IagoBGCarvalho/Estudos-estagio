var botaoAdicionar = document.querySelector("#buscar-pacientes");

botaoAdicionar.addEventListener("click", function () {
    console.log("Buscando pacientes...");
    fetch("js/pacientes.json") // Gera uma promisse assíncrona que pode representar pendência, sucesso ou erro.
        // Then é ativado caso a captura de dados for concluída com sucesso
        .then(response => response.json()) // Responde é um objeto que representa a resposta HTTP, o response.josn() é um método que pega o copro da resposta e a trasnforma de uma string para um array Javascript. Gera outra promisse.
        .then(pacientes => { // Caso a promisse do response.json seja bem sucedida, executa o processamento.
            pacientes.forEach(function (paciente) {
                var erroFetch = document.querySelector("#erro-fetch");
                erroFetch.classList.add("invisivel");
                var pacienteTr = montaTr(paciente); // Usa função do form.js
                var tabela = document.querySelector("#tabela-pacientes");
                tabela.appendChild(pacienteTr);
            });
        })
        .catch(function (error) { // Catch é ativado caso a entrega de dados não seja concluída com sucesso
            console.error("Erro ao buscar pacientes:", error);
            var erroFetch = document.querySelector("#erro-fetch");
            erroFetch.classList.remove("invisivel");
        });
});