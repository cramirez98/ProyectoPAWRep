$('button[name="complete_checkout_button"]').click(function () {
    var validation = true;

    if ($("[id$=CheckoutNombres]").val() == "") {
        $("#ValNombres").removeClass("d-none");
        $("#ValNombres").addClass("d-block");
        validation = false;
    } else {
        if ($("#ValNombres").hasClass("d-block")) {
            $("#ValNombres").removeClass("d-block");
            $("#ValNombres").addClass("d-none");
        }
    }
    if ($("[id$=CheckoutApellidos]").val() == "") {
        $("#ValApellidos").toggleClass("d-none");
        $("#ValApellidos").removeClass("d-none");
        $("#ValApellidos").addClass("d-block");
        validation = false;
    } else {
        if ($("#ValApellidos").hasClass("d-block")) {
            $("#ValApellidos").removeClass("d-block");
            $("#ValApellidos").addClass("d-none");
        }
    }
    if ($("[id$=CheckoutTelefono]").val() == "") {
        $("#ValTelefono").text("No puede estar vacio.");
        $("#ValTelefono").removeClass("d-none");
        $("#ValTelefono").addClass("d-block");
        validation = false;
    } else if (!/^\d+$/.test($("[id$=CheckoutTelefono]").val())) {
        $("#ValTelefono").text("Solo puede tener numeros.");
        $("#ValTelefono").removeClass("d-none");
        $("#ValTelefono").addClass("d-block");
        validation = false;
    } else {
        if ($("#ValTelefono").hasClass("d-block")) {
            $("#ValTelefono").removeClass("d-block");
            $("#ValTelefono").addClass("d-none");
        }
    }
    if ($("[id$=CheckoutCorreo]").val() == "") {
        $("#ValCorreo").removeClass("d-none");
        $("#ValCorreo").addClass("d-block");
        validation = false;
    } else if (!/^(([^<>()[\]\\.,;:\s@"]+(\.[^<>()[\]\\.,;:\s@"]+)*)|(".+"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/.test($("[id$=CheckoutCorreo]").val())) {
        $("#ValCorreo").text("Debe ser un correo valido.")
        $("#ValCorreo").removeClass("d-none");
        $("#ValCorreo").addClass("d-block");
        validation = false;
    } else {
        if ($("#ValCorreo").hasClass("d-block")) {
            $("#ValCorreo").removeClass("d-block");
            $("#ValCorreo").addClass("d-none");
        }
    }
    if ($("[id$=CheckoutDireccion]").val() == "") {
        $("#ValDireccion").removeClass("d-none");
        $("#ValDireccion").addClass("d-block");
        validation = false;
    } else {
        if ($("#ValDireccion").hasClass("d-block")) {
            $("#ValDireccion").removeClass("d-block");
            $("#ValDireccion").addClass("d-none");
        }
    }

    if ($("[id$=CheckoutCiudad]").val() == "") {
        $("#ValCiudad").removeClass("d-none");
        $("#ValCiudad").addClass("d-block");
        validation = false;
    } else {
        if ($("#ValCiudad").hasClass("d-block")) {
            $("#ValCiudad").removeClass("d-block");
            $("#ValCiudad").addClass("d-none");
        }
    }
    if ($("[id$=CheckoutCedula]").val() == "") {
        $("#ValCedula").removeClass("d-none");
        $("#ValCedula").addClass("d-block");
        $("#ValCedula").text("No puede estar vacio.")
        validation = false;
    } else if (!/^\d+$/.test($("[id$=CheckoutCedula]").val())) {
        $("#ValCedula").removeClass("d-none");
        $("#ValCedula").addClass("d-block");
        $("#ValCedula").text("Solo puede tener numeros.")
        validation = false;
    } else {
        if ($("#ValCedula").hasClass("d-block")) {
            $("#ValCedula").removeClass("d-block");
            $("#ValCedula").addClass("d-none");
        }
    }

    if ($("#nav-home-tab").hasClass("active")) {
        if ($("#inputNumero").val() == "") {
            $("#ValTarjetaNumero").removeClass("d-none");
            $("#ValTarjetaNumero").addClass("d-block");
            validation = false;
        } else {
            if ($("#ValTarjetaNumero").hasClass("d-block")) {
                $("#ValTarjetaNumero").removeClass("d-block");
                $("#ValTarjetaNumero").addClass("d-none");
            }
        }
        if ($("#inputNombre").val() == "") {
            $("#ValNombreTarjeta").removeClass("d-none");
            $("#ValNombreTarjeta").addClass("d-block");
            validation = false;
        } else {
            if ($("#ValNombreTarjeta").hasClass("d-block")) {
                $("#ValNombreTarjeta").removeClass("d-block");
                $("#ValNombreTarjeta").addClass("d-none");
            }
        }
    } else if ($("#nav-profile").hasClass("active")) {
        if ($("#paypalemail").val() == "") {
            $("#ValCorreoPaypal").removeClass("d-none");
            $("#ValCorreoPaypal").addClass("d-block");
            validation = false;
        } else {
            if ($("#ValCorreoPaypal").hasClass("d-block")) {
                $("#ValCorreoPaypal").removeClass("d-block");
                $("#ValCorreoPaypal").addClass("d-none");
            }
        }
        if ($("#paypalpass").val() == "") {
            $("#ValPassPaypal").removeClass("d-none");
            $("#ValPassPaypal").addClass("d-block");
            validation = false;
        } else {
            if ($("#ValPassPaypal").hasClass("d-block")) {
                $("#ValPassPaypal").removeClass("d-block");
                $("#ValPassPaypal").addClass("d-none");
            }
        }
    } else {
        if ($("#pseemail").val() == "") {
            $("#ValEmailPSE").removeClass("d-none");
            $("#ValEmailPSE").addClass("d-block");
            validation = false;
        } else {
            if ($("#ValEmailPSE").hasClass("d-block")) {
                $("#ValEmailPSE").removeClass("d-block");
                $("#ValEmailPSE").addClass("d-none");
            }
        }
    }

    if (validation) {
        $(window).scrollTop(0);
        var paymentObject = {};

        paymentObject.nombres = $("[id$=CheckoutNombres]").val();
        paymentObject.apellidos = $("[id$=CheckoutApellidos]").val()
        paymentObject.correo = $("[id$=CheckoutCorreo]").val();
        paymentObject.telefono = $("[id$=CheckoutTelefono]").val();
        paymentObject.cedula = $("[id$=CheckoutCedula]").val()
        paymentObject.ciudad = $("[id$=CheckoutCiudad]").val()
        paymentObject.direccion = $("[id$=CheckoutDireccion]").val();
        paymentObject.numeroHabitacion = $("#CheckoutNumeroHabitacion").data("numeroh");
        paymentObject.valorPago = $("#CheckoutNumeroHabitacion").data("precioh");
        paymentObject.fechaInicio = $("#CheckoutNumeroHabitacion").data("fechainicio");
        paymentObject.fechafinalizacion = $("#CheckoutNumeroHabitacion").data("fechafinalizacion");
        paymentObject.numeropersonas = $("#CheckoutNumeroHabitacion").data("npersonas");
        paymentObject.correou = $("#CheckoutNumeroHabitacion").data("correou");
        paymentObject.metododepago = $(this).data("metodo");

        //alert('{paymentobj: ' + JSON.stringify(paymentObject) + '}');

        $.ajax({
            type: "POST",
            url: "checkout.aspx/procesarpago",
            data: '{paymentobj: ' + JSON.stringify(paymentObject) + '}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $("#alertseccion").html(msg.d);
                $(window).scrollTop(0);
            }
        });
    } else {
        $(window).scrollTop(0);
    }

});

$('button[name="pse_tipo_persona"]').click(function () {
    $(this).toggleClass("active");
    if ($('button[name="pse_tipo_juridica"]').hasClass("active")) {
        $('button[name="pse_tipo_juridica"]').removeClass("active");
    }
});

$('button[name="pse_tipo_juridica"]').click(function () {
    $(this).toggleClass("active");
    if ($('button[name="pse_tipo_persona"]').hasClass("active")) {
        $('button[name="pse_tipo_persona"]').removeClass("active");
    }
});