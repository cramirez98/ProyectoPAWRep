<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="EliminarUsuario.aspx.cs" Inherits="ProyectoPAWRep.pages.EliminarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
                  <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Eliminar usuario</div>
                  <div class="admin-page-description mb-2">En esta sección podras eliminar los usuarios que se encuentren registrados en la pagina, ten en cuenta que cuando borres un usuario, se borraran automaticamente todas las reservas que este haya realizado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Usuario a eliminar</h1>
                      <div runat="server" id="alertaspace"></div>
                    <form class="row g-3" runat="server">
                      
                      <div class="row">
                        <label for="EUUsuario" class="col-sm-2 col-form-label">Nombres, Apellidos y Correo del usuario a eliminar</label>
                        <div class="col-sm-5">
                       <asp:DropDownList ID="EUUsuario" class="form-select" runat="server">
                        </asp:DropDownList>
                        </div>
                      </div>
                      <div class="col-12">
                        <button id="submitbtneliminaru" type="submit" class="btn btn-danger" runat="server" onserverclick="submitbtneliminaru_ServerClick"><i class="fa fa-remove"></i> Eliminar habitación</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
