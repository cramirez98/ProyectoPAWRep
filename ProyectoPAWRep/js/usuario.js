$('button[name="CargarDatosModal"]').click(function () {
    var numeroh = $(this).data("numeroh");

    $.ajax({
        type: "POST",
        url: "usuario.aspx/generarmodal",
        data: '{numerohabitacion: ' + numeroh + '}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (msg) {
            var strings = msg.d.split("<--CambioDeInformacion-->");
            $("#modal-habitacion-fotos").html(strings[0]);
            $("#modal-habitacion-info").html(strings[1]);
        }
    });
});