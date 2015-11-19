$(document).ready(function () {
    if ($("input[name='Segurado.IECondutorPrincipal']:checked").val() == 'OUTRAPESSOA') {
        $('#OutroCondutor').show();
    }

    //exclusivo para detalhes
    if ($("#SeguradoIECondutorPrincipalDetalhes").val() == 'OUTRAPESSOA') {
        $('#OutroCondutor').show();
    } else {
        $('#OutroCondutor').hide();
    }
});


$("input[name='Segurado.IECondutorPrincipal']").on('click', function () {
    if ($(this).val() == "OUTRAPESSOA") {
        $('#OutroCondutor').show();
    } else {
        $('#OutroCondutor').hide();
    }
});