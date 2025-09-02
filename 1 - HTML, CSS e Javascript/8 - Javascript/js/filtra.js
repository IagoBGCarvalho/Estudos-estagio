var campoFiltro = document.querySelector("#filtrar-tabela");

campoFiltro.addEventListener("input", function () {
    var pacientes = document.querySelectorAll(".paciente");
    if (this.value.length > 0) { // Se o valor do campo de filtro for maior que 0, ou seja, se houver algo digitado no campo, adiciona a classe invisível aos pacientes que não correspondem ao filtro
        for (var i = 0; i < pacientes.length; i++) {
            var paciente = pacientes[i];
            var tdNome = paciente.querySelector(".info-nome");
            var nome = tdNome.textContent;
            var expressao = new RegExp(this.value, "i"); // Cria uma expressão regular com o valor do campo de filtro. O "i" indica que a busca será feita ignorando maiúsculas e minúsculas
            if (!expressao.test(nome)) { // Testa se o nome do paciente corresponde ao valor do campo de filtro, ignorando maiúsculas e minúsculas
                paciente.classList.add("invisivel");
            } else {
                paciente.classList.remove("invisivel");
            }
        }
    } else { // Se o campo de filtro estiver vazio, remove a classe invisível de todos os pacientes
        pacientes.forEach(function(paciente) {
            paciente.classList.remove("invisivel");
        });
    }
});