$(document).ready(function () {
    if ($("input[name='IETipoEstacionamento']").val() == 'RESIDENCIAGARAGEM') {
        $('#IETipoPortao').show();
    }

    if ($("input[name='IEUtilizacaoVeiculoTrabalho']").is(':checked')) {
        $('#IELocalGaragemTrabalho').show();
        $('#IEDistanciaParaTrabalhoVeiculo').show();
    }

    if ($("input[name='IEUtilizacaoVeiculoEstudo']").is(':checked')) {
        $('#IELocalGaragemEstudo').show();
    }

});

//controles da pagina
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
    if ($(this).val() == "SIM") {
        $('#IEUtilizacaoVeiculoInstrumentoForma').show();
    } else {
        $('#IEUtilizacaoVeiculoInstrumentoForma').hide();
    }
});