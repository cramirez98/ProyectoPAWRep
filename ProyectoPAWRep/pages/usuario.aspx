<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Normal.Master" AutoEventWireup="true" CodeBehind="usuario.aspx.cs" Inherits="ProyectoPAWRep.pages.usuario1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Usuario</title>
    <!-- CSS -->
    <link rel="stylesheet" href="../css/bootstrap.css" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/custom.css" crossorigin="anonymous">
    <link rel="stylesheet" href="/css/carousel-custom.css">
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
    <!-- Javascript -->
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
    <script src="/js/bootstrap.bundle.min.js"></script>
    <script src="https://kit.fontawesome.com/7e4e3039b1.js" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
    <!-- Load google fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;300;500;700&family=Recursive:wght@300;400&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,700;0,900;1,100&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Recursive:wght@300;400&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet">
    <script>
        $(function () {
            $('input[name="datetimes"]').daterangepicker({
                timePicker: true,
                startDate: moment().startOf('hour'),
                endDate: moment().startOf('hour').add(32, 'hour'),
                locale: {
                    format: 'M/DD hh:mm A'
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid mt-30 mb-3 mt-xl-3">
          <div class="row bg-less-light justify-content-md-center">
              <div class="col-xxl-3">
                <div class="card round-edges">
                  <div class="card-body">
                    <div class="row g-0">
                        <div class="col-xxl-12 col-lg-6 text-center">
                          <img src="img/nelson.jpeg" class="m-2 border border-5 img-fluid rounded-circle" alt="..." width="200" height="200" runat="server" id="info_panel_image">
                        </div>
                        <div class="col-xxl-12 col-lg-6 d-flex flex-column text-center justify-content-center">
                          <div class="usuario-nombre" runat="server" id="info_panel_nombre">
                            Nelson Esteban Castano
                          </div>
                          <div class="usuario-tiempo" runat="server" id="info_panel_tiempo">
                            Miembro desde Mayo 2020
                          </div>
                            <div class="d-grid gap-2 d-sm-block">
                                <span class="badge bg-primary" runat="server" id="info_panel_tipo">Tipo</span>
                            </div>
                          <br>
                            <div class="row g-0 justify-content-center">
                              <div class="col-sm-4">
                                <div class="usuario-info-label-sidebar text-start">Correo:</div>
                              </div>
                              <div class="col-sm-6">
                                <div class="usuario-info-text-sidebar text-start" runat="server" id="info_panel_correo">camilo.706@hotmail.com</div>
                              </div>
                              <div class="col-sm-4">
                                <div class="usuario-info-label-sidebar text-start">Telefono:</div>
                              </div>
                              <div class="col-sm-6">
                                <div class="usuario-info-text-sidebar text-start" runat="server" id="info_panel_celular">318 500 400</div>
                              </div>
                              <div class="col-sm-4">
                                <div class="usuario-info-label-sidebar text-start">Cedula:</div>
                              </div>
                              <div class="col-sm-6">
                                <div class="usuario-info-text-sidebar text-start" runat="server" id="info_panel_cedula">115558901</div>
                              </div>
                              <div class="col-sm-4">
                                <div class="usuario-info-label-sidebar text-start">Direccion:</div>
                              </div>
                              <div class="col-sm-6">
                                <div class="usuario-info-text-sidebar text-start" runat="server" id="info_panel_direccion">Calle 4D #45 87</div>
                              </div>
                              <div class="col-sm-4">
                                <div class="usuario-info-label-sidebar text-start">Ciudad:</div>
                              </div>
                              <div class="col-sm-6">
                                <div class="usuario-info-text-sidebar text-start" runat="server" id="info_panel_ciudad">Medellin</div>
                              </div>
                            </div>
                        </div>
                    </div>
                  </div>
                  </div>
              </div>
              <div class="col-xxl-8 bg-less-light">
                  <div class="container-fluid mt-3">
                    <ul class="nav navigation-tabs d-flex" id="myTab" role="tablist">
                        <li class="nav-item" role="presentation">
                          <button class="navigation-link active" id="home-tab" data-bs-toggle="tab" data-bs-target="#home" type="button" role="tab" aria-controls="home" aria-selected="true"><i class="fas fa-history"></i> Reserva activa</button>
                        </li>
                        <li class="nav-item" role="presentation">
                          <button class="navigation-link" id="profile-tab" data-bs-toggle="tab" data-bs-target="#profile" type="button" role="tab" aria-controls="profile" aria-selected="false"><i class="fas fa-book"></i> Historial de reservas</button>
                        </li>
                        <li class="nav-item" role="presentation">
                          <button class="navigation-link" id="contact-tab" data-bs-toggle="tab" data-bs-target="#contact" type="button" role="tab" aria-controls="contact" aria-selected="false"><i class="fas fa-user-edit"></i> Modificar información personal</button>
                        </li>
                      </ul>
                      <div class="tab-content tab-contenido pt-3 pb-3 mb-4" id="myTabContent">
                        <div class="tab-pane fade show active" id="home" role="tabpanel" aria-labelledby="home-tab">
                          <h2 class="text-center fw-bold">Informacion de la reserva activa</h2>
                            <div class="container">
                                <div runat="server" id="info_reserva_alertspace"></div>
                                <div class="row" runat="server" id="info_reserva_seccion">
                                  <div class="col-sm-12" runat="server" id="info_reserva_alertacancelacion">
                                    <div class="alert alert-danger d-flex align-items-center alert-dismissible fade show" role="alert">
                                      <span class="fa fa-exclamation-triangle flex-shrink-0 me-2"></span>
                                      <div>
                                        Se ha terminado el lapso de tiempo máximo para realizar la cancelación de la reserva.
                                      </div>
                                      <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                    </div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Fecha de pago:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_fechapago">20/07/2020</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Fecha de llegada:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_fechainicio">01/09/2020</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Fecha de salida:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_fechafinalizacion">07/09/2020</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Valor del pago:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_valorpago">300.000 pesos</div>
                                  </div>
                                  <hr>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Habitación reservada:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_habitacion_numero">407</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Tamaño de habitacion:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_habitacion_tamaño">Familiar</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Numero de camas de la habitacion:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_habitacion_numerocamas">4</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Baño para discapacitados:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_habitacion_bañodiscapacitados">Si</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Posibilidad de mascota:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start" runat="server" id="info_reserva_habitacion_mascotas">Si</div>
                                  </div>
                                  <div class="col-sm-12 text-center">
                                    <button type="button" class="btn btn-outline-danger btn-lg round-edges-20" runat="server" onserverclick="info_reserva_botoncancelar_ServerClick" id="info_reserva_botoncancelar"><i class="fas fa-calendar-times"></i> Cancelar la reserva</button>
                                  </div>

                                </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="profile" role="tabpanel" aria-labelledby="profile-tab">
                          <h2 class="text-center fw-bold">Historial de reservas</h2>
                            <div class="container">
                              <div class="table-responsive">
                              <table class="table">
                                <thead class="table-blue">
                                  <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Fecha de llegada</th>
                                    <th scope="col">Fecha de salida</th>
                                    <th scope="col">Fecha de pago</th>
                                    <th scope="col">Valor del pago</th>
                                    <th scope="col">Numero de personas</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col">Habitación</th>
                                  </tr>
                                </thead>
                                <tbody runat="server" id="reservas_table_info">
                                  <tr>
                                    <th scope="row">1</th>
                                    <td>4</td>
                                    <td>11/12/2020</td>
                                    <td>19/12/2020</td>
                                    <td>30/11/2020</td>
                                    <td>$ 12.350.400 COP</td>
                                    <td><span class="badge bg-danger">Cancelada</span></td>
                                    <td><button type="button" class="btn btn-outline-primary round-edges-20" data-bs-toggle="modal" data-bs-target="#exampleModal">
                                      <i class="fa fa-eye" aria-hidden="true"></i> Ver habitación
                                    </button></td>
                                  </tr>
                                </tbody>
                              </table>
                            </div>
                            </div>
                        </div>
                        <div class="tab-pane fade" id="contact" role="tabpanel" aria-labelledby="contact-tab">
                          <h2 class="text-center fw-bold">Modifica tus datos personales</h2>
                          <div class="container">
                            <form runat="server" class="row justify-content-center">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>

                                <div class="row d-flex justify-content-center">
                                    <div class="col-xs-4 d-flex justify-content-center text-center">
                                        <img src="../img/nelson.jpeg" class="m-2 border border-5 img-fluid rounded-circle" alt="..." width="200" height="200" runat="server" id="ImagePerfilPaginaModificar">

                                    </div>
                                </div>

                                <div runat="server" id="alertaspace"></div>
                                <div class="row justify-content-center mb-3">
                                    <div class="col-xl-6">
                                      <label for="FotoPerfil" class="form-label">Foto de perfil</label>
                                      <asp:FileUpload ID="FotoPerfil" runat="server" class="form-control"/>
                                    </div>
                                </div>
                                    <div class="col-xl-6">
                                      <label for="Nombres" class="form-label">Nombres</label>
                                        <div class="input-group">
                                          <asp:TextBox ID="Nombres" class="form-control form-control-lg" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnnombres" type="button" data-textbox="Nombres"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <asp:RequiredFieldValidator ID="ValNombres" class="text-danger small validacion-text" runat="server" ControlToValidate="Nombres" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-6">
                                      <label for="Apellidos" class="form-label">Apellidos</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Apellidos" class="form-control form-control-lg" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnapellidos" type="button" data-textbox="Apellidos"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <asp:RequiredFieldValidator ID="ValApellidos" class="text-danger small validacion-text" runat="server" ControlToValidate="Apellidos" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-5">
                                        <label for="Celular" class="form-label">Numero de celular o telefono fijo</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Celular" class="form-control form-control-lg" EnableViewState="true" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btncelular" type="button" data-textbox="Celular"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCelular" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Celular" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Celular" class="text-danger small validacion-text" runat="server" ControlToValidate="Celular" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                      

                                    </div>
                                      <div class="col-xl-4">
                                        <label for="Cedula" class="form-label">Numero de cedula</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Cedula" class="form-control form-control-lg" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btncedula" type="button" data-textbox="Cedula"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCedula" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Cedula" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Cedula" class="text-danger small validacion-text" runat="server" ControlToValidate="Cedula" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                      <div class="col-xl-3">
                                        <label for="Edad" class="form-label">Edad</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Edad" class="form-control form-control-lg" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnedad" type="button" data-textbox="Edad"><i class="fas fa-edit"></i></button>
                                        </div>
                                          <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValEdad" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Edad" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Edad" class="text-danger small validacion-text" runat="server" ControlToValidate="Edad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                            <asp:RangeValidator ID="Val3Edad" class="text-danger small validacion-text" runat="server" MaximumValue="80" MinimumValue="18" ValidationGroup="Requeridos" ControlToValidate="Edad" Display="Dynamic">Debe ser mayor de edad (+18 años)</asp:RangeValidator>
                                          </div>
                                      </div>
                                      <div class="col-xl-9">
                                        <label for="Direccion" class="form-label">Dirección de residencia</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Direccion" class="form-control form-control-lg" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btndireccion" type="button" data-textbox="Direccion"><i class="fas fa-edit"></i></button>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">

                                            <asp:RequiredFieldValidator ID="Val2Direccion" class="text-danger small validacion-text" runat="server" ControlToValidate="Direccion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                    <div class="col-xl-3">
                                      <label for="Ciudad" class="form-label">Ciudad de residencia</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Ciudad" class="form-control form-control-lg" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox" id="btnciudad" type="button" data-textbox="Ciudad"><i class="fas fa-edit"></i></button>
                                        </div>
                                            <asp:RequiredFieldValidator ID="ValCiudad" class="text-danger small validacion-text" runat="server" ControlToValidate="Ciudad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                      <div class="col-xl-6">
                                        <label for="Contraseña" class="form-label">Nueva contraseña</label>
                                        <div class="input-group">
                                      <asp:TextBox ID="Contraseña" class="form-control form-control-lg" runat="server" placeholder="" ClientIDMode="Static"></asp:TextBox>
                                          <button class="btn btn-warning enable-textbox-password" id="btncontraseña" type="button" data-textbox="Contraseña"><i class="fas fa-edit"></i></button>
                                        </div>
                                      </div>
                                      <div class="col-xl-6">
                                        <label for="RContraseña" class="form-label" id="labelRContraseña" hidden>Repetir nueva contraseña</label>
                                        <asp:TextBox ID="RContraseña" class="form-control form-control-lg" runat="server" hidden></asp:TextBox>
                                      </div>
                                    <div class="col-12 text-center">
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:CompareValidator ID="ValPass" class="text-danger small" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="Contraseña" ControlToValidate="RContraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small" runat="server" ControlToValidate="Contraseña" ErrorMessage="Debe ingresar una contraseña" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                    

                                    </div>
                                    <div class="col-md-6 text-center mt-2">
                                        <button type="button" onserverclick="BtnGuardarInformacion_Click" class="btn btn-primary btn-lg round-edges-20" runat="server" ValidationGroup="Requeridos"><i class="fas fa-save"></i> Guardar informacion</button>
                                    </div>
                            </form>
                          </div>
                        </div>
                      </div>
                      
                  </div>
              </div>
          </div>
      </div>

<!-- Modal -->
<div class="modal fade" id="exampleModal" tabindex="-1" aria-labelledby="exampleModalLabel" aria-hidden="true">
  <div class="modal-dialog modal-lg">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title" id="exampleModalLabel">Caracteristicas de la habitación</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <div id="carouselExampleIndicators" class="carousel slide" data-bs-ride="carousel">
          <div class="carousel-indicators">
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
            <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
          </div>
          <div class="carousel-inner" id="modal-habitacion-fotos">
          </div>
          <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
            <span class="carousel-control-prev-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Previous</span>
          </button>
          <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
            <span class="carousel-control-next-icon" aria-hidden="true"></span>
            <span class="visually-hidden">Next</span>
          </button>
        </div>

        <div class="container-fluid mt-2">
          <div class="row" id="modal-habitacion-info">
          </div>
        </div>

      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Cerrar</button>
      </div>
    </div>
  </div>
</div>
<!-- Optional JavaScript -->
<script src="../js/EnableTextbox.js"></script>
<script src="../js/usuario.js"></script>
      <script>
          $(window).scroll(function () {
              $('nav').toggleClass('scrolled', $(this).scrollTop() > 50);
              $('nav').toggleClass('scrolled-nav', $(this).scrollTop() > 50);
          });
      </script>
</asp:Content>
