$(document).ready(function () {
    if ($("input[name='IETipoEstacionamento']").val() == 'RESIDENCIAGARAGEM' || $("input[name='Proposta.IETipoEstacionamento']").val() == 'RESIDENCIAGARAGEM') {
        $('#IETipoPortao').show();
        $('.IETipoPortao').show();
    } else {
        $('#IETipoPortao').hide();
        $('.IETipoPortao').hide();
    }

    if ($("input[name='IEUtilizacaoVeiculoTrabalho']").is(':checked') || $("input[name='Proposta.IEUtilizacaoVeiculoTrabalho']").is(':checked')) {
        $('#IELocalGaragemTrabalho').show();
        $('#IEDistanciaParaTrabalhoVeiculo').show();
    } else {
        $('#IELocalGaragemTrabalho').hide();
        $('#IEDistanciaParaTrabalhoVeiculo').hide();
    }

    if ($("input[name='IEUtilizacaoVeiculoEstudo']").is(':checked') || $("input[name='Proposta.IEUtilizacaoVeiculoEstudo']").is(':checked')) {
        $('#IELocalGaragemEstudo').show();
    }
    else {
        $('#IELocalGaragemEstudo').hide();
    }

    

    

    //exclusivo de detalhes
    if ($("#IEUtilizacaoVeiculoEstudoDetalhes").val() == 'True') {
        $('#IELocalGaragemEstudo').show();
    }
    else if ($("#IEUtilizacaoVeiculoInstrumento").val() == 'False') {
        $('#IELocalGaragemEstudo').hide();
    }

    if ($("#IEUtilizacaoVeiculoInstrumento").val() == 'True') {
        $('#IEUtilizacaoVeiculoInstrumentoForma').show();
    }
    else if ($("#IEUtilizacaoVeiculoInstrumento").val() == 'False') {
        $('#IEUtilizacaoVeiculoInstrumentoForma').hide();
    }

    if ($("#IEUtilizacaoVeiculoTrabalho").val() == 'True') {
        $('#IEUtilizacaoVeiculoTrabalhoDetalhes').show();
        $('#IELocalGaragemTrabalho').show();
        $('#IEDistanciaParaTrabalhoVeiculo').show();
    } else  if ($("#IEUtilizacaoVeiculoTrabalho").val() == 'False') {
        $('#IEUtilizacaoVeiculoTrabalhoDetalhes').hide();
        $('#IELocalGaragemTrabalho').hide();
        $('#IEDistanciaParaTrabalhoVeiculo').hide();
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
    $('#IEUtilizacaoVeiculoInstrumentoForma').toggle();
});


/***************************************************
    controles da pagina - Para Proposta na Apolice
****************************************************/
$("input[name='Proposta.IETipoEstacionamento']").on('click', function () {
    if ($(this).val() == 'RESIDENCIAGARAGEM') {
        $('#IETipoPortao').show();
    } else {
        $('#IETipoPortao').hide();
    }
});

$("input[name='Proposta.IEUtilizacaoVeiculoTrabalho']").on('click', function () {
    $('#IELocalGaragemTrabalho').toggle();
    $('#IEDistanciaParaTrabalhoVeiculo').toggle();
});

$("input[name='Proposta.IEUtilizacaoVeiculoEstudo']").on('click', function () {
    $('#IELocalGaragemEstudo').toggle();
});

$("input[name='Proposta.IEUtilizacaoVeiculoInstrumento']").on('click', function () {
    $('#IEUtilizacaoVeiculoInstrumentoForma').toggle();
});


//


if ($("#Proposta\\.IEUtilizacaoVeiculoInstrumento").val() == 'True') {
    $('#IEUtilizacaoVeiculoInstrumentoForma').show();
}
else {
    $('#IEUtilizacaoVeiculoInstrumentoForma').hide();
}

if ($("#Proposta\\.IEUtilizacaoVeiculoTrabalho").val() == 'True') {
    $('#IEUtilizacaoVeiculoTrabalhoDetalhes').show();
    $('#IELocalGaragemTrabalho').show();
    $('#IEDistanciaParaTrabalhoVeiculo').show();
} else {
    $('#IEUtilizacaoVeiculoTrabalhoDetalhes').hide();
    $('#IELocalGaragemTrabalho').hide();
    $('#IEDistanciaParaTrabalhoVeiculo').hide();
}