$(document).ready(function () {
    $('input[data-enable="true"]').attr("ReadOnly", true);
});

$(".enable-textbox").click(function (event) {
    object_clicked = $(this);
    textbox_to_enable = object_clicked.parent().children('input[data-enable="true"]').attr("ReadOnly", false);
    object_clicked.prop('disabled', true);
});

$(".enable-textbox-password").click(function (event) {
    object_clicked = $(this);
    object_clicked.parent().children('input[data-enable="true"]').attr('data-modified', 'true');
    object_clicked.parent().children('input[data-enable="true"]').val("");
    object_clicked.parent().children('input[data-enable="true"]').attr("ReadOnly", false);
    $("[id$=RContraseña]").attr("hidden", false);

    $("#labelRContraseña").val("");
    $("#labelRContraseña").attr("hidden", false);
    object_clicked.hide();
});