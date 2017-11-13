// PRECISA ARRUMAR ESTE
function mudaStatus(usuarioId) {
    var url = "@Url.Action(\"MudaStatus\", \"Usuario\")";
    var params = { id: usuarioId };
    $.post(url, params, atualiza);
}

// PRECISA ARRUMAR ESTE
function atualiza(resposta) {
    var colunaStatus = $("#status" + resposta.usuarioId);
    if (resposta.Ativo.Equals("1")) {
        colunaStatus.html("Ativo");
    }
    else {
        colunaStatus.html("Desativado");
    }
}