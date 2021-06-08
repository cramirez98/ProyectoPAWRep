<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarUsuario.aspx.cs" Inherits="ProyectoPAWRep.pages.ModificarUsuario" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar Usuario</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Modificar usuario</div>
                  <div class="admin-page-description mb-2">En esta seccion podras modificar la información de los usuarios que se han creado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <div runat="server" id="seleccionar_usuario">
                        <h1>Cargar información del usuario</h1>
                          <div class="row">
                            <label for="MUsuarioLoad" class="col-sm-2 col-form-label">Nombres, apellidos y correo del usuario:</label>
                            <div class="col-sm-4">
                           <asp:DropDownList ID="MUsuarioLoad" class="form-select" runat="server">
                            </asp:DropDownList>
                            </div>
                          </div>
                          <div class="col-12">
                            <button id="cargarinformacionusuario" type="submit" class="btn btn-primary mt-2" runat="server" onserverclick="cargarinformacionusuario_ServerClick" Enabled="false"><i class="fa fa-download"></i> Cargar información</button>
                          </div>
                      </div>
                        <div class="row d-none" runat="server" id="informacion_usuario">
                        <h1 class="mt-3">Información del usuario</h1>
                        <div runat="server" id="alertaspace"></div>
                         <asp:TextBox ID="IDUsuario" class="form-control form-control-lg d-none" data-enable="true" EnableViewState="true" runat="server" placeholder=""></asp:TextBox>
                                <div class="row d-flex justify-content-center">
                                    <div class="col-xs-4 d-flex justify-content-center text-center">
                                        <img src="../img/nelson.jpeg" class="m-2 border border-5 img-fluid rounded-circle" alt="..." width="200" height="200" runat="server" id="ImagePerfilPaginaModificar">

                                    </div>
                                </div>                                
                                <div class="row justify-content-center mb-3">
                                    <div class="col-xl-6">
                                      <label for="MUFotoPerfil" class="form-label">Foto de perfil</label>
                                      <asp:FileUpload ID="MUFotoPerfil" runat="server" class="form-control"/>
                                    </div>
                                </div>
                                    <div class="col-xl-6">
                                      <label for="MUNombres" class="form-label">Nombres</label>
                                        <div class="input-group">
                                          <asp:TextBox ID="MUNombres" class="form-control form-control-lg" data-enable="true" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" type="button" data-textbox="MUNombres"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <asp:RequiredFieldValidator ID="ValNombres" class="text-danger small validacion-text" runat="server" ControlToValidate="MUNombres" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-6">
                                      <label for="MUApellidos" class="form-label">Apellidos</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUApellidos" class="form-control form-control-lg" data-enable="true" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnapellidos" type="button" data-textbox="MUApellidos"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <asp:RequiredFieldValidator ID="ValApellidos" class="text-danger small validacion-text" runat="server" ControlToValidate="MUApellidos" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-5">
                                        <label for="MUCelular" class="form-label">Numero de celular o telefono fijo</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUCelular" class="form-control form-control-lg" data-enable="true" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btncelular" type="button" data-textbox="Celular"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCelular" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="MUCelular" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Celular" class="text-danger small validacion-text" runat="server" ControlToValidate="MUCelular" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                      

                                    </div>
                                      <div class="col-xl-4">
                                        <label for="MUCedula" class="form-label">Numero de cedula</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUCedula" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btncedula" type="button" data-textbox="Cedula"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCedula" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="MUCedula" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Cedula" class="text-danger small validacion-text" runat="server" ControlToValidate="MUCedula" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                      <div class="col-xl-3">
                                        <label for="MUEdad" class="form-label">Edad</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUEdad" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnedad" type="button" data-textbox="Edad"><i class="fas fa-edit"></i></button>
                                        </div>
                                          <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValEdad" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="MUEdad" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Edad" class="text-danger small validacion-text" runat="server" ControlToValidate="MUEdad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                            <asp:RangeValidator ID="Val3Edad" class="text-danger small validacion-text" runat="server" MaximumValue="80" MinimumValue="18" ValidationGroup="Requeridos" ControlToValidate="MUEdad" Display="Dynamic">Debe ser mayor de edad (+18 años)</asp:RangeValidator>
                                          </div>
                                      </div>
                                      <div class="col-xl-9">
                                        <label for="MUDireccion" class="form-label">Dirección de residencia</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUDireccion" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btndireccion" type="button" data-textbox="Direccion"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">

                                            <asp:RequiredFieldValidator ID="Val2Direccion" class="text-danger small validacion-text" runat="server" ControlToValidate="MUDireccion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                    <div class="col-xl-3">
                                      <label for="MUCiudad" class="form-label">Ciudad de residencia</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUCiudad" class="form-control form-control-lg" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnciudad" type="button" data-textbox="Ciudad"><i class="fas fa-edit"></i></button>
                                        </div>
                                            <asp:RequiredFieldValidator ID="ValCiudad" class="text-danger small validacion-text" runat="server" ControlToValidate="MUCiudad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-12">
                                        <label for="MUCorreo" class="form-label">Correo electronico</label>
                                        <div class="input-group">
                                        <asp:TextBox ID="MUCorreo" class="form-control form-control-lg" data-enable="true" runat="server"></asp:TextBox>                                          
                                            <button class="btn btn-warning enable-textbox" id="btncorreo" type="button" data-textbox="Direccion"><i class="fas fa-edit"></i></button>
                                        </div>                                
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCorreo" class="text-danger small validacion-text" runat="server" ErrorMessage="Debe ingresar un correo valido" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" ControlToValidate="MUCorreo" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Correo" class="text-danger small validacion-text" runat="server" ControlToValidate="MUCorreo" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>      
                                            <div runat="server" class="text-danger small validacion-text" id="Val3Correo" Visible="false">El correo ingresado ya esta en uso.</div>
                                        </div>
                                      </div>
                                      <div class="col-xl-6 mt-2">
                                        <label for="MUContraseña" class="form-label">Nueva contraseña</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="MUContraseña" class="form-control form-control-lg" data-modified="false" data-enable="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox-password" id="btncontraseña" type="button" data-textbox="Contraseña"><i class="fas fa-edit"></i></button>
                                        </div>
                                      </div>
                                      <div class="col-xl-6 mt-2">
                                        <label for="MURContraseña" class="form-label" id="labelRContraseña" data-enable="true" hidden>Repetir nueva contraseña</label>
                                        <asp:TextBox ID="MURContraseña" class="form-control form-control-lg" runat="server" hidden></asp:TextBox>
                                      </div>
                                    <div class="col-12 text-center">
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:CompareValidator ID="ValPass" class="text-danger small" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="MUContraseña" ControlToValidate="MURContraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small" runat="server" ControlToValidate="MUContraseña" ErrorMessage="Debe ingresar una contraseña" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                    

                                    </div>
                          <div class="row">
                            <label for="MUTipo" class="col-sm-2 col-form-label">Tipo de usuario</label>
                            <div class="col-sm-4">
                           <asp:DropDownList ID="MUTipo" class="form-select form-control-lg" runat="server">
                               <asp:ListItem>Cliente</asp:ListItem>
                               <asp:ListItem>Administrador</asp:ListItem>
                            </asp:DropDownList>
                            </div>
                          </div>
                        <div class="col-12 text-center">
                            <asp:Button ID="BtnModificarUsuario" class="btn btn-primary btn-lg mt-4 d-none" runat="server" Text="Modificar usuario" OnClick="BtnModificarUsuario_Click" ValidationGroup="Requeridos"/>
                        </div>
                            </div>
                    </form>
                  </div>
                </div>
              </div>
        <script src="../js/EnableTextboxPlugin.js"></script>
</asp:Content>
