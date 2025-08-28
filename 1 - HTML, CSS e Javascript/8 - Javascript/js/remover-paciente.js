var pacientes = document.querySelector("#tabela-pacientes");

pacientes.addEventListener("dblclick", function (event) {
  var paiAlvo = event.target.parentNode;
  paiAlvo.classList.add("fade-out");
  setTimeout(function () {
    paiAlvo.remove();
  }, 500);
});
