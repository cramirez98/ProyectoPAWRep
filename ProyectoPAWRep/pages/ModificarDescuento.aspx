<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarDescuento.aspx.cs" Inherits="ProyectoPAWRep.pages.ModificarDescuento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar descuento</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Modificar descuento</div>
                  <div class="admin-page-description mb-2">En esta sección podras modificar los descuentos que hayas creado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                    <form class="row g-3" runat="server" style="margin-top: -40pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <div runat="server" id="seleccionar_descuento">
                        <h1>Cargar información del descuento</h1>
                          <div class="row">
                            <label for="MDescuentoNombreToLoad" class="col-sm-2 col-form-label">Nombre del descuento</label>
                            <div class="col-sm-4">
                           <asp:DropDownList ID="MDescuentoNombreToLoad" class="form-select" runat="server">
                            </asp:DropDownList>
                            </div>
                          </div>
                          <div class="col-12">
                            <button id="cargarinformaciondescuento" type="submit" class="btn btn-primary mt-2" runat="server" onserverclick="cargarinformaciondescuento_ServerClick"><i class="fa fa-download"></i> Cargar informacion del descuento</button>
                          </div>
                      </div>
                      <h1>Información del descuento</h1>
                        <div runat="server" id="alertaspace" class=""></div>
                      <div class="col-md-4">
                        <label for="MDescuentoNombre" class="form-label">Nombre del descuento</label>
                        <asp:TextBox ID="MDescuentoNombre" class="form-control" runat="server" ReadOnly="true"></asp:TextBox>
                          <div class="d-flex flex-column justify-content-start">
                            <asp:RequiredFieldValidator ID="ValDescNombre" class="text-danger small validacion-text" runat="server" ControlToValidate="MDescuentoNombre" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                            <div class="text-danger small" runat="server" id="Val2DescNombre" visible="false">El nombre ingresado ya existe.</div>
                          </div>
                      </div>
                      <div class="col-md-auto">
                        <label for="MDescuentoFechaInicio" class="form-label">Fecha de inicio</label>
                        <div class="input-group">
                            <span class="input-group-text"><span class="far fa-calendar-alt"></span></span>  
                            <asp:TextBox ID="MDescuentoFechaInicio" style="cursor:pointer;" class="form-control" runat="server" placeholder="2021-06-01" ClientIDMode="Static"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-auto">
                        <label for="MDescuentoFechaFinal" class="form-label">Fecha de finalizacion</label>
                        <div class="input-group">
                            <span class="input-group-text"><span class="far fa-calendar-alt"></span></span>
                            <asp:TextBox ID="MDescuentoFechaFinal" style="cursor:pointer;" class="form-control" runat="server" placeholder="2021-06-02" ClientIDMode="Static"></asp:TextBox>                                             
                        </div>
                      </div>
                      <div class="col-xl-auto">
                        <label for="MDescuentoPorcentaje" class="form-label">Porcentaje</label>
                        <div class="input-group">
                          <asp:TextBox ID="MDescuentoPorcentaje" class="form-control" runat="server" placeholder="60"></asp:TextBox>
                          <span class="input-group-text">%</span>
                        </div>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValPor" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos enteros" ValidationExpression="^([0-9])*$" ControlToValidate="MDescuentoPorcentaje" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Por" class="text-danger small validacion-text" runat="server" ControlToValidate="MDescuentoPorcentaje" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <div class="text-danger small" runat="server" id="Val3Por" visible="false">Debe ingresar 3 imagenes</div>
                            </div>
                      </div>
                        <asp:TextBox ID="MDescuentoFechaInicioHidden" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                        <asp:TextBox ID="MDescuentoFechaFinalizacionHidden" class="form-control" runat="server" ClientIDMode="Static"></asp:TextBox>
                      <div class="col-12 text-center">
                        <button type="submit" id="BtnModificarDescuento" runat="server" ValidationGroup="Requeridos" class="btn btn-primary btn-lg" onserverclick="BtnModificarDescuento_ServerClick">Modificar descuento</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>

<script>
$(document).ready(function () {
    if ($('[id$=MDescuentoFechaInicioHidden]').val() != "") {
        var fecha_inicio = Date.parse($('[id$=MDescuentoFechaInicioHidden]').val());
        var fecha_finalizacion = Date.parse($('[id$=MDescuentoFechaFinalizacionHidden]').val());
        $('[id$=MDescuentoFechaInicio]').daterangepicker({
            "singleDatePicker": true,
            "startDate": $('[id$=MDescuentoFechaInicioHidden]').val(),
            "minDate": $('[id$=MDescuentoFechaInicioHidden]').val(),
            locale: {
                format: 'Y-MM-DD'
            },
        }, function (start, end, label) {
            console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
        });
        $('[id$=MDescuentoFechaInicioHidden]').hide();
        $('[id$=MDescuentoFechaFinal]').daterangepicker({
            "singleDatePicker": true,
            "startDate": $('[id$=MDescuentoFechaFinalizacionHidden]').val(),
            "minDate": $('[id$=MDescuentoFechaFinalizacionHidden]').val(),
            locale: {
                format: 'Y-MM-DD'
            },
        }, function (start, end, label) {
            console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
        });
        $('[id$=MDescuentoFechaFinalizacionHidden]').hide();
    } else {
        $('[id$=MDescuentoFechaInicioHidden]').hide();
        $('[id$=MDescuentoFechaFinalizacionHidden]').hide();
    }
});
</script>
</asp:Content>
