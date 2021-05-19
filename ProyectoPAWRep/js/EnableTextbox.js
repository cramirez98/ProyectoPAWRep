$(document).ready(function () {
    $("[id$=Nombres]").attr("ReadOnly", true);
    $("[id$=Apellidos]").attr("ReadOnly", true);
    $("[id$=Celular]").attr("ReadOnly", true);
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
    object_clicked.hide();
});

$(".enable-textbox-password").click(function (event) {
    object_clicked = $("#" + event.currentTarget.id);
    textbox_to_enable = object_clicked.data("textbox");
    $("[id$=" + textbox_to_enable + "]").val("");
    $("[id$=" + textbox_to_enable + "]").attr("ReadOnly", false);
    $("[id$=RContraseña]").attr("hidden", false);

    $("#labelRContraseña").val("");
    $("#labelRContraseña").attr("hidden", false);
    object_clicked.hide();
});