﻿$(document).ready(function () {
    if ($("input[name='IETipoEstacionamento']").val() == 'RESIDENCIAGARAGEM') {
        $('#IETipoPortao').show();
        $('.IETipoPortao').show();
    } else {
        $('#IETipoPortao').hide();
        $('.IETipoPortao').hide();
    }

    if ($("input[name='IEUtilizacaoVeiculoTrabalho']").is(':checked')) {
        $('#IELocalGaragemTrabalho').show();
        $('#IEDistanciaParaTrabalhoVeiculo').show();
    } else {
        $('#IELocalGaragemTrabalho').hide();
        $('#IEDistanciaParaTrabalhoVeiculo').hide();
    }

    if ($("input[name='IEUtilizacaoVeiculoEstudo']").is(':checked')) {
        $('#IELocalGaragemEstudo').show();
    }
    else {
        $('#IELocalGaragemEstudo').hide();
    }

    

    

    //exclusivo de detalhes
    if ($("#IEUtilizacaoVeiculoEstudoDetalhes").val() == 'True') {
        $('#IELocalGaragemEstudo').show();
    }
    else {
        $('#IELocalGaragemEstudo').hide();
    }

    if ($("#IEUtilizacaoVeiculoInstrumento").val() == 1) {
        $('#IEUtilizacaoVeiculoInstrumentoForma').show();
    }
    else {
        $('#IEUtilizacaoVeiculoInstrumentoForma').hide();
    }

    if ($("#IEUtilizacaoVeiculoTrabalho").val() == 'True') {
        $('#IELocalGaragemTrabalho').show();
        $('#IEDistanciaParaTrabalhoVeiculo').show();
    }
});


/********************************
    controles da pagina
*********************************/
$("input[name='IETipoEstacionamento']").on('click', function () {
    if ($(this).val() == 'RESIDENCIAGARAGEM') {
        $('#IETipoPortao').show();
    } else {
        $('#IETipoPortao').hide();
    }
});

$("input[name='IEUtilizacaoVeiculoTrabalho']").on('click', function () {
    $('#IELocalGaragemTrabalho').toggle();
    $('#IEDistanciaParaTrabalhoVeiculo').toggle();
});

$("input[name='IEUtilizacaoVeiculoEstudo']").on('click', function () {
    $('#IELocalGaragemEstudo').toggle();
});

$("input[name='IEUtilizacaoVeiculoInstrumento']").on('click', function () {
    if ($(this).val() == "1") {
        $('#IEUtilizacaoVeiculoInstrumentoForma').show();
    } else {
        $('#IEUtilizacaoVeiculoInstrumentoForma').hide();
    }
});