// 
// Pega referencias da View (nome)
var labelNome = document.querySelector("#lblNome");
var campoNome = document.querySelector("#campoNome");

// Pega referencias da View (dataNascimento)
var labelDate = document.querySelector("#lblDate");
var campoDate = document.querySelector("#campoDate");

// Pega referencias da View (email)
var labelEmail = document.querySelector("#lblEmail");
var campoEmail = document.querySelector("#campoEmail");

// Pega referencias da View (senha)
var labelSenha1 = document.querySelector("#lblSenha1");
var labelSenha2 = document.querySelector("#lblSenha2");
var campoSenha1 = document.querySelector("#campoSenha1");
var campoSenha2 = document.querySelector("#campoSenha2");

// Views Adicionais
var spnMensagem = document.querySelector("#spnMensagem");

// Adiciona evento 'onblur' ao campo 'Nome'
//
campoNome.addEventListener("oninput", function () {
    if (validaNome(campoNome)) {
        labelNome.style.color = "orangered";
        labelNome.innerHTML = "Nome: (Verifique)";

        spnMensagem.innerHMTL = "Verifique o campo 'Nome', pois não pode estar vazio!";
    }
    else {
        labelNome.style.color = "black";
        labelNome.innerHTML = "Nome:";
        spnMensagem.innerHMTL = "";
    }
}, true);


// Adiciona evento 'onblur' ao campo 'Email'
//
campoEmail.addEventListener("oninput", function () {
    if (validaEmail(campoEmail)) {
        labelNome.style.color = "orangered";
        labelNome.innerHTML = "Data de Nascimento: (Verifique)";

        spnMensagem.innerHMTL = "Verifique e corrija o campo 'Data de nascimento'";
    }
    else {
        labelNome.style.color = "black";
        labelNome.innerHTML = "Data de Nascimento:";
        spnMensagem.innerHMTL = "";
    }
}, true);

// Adiciona envento 'onblur' ao campo 'dataNascimento'
//
campoDate.addEventListener("onblur", function () {
    if (validaDate(campoDate)) {
        labelDate.style.color = "orangered";
        labelDate.innerHTML = "Data de Nascimento: (Verifique)";

        spnMensagem.innerHMTL = "Verifique e corrija o campo 'Data de nascimento'";
    }
    else {
        labelDate.style.color = "black";
        labelDate.innerHTML = "Data de Nascimento:";
        spnMensagem.innerHMTL = "";
    }
}, true);

// Adiciona envento 'onblur' ao campo 'confirmaSenha'
//
campoSenha2.addEventListener("oninput", function () {
    // Captura Valores
    var senha1 = campoSenha1.value;
    var senha2 = campoSenha1.value;

    if (senha1 !== senha2) {
        labelSenha1.style.color = "orangered";
        labelSenha2.style.color = "orangered";

        labelSenha1.innerHTML = "Senha: (Verifique)";
        labelSenha2.innerHTML = "Confirme a senha: (Verifique)";

        spnMensagem.innerHMTL = "Senhas não conferem! Corrija as senhas nos campos por favor.";
    }
    else {
        labelSenha1.style.color = "black";
        labelSenha2.style.color = "black";

        labelSenha1.innerHTML = "Senha:";
        labelSenha2.innerHTML = "Confirme a senha:";

        spnMensagem.innerHMTL = "";
    }
}, true);

/* ======== Conjunto de pequenas funções de validação ======== */
// Valida nome
function validaNome(inputField) {
    if (!validateNonEmpty(inputField))
        return false;
    if (validateRegEx("/^a-zA-Z$/", inputField.value))
        return false;
    return true;
}

// Valida formato da data de nascimento
function validaDate(inputField) {
    if (!validateNonEmpty(inputField))
        return false;

    if (validateRegEx("/^\d{2}\/\d{2)\/\d{2,4}$/", inputField.value))
        return false;

    return true;
}

// Valida formato do email
function validaEmail(inputField) {
    if (!validateNonEmpty(inputField))
        return false;
    if (validateRegEx("/^\w+@\w+\.\w{2,3}$/", inputField.value))
        return false;
    return true;
}

// Função que recebe e testa regex
function validateRegEx(regex, inputStr) {
    if (!regex.test(inputStr))
        return false;
    return true;
}

// Função que verifica se está vazio/nulo
function validateNonEmpty(inputField) {
    if (inputField.value.length === 0)
        return false;
    return true;
}