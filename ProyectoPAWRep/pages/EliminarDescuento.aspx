<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="EliminarDescuento.aspx.cs" Inherits="ProyectoPAWRep.pages.EliminarDescuento" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Eliminar descuento</div>
                  <div class="admin-page-description mb-2">En esta sección podras eliminar los descuentos que hayas creado y asi tambien dejaran de estar activos en las habitaciones que tenga este descuento.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Descuento a eliminar</h1>
                      <div runat="server" id="alertaspace"></div>
                    <form class="row g-3" runat="server">
                      
                      <div class="row">
                        <label for="DDescuentoNombre" class="col-sm-2 col-form-label">Nombre del descuento</label>
                        <div class="col-sm-4">
                       <asp:DropDownList ID="DDescuentoNombre" class="form-select" runat="server">
                        </asp:DropDownList>
                        </div>
                      </div>
                      <div class="col-12">
                        <button id="submitbtneliminard" type="submit" class="btn btn-danger" runat="server" onserverclick="submitbtneliminard_ServerClick"><i class="fa fa-remove"></i> Eliminar habitación</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
