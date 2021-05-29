<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="AgregarUsuario.aspx.cs" Inherits="ProyectoPAWRep.pages.AgregarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <title>Crear usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Agregar usuario</div>
                  <div class="admin-page-description mb-2">En esta seccion podras agregar nuevos usuarios a la pagina web.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <div runat="server" id="alertaspace"></div>
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                        <div class="col-xl-6">
                            <label for="Nombres" class="form-label">Nombres</label>
                            <asp:TextBox ID="Nombres" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValNombres" class="text-danger small validacion-text" runat="server" ControlToValidate="Nombres" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="col-xl-6">
                            <label for="Apellidos" class="form-label">Apellidos</label>
                            <asp:TextBox ID="Apellidos" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValApellidos" class="text-danger small validacion-text" runat="server" ControlToValidate="Apellidos" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="col-xl-5">
                            <label for="Celular" class="form-label">Numero de celular o telefono fijo</label>
                            <asp:TextBox ID="Celular" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValCelular" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Celular" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Celular" class="text-danger small validacion-text" runat="server" ControlToValidate="Celular" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>                                      

                        </div>
                            <div class="col-xl-4">
                            <label for="Cedula" class="form-label">Numero de cedula</label>
                            <asp:TextBox ID="Cedula" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValCedula" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Cedula" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Cedula" class="text-danger small validacion-text" runat="server" ControlToValidate="Cedula" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>
                            </div>
                            <div class="col-xl-3">
                            <label for="Edad" class="form-label">Edad</label>
                            <asp:TextBox ID="Edad" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValEdad" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Edad" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Edad" class="text-danger small validacion-text" runat="server" ControlToValidate="Edad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <asp:RangeValidator ID="Val3Edad" class="text-danger small validacion-text" runat="server" MaximumValue="80" MinimumValue="18" ValidationGroup="Requeridos" ControlToValidate="Edad" Display="Dynamic">Debe ser mayor de edad (+18 años)</asp:RangeValidator>
                                </div>
                            </div>
                            <div class="col-xl-9">
                            <label for="Direccion" class="form-label">Dirección de residencia</label>
                            <asp:TextBox ID="Direccion" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">

                                <asp:RequiredFieldValidator ID="Val2Direccion" class="text-danger small validacion-text" runat="server" ControlToValidate="Direccion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>
                            </div>
                        <div class="col-xl-3">
                            <label for="Ciudad" class="form-label">Ciudad de residencia</label>
                            <asp:TextBox ID="Ciudad" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValCiudad" class="text-danger small validacion-text" runat="server" ControlToValidate="Ciudad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="col-12">
                            <label for="Correo" class="form-label">Correo electronico</label>
                            <asp:TextBox ID="Correo" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValCorreo" class="text-danger small validacion-text" runat="server" ErrorMessage="Debe ingresar un correo valido" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" ControlToValidate="Correo" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Correo" class="text-danger small validacion-text" runat="server" ControlToValidate="Correo" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>      
                                <div runat="server" id="Val3Correo"></div>
                            </div>
                            </div>
                            <div class="col-xl-6">
                            <label for="Contraseña" class="form-label">Contraseña</label>
                            <asp:TextBox ID="Contraseña" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xl-6">
                            <label for="RContraseña" class="form-label">Repetir contraseña</label>
                            <asp:TextBox ID="RContraseña" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            </div>
                           <div class="col-12 text-center">
                            <div class="d-flex flex-column justify-content-start">
                                <asp:CompareValidator ID="ValPass" class="text-danger small" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="Contraseña" ControlToValidate="RContraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small" runat="server" ControlToValidate="Contraseña" ErrorMessage="Debe ingresar una contraseña" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>                                    

                        </div>
                        <div class="col-12 text-center">
                            <asp:Button ID="BtnCrearUsuario" class="btn btn-primary btn-lg w-75" runat="server" Text="Registrar usuario" OnClick="BtnCrearUsuario_Click" ValidationGroup="Requeridos"/>
                        </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
