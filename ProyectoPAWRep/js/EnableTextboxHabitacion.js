$(document).ready(function () {
    $("[id$=MHabitacionNumero]").attr("ReadOnly", true);
    $("[id$=MHabitacionPrecio]").attr("ReadOnly", true);
    $("[id$=MHabitacionDescripcion]").attr("ReadOnly", true);
    $("[id$=Cedula]").attr("ReadOnly", true);
    $("[id$=Edad]").attr("ReadOnly", true);
    $("[id$=Contraseña]").attr("ReadOnly", true);
    $("[id$=Direccion]").attr("ReadOnly", true);
    $("[id$=Ciudad]").attr("ReadOnly", true);
});

$(".enable-textbox").click(function (event) {
    object_clicked = $("#" + event.currentTarget.id);
    textbox_to_enable = object_clicked.data("textbox");
    $("[id$=" + textbox_to_enable + "]").attr("ReadOnly", false);
    object_clicked.prop('disabled', true);
});