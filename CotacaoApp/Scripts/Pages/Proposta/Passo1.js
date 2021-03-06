﻿$(document).ready(function () {
    $('#CodigoCobertura').val($('#CodigoCoberturaHidden').val());
    var codigoCobertura = $('#CodigoCoberturaHidden').val();
    if (codigoCobertura !== undefined) {
        ObterCobertura(codigoCobertura);
    }
    //preencher select de marcas
    obterMarcasDeCarro('NomeMarcaVeiculoSelect', 'NomeMarcaVeiculoHidden');
    obterListaAnoFabricacao('AnoFabricacaoVeiculo', 'AnoFabricacaoVeiculoHidden');

    debugger;
    if ($('#NomeMarcaVeiculoDisplay').text().trim() != "")
    {
        obterMarcasDeCarroPorId($('#NomeMarcaVeiculoDisplay').text().trim(), 'NomeMarcaVeiculoDisplay');
    }
    $.support.cors = true;
});

/********************************
    Obter Descrição da cobertura
*********************************/
        $('#CodigoCobertura').on('change', function () {
            var Cobertura = {};
            Cobertura.Id = $(this).val();
            $.getJSON("/Proposta/ObterCobertura", Cobertura, ObterCoberturaCallBack);
        });

        //Obter Descrição da cobertura - ao carregar a pagina
        function ObterCobertura(codigoCobertura) {
            var Cobertura = {};
            Cobertura.Id = codigoCobertura;
            $.getJSON("/Proposta/ObterCobertura", Cobertura, ObterCoberturaCallBack);
            debugger;

        };

        var ObterCoberturaCallBack = function (data) {
            $("#coberturaDescricao").text(data);
            $("#coberturaDescricao").show();
        };

/********************************
    mudar ano do modelo
*********************************/
        $('#AnoFabricacaoVeiculo').on('change', function () {
            obterListaAnoModelo($(this).val(), 'AnoModeloVeiculoHidden');
            obterListaAnoModeloParaApolice($(this).val(), 'AnoModeloVeiculoHidden'); //Para Edit do Apolice
        });

/********************************
    carregar nomes dos modelos
*********************************/
        $('#NomeMarcaVeiculoSelect').on('change', function () {
            var codigoMarca = $(this).val();
            obterModelosDeCarro('NomeVeiculo', codigoMarca);
        });


/********************************
    Obter Descrição da cobertura
*********************************/
        function ObterCobertura(codigoCobertura) {
            var Cobertura = {};
            Cobertura.Id = codigoCobertura;
            $.getJSON("/Proposta/ObterCobertura", Cobertura, ObterCoberturaCallBack);
            debugger;

        };