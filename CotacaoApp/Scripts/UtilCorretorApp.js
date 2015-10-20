$('.cep').on('blur', function () {
    getEndereco($(this));


    $.validator.addMethod($(this).attr('id'), function (value, element) {
        return value == getEndereco($(this));

    }, 'Endereço não encontrado!');
});

function getEndereco(cepTag) {

    if ($.trim(cepTag.val()) != "") {

        $.getScript("//cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + cepTag.val(), function () {
            // o getScript dá um eval no script, então é só ler!
            //Se o resultado for igual a 1
            var retorno = false;
            if (resultadoCEP["resultado"]) {
                if (unescape(resultadoCEP["resultado_txt"]).indexOf("não encontrado") != -1) {


                    if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                        cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'>Endereço não encontrado</span>");
                    } else {
                        $('#' + cepTag.attr('id') + 'txtEndereco').text("Endereço não encontrado");
                    }
                    return false;

                } else {
                    // troca o valor dos elementos
                    var txtEndereco = unescape(resultadoCEP["tipo_logradouro"]) + " " + unescape(resultadoCEP["logradouro"]).trim();

                    if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                        cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'>" + txtEndereco + "</span>");
                    } else {
                        $('#' + cepTag.attr('id') + 'txtEndereco').text(txtEndereco);
                    }
                    return true;
                }
            } else {
                alert("Endereço não encontrado!");
                return false;
            }
            
        });
    }
}


///validação do cep
//function getEndereco() {
//    if ($.trim($("#txtCep").val()) != "") {
//        /* 
//        Para conectar no serviço e executar o json, precisamos usar a função
//        getScript do jQuery, o getScript e o dataType:"jsonp" conseguem fazer o cross-domain, os outros
//        dataTypes não possibilitam esta interação entre domínios diferentes
//        Estou chamando a url do serviço passando o parâmetro "formato=javascript" e o CEP digitado no formulário
//        //cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep="+$("#txtCep").val()
//        */

//        $("#txtEndereco").removeAttr('readonly');
//        $("#txtBairro").removeAttr('readonly');
//        $("#txtCidade").removeAttr('readonly');
//        $("#selEstado").removeAttr('disabled');

//        $.getScript("//cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + $("#txtCep").val(), function () {
//            // o getScript dá um eval no script, então é só ler!
//            //Se o resultado for igual a 1
//            if (resultadoCEP["resultado"]) {
//                if (unescape(resultadoCEP["resultado_txt"]).indexOf("não encontrado") != -1) {
//                    $("#txtEndereco").val("");
//                    $("#txtBairro").val("");
//                    $("#txtCidade").val("");
//                    $("#selEstado").val("");
//                    $("#txtEndereco").focus();
//                } else {
//                    // troca o valor dos elementos
//                    $("#txtEndereco").val(unescape(resultadoCEP["tipo_logradouro"]) + " " + unescape(resultadoCEP["logradouro"]));
//                    $("#txtEndereco").val($("#txtEndereco").val().trim());
//                    $("#txtBairro").val(unescape(resultadoCEP["bairro"]).trim());
//                    $("#txtCidade").val(unescape(resultadoCEP["cidade"]).trim());
//                    $("#selEstado").val(unescape(resultadoCEP["uf"]).trim());

//                    // bloquei campos que foram preenchidos
//                    if ($("#txtEndereco").val() != "") { $("#txtEndereco").prop('readonly', true) }
//                    if ($("#txtBairro").val() != "") { $("#txtBairro").prop('readonly', true) }
//                    if ($("#txtCidade").val() != "") { $("#txtCidade").prop('readonly', true) }
//                    if ($("#selEstado").val() != "") { $("#selEstado").prop('disabled', true) }

//                    // Seta o foco no primeiro campo sem preenchimento
//                    if ($("#txtEndereco").val() != "" && $("#txtBairro").val() != "" && $("#txtCidade").val() != "" && $("#selEstado").val() != "") {
//                        $("#txtNumero").focus();
//                    } else if ($("#txtEndereco").val() == "") {
//                        $("#txtEndereco").focus();
//                    } else if ($("#txtBairro").val() == "") {
//                        $("#txtBairro").focus();
//                    } else {
//                        $("#txtNumero").focus();
//                    }
//                }
//            } else {
//                alert("Endereço não encontrado!");
//            }
//        });
//    }
//}