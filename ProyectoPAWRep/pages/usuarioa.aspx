<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="usuarioa.aspx.cs" Inherits="ProyectoPAWRep.pages.usuario" %>

<!doctype html>
<html lang="en">
  <head>
    <title>Pagina principal</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- CSS -->
    <link rel="stylesheet" href="/css/bootstrap.css" crossorigin="anonymous">
    <link rel="stylesheet" href="/css/custom.css" crossorigin="anonymous">
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
      $(function() {
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
  
  </head>
  <body class="body-roboto-font-family bg-less-light">
<div id="inicio"></div>
<div id="navbar-principal">
      <nav class="navbar navbar-expand-xl fixed-top navbar-dark bg-blue">
          <div class="container-fluid">
            <a class="navbar-brand" href="#">
              <img src="../img/logo/logonavbar.png" alt="" width="115" height="45">
            </a>
            <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
              <span class="navbar-toggler-icon"></span>
            </button>
            <div class="collapse navbar-collapse" id="navbarSupportedContent">
              <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                <li class="nav-item">
                  <a class="nav-link active" aria-current="page" href="/index.html"><i class="icon-camera-retro"></i>Inicio</a>
                </li>
                <li class="nav-item dropdown">
                  <a class="nav-link" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    Habitaciones
                  </a>
                  <ul class="dropdown-menu" aria-labelledby="navbarDropdown">
                    <li><a class="dropdown-item" href="#">Habitaciones familiares</a></li>
                    <li><a class="dropdown-item" href="#">Habitaciones Piso Ejecutivo</a></li>
                    <li><hr class="dropdown-divider"></li>
                    <li><a class="dropdown-item" href="#">Visualizar todas las habitaciones</a></li>
                  </ul>
                </li>
              </ul>
  
            <ul class="navbar-nav ml-auto">
              <li class="nav-item dropdown">
                <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                    <img src="img/nelson.jpeg" class="rounded-circle" alt="..." width="50" height="50" runat="server" id="navbar_image_profile">
                </a>
                <ul class="dropdown-menu dropdown-menu-lg-end" aria-labelledby="navbarDropdown">
                  <li><a class="dropdown-item" href="login.html">Perfil</a></li>
                  <li><a class="dropdown-item" href="registro.html">Cerrar sesion</a></li>
                </ul>
              </li>
            </ul>            
              
            </div>
          </div>
        </nav>
</div>

      <header class="normal-page d-none d-xl-block">
      </header>

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
                                <div class="row">
<!--                                   <div class="alert alert-primary" role="alert">
                                    <h4 class="alert-heading"><i class="fas fa-inbox"></i> No posees ninguna reserva activa</h4>
                                    <p>No poseemos ningún registro de que poseas una reserva activa, cuando realices una reservación para una habitación, en este lugar aparecerá la información de dicha reserva
                                      y también se te dará la opción de cancelarla siempre y cuando te encuentres dentro del tiempo estipulado para realizar dicha cancelación.
                                    </p>
                                    <hr>
                                    <p class="mb-0">Encuentra la habitacion ideal y preparate para una experiencia inolvidable, solo debes revisar las habitaciones disponibles dando <a href="#" class="alert-link">click aquí</a>!</p>
                                  </div> -->
                                  <div class="col-sm-12">
                                    <div class="alert alert-danger d-flex align-items-center alert-dismissible fade show" role="alert">
                                      <span class="fa fa-exclamation-triangle flex-shrink-0 me-2"></span>
                                      <div>
                                        Se ha terminado el lapso de tiempo máximo para realizar la cancelación de la reserva.
                                      </div>
                                      <button type="button" class="btn-close" data-bs-dismiss="alert" aria-label="Close"></button>
                                    </div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Estado:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <span class="badge rounded-pill bg-success">Activa</span>
                                  </div>
                                  <hr>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Fecha de pago:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">20/07/2020</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Fecha de llegada:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">01/09/2020</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Fecha de salida:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">07/09/2020</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Valor del pago:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">300.000 pesos</div>
                                  </div>
                                  <hr>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Habitación reservada:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">407</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Tamaño de habitacion:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">Familiar</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Numero de camas de la habitacion:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">4</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Baño para discapacitados:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">Si</div>
                                  </div>
                                  <div class="col-sm-3 mb-2">
                                    <div class="usuario-info-label-sidebar text-start">Posibilidad de mascota:</div>
                                  </div>
                                  <div class="col-sm-9 mb-2">
                                    <div class="usuario-info-text-sidebar text-start">Si</div>
                                  </div>
                                  <div class="col-sm-12 text-center">
                                    <button type="button" class="btn btn-outline-danger btn-lg round-edges-20"><i class="fas fa-calendar-times"></i> Cancelar la reserva</button>
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
                                    <th scope="col">Habitacion</th>
                                    <th scope="col">Fecha de llegada</th>
                                    <th scope="col">Fecha de salida</th>
                                    <th scope="col">Fecha de pago</th>
                                    <th scope="col">Caracteristicas</th>
                                  </tr>
                                </thead>
                                <tbody>
                                  <tr>
                                    <th scope="row">1</th>
                                    <td>407</td>
                                    <td>11/12/2020</td>
                                    <td>19/12/2020</td>
                                    <td>30/11/2020</td>
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
                                <div runat="server" id="alertaspace"></div>
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

      <div class="seccion bg-dark flex-grow-1">
        <div class="container-fluid">
          <div class="row justify-content-center">
            <div class="col-lg-2 col-6 align-self-center text-center">
              <img src="/img/logo/logonavbar.png" class="img-fluid" alt="..." width="300" height="300">
              <p class="text-white">Hospedate con nosotros!</p>
            </div>
            <div class="col-lg-10 d-flex flex-column">
              <h4 class="text-white">Links</h4>
              <a href="http://">Inicio</a>
              <a href="http://">Habitaciones</a>
              <a href="http://">Inicio de sesion</a>
              <a href="http://">Registro</a>
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
          <div class="carousel-inner">
            <div class="carousel-item active">
              <img src="/img/Aboutus1.png" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="/img/Aboutus1.png" class="d-block w-100" alt="...">
            </div>
            <div class="carousel-item">
              <img src="/img/Aboutus1.png" class="d-block w-100" alt="...">
            </div>
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
          <div class="row">
            <div class="col-sm-4 mb-2">
              <div class="usuario-info-label-sidebar text-start">Habitación:</div>
            </div>
            <div class="col-sm-8 mb-2">
              <div class="usuario-info-text-sidebar text-start">407</div>
            </div>
            <div class="col-sm-4 mb-2">
              <div class="usuario-info-label-sidebar text-start">Tamaño de habitacion:</div>
            </div>
            <div class="col-sm-8 mb-2">
              <div class="usuario-info-text-sidebar text-start">Familiar</div>
            </div>
            <div class="col-sm-4 mb-2">
              <div class="usuario-info-label-sidebar text-start">Numero de camas de la habitacion:</div>
            </div>
            <div class="col-sm-8 mb-2">
              <div class="usuario-info-text-sidebar text-start">4</div>
            </div>
            <div class="col-sm-4 mb-2">
              <div class="usuario-info-label-sidebar text-start">Baño para discapacitados:</div>
            </div>
            <div class="col-sm-8 mb-2">
              <div class="usuario-info-text-sidebar text-start">Si</div>
            </div>
            <div class="col-sm-4 mb-2">
              <div class="usuario-info-label-sidebar text-start">Posibilidad de mascota:</div>
            </div>
            <div class="col-sm-8 mb-2">
              <div class="usuario-info-text-sidebar text-start">Si</div>
            </div>
            <div class="col-sm-4 mb-2">
              <div class="usuario-info-label-sidebar text-start">Puntaje:</div>
            </div>
            <div class="col-sm-8 mb-2">
              <div class="usuario-info-text-sidebar text-start"><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i></div>
            </div>
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
      <script>
        $(window).scroll(function(){
          $('nav').toggleClass('scrolled', $(this).scrollTop() > 50);
          $('nav').toggleClass('scrolled-nav', $(this).scrollTop() > 50);
        });
        
      </script>
  </body>
</html>
