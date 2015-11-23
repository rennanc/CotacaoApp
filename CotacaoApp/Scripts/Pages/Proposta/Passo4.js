$(document).ready(function () {
    if ($("input[name='Segurado.IECondutorPrincipal']:checked").val() == 'OUTRAPESSOA' || $("input[name='Proposta.Segurado.IECondutorPrincipal']:checked").val() == 'OUTRAPESSOA') {
        $('#OutroCondutor').show();
    }

    //exclusivo para detalhes
    if ($("#SeguradoIECondutorPrincipalDetalhes").val() == 'OUTRAPESSOA') {
        $('#OutroCondutor').show();
    } else {
        $('#OutroCondutor').hide();
    }
});


/********************************
    controles da pagina
*********************************/

$("input[name='Segurado.IECondutorPrincipal']").on('click', function () {
    if ($(this).val() == "OUTRAPESSOA") {
        $('#OutroCondutor').show();
    } else {
        $('#OutroCondutor').hide();
    }
});


/***************************************************
    controles da pagina - Para Proposta na Apolice
****************************************************/

$("input[name='Proposta.Segurado.IECondutorPrincipal']").on('click', function () {
    if ($(this).val() == "OUTRAPESSOA") {
        $('#OutroCondutor').show();
    } else {
        $('#OutroCondutor').hide();
    }
});