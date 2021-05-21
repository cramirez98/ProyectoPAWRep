<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="EliminarHabitacion.aspx.cs" Inherits="ProyectoPAWRep.pages.EliminarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Eliminar habitación</div>
                  <div class="admin-page-description mb-2">En esta seccion podras eliminar las habitaciones que desees, ten en cuenta que cuando elimines una habitaciones, tambien se eliminara la reserva en caso de que esta tenga una.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Habitación a eliminar</h1>
                      <div runat="server" id="alertaspace"></div>
                    <form class="row g-3" action="" runat="server">
                      
                      <div class="row">
                        <label for="DHabitacionNumero" class="col-sm-2 col-form-label">Numero de la habitación</label>
                        <div class="col-sm-4">
                       <asp:DropDownList ID="DHabitacionNumero" class="form-select" runat="server">
                        </asp:DropDownList>
                        </div>
                      </div>
                      <div class="col-12">
                        <button id="submitbtneliminarh" type="submit" class="btn btn-danger" runat="server" onserverclick="BtnEliminar_Click"><i class="fa fa-remove"></i> Eliminar habitación</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
