$(document).ready(function () {

    $(".cpf").inputmask("999.999.999-99");
    $(".cep").inputmask("99.999-999");
    $(".email").inputmask({ alias: "email" });
    $(".telefone").inputmask("(99) 9999-99999");

    $('.datepicker').datepicker({
        format: 'dd/mm/yyyy',
        autoclose: true,
        startDate: new Date()
    });

    $(".dateDisplayFormat").each(function () {
        var datas = $(this).text().trim().split("-");
        $(this).text(datas[2] + "/" + datas[1] + "/" + datas[0])
    });

});

//VALIDACAO COMPORTAMENTO PADRAO
$.validator.setDefaults({
    highlight: function (element) {
        $(element).closest('.form-group').addClass('has-error');
    },
    unhighlight: function (element) {
        $(element).closest('.form-group').removeClass('has-error');
    },
    errorElement: 'span',
    errorClass: 'help-block',
    errorPlacement: function (error, element) {
        if (element.parent('.input-group').length) {
            error.insertAfter(element.parent());
        } else {
            error.insertAfter(element);
        }
    }
});


SubmittingForm = function () {
    //Validate Statements...
    validForm = true;
    $("#Proposta").submit();
}


/*****************************
*   CAMPOS QUE SERÃO VALIDADOS
******************************/
$("#Proposta").validate({
    submitHandler: function (form) {
        if (validForm)
            $("#Proposta").submit();
        else
            SubmittingForm();
    },
    rules: {
        /*fazer igual o exemplo para todos os campos obrigatórios do formulario, ou seja, todos que apresentam asterisco.
          Será necessário fazer nos 5 passos*/
        //EXEMPLO para o campo CodigoCobertura - INICIO
        CodigoCobertura: {
            required: true
        },
        AnoFabricacaoVeiculo: {
            required: true
        },
        NomeMarcaVeiculo: {
            required: true
        },
        AnoModeloVeiculo: {
            required: true
        },
        IEZeroKM: {
            required: true
        },
        NomeVeiculo: {
            required: true
        },
        IEFinanciadoVeiculo: {
            required: true
        },
        IEAlarmeVeiculo: {
            required: true
        },
        //============ PASSO 2 =============
        IETipoEstacionamento: {
            required: true
        },
        IeTipoPortao: {
            required: true
        },
        CepEstacionamento: {
            required: true,
            cepcorreio: true
        },
        CepDeslocamento: {
            required: true,
            cepcorreio: true
        },
        //IEUtilizacaoVeiculoLazer: {
        //    required: true
        //},
        //IELocalGaragemTrabalho: {
        //    required: true
        //},
        //IEDistanciaParaTrabalhoVeiculo: {
        //    required: true
        //},
        IELocalGaragemEstudo: {
            required: true
        },
        //IEUtilizacaoVeiculoInstrumento: {
        //    required: true
        //},
        IEUtilizacaoVeiculoInstrumentoForma: {
            required: true
        },
        IeKmMedia: {
            required: true
        },
        CodigoCobertura: {
            required: true
        },
        AnoFabricacaoVeiculo: {
            required: true
        },
        NomeMarcaVeiculo: {
            required: true
        },
        AnoModelo: {
            required: true
        },
        IEZeroKM: {
            required: true
        },
        NomeVeiculo: {
            required: true
        },
        IEFinanciadoVeiculo: {
            required: true
        },
        IEAlarmeVeiculo: {
            required: true
        },
        // PASSO 3
        "Segurado.Nome": {
            required: true
        },
        "Segurado.DataNascimento": {
            required: true
        },
        "Segurado.IESexo": {
            required: true
        },
        "Segurado.IEEstadoCivil": {
            required: true
        },
        "Segurado.CodigoCpf": {
            required: true
        },
        "Segurado.NumeroCep": {
            required: true,
            cepcorreio: true
        },
        "Segurado.IEPossuiOutrosCarros": {
            required: true
        },
        "Segurado.IEQuantidadeCarro": {
            required: true
        },
        "Segurado.AnosDeCNH": {
            required: true
        },
        "Segurado.IEProprietarioVeiculo": {
            required: true
        },

        //Dodos do Proprietario
        "Proprietario.Nome": {
            required: true
        },
        "Proprietario.DataNascimento": {
            required: true
        },
        "Proprietario.IESexo": {
            required: true
        },
        "Proprietario.IERelacaoProprietario": {
            required: true
        },
        "Proprietario.IEEstadoCivil": {
            required: true
        },
        "Proprietario.CodigoCpf": {
            required: true
        },
        "Proprietario.NumeroCep": {
            required: true,
            cepcorreio: true
        },

        //Seguro Atual
        "IEMotivoCotacao": {
            required: true
        },
        "NomeSeguradoraAtual": {
            required: true
        },
        "DataApoliceAtualVencimento": {
            required: true
        },
        // PASSO 4
        "Segurado.IECondutorPrincipal": {
            required: true
        },
        "OutroCondutor.Nome": {
            required: true
        },
        "OutroCondutor.IESexo": {
            required: true
        },
        "OutroCondutor.IEEstadoCivil": {
            required: true
        },
        "OutroCondutor.CodigoCpf": {
            required: true
        },
        "OutroCondutor.IERelacaoProprietario": {
            required: true
        },
        "OutroCondutor.NumeroCep": {
            required: true,
            cepcorreio: true
        },
        "Segurado.IETipoResidencia": {
            required: true
        },
        "Segurado.Profissao": {
            required: true
        },
        "Segurado.IERoubadoEm24Meses": {
            required: true
        },
        "Segurado.IEAlgumCondutorEstuda": {
            required: true
        },
        "Segurado.Email": {
            required: true
        },
        "Segurado.Telefones[0].NumeroTelefone": {
            required: true
        }
    },
    messages: {
            required: "Campo Obrigatório"
        }
});