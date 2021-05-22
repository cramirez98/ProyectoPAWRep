<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="CrearDescuento.aspx.cs" Inherits="ProyectoPAWRep.pages.CrearDescuento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
<title>Crear descuento</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Crear descuento</div>
                  <div class="admin-page-description mb-2">En esta seccion podras crear nuevos descuentos.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                    <form class="row g-3" runat="server" style="margin-top: -50pt;">
                        <div runat="server" id="alertaspace"></div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <h1>Información del descuento</h1>
                      <div class="col-md-4">
                        <label for="CDescuentoNombre" class="form-label">Nombre del descuento</label>
                        <asp:TextBox ID="CDescuentoNombre" class="form-control" runat="server"></asp:TextBox>
                          <div class="d-flex flex-column justify-content-start">
                            <asp:RequiredFieldValidator ID="ValDescNombre" class="text-danger small validacion-text" runat="server" ControlToValidate="CDescuentoNombre" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                            <div class="text-danger small" runat="server" id="Val2DescNombre" visible="false">El nombre ingresado ya existe.</div>
                          </div>
                      </div>
                      <div class="col-md-auto">
                        <label for="CDescuentoFechaInicio" class="form-label">Fecha de inicio</label>
                        <div class="input-group">
                            <span class="input-group-text"><span class="far fa-calendar-alt"></span></span>  
                            <asp:TextBox ID="CDescuentoFechaInicio" class="form-control" runat="server" placeholder="409" ClientIDMode="Static"></asp:TextBox>
                        </div>
                      </div>
                      <div class="col-md-auto">
                        <label for="CDescuentoFechaFinal" class="form-label">Fecha de finalizacion</label>
                        <div class="input-group">
                            <span class="input-group-text"><span class="far fa-calendar-alt"></span></span>
                            <asp:TextBox ID="CDescuentoFechaFinal" class="form-control" runat="server" placeholder="409" ClientIDMode="Static"></asp:TextBox>                                             
                        </div>
                      </div>
                      <div class="col-xl-auto">
                        <label for="CDescuentoPorcentaje" class="form-label">Porcentaje</label>
                        <div class="input-group">
                          <asp:TextBox ID="CDescuentoPorcentaje" class="form-control" runat="server" placeholder="60"></asp:TextBox>
                          <span class="input-group-text">%</span>
                        </div>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValPor" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos enteros" ValidationExpression="^([0-9])*$" ControlToValidate="CDescuentoPorcentaje" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Por" class="text-danger small validacion-text" runat="server" ControlToValidate="CDescuentoPorcentaje" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <div class="text-danger small" runat="server" id="Val3Por" visible="false">Debe ingresar 3 imagenes</div>
                            </div>
                      </div>
                      <div class="col-12 text-center">
                        <button type="submit" runat="server" ValidationGroup="Requeridos" class="btn btn-primary btn-lg" onserverclick="BtnCrearDescuento_Click">Crear descuento</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>

<script>
$(document).ready(function () {
    $('[id$=CDescuentoFechaInicio]').daterangepicker({
        "singleDatePicker": true,
        "startDate": moment(),
        "minDate": moment(),
        locale: {
            format: 'Y-MM-DD'
        },
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
    $('[id$=CDescuentoFechaFinal]').daterangepicker({
        "singleDatePicker": true,
        "startDate": moment().add(1,'day'),
        "minDate": moment().add(1, 'day'),
        locale: {
            format: 'Y-MM-DD'
        },
    }, function (start, end, label) {
        console.log('New date range selected: ' + start.format('YYYY-MM-DD') + ' to ' + end.format('YYYY-MM-DD') + ' (predefined range: ' + label + ')');
    });
});
</script>
</asp:Content>
