$(document).ready(function () {
    $("[id$=CCComentarioRating]").hide();
    $("[id$=CCComentarioRating]").val("0");
});

$("[name=rating]").change(function () {
    $("[id$=CCComentarioRating]").val($(this).val());
});