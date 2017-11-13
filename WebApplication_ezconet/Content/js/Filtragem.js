// Salva valor do contador original da busca
var contadorTexto = document.querySelector("#mostraContador");
var contadorOriginal = contadorTexto.textContent;

function LimpaFiltros() {
    // Recolhe dados a serem filtrados
    var campoFiltroNome = document.querySelector("#CampoFiltroNome");
    var campoFiltroAtivo = document.querySelector("#CampoFiltroAtivo");
    var contador = document.querySelector("#mostraContador");

    // Limpa campos de filtro
    campoFiltroNome.value = "";
    campoFiltroAtivo.value = 2;
    contador.textContent = contadorOriginal;

    // Carrega usuarios
    var usuarios = document.querySelectorAll(".usuario");

    // Percorre dataset retirando classes do filtro
    for (var i = 0; i < usuarios.length; i++) {
        var usuario = usuarios[i];
        usuario.classList.remove("fadeOutNome");
        usuario.classList.remove("fadeOutAtivo");
        usuario.classList.remove("invisivelAtivo");
        usuario.classList.remove("invisivelNome")
    }
}

function FiltraTabela() {
    // Recolhe dados a serem filtrados
    var campoFiltroNome = document.querySelector("#CampoFiltroNome");
    var campoFiltroAtivo = document.querySelector("#CampoFiltroAtivo");

    // Carrega usuarios
    var usuarios = document.querySelectorAll(".usuario");
    var usuario;
    var i;

    if (campoFiltroNome.value.length > 0) {
        FiltraPorNome(campoFiltroNome);
    }
    else {
        for (i = 0; i < usuarios.length; i++) {
            usuario = usuarios[i];
            usuario.classList.remove("fadeOutNome");
            usuario.classList.remove("invisivelNome");
        }
    }

    if (campoFiltroAtivo.value === 1 || campoFiltroAtivo.value === 0) {
        FiltraPorStatus(CampoFiltroAtivo);
    }
    else {
        for (i = 0; i < usuarios.length; i++) {
            usuario = usuarios[i];
            usuario.classList.remove("fadeOutAtivo");
            usuario.classList.remove("invisivelAtivo");
        }
    }
}

function FiltraPorStatus(CampoFiltroAtivo) {
    //Objeto usuario
    var usuarios = document.querySelectorAll(".usuario");
    var count = 0;
    var status = "";

    // Percorre todos os usuarios
    for (var i = 0; i < usuarios.length; i++) {
        // singular
        var usuario = usuarios[i];

        var tdAtivo = usuario.querySelector(".usuarioStatus");
        var ativo = tdAtivo.innerHTML;
        console.log("Ativo: " + ativo);

        // Troca valor booleano para valor descritivo
        if (CampoFiltroAtivo.value === 1) {
            status = "Ativo";
        } else {
            status = "Desativado";
        }
        console.log("status: " + status);
        console.log(ativo + " == " + status);

        // Compara valores descritivos
        if (ativo !== status) {
            console.log("Diferentes");
            usuario.classList.add("fadeOutAtivo");
            usuario.classList.add("invisivelAtivo");
        } else {
            count++;
            console.log("iguais");
            usuario.classList.remove("fadeOutAtivo");
            usuario.classList.remove("invisivelAtivo");
        }
    }
    console.log("acabou");
    var contador = document.querySelector("#mostraContador");
    contador.textContent = ("Foram encontrados " + count + " resultados.");
}



function FiltraPorNome(campoFiltroNome) {
    //Objeto usuario
    var usuarios = document.querySelectorAll(".usuario");
    var count = 0;

    // Percorre todos os usuarios
    for (var i = 0; i < usuarios.length; i++) {
        // singular
        var usuario = usuarios[i];

        var tdNome = usuario.querySelector(".usuarioNome");
        var nome = tdNome.textContent;
        var expressao = new RegExp(campoFiltroNome.value, "i");

        if (!expressao.test(nome)) {
            usuario.classList.add("invisivelNome");
        } else {
            count++;
            usuario.classList.remove("fadeOutNome");
            usuario.classList.remove("invisivelNome");
        }
    }
    var contador = document.querySelector("#mostraContador");
    contador.textContent = ("Foram encontrados " + count + " resultados.");
}