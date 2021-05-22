<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Normal.Master" AutoEventWireup="true" CodeBehind="habitacion_pagina.aspx.cs" Inherits="ProyectoPAWRep.pages.HabitacionPagina" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Habitacion</title>
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
      <div class="container-fluid container-lg mt-30 mb-3 mt-xl-3">
          <div class="row">
              <div class="habitacion-body p-3">
                <!-- Informacion de la habitacion -->
                <div id="carouselExampleCaptions" class="carousel slide" data-bs-interval="false"><!-- Empieza carousel -->
                    <ol class="carousel-indicators my-4">
                        <li data-bs-target="#carouselExampleCaptions" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></li>
                        <li data-bs-target="#carouselExampleCaptions" data-bs-slide-to="1" aria-label="Slide 2"></li>
                        <li data-bs-target="#carouselExampleCaptions" data-bs-slide-to="2" aria-label="Slide 3"></li>
                      </ol>
                    <div class="carousel-inner">
                      <div class="carousel-item active">
                        <img src="/img/habitaciones/409/foto1.png" class="d-block w-100" alt="..." runat="server" id="PHabitacionFoto1">
                      </div>
                      <div class="carousel-item">
                        <img src="/img/habitaciones/409/foto2.png" class="d-block w-100" alt="..." runat="server" id="PHabitacionFoto2">
                      </div>
                      <div class="carousel-item">
                        <img src="/img/habitaciones/409/foto3.png" class="d-block w-100" alt="..." runat="server" id="PHabitacionFoto3">
                      </div>
                    </div>
                    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="prev">
                      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                      <span class="visually-hidden">Previous</span>
                    </button>
                    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleCaptions" data-bs-slide="next">
                      <span class="carousel-control-next-icon" aria-hidden="true"></span>
                      <span class="visually-hidden">Next</span>
                    </button>
                  </div><!-- Termina carousel -->
                  <div class="container-fluid mt-2">
                      <div class="row g-0 border-bottom-1">
                        <div class="col-lg-8">
                            <div class="d-flex flex-row">
                                <div class="ff-oswaldo text-uppercase">20 opiniones</div>
                                  <div class="habitacion-info-review">
                                    <div class="stars-outer">
                                        <div class="stars-inner" style="width: 80%;"></div>
                                      </div>
                                    </div>
                                    <div class="fc-gray fw-bold ff-oswaldo">4</div>
                                  </div>
                                <div class="d-flex flex-column">
                                    <div class="habitacion-info-title text-center text-lg-start" runat="server" id="PHabitacionNumero">
                                        Habitacion 409
                                    </div>
                                    <div class="habitacion-info-subtitle d-none d-lg-block" runat="server" id="PHabitacionTamaño">
                                        Mediana
                                    </div>
                                </div>
                        </div>
                        <div class="col-lg-4">
                            <div class="d-flex text-start text-lg-end flex-column" runat="server" id="PHabitacionConDescuento">
                                <div class="d-flex justify-content-lg-end">
                                    <div class="habitacion-info-precio text-decoration-line-through text-muted fs-5" runat="server" id="PHabitacionPrecioSinDescuento">
                                    $460.300 COP
                                    </div>
                                    <span class="fc-blue ff-oswaldo" runat="server" id="PHabitacionDescuento">50% OFF</span>
                                </div>
                                <div class="habitacion-info-precio fc-orange" runat="server" id="PHabitacionPrecioConDescuento">
                                    $230.150 COP
                                </div>
                                <div class="habitacion-precio-desc">Por noche</div>
                              </div>
                            <div class="d-flex text-start text-lg-end flex-column" runat="server" id="PHabitacionSinDescuento">
                                <div class="habitacion-info-precio" runat="server" id="PHabitacionPrecioSinDescuento2">
                                    $230.150 COP
                                </div>
                                <div class="habitacion-precio-desc">Por noche</div>
                              </div>
                        </div>
                        </div>
                        <div class="row mt-2">
                            <div class="habitacion-info-desc" runat="server" id="PHabitacionDescripcion">
                                Aliquip adipisicing anim incididunt quis nulla ipsum elit cillum ut labore. Dolor ullamco sit excepteur
                                 minim ullamco sint veniam reprehenderit. Irure laboris nisi aliqua esse Lorem deserunt qui ea ipsum 
                                 consequat deserunt sunt. Ullamco proident aute dolore ea id laborum exercitation consequat pariatur 
                                 enim. Proident ullamco velit quis adipisicing tempor.
                            </div>
                        </div>
                        <div class="row">
                            <div class="col-xl-9">
                                <div class="ff-oswaldo text-uppercase fs-4 border-bottom-1 mb-3">
                                    Caracteristicas de la habitacion
                                </div>
                                
                                <div class="row">
                                    <div class="col-md-6">
                                        <div class="d-flex justify-content-start icon-caracteristicas">
                                            <span class="fa-stack fa-2x">
                                                <i class="fas fa-square fa-stack-2x icon-caracteristicas-outter"></i>
                                                <i class="fab fa-accessible-icon fa-stack-1x fa-inverse"></i>
                                              </span>
                                              <div class="d-flex flex-column justify-content-evenly">
                                                  <div class="text-uppercase ff-oswaldo">Baño para personas discapacitadas</div>
                                                  <div class="text-uppercase ff-oswaldo habitacion-info-carac-itemtitle" runat="server" id="PHabitacionDiscapacitados"></div>
                                              </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="d-flex justify-content-start icon-caracteristicas">
                                            <span class="fa-stack fa-2x">
                                                <i class="fas fa-square fa-stack-2x icon-caracteristicas-outter"></i>
                                                <i class="fas fa-dog fa-stack-1x fa-inverse"></i>
                                              </span>
                                              <div class="d-flex flex-column justify-content-evenly">
                                                <div class="text-uppercase ff-oswaldo">Posibilidad de mascota</div>
                                                <div class="text-uppercase ff-oswaldo habitacion-info-carac-itemtitle" runat="server" id="PHabitacionMascota"></div>
                                            </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6">
                                        <div class="d-flex justify-content-start icon-caracteristicas">
                                            <span class="fa-stack fa-2x">
                                                <i class="fas fa-square fa-stack-2x icon-caracteristicas-outter"></i>
                                                <i class="fas fa-bed fa-stack-1x fa-inverse"></i>
                                              </span>
                                              <div class="d-flex flex-column justify-content-evenly">
                                                  <div class="text-uppercase ff-oswaldo">Numero de camas</div>
                                                  <div class="text-uppercase ff-oswaldo habitacion-info-carac-itemtitle" runat="server" id="PHabitacionCamas">4 camas</div>
                                              </div>
                                        </div>
                                    </div>
                                    <div class="col-md-6 d-block d-lg-none">
                                        <div class="d-flex justify-content-start icon-caracteristicas">
                                            <span class="fa-stack fa-2x">
                                                <i class="fas fa-square fa-stack-2x icon-caracteristicas-outter"></i>
                                                <i class="fas fa-hotel fa-stack-1x fa-inverse"></i>
                                              </span>
                                              <div class="d-flex flex-column justify-content-evenly">
                                                  <div class="text-uppercase ff-oswaldo">Tamaño</div>
                                                  <div class="text-uppercase ff-oswaldo habitacion-info-carac-itemtitle" runat="server" id="PHabitacionTamaño2">Mediana</div>
                                              </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                            <div class="col-xl-3">
                              <div class="ff-oswaldo text-uppercase fs-4 border-bottom-1 mb-3">
                                Reserva la habitación
                            </div>
                              <div class="row">
                                <div class="form-group">
                                  <label for="formGroupExampleInput">Fecha y hora de llegada y de salida</label>
                                  <input type="text" class="form-control" name="datetimes" />
                                </div> 
                                <div class="d-grid gap-2 col-xl-12 col-8 mx-auto mt-2">
                                  <button class="btn btn-primary btn-lg" type="button"><i class="fa fa-key" aria-hidden="true"></i> Reservar habitación</button>
                                </div>
                              </div>
                            </div>
                        </div>
                        <!-- Dejar reseña -->
                            <div class="ff-oswaldo text-uppercase fs-4 border-bottom-1 mt-3">
                              Califica y cuentanos tu experiencia en esta habitacion
                          </div>
                          <div class="mt-2 fc-blue fw-bold text-uppercase">Calificacion de 0 a 5 estrellas:</div>
                          <div class="">En progreso</div>
                          <div class="mt-2 fc-blue fw-bold text-uppercase">Reseña de tu experiencia:</div>
                          <textarea class="form-control round-edges form-control-lg " id="inputApellido" rows="5" placeholder="Cuentanos tu experiencia cuando te hospedaste en esta habitacion."></textarea>
                          <div class="d-grid gap-2 col-xl-2 col-md-4 col-6 mx-auto mt-2">
                            <button class="btn btn-primary btn-lg" type="button"><i class="fa fa-comments" aria-hidden="true"></i> Enviar reseña</button>
                          </div>
                          <!-- Dejar reseña-->
                         <!-- Reseñas de otros clientes -->
                         <div class="ff-oswaldo text-uppercase fs-4 border-bottom-1 mt-3">
                          Reseñas de otros clientes
                          </div>
                          <!-- Empieza comentario -->
                          <div class="comentario-body mt-3">
                            <div class="container-fluid">
                              <div class="row">
                                <div class="col-lg-2 my-auto text-center">
                                  <img src="img/nelson.jpeg" class="border border-5 img-fluid rounded-circle" alt="..." width="200" height="200">
                                </div>
                                <div class="col-lg-10">
                                  <div class="d-flex flex-column">
                                    <div class="comentario-title fc-blue">Nelson Fabian Rodriguez</div>
                                    <div class="d-flex">
                                      <div class="stars-outer">
                                        <div class="stars-inner" style="width: 80%;"></div>
                                      </div>
                                      <div class="fc-gray fw-bold ff-oswaldo">4</div>
                                    </div>
                                    <div class="comentario mt-2">
                                      Elit enim adipisicing anim esse incididunt occaecat sunt minim duis proident aliquip. Cillum exercitation dolor sint non Lorem est nostrud proident nostrud. Consectetur excepteur laboris exercitation magna velit culpa. Sunt laborum ipsum officia dolore. Voluptate veniam ea aliqua adipisicing labore. Do cillum deserunt adipisicing duis Lorem ex est. Elit enim adipisicing anim esse incididunt occaecat sunt minim duis proident aliquip. Cillum exercitation dolor sint non Lorem est nostrud proident nostrud.
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                          <!-- Acaba comentario -->
                          <!-- Empieza comentario -->
                          <div class="comentario-body mt-3">
                            <div class="container-fluid">
                              <div class="row">
                                <div class="col-lg-2 my-auto text-center">
                                  <img src="img/profile-mujer.jpg" class="border border-5 img-fluid rounded-circle" alt="..." width="200" height="200">
                                </div>
                                <div class="col-lg-10">
                                  <div class="d-flex flex-column">
                                    <div class="comentario-title fc-blue">Isabel Naranjo Herrera</div>
                                    <div class="d-flex">
                                      <div class="stars-outer">
                                        <div class="stars-inner" style="width: 60%;"></div>
                                      </div>
                                      <div class="fc-gray fw-bold ff-oswaldo">3</div>
                                    </div>
                                    <div class="comentario mt-2">
                                      Elit enim adipisicing anim esse incididunt occaecat sunt minim duis proident aliquip. Cillum exercitation dolor sint non Lorem est nostrud proident nostrud. Consectetur excepteur laboris exercitation magna velit culpa. Sunt laborum ipsum officia dolore. Voluptate veniam ea aliqua adipisicing labore. Do cillum deserunt adipisicing duis Lorem ex est. Elit enim adipisicing anim esse incididunt occaecat sunt minim duis proident aliquip. Cillum exercitation dolor sint non Lorem est nostrud proident nostrud.
                                    </div>
                                  </div>
                                </div>
                              </div>
                            </div>
                          </div>
                          <!-- Acaba comentario -->
                         <!-- Reseñas de otros clientes -->
                </div>
            </div>
                  <!-- Termina informacion de la habitacion -->
              </div>
          </div>
</asp:Content>
