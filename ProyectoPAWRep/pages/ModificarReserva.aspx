<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarReserva.aspx.cs" Inherits="ProyectoPAWRep.pages.ModificarReserva" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar reserva</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Modificar reserva</div>
                  <div class="admin-page-description mb-2">En esta sección podras modificar una reserva.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <div runat="server" id="seleccionar_reserva">
                        <h1>Cargar información de las reservas que posee una habitación particular</h1>
                          <div class="row">
                            <label for="MReservaNumeroHabitacionesToLoad" class="col-sm-2 col-form-label">Numero de la habitación</label>
                            <div class="col-sm-4">
                           <asp:DropDownList ID="MReservaNumeroHabitacionesToLoad" class="form-select" runat="server">
                            </asp:DropDownList>
                            </div>
                          </div>
                          <div class="col-12">
                            <button id="cargarinformacionreservas" type="submit" class="btn btn-primary mt-2" runat="server" onserverclick="cargarinformacionreservas_ServerClick"><i class="fa fa-download"></i> Cargar informacion de las reservas.</button>
                          </div>
                          <div class="col-12 mt-4" runat="server" id="seccion_tabla_info_reservas" ClientIDMode="static">
                            <h1>Reservas que posee la habitación seleccionada.</h1>
                                <table class="table">
                                  <thead class="table-blue">
                                    <tr>
                                      <th scope="col">#</th>
                                      <th scope="col">Cliente</th>
                                      <th scope="col">Fecha Inicio</th>
                                      <th scope="col">Fecha Finalizacion</th>
                                      <th scope="col">Numero de personas</th>
                                      <th scope="col">Estado</th>
                                      <th scope="col">Valor pagado</th>
                                      <th scope="col">Fecha de la reserva</th>
                                    <th scope="col">Seleccionar</th>
                                    </tr>
                                  </thead>
                                  <tbody runat="server" id="filas_tabla_reservas">
                                    <tr>
                                      <td colspan="8">No se han encontrado reservas para la habitación seleccionada.</td>
                                    </tr>
                                  </tbody>
                                </table>
                          </div>
                      </div>
                    <div runat="server" id="alertaspace"></div>
                        <div runat="server" id="seccion_info_reserva" class="row mt-2 d-none" ClienteIDMode="static">
                    <h1>Información de la reserva</h1>
                        <div class="col-xl-6 mb-2">
                            <input runat="server" id="reserva_id_input_hidden" class="d-none" value="" ClientIDMode="Static">
                            <label for="MReservaCliente" class="form-label">Cliente que tendra la reserva</label>
                            <asp:DropDownList ID="MReservaCliente" class="form-select form-control-lg" runat="server" ClientIDMode="Static">
                            </asp:DropDownList>
                            <div class="text-danger small validacion-text" runat="server" id="ValCliente" visible="false">El cliente ya posee una reserva en el tiempo especificado.</div>
                        </div>
                        <div class="col-xl-6">
                            <label for="MReservaHabitacion" class="form-label">Habitación que sera reservada</label>
                            <asp:DropDownList ID="MReservaHabitacion" class="form-select form-control-lg" runat="server" ClientIDMode="Static">
                            </asp:DropDownList>
                        </div>
                        <div class="col-xl-5">
                            <label for="MReservaFechas" class="form-label">Fecha de inicio y finalización</label>
                            <div class="input-group">
                                <span class="input-group-text"><i class="fas fa-calendar-alt"></i></span>
                                <asp:TextBox ID="MReservaFechas" style="cursor:pointer;" class="form-control form-control-lg" runat="server" ClientIDMode="Static"></asp:TextBox>
                            </div>
                            <div class="d-flex flex-column justify-content-start">
                                <div class="text-danger small validacion-text" runat="server" id="ValHabitacion" visible="false">La habitación ya posee una reserva dentro de las fechas especificadas.</div>
                            </div>                                      

                        </div>
                            <div class="col-xl-3">
                            <label for="MReservaNumeroPersonas" class="form-label">Numero de personas</label>
                            <asp:DropDownList ID="MReservaNumeroPersonas" class="form-select form-control-lg" runat="server" ClientIDMode="Static">
                                <asp:ListItem Selected="True">1</asp:ListItem>
                                <asp:ListItem>2</asp:ListItem>
                                <asp:ListItem>3</asp:ListItem>
                                <asp:ListItem>4</asp:ListItem>
                                <asp:ListItem>5</asp:ListItem>
                                <asp:ListItem>6</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                            <div class="col-xl-3">
                            <label for="MReservaEstado" class="form-label">Estado de la reserva</label>
                            <div class="form-check">
                                <asp:CheckBox ID="MReservaEstado" runat="server" class="form-check-input" ClientIDMode="Static" CssClass="form-check-input" BorderStyle="None" />
                              <label class="form-check-label" for="MReservaEstado">
                                Cancelada
                              </label>
                            </div>
                            </div>
                        <asp:TextBox ID="MReservaFechaInicioHidden" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="MReservaFechaFinalizacionHidden" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <div class="col-12 text-center mt-3">
                            <asp:Button ID="BtnModificarReserva" class="btn btn-primary btn-lg" ClientIDMode="Static" runat="server" data-buttonsubmit="true" Text="Modificar reserva" OnClick="BtnModificarReserva_Click" disabled/>
                        </div>
                            </div>
                    </form>
                  </div>
                </div>
              </div>
<script src="../js/LoadInformationReservas.js"></script>
<script>
$(document).ready(function () {
    if ($('[id$=MReservaFechaInicioHidden]').val() != "" && $('[id$=MReservaFechaFinalizacionHidden]').val() != "") {
        $('#BtnModificarReserva').attr("disabled", false);
        $('[id$=MReservaFechas]').daterangepicker({
            "startDate": $('[id$=MReservaFechaInicioHidden]').val(),
            "minDate": $('[id$=MReservaFechaInicioHidden]').val(),
            endDate: $('[id$=MReservaFechaFinalizacionHidden]').val(),
            locale: {
                format: 'Y-MM-DD'
            },
        }, function (start, end, label) {
            console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
        });
        $('[id$=MReservaFechaInicioHidden]').hide();
        $('[id$=MReservaFechaFinalizacionHidden]').hide();
    } else {
        $('[id$=MReservaFechaInicioHidden]').hide();
        $('[id$=MReservaFechaFinalizacionHidden]').hide();
    }
});
</script>
</asp:Content>
