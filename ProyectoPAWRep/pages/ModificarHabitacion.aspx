<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="ModificarHabitacion.aspx.cs" Inherits="ProyectoPAWRep.pages.ModificarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Modificar habitación</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Modificar habitación</div>
                  <div class="admin-page-description mb-2">En esta seccion podras modificar las habitaciones.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <div runat="server" id="alertaspace"></div>
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <div runat="server" id="seleccionar_habitacion">
                        <h1>Cargar información de la habitación</h1>
                          <div class="row">
                            <label for="MHabitacionNumero" class="col-sm-2 col-form-label">Numero de la habitación</label>
                            <div class="col-sm-4">
                           <asp:DropDownList ID="MHabitacionNumeroToLoad" class="form-select" runat="server">
                            </asp:DropDownList>
                            </div>
                          </div>
                          <div class="col-12">
                            <button id="cargarinformacionhabitacion" type="submit" class="btn btn-primary mt-2" runat="server" onserverclick="cargarinformacionhabitacion_ServerClick"><i class="fa fa-download"></i> Cargar informacion habitación</button>
                          </div>
                      </div>
                    <h1>Imagenes de la habitación</h1>
                      <div class="col-md-6">
                        <label for="MHabitacionImg" class="form-label">Imagenes que se mostraran en la pagina de la habitación</label>
                        <div class="form-text">
                          Solo se permiten subir 3 imagenes, las cuales eran las que se mostraran en la pagina de dicha habitación. Preferiblemente imagenes de dimensiones 900x500 pixeles.
                        </div>
                        <asp:FileUpload ID="MHabitacionImg" AllowMultiple="true" runat="server" class="form-control"/>
                          <div class="text-danger small" runat="server" id="ValFotos" visible="false">Debe ingresar 3 imagenes</div>
                      </div>
                      <div class="col-md-6">
                        <label for="MHabitacionIcon" class="form-label">Imagen icono</label>
                        <div class="form-text">
                          Esta imagen se mostrara en la lista de las habitaciones. Preferiblemente imagen de dimensiones 600x600 pixeles
                        </div>
                        <asp:FileUpload ID="MHabitacionIcon" AllowMultiple="false" runat="server" class="form-control"/>
                        <div class="text-danger small" runat="server" id="ValIcono" visible="false">Debe ingresar una imagen</div>
                      </div>
                      <h1>Información de la habitación</h1>
                      <div class="col-2">
                        <label for="MHabitacionNumero" class="form-label">Numero de habitación</label>
                            <asp:TextBox ID="MHabitacionNumero" class="form-control" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                        <div class="d-flex flex-column justify-content-start">
                            <asp:RegularExpressionValidator ID="ValNumeroH" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores enteros" ValidationExpression="^([0-9])*$" ControlToValidate="MHabitacionNumero" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="Val2NumeroH" class="text-danger small validacion-text" runat="server" ControlToValidate="MHabitacionNumero" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                            <div class="text-danger small" runat="server" id="Val3NumeroH" visible="false">El numero de habitación ingresado ya existe</div>
                        </div>    
                      </div>
                      <div class="col-2">
                        <label for="MHabitacionCamas" class="form-label">Numero de camas</label>
                             <asp:DropDownList ID="MHabitacionCamas" class="form-select" runat="server" ClientIDMode="Static">
                                <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                                <asp:ListItem Value="2">2</asp:ListItem>
                                <asp:ListItem Value="3">3</asp:ListItem>
                                <asp:ListItem Value="4">4</asp:ListItem>
                                <asp:ListItem Value="5">5</asp:ListItem>
                                <asp:ListItem Value="6">6</asp:ListItem>
                            </asp:DropDownList>
                      </div>
                      <div class="col-2">
                        <label for="MHabitacionSize" class="form-label">Tamaño</label>
                        <asp:DropDownList ID="MHabitacionSize" class="form-select" runat="server">
                            <asp:ListItem Value="Pequeña" Selected="True">Pequeña</asp:ListItem>
                            <asp:ListItem Value="Mediana">Mediana</asp:ListItem>
                            <asp:ListItem Value="Grande">Grande</asp:ListItem>
                            <asp:ListItem Value="Piso ejecutivo">Piso ejecutivo</asp:ListItem>
                        </asp:DropDownList>
                      </div>
                      <div class="col-2">
                        <label for="MHabitacionPrecio" class="form-label">Precio por noche</label>
                        <div class="input-group">
                          <span class="input-group-text">$</span>
                            <asp:TextBox ID="MHabitacionPrecio" class="form-control" placeholder="139.000" runat="server" ClientIDMode="Static"></asp:TextBox>
                          <span class="input-group-text">COP</span>
                            <button class="btn btn-warning enable-textbox" id="btnprecio" type="button" data-textbox="MHabitacionPrecio"><i class="fas fa-edit"></i></button>
                        </div>
                        <div class="d-flex flex-column justify-content-start">
                            <asp:RegularExpressionValidator ID="ValPrecioH" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite numeros decimales" ValidationExpression="^[0-9]+(\.[0-9]{1,4})?$" ControlToValidate="MHabitacionPrecio" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="Val2PrecioH" class="text-danger small validacion-text" runat="server" ControlToValidate="MHabitacionPrecio" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>  
                      </div>
                      <div class="col-2 d-flex flex-column justify-content-center">
                        <div class="form-check">
                            <asp:CheckBox ID="MHabitacionMascotas" runat="server" class="form-check-input" CssClass="form-check-input" BorderStyle="None" />
                          <label class="form-check-label" for="CHabitacionMascotas">
                            Admite mascotas
                          </label>
                        </div>
                      </div>
                      <div class="col-2 d-flex flex-column justify-content-center">
                        <div class="form-check">
                          <asp:CheckBox ID="MHabitacionDiscapacitados" runat="server" class="form-check-input" CssClass="form-check-input" BorderStyle="None" />
                          <label class="form-check-label" for="CHabitacionDiscapacitados">
                            Posee baños para discapacitados
                          </label>
                        </div>
                      </div>
                      <div class="col-12">
                        <div class="input-group">
                            <asp:TextBox ID="MHabitacionDescripcion" class="form-control" placeholder="Descripción" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                            <button class="btn btn-warning enable-textbox" id="btndesc" type="button" data-textbox="MHabitacionDescripcion"><i class="fas fa-edit"></i></button>
                        </div>
                          <asp:RequiredFieldValidator ID="ValDescH" class="text-danger small validacion-text" runat="server" ControlToValidate="MHabitacionDescripcion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                      </div>
                    <h1>Descuento</h1>
                      <div class="col-2">
                        <label for="MHabitacionDescuentoDropdown" class="form-label">Descuento de la habitación</label>
                        <asp:DropDownList ID="MHabitacionDescuentoDropdown" class="form-select" runat="server">
                        </asp:DropDownList>
                      </div>
                      <div class="col-12 text-center">
                          <asp:Button ID="BtnModificarHabitacion" ValidationGroup="Requeridos" class="btn btn-primary btn-lg" runat="server" Text="Modificar habitacíon" OnClick="BtnModificarHabitacion_Click" />
                      </div>
                    </form>
                  </div>
                </div>
              </div>
        <script src="../js/EnableTextboxHabitacion.js"></script>
</asp:Content>
