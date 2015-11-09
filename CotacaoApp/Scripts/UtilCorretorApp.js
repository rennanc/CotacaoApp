var resultCep = false;
$('.cep').on('blur', function () {
    resultCep = false;
    getEndereco2($(this));
});


$.validator.addMethod('cepcorreio', function (value, element) {
    var cepTag = $('#' + element.id);
    if (!resultCep) {
        if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
            cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'></span>");
        } else {
            $('#' + cepTag.attr('id') + 'txtEndereco').text("");
        }
    }
    return resultCep;
}, 'Endereço não encontrado!');


function getEndereco(cepTag) {

    if ($.trim(cepTag.val()) != "") {

        $.getScript("//cep.republicavirtual.com.br/web_cep.php?formato=javascript&cep=" + cepTag.val(), function () {
            // o getScript dá um eval no script, então é só ler!
            //Se o resultado for igual a 1
            var retorno = false;
            if (resultadoCEP["resultado"]) {
                if (unescape(resultadoCEP["resultado_txt"]).indexOf("não encontrado") != -1) {


                    //if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                    //    cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'>Endereço não encontrado</span>");
                    //} else {
                    //    $('#' + cepTag.attr('id') + 'txtEndereco').text("Endereço não encontrado");
                    //}
                    
                    
                    resultCep = false;
                    $('#CepEstacionamento').valid();
                    return false;

                } else {
                    // troca o valor dos elementos
                    var txtEndereco = unescape(resultadoCEP["tipo_logradouro"]) + " " + unescape(resultadoCEP["logradouro"]).trim();

                    if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                        cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'>" + txtEndereco + "</span>");
                    } else {
                        $('#' + cepTag.attr('id') + 'txtEndereco').text(txtEndereco);
                    }
                    resultCep = true;
                    $('#CepEstacionamento').valid();
                    return true;
                }
            } else {
                resultCep = false;
                return false;
            }
            
        });
    }
}



function getEndereco2(cepTag) {

    if ($.trim(cepTag.val()) != "") {

        //$.getScript("//cep.correiocontrol.com.br/" + cepTag.val().replace("-","").replace(".","") + ".json", function (data) {
        $.getJSON("//cep.correiocontrol.com.br/" + cepTag.val().replace("-", "").replace(".", "").replace("_", "") + ".json", function (data) {
            // o getScript dá um eval no script, então é só ler!
            //Se o resultado for igual a 1
            var retorno = false;
            if (data) {
                if (data.erro) {


                    if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                        cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'></span>");
                    } else {
                        $('#' + cepTag.attr('id') + 'txtEndereco').text("");
                    }
                    resultCep = false;
                    cepTag.valid();
                    return false;

                } else {
                    // troca o valor dos elementos
                    var txtEndereco = unescape(data.logradouro) + " - " + unescape(data.bairro).trim() + " - " + unescape(data.cidade).trim() + "/" + unescape(data.uf);

                    if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                        cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'>" + txtEndereco + "</span>");
                    } else {
                        $('#' + cepTag.attr('id') + 'txtEndereco').text(txtEndereco);
                    }
                    resultCep = true;
                    cepTag.valid();
                    return true;
                }
            } else {
                if ($.find('#' + cepTag.attr('id') + 'txtEndereco')[0] == null) {
                    cepTag.parent().append("<span id='" + cepTag.attr('id') + "txtEndereco' class='help-block'></span>");
                } else {
                    $('#' + cepTag.attr('id') + 'txtEndereco').text("");
                }
                resultCep = false;
                return false;
            }

        });
    }
}



function obterMarcasDeCarro(){
    $.getJSON("../Scripts/json/marcas.json", function (data) {
        var selectMarcas = "";
        if (data) {
            $.each(data, function (i, marca) {
                $('#NomeMarcaVeiculo').append($('<option>', {
                    value: marca.id,
                    text: unescape(marca.name).trim()
                }));
            });
        }
    });
}

function obterListaAnoFabricacao() {
    var dataHoje = new Date();
    for (i = 2000; i <= dataHoje.getFullYear(); i++) {
        $('#AnoFabricacaoVeiculo').append($('<option>', {
            value: i,
            text: i
        }));
    }
}

function obterListaAnoModelo(ano) {
    ano = parseInt(ano, 10);
    var anosModelo = "";
    for (i = ano; i <= ano + 1; i++) {
        anosModelo += '<input type="radio"  name="AnoModeloVeiculo" id="AnoModeloVeiculo" value="' + i + '"> ' + i + ' ';
    }
    $('#AnoModeloVeiculoRadios').html(anosModelo);
    $('#AnoModeloVeiculoField').show();
}

function obterModelosDeCarro(campoId, codigoMarca) {
    
    $.getJSON("//fipeapi.appspot.com/api/1/carros/veiculos/" + codigoMarca + ".json?format=json&callback=?", function (data) {

        var source = [];
        var typeahead = $('#NomeVeiculo').data('typeahead');
        if (data) {
            $.each(data, function (i, modelo) {
                source.push(modelo.name);
            });
        }

        if (typeahead) typeahead.source = source;
        else $('#NomeVeiculo').typeahead({ source: source });

     });
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