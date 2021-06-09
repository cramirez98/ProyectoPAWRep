<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="MiInformacion.aspx.cs" Inherits="ProyectoPAWRep.pages.MiUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Mi información</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Mi información</div>
                  <div class="admin-page-description mb-2">En esta seccion ver tu información personal y modificar.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                        <div class="row" runat="server" id="informacion_usuario">
                        <h1 class="mt-3">Tu información personal</h1>
                        <div runat="server" id="alertaspace"></div>
                                <div class="row d-flex justify-content-center">
                                    <div class="col-xs-4 d-flex justify-content-center text-center">
                                        <img src="../img/nelson.jpeg" class="m-2 border border-5 img-fluid rounded-circle" alt="..." width="200" height="200" runat="server" id="MIImagePerfilPaginaModificar">

                                    </div>
                                </div>                                
                                <div class="row justify-content-center mb-3">
                                    <div class="col-xl-6">
                                      <label for="MIFotoPerfil" class="form-label">Foto de perfil</label>
                                      <asp:FileUpload ID="MIFotoPerfil" runat="server" class="form-control"/>
                                    </div>
                                </div>
                                    <div class="col-xl-6">
                                      <label for="MINombres" class="form-label">Nombres</label>
                                        <div class="input-group">
                                          <asp:TextBox ID="MINombres" class="form-control form-control-lg" data-enable="true" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" type="button" data-textbox="MUNombres"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <asp:RequiredFieldValidator ID="ValNombres" class="text-danger small validacion-text" runat="server" ControlToValidate="MINombres" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-6">
                                      <label for="MIApellidos" class="form-label">Apellidos</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MIApellidos" class="form-control form-control-lg" data-enable="true" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnapellidos" type="button" data-textbox="MUApellidos"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <asp:RequiredFieldValidator ID="ValApellidos" class="text-danger small validacion-text" runat="server" ControlToValidate="MIApellidos" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-5">
                                        <label for="MICelular" class="form-label">Numero de celular o telefono fijo</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MICelular" class="form-control form-control-lg" data-enable="true" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btncelular" type="button" data-textbox="Celular"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCelular" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="MICelular" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Celular" class="text-danger small validacion-text" runat="server" ControlToValidate="MICelular" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                      

                                    </div>
                                      <div class="col-xl-4">
                                        <label for="MICedula" class="form-label">Numero de cedula</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MICedula" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btncedula" type="button" data-textbox="Cedula"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCedula" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="MICedula" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Cedula" class="text-danger small validacion-text" runat="server" ControlToValidate="MICedula" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                      <div class="col-xl-3">
                                        <label for="MIEdad" class="form-label">Edad</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MIEdad" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnedad" type="button" data-textbox="Edad"><i class="fas fa-edit"></i></button>
                                        </div>
                                          <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValEdad" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="MIEdad" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Edad" class="text-danger small validacion-text" runat="server" ControlToValidate="MIEdad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                            <asp:RangeValidator ID="Val3Edad" class="text-danger small validacion-text" runat="server" MaximumValue="80" MinimumValue="18" ValidationGroup="Requeridos" ControlToValidate="MIEdad" Display="Dynamic">Debe ser mayor de edad (+18 años)</asp:RangeValidator>
                                          </div>
                                      </div>
                                      <div class="col-xl-9">
                                        <label for="MIDireccion" class="form-label">Dirección de residencia</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MIDireccion" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btndireccion" type="button" data-textbox="Direccion"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">

                                            <asp:RequiredFieldValidator ID="Val2Direccion" class="text-danger small validacion-text" runat="server" ControlToValidate="MIDireccion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                    <div class="col-xl-3">
                                      <label for="MICiudad" class="form-label">Ciudad de residencia</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MICiudad" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnciudad" type="button" data-textbox="Ciudad"><i class="fas fa-edit"></i></button>
                                        </div>
                                            <asp:RequiredFieldValidator ID="ValCiudad" class="text-danger small validacion-text" runat="server" ControlToValidate="MICiudad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-12">
                                        <label for="MICorreo" class="form-label">Correo electronico</label>
                                        <div class="input-group">
                                        <asp:TextBox ID="MICorreo" class="form-control form-control-lg" data-enable="true" runat="server"></asp:TextBox>                                          
                                            <button class="btn btn-warning enable-textbox" id="btncorreo" type="button" data-textbox="Direccion"><i class="fas fa-edit"></i></button>
                                        </div>                                
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCorreo" class="text-danger small validacion-text" runat="server" ErrorMessage="Debe ingresar un correo valido" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" ControlToValidate="MICorreo" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Correo" class="text-danger small validacion-text" runat="server" ControlToValidate="MICorreo" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>      
                                            <div runat="server" class="text-danger small validacion-text" id="Val3Correo" Visible="false">El correo ingresado ya esta en uso.</div>
                                        </div>
                                      </div>
                                      <div class="col-xl-6 mt-2">
                                        <label for="MIContraseña" class="form-label">Nueva contraseña</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MIContraseña" class="form-control form-control-lg" data-modified="false" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox-password" id="btncontraseña" type="button" data-textbox="Contraseña"><i class="fas fa-edit"></i></button>
                                        </div>
                                      </div>
                                      <div class="col-xl-6 mt-2">
                                        <label for="MIRContraseña" class="form-label" id="labelRContraseña" data-enable="true" hidden>Repetir nueva contraseña</label>
                                        <asp:TextBox ID="MIRContraseña" class="form-control form-control-lg" runat="server" hidden></asp:TextBox>
                                      </div>
                                    <div class="col-12 text-center">
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:CompareValidator ID="ValPass" class="text-danger small" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="MIContraseña" ControlToValidate="MIRContraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small" runat="server" ControlToValidate="MIContraseña" ErrorMessage="Debe ingresar una contraseña" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                    

                                    </div>
                        <div class="col-12 text-center">
                            <asp:Button ID="BtnModificarMiInfo" class="btn btn-primary btn-lg mt-4" runat="server" Text="Modificar tu información" OnClick="BtnModificarMiInfo_Click" ValidationGroup="Requeridos"/>
                        </div>
                            </div>
                    </form>
                  </div>
                </div>
              </div>
        <script src="../js/EnableTextboxPlugin.js"></script>
</asp:Content>
