<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="CrearReserva.aspx.cs" Inherits="ProyectoPAWRep.pages.CrearReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Crear reserva</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Crear reserva</div>
                  <div class="admin-page-description mb-2">En esta sección podras crear una nueva reserva.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <div runat="server" id="alertaspace"></div>
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                    <h1>Información de la reserva</h1>
                        <div class="col-xl-6">
                            <label for="CReservaCliente" class="form-label">Cliente que tendra la reserva</label>
                            <asp:DropDownList ID="CReservaCliente" class="form-select form-control-lg" runat="server">
                            </asp:DropDownList>
                            <div class="text-danger small validacion-text" runat="server" id="ValCliente" visible="false">El cliente ya posee una reserva en el tiempo especificado.</div>
                        </div>
                        <div class="col-xl-6">
                            <label for="CReservaHabitacion" class="form-label">Habitación que sera reservada</label>
                            <asp:DropDownList ID="CReservaHabitacion" class="form-select form-control-lg" runat="server">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xl-5">
                            <label for="CReservaFechas" class="form-label">Fecha de inicio y finalización</label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                                <asp:TextBox ID="CReservaFechas" style="cursor:pointer;" class="form-control form-control-lg" runat="server" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="d-flex flex-column justify-content-start">
                                <div class="text-danger small validacion-text" runat="server" id="ValHabitacion" visible="false">La habitación ya posee una reserva dentro de las fechas especificadas.</div>
                            </div>                                      

                        </div>
                            <div class="col-xl-3">
                            <label for="CReservaNumeroPersonas" class="form-label">Numero de personas</label>
                            <asp:DropDownList ID="CReservaNumeroPersonas" class="form-select form-control-lg" runat="server">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                        <div class="col-12 text-center">
                            <asp:Button ID="BtnCrearReserva" class="btn btn-primary btn-lg" runat="server" Text="Crear reserva" OnClick="BtnCrearReserva_Click"/>
                        </div>
                    </form>
                  </div>
                </div>
              </div>

<script>
$(document).ready(function () {
    $('[id$=CReservaFechas]').daterangepicker({
        "startDate": moment(),
        "minDate": moment(),
        endDate: moment().add(6, 'day'),
        locale: {
            format: 'Y-MM-DD'
        },
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
});
</script>
</asp:Content>
