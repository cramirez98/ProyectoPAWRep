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
            $('#BtnModificarReserva').attr("disabled", false);
            $("[id$=reserva_id_input_hidden]").val(strings[6]);
            $('[id$=MReservaFechas]').daterangepicker({
                "startDate": strings[2],
                "minDate": moment().subtract(29, 'days'),
                endDate: strings[3],
                locale: {
                    format: 'Y-MM-DD'
                },
            }, function (start, end, label) {
                console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
            });
        }
    });
});