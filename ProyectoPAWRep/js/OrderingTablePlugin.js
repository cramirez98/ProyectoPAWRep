$('th[data-ordering="true"]').click(function () {
    var object_clicked = $(this);

    if (object_clicked.hasClass("active"))
    {
        if (object_clicked.attr("data-direction") == "DESC")
        {
            object_clicked.attr("data-direction", "ASC");
            if (object_clicked.attr("data-order") == "Mascotas" || object_clicked.attr("data-order") == "BañosPDiscapacitadas") {
                object_clicked.children("i").removeClass("far fa-square");
                object_clicked.children("i").addClass("far fa-check-square"); // Desc para cuando si hay posibilidad
            } else {
                object_clicked.children("i").removeClass("fas fa-sort-numeric-up");
                object_clicked.children("i").addClass("fas fa-sort-numeric-down");
            }
        }
        else
        {
            object_clicked.attr("data-direction", "DESC");
            if (object_clicked.attr("data-order") == "Mascotas" || object_clicked.attr("data-order") == "BañosPDiscapacitadas") {
                object_clicked.children("i").removeClass("far fa-check-square");
                object_clicked.children("i").addClass("far fa-square"); // ASC para cuando no hay posibilidad
            } else {
                object_clicked.children("i").removeClass("fas fa-sort-numeric-down");
                object_clicked.children("i").addClass("fas fa-sort-numeric-up");
            }
        }

        Ordenar(object_clicked.attr("data-order"),object_clicked.attr("data-direction"));
    }
    else
    {
        $('th.active i').remove();
        $('th.active').removeAttr("data-direction");
        $('th.active').removeClass("active");

        if (object_clicked.attr("data-order") == "Mascotas" || object_clicked.attr("data-order") == "BañosPDiscapacitadas") {
            object_clicked.addClass("active");
            object_clicked.attr("data-direction", "DESC");
            object_clicked.prepend('<i class="far fa-square"></i>');
        } else {
            object_clicked.addClass("active");
            object_clicked.attr("data-direction", "DESC");
            object_clicked.prepend('<i class="fas fa-sort-numeric-up"></i>');
        }

        Ordenar(object_clicked.attr("data-order"), object_clicked.attr("data-direction"));
    }
});

function Ordenar(orderby, direction) {
    $.ajax({
        type: "POST",
        url: "VerHabitaciones.aspx/OrdenarHabitaciones",
        data: '{orderby: "'+orderby+'", direction: "'+direction+'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $('tbody[data-tablecontent="true"]').html(msg.d);
        }
    });
}