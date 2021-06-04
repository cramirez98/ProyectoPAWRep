<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="adminpanel.aspx.cs" Inherits="ProyectoPAWRep.pages.adminpanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Panel de administrador</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row d-flex flex-column">
                  <div class="admin-page-title">Panel de informacion</div>
                </div>
                <div class="row d-flex flex-row justify-content-center">
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-green mb-2 mb-xl-0">
                      <div class="d-flex flex-column">
                        <div class="title">Habitaciones ocupadas</div>
                        <div class="value" runat="server" id="numhabitacionesocupadas">0</div>
                      </div>
                      <i class="fas fa-door-closed icon"></i>
                    </div>
                  </div>
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-magenta">
                      <div class="d-flex flex-column">
                        <div class="title">Habitaciones libres</div>
                        <div class="value" runat="server" id="numhabitacionesdisponibles">0</div>
                      </div>
                      <i class="fa fa-door-open icon"></i>
                    </div>                    
                  </div>
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-orange">
                      <div class="d-flex flex-column">
                        <div class="title">Descuentos vigentes</div>
                        <div class="value" runat="server" id="numdescuentosvigentes">0</div>
                      </div>
                      <i class="fas fa-tags icon"></i>
                    </div>  
                  </div>
                </div>
                  <div class="admin-content mt-4">
                        <h1>Ultimos 10 pagos recibidos</h1>
                              <table class="table mt-2">
                                <thead class="table-blue">
                                  <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Nombres y apellidos</th>
                                    <th scope="col">Correo</th>
                                    <th scope="col">Cedula</th>
                                    <th scope="col">Direccion</th>
                                    <th scope="col">Telefono</th>
                                    <th scope="col">Valor</th>
                                    <th scope="col">Metodo</th>
                                    <th scope="col">Fecha</th>
                                    <th scope="col">Concepto</th>
                                  </tr>
                                </thead>
                                <tbody runat="server" id="pagos_table_info">
                                  <tr>
                                       <td colspan="10">No hay pagos para mostrar.</td>
                                  </tr>
                                </tbody>
                              </table>
                  </div>
              </div>
</asp:Content>
