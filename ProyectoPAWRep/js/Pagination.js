$("[name=button-page]").click(function () {
    var numero_paginas = $("[name=pagination-markup]").data("total-pages");
    var elementos_por_pagina = $("[name=pagination-markup]").data("elements-page");
    var pagina_actual = $("[name=button-page]:disabled").data("button-page");

    var pagina_a_cargar = $(this).data("button-page");

    var PaginationObject = {};
    PaginationObject.pagina_actual = $("[name=button-page]:disabled").data("button-page");
    PaginationObject.numero_paginas = $("[name=pagination-markup]").data("total-pages");
    PaginationObject.elementos_por_pagina = $("[name=pagination-markup]").data("elements-page");
    PaginationObject.pagina_a_cargar = $(this).data("button-page");
    PaginationObject.advanceSearch = "false";

    $.ajax({
        type: "POST",
        url: "habitaciones.aspx/SayHello",
        data: '{paginationobj: ' + JSON.stringify(PaginationObject) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            alert(msg.d);
        }
    });
});