$(document).ready(function () {
    if ($("input[name='IEMotivoCotacao']:checked").val() == 'FAZERPRIMEIROSEGURO') {
        $('#IEMotivoCotacao1').show();
    } else if ($("input[name='IEMotivoCotacao']:checked").val() == 'RENOVARSEGURO') {
        $('#IEMotivoCotacao2').show();
    }

    if ($("input[name='Segurado.IEPossuiOutrosCarros']:checked").val() == 'SIM') {
        $('#IEQuantidadeCarro').show();
    }

    if ($("input[name='Segurado.IEProprietarioVeiculo']:checked").val() == 'NAO') {
        $('#Proprietario').show();
    }

});



$("input[name='IEMotivoCotacao']").on('click', function () {
    if ($(this).val() == 'FAZERPRIMEIROSEGURO') {
        $('#IEMotivoCotacao1').show();
    } else {
        $('#IEMotivoCotacao1').hide();
    }

    if ($(this).val() == 'RENOVARSEGURO') {
        $('#IEMotivoCotacao2').show();
    } else {
        $('#IEMotivoCotacao2').hide();
    }
});


$("input[name='Segurado.IEPossuiOutrosCarros']").on('click', function () {
    if ($(this).val() == "SIM") {
        $('#IEQuantidadeCarro').show();
    } else {
        $('#IEQuantidadeCarro').hide();
    }
});


$("input[name='Segurado.IEProprietarioVeiculo']").on('click', function () {
    if ($(this).val() == "NAO") {
        $('#Proprietario').show();
    } else {
        $('#Proprietario').hide();
    }
});