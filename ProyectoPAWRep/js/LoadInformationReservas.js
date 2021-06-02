$("#seccion_tabla_info_reservas").on('click', "button[name=CargarDatosModificarReserva]", function () {
    var reserva_id = $('button[name="CargarDatosModificarReserva"]').data("loadreserva");

    $.ajax({
        type: "POST",
        url: "ModificarReserva.aspx/CargarInformacionReserva",
        data: '{reserva_id: "'+reserva_id+'"}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            $("[id$=seccion_info_reserva]").removeClass("d-none");
            var strings = msg.d.split(";");

            $("[id$=MReservaCliente]").val(strings[0]);
            $("[id$=MReservaHabitacion]").val(strings[1]);
            $("[id$=MReservaNumeroPersonas]").val(strings[4]);

            if (strings[5] == "1") {
                $("[id$=MReservaEstado]").prop('checked', true)
            }
            else
            {
                $("[id$=MReservaEstado]").prop('checked', false)
            }
        }
    });
});