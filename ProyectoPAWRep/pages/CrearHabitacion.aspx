<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="CrearHabitacion.aspx.cs" Inherits="ProyectoPAWRep.pages.CrearHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Crear habitación</div>
                  <div class="admin-page-description mb-2">En esta seccion podras crear nuevas habitaciones que se mostraran en su respectiva pagina.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <div runat="server" id="alertaspace"></div>
                    <h1>Imagenes de la habitación</h1>
                    <form class="row g-3" runat="server" style="margin-top: -30pt;">
                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                    </asp:ScriptManager>
                      <div class="col-md-6">
                        <label for="CHabitacionImg" class="form-label">Imagenes que se mostraran en la pagina de la habitación</label>
                        <div class="form-text">
                          Solo se permiten subir 3 imagenes, las cuales eran las que se mostraran en la pagina de dicha habitación. Preferiblemente imagenes de dimensiones 900x500 pixeles.
                        </div>
                        <asp:FileUpload ID="CHabitacionImg" AllowMultiple="true" runat="server" class="form-control"/>
                          <div class="text-danger small" runat="server" id="ValFotos" visible="false">Debe ingresar 3 imagenes</div>
                      </div>
                      <div class="col-md-6">
                        <label for="CHabitacionIcon" class="form-label">Imagen icono</label>
                        <div class="form-text">
                          Esta imagen se mostrara en la lista de las habitaciones. Preferiblemente imagen de dimensiones 600x600 pixeles
                        </div>
                        <asp:FileUpload ID="CHabitacionIcon" AllowMultiple="false" runat="server" class="form-control"/>
                          <div class="text-danger small" runat="server" id="ValIcono" visible="false">Debe ingresar una imagen</div>
                      </div>
                      <h1>Información de la habitación</h1>
                      <div class="col-2">
                        <label for="CHabitacionNumero" class="form-label">Numero de habitación</label>
                        <asp:TextBox ID="CHabitacionNumero" class="form-control" runat="server" placeholder="409"></asp:TextBox>
                        <div class="d-flex flex-column justify-content-start">
                            <asp:RegularExpressionValidator ID="ValNumeroH" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores enteros" ValidationExpression="^([0-9])*$" ControlToValidate="CHabitacionNumero" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="Val2NumeroH" class="text-danger small validacion-text" runat="server" ControlToValidate="CHabitacionNumero" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                            <div class="text-danger small" runat="server" id="Val3NumeroH" visible="false">El numero de habitación ingresado ya existe</div>
                        </div>    
                      </div>
                      <div class="col-2">
                        <label for="CHabitacionCamas" class="form-label">Numero de camas</label>
                         <asp:DropDownList ID="CHabitacionCamas" class="form-select" runat="server">
                            <asp:ListItem Value="1" Selected="True">1</asp:ListItem>
                            <asp:ListItem Value="2">2</asp:ListItem>
                            <asp:ListItem Value="3">3</asp:ListItem>
                            <asp:ListItem Value="4">4</asp:ListItem>
                            <asp:ListItem Value="5">5</asp:ListItem>
                            <asp:ListItem Value="6">6</asp:ListItem>
                        </asp:DropDownList>
                      </div>
                      <div class="col-2">
                        <label for="CHabitacionSize" class="form-label">Tamaño</label>
                        <asp:DropDownList ID="CHabitacionSize" class="form-select" runat="server">
                            <asp:ListItem Value="Pequeña" Selected="True">Pequeña</asp:ListItem>
                            <asp:ListItem Value="Mediana">Mediana</asp:ListItem>
                            <asp:ListItem Value="Grande">Grande</asp:ListItem>
                            <asp:ListItem Value="Piso ejecutivo">Piso ejecutivo</asp:ListItem>
                        </asp:DropDownList>
                      </div>
                      <div class="col-2">
                        <label for="CHabitacionPrecio" class="form-label">Precio por noche</label>
                        <div class="input-group">
                          <span class="input-group-text">$</span>
                            <asp:TextBox ID="CHabitacionPrecio" class="form-control" placeholder="139.000" runat="server"></asp:TextBox>
                          <span class="input-group-text">COP</span>
                        </div>
                        <div class="d-flex flex-column justify-content-start">
                            <asp:RegularExpressionValidator ID="ValPrecioH" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite numeros decimales" ValidationExpression="^[0-9]+(\.[0-9]{1,4})?$" ControlToValidate="CHabitacionPrecio" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="Val2PrecioH" class="text-danger small validacion-text" runat="server" ControlToValidate="CHabitacionPrecio" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                        </div>  
                      </div>
                      <div class="col-2 d-flex flex-column justify-content-center">
                        <div class="form-check">
                            <asp:CheckBox ID="CHabitacionMascotas" runat="server" class="form-check-input" CssClass="form-check-input" BorderStyle="None" />
                          <label class="form-check-label" for="CHabitacionMascotas">
                            Admite mascotas
                          </label>
                        </div>
                      </div>
                      <div class="col-2 d-flex flex-column justify-content-center">
                        <div class="form-check">
                          <asp:CheckBox ID="CHabitacionDiscapacitados" runat="server" class="form-check-input" CssClass="form-check-input" BorderStyle="None" />
                          <label class="form-check-label" for="CHabitacionDiscapacitados">
                            Posee baños para discapacitados
                          </label>
                        </div>
                      </div>
                      <div class="col-12">
                        <asp:TextBox ID="CHabitacionDescripcion" class="form-control" placeholder="Descripción" runat="server" TextMode="MultiLine" Rows="3"></asp:TextBox>
                          <asp:RequiredFieldValidator ID="ValDescH" class="text-danger small validacion-text" runat="server" ControlToValidate="CHabitacionDescripcion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                      </div>
                      <div class="col-12 text-center">
                          <asp:Button ID="BtnCrearHabitacion" ValidationGroup="Requeridos" class="btn btn-primary btn-lg" runat="server" Text="Crear habitacíon" OnClick="BtnCrearHabitacion_Click" />
                      </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
