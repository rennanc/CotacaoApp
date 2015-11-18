$(document).ready(function () {
    var codigoCobertura = $('#CodigoCoberturaHidden').val();
    if (codigoCobertura !== undefined) {
        $('#CodigoCobertura').trigger('change');
    }
    //preencher select de marcas
    obterMarcasDeCarro('NomeMarcaVeiculoSelect', 'NomeMarcaVeiculoHidden');
    obterListaAnoFabricacao('AnoFabricacaoVeiculo', 'AnoFabricacaoVeiculoHidden');
    $.support.cors = true;

});


//Obter Descrição da cobertura
        $('#CodigoCobertura').on('change', function () {
            var Cobertura = {};
            Cobertura.Id = $(this).val();
            $.getJSON("/Proposta/ObterCobertura", Cobertura, ObterCobertura);
        });


//mudar ano do modelo
        $('#AnoFabricacaoVeiculo').on('change', function () {
            obterListaAnoModelo($(this).val(), 'AnoModeloVeiculoHidden');
        });

        var ObterCobertura = function (data) {
            $("#coberturaDescricao").val(data);
            $("#coberturaDescricao").show();
        };

//carregar nomes dos modelos
        $('#NomeMarcaVeiculoSelect').on('change', function () {
            var codigoMarca = $(this).val();
            obterModelosDeCarro('NomeVeiculo', codigoMarca);
        });