<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="adminaboutus.aspx.cs" Inherits="ProyectoPAWRep.pages.adminaboutus" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Seccion About Us</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Seccion About Us</div>
                  <div class="admin-page-description mb-2">En esta seccion podras modificar la informacion de acerca de nosotros que se visualiza en la pagina principal.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                    <form class="row g-3" runat="server" style="margin-top: -40pt;">
                        <div runat="server" id="alertaspace"></div>
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <h1>Informacion de la seccion de About Us</h1>
                      <div class="col-md-12">
                        <label for="AboutUsHistoria" class="form-label">Historia:</label>
                        <asp:TextBox ID="AboutUsHistoria" TextMode="MultiLine" Rows="4" class="form-control" runat="server"></asp:TextBox>
                          <div class="d-flex flex-column justify-content-start">
                            <asp:RequiredFieldValidator ID="ValHistoria" class="text-danger small validacion-text" runat="server" ControlToValidate="AboutUsHistoria" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                          </div>
                      </div>
                      <div class="col-md-12">
                        <label for="AboutUsMision" class="form-label">Mision</label>
                        <asp:TextBox ID="AboutUsMision" TextMode="MultiLine" Rows="4" class="form-control" runat="server"></asp:TextBox>
                          <div class="d-flex flex-column justify-content-start">
                            <asp:RequiredFieldValidator ID="ValMision" class="text-danger small validacion-text" runat="server" ControlToValidate="AboutUsMision" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                          </div>
                      </div>
                      <div class="col-md-12">
                        <label for="AboutUsVision" class="form-label">Vision</label>
                        <asp:TextBox ID="AboutUsVision" TextMode="MultiLine" Rows="4" class="form-control" runat="server"></asp:TextBox>
                          <div class="d-flex flex-column justify-content-start">
                            <asp:RequiredFieldValidator ID="ValVision" class="text-danger small validacion-text" runat="server" ControlToValidate="AboutUsVision" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                          </div>
                      </div>
                      <div class="col-md-12">
                        <label for="AboutUsPrincipios" class="form-label">Principios</label>
                        <asp:TextBox ID="AboutUsPrincipios" TextMode="MultiLine" Rows="4" class="form-control" runat="server"></asp:TextBox>
                          <div class="d-flex flex-column justify-content-start">
                            <asp:RequiredFieldValidator ID="ValPrincipios" class="text-danger small validacion-text" runat="server" ControlToValidate="AboutUsPrincipios" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                          </div>
                      </div>
  
                      <div class="col-12 text-center">
                        <button type="submit" id="BtnAboutUsSubmit" runat="server" ValidationGroup="Requeridos" class="btn btn-primary btn-lg" onserverclick="BtnAboutUsSubmit_ServerClick">Guardar información</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
