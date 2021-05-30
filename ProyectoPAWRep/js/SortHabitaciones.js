
function CreatePaginationObject(changed_order, changedsearchterms) {
    var PaginationObject = {};

    if ($("button[name=button-advanceSearch]").data("initializedb") == true) {
        PaginationObject.numero_paginas = $("[name=pagination-markup]").data("total-pages");
        PaginationObject.elementos_por_pagina = $("[name=pagination-markup]").data("elements-page");
        PaginationObject.order_by = $(".sorter.active").data("orderby");
        PaginationObject.direction = $(".sorter.active").data("sort").toUpperCase();
        PaginationObject.advanceSearch = "true";
        PaginationObject.changed_order = changed_order;
        var strings = $('input[name="formfechainiciofinalizacion"]').val().split(" - ");
        PaginationObject.fechaInicio = strings[0];
        PaginationObject.fechaFinalizacion = strings[1];
        PaginationObject.minPrecio = document.getElementsByName('min-value').value;
        PaginationObject.maxPrecio = document.getElementsByName('max-value').value;
        PaginationObject.numeroEstrellas = $('input[name="ASEstrellas"]').val();
        PaginationObject.changedsearchterms = changedsearchterms;


        if ($('input[name="ASMascotas"]').is(":checked")) {
            PaginationObject.mascotas = "1";
        } else {
            PaginationObject.mascotas = "0";
        }
        if ($('input[name="ASBañosDiscapacitados"]').is(":checked")) {
            PaginationObject.bañosPDiscapacitadas = "1";
        } else {
            PaginationObject.bañosPDiscapacitadas = "0";
        }
        PaginationObject.tamaño = $('select[name="ASTamaño"]').val();
        PaginationObject.numeroCamas = $("input[name='camasrange']").val();
    } else {
        if (changed_order) {
            PaginationObject.numero_paginas = $("[name=pagination-markup]").data("total-pages");
            PaginationObject.elementos_por_pagina = $("[name=pagination-markup]").data("elements-page");
            PaginationObject.order_by = $(".sorter.active").data("orderby");
            PaginationObject.direction = $(".sorter.active").data("sort").toUpperCase();
            PaginationObject.advanceSearch = "false";
            PaginationObject.changed_order = "true";
        } else {
            PaginationObject.pagina_actual = $("[name=button-page]:disabled").data("button-page");
            PaginationObject.numero_paginas = $("[name=pagination-markup]").data("total-pages");
            PaginationObject.elementos_por_pagina = $("[name=pagination-markup]").data("elements-page");
            PaginationObject.order_by = $(".sorter.active").data("orderby");
            PaginationObject.direction = $(".sorter.active").data("sort").toUpperCase();
            PaginationObject.advanceSearch = "false";
            PaginationObject.changed_order = "false";
        }
    }

    return PaginationObject;
}
function LoadHabitaciones(PaginationObject) {
    console.log('{paginationobj: ' + JSON.stringify(PaginationObject) + '}');
    $.ajax({
        type: "POST",
        url: "habitaciones.aspx/ActualizarInformacion",
        data: '{paginationobj: ' + JSON.stringify(PaginationObject) + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var strings = msg.d.split("<---CambioDePagina--->");
            $("div[name=habitaciones_cartas_lugar]").html(strings[0]);
            $("div[name=seccion_paginacion]").html(strings[1]);
            $(window).scrollTop(120);
            var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
            var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                return new bootstrap.Tooltip(tooltipTriggerEl)
            })
        }
    });
}
$("button[name=button-advanceSearch]").click(function () {
    if ($(this).data("initializedb") == false) {
        $(this).data("initializedb", true);
    }

    LoadHabitaciones(CreatePaginationObject(false, true));
});
$(".sorter").click(function () {
    object_clicked = $(this);
    object_with_sorter = $(".sorter.active");
    if (object_clicked.hasClass('active')) {
        switch (object_clicked.data("sort")) {
            case 'asc':
                object_clicked.children("i").removeClass('fa fa-sort-numeric-up-alt');
                object_clicked.children("i").addClass('fa fa-sort-numeric-down-alt');
                object_clicked.data("sort", 'desc');
                break;
            case 'desc':
                object_clicked.children("i").removeClass('fa fa-sort-numeric-down-alt');
                object_clicked.children("i").addClass('fa fa-sort-numeric-up-alt');
                object_clicked.data("sort", 'asc');
                break;
        }
    } else {
        object_with_sorter.removeData("sort");
        object_with_sorter.removeClass("active");
        object_with_sorter.children("i").remove();

        object_clicked.prepend('<i class="fa fa-sort-numeric-up-alt" aria-hidden="true"></i> ');
        object_clicked.data("sort", 'asc');
        object_clicked.addClass('active');
    }

    LoadHabitaciones(CreatePaginationObject(true, false));
});

$('[name=seccion_paginacion]').on('click', "button[name=button-page]", function () {
    var PaginationObject = CreatePaginationObject(false,false);
    PaginationObject.pagina_a_cargar = $(this).data("button-page");
    LoadHabitaciones(PaginationObject);
});

$('[name=seccion_paginacion]').on('click', "button[name=button-pagination-before]", function () {
    var pagina_actual = $("[name=button-page]:disabled").data("button-page");
    var PaginationObject = CreatePaginationObject(false, false);
    PaginationObject.pagina_a_cargar = parseInt(pagina_actual) - 1;
    LoadHabitaciones(PaginationObject);
});

$('[name=seccion_paginacion]').on('click', "button[name=button-pagination-after]", function () {
    var pagina_actual = $("[name=button-page]:disabled").data("button-page");
    var PaginationObject = CreatePaginationObject(false, false);
    PaginationObject.pagina_a_cargar = parseInt(pagina_actual) + 1;
    LoadHabitaciones(PaginationObject);
});