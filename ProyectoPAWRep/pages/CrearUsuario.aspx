<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="CrearUsuario.aspx.cs" Inherits="ProyectoPAWRep.pages.AgregarUsuario" %>
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
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                        <h1>Información del usuario</h1>
                        <div runat="server" id="alertaspace"></div>
                        <div class="col-xl-6">
                            <label for="CUNombres" class="form-label">Nombres</label>
                            <asp:TextBox ID="CUNombres" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValNombres" class="text-danger small validacion-text" runat="server" ControlToValidate="CUNombres" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="col-xl-6">
                            <label for="CUApellidos" class="form-label">Apellidos</label>
                            <asp:TextBox ID="CUApellidos" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="ValApellidos" class="text-danger small validacion-text" runat="server" ControlToValidate="CUApellidos" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="col-xl-5">
                            <label for="CUCelular" class="form-label">Numero de celular o telefono fijo</label>
                            <asp:TextBox ID="CUCelular" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValCelular" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="CUCelular" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Celular" class="text-danger small validacion-text" runat="server" ControlToValidate="CUCelular" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>                                      

                        </div>
                            <div class="col-xl-4">
                            <label for="CUCedula" class="form-label">Numero de cedula</label>
                            <asp:TextBox ID="CUCedula" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValCedula" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="CUCedula" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Cedula" class="text-danger small validacion-text" runat="server" ControlToValidate="CUCedula" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>
                            </div>
                            <div class="col-xl-3">
                            <label for="CUEdad" class="form-label">Edad</label>
                            <asp:TextBox ID="CUEdad" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValEdad" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="CUEdad" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Edad" class="text-danger small validacion-text" runat="server" ControlToValidate="CUEdad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                <asp:RangeValidator ID="Val3Edad" class="text-danger small validacion-text" runat="server" MaximumValue="80" MinimumValue="18" ValidationGroup="Requeridos" ControlToValidate="CUEdad" Display="Dynamic">Debe ser mayor de edad (+18 años)</asp:RangeValidator>
                                </div>
                            </div>
                            <div class="col-xl-9">
                            <label for="CUDireccion" class="form-label">Dirección de residencia</label>
                            <asp:TextBox ID="CUDireccion" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">

                                <asp:RequiredFieldValidator ID="Val2Direccion" class="text-danger small validacion-text" runat="server" ControlToValidate="CUDireccion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>
                            </div>
                        <div class="col-xl-3">
                            <label for="CUCiudad" class="form-label">Ciudad de residencia</label>
                            <asp:TextBox ID="CUCiudad" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                <asp:RequiredFieldValidator ID="ValCiudad" class="text-danger small validacion-text" runat="server" ControlToValidate="CUCiudad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>
                        <div class="col-12">
                            <label for="CUCorreo" class="form-label">Correo electronico</label>
                            <asp:TextBox ID="CUCorreo" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            <div class="d-flex flex-column justify-content-start">
                                <asp:RegularExpressionValidator ID="ValCorreo" class="text-danger small validacion-text" runat="server" ErrorMessage="Debe ingresar un correo valido" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" ControlToValidate="CUCorreo" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                <asp:RequiredFieldValidator ID="Val2Correo" class="text-danger small validacion-text" runat="server" ControlToValidate="CUCorreo" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>      
                                <div runat="server" class="text-danger small validacion-text" id="Val3Correo" Visible="false">El correo ingresado ya esta en uso.</div>
                            </div>
                            </div>
                            <div class="col-xl-6">
                            <label for="CUContraseña" class="form-label">Contraseña</label>
                            <asp:TextBox ID="CUContraseña" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            </div>
                            <div class="col-xl-6">
                            <label for="CURContraseña" class="form-label">Repetir contraseña</label>
                            <asp:TextBox ID="CURContraseña" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                            </div>
                           <div class="col-12 text-center">
                            <div class="d-flex flex-column justify-content-start">
                                <asp:CompareValidator ID="ValPass" class="text-danger small" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="CUContraseña" ControlToValidate="CURContraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:CompareValidator>
                                <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small" runat="server" ControlToValidate="CUContraseña" ErrorMessage="Debe ingresar una contraseña" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                            </div>                                    

                        </div>
                          <div class="row">
                            <label for="CUTipo" class="col-sm-2 col-form-label">Tipo de usuario</label>
                            <div class="col-sm-4">
                           <asp:DropDownList ID="CUTipo" class="form-select form-control-lg" runat="server">
                               <asp:ListItem>Cliente</asp:ListItem>
                               <asp:ListItem>Administrador</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                          </div>
                        <div class="col-12 text-center">
                            <asp:Button ID="BtnCrearUsuario" class="btn btn-primary btn-lg" runat="server" Text="Registrar usuario" OnClick="BtnCrearUsuario_Click" ValidationGroup="Requeridos"/>
                        </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
