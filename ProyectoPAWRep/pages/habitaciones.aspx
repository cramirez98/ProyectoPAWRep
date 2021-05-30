<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Normal.Master" AutoEventWireup="true" CodeBehind="habitaciones.aspx.cs" Inherits="ProyectoPAWRep.pages.habitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ver habitaciones</title>
    <!-- CSS -->
    <link rel="stylesheet" href="../css/bootstrap.css" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/custom.css" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" href="../css/RangeSlider.css">
    <link href="../css/StartRating.css" rel="stylesheet" />
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
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;400;500;600&display=swap" rel="stylesheet">
    <script>
        $(function () {
            $('input[name="formfechainiciofinalizacion"]').daterangepicker({
                "startDate": moment().add(2, 'day'),
                "minDate": moment().add(2, 'day'),
                endDate: moment().add(6, 'day'),
                locale: {
                    format: 'Y-MM-DD'
                }
            });
        });
    </script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
      <div class="container-fluid mt-30 mb-3 mt-xl-3">
          <div class="row justify-content-md-center">
              <div class="col-xxl-3">
                <div class="card round-edges">
                  <div class="card-body">
                    <h4 class="text-center fw-bold">Busqueda avanzada</h4>
                    <hr>

                    <div class="accordion accordion-flush" id="accordionExample">
                      <div class="accordion-item">
                        <h2 class="accordion-header" id="headingZero">
                          <button class="accordion-button" type="button" data-bs-toggle="collapse" data-bs-target="#horasalidaentrada" aria-expanded="true" aria-controls="horasalidaentrada">
                            Disponibilidad
                          </button>
                        </h2>
                        <div id="horasalidaentrada" class="accordion-collapse collapse show" aria-labelledby="headingZero">
                          <div class="accordion-body">
                            <div class="form-group">
                                <label for="formGroupExampleInput">Fecha y hora de llegada y de salida</label>

                                <div class="input-group">
                                  <span class="input-group-text" id="basic-addon1"><i class="fa fa-calendar-alt"></i></span>
                                  <input type="text" class="form-control" name="formfechainiciofinalizacion" />
                                </div>
                            </div> 
                          </div>
                        </div>
                      </div>
                      <div class="accordion-item">
                        <h2 class="accordion-header" id="headingOne">
                          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#preciopornoche" aria-expanded="false" aria-controls="preciopornoche">
                            Precio por noche
                          </button>
                        </h2>
                        <div id="preciopornoche" class="accordion-collapse collapse" aria-labelledby="headingOne">
                          <div class="accordion-body">
                            <div class="container-fluid">
                              <div class="row">
                                <div class="col-sm-12">
                                  <div id="slider-range"></div>
                                </div>
                              </div>
                              <div class="row slider-labels mt-3">
                                <div class="col-sm-6 col-xs-6 caption">
                                  <strong>Min:</strong> <span id="slider-range-value1"></span>
                                </div>
                                <div class="col-sm-6 col-xs-6 text-sm-end caption">
                                  <strong>Max:</strong> <span id="slider-range-value2"></span>
                                </div>
                                <input type="hidden" name="min-value" value="">
                                <input type="hidden" name="max-value" value="">
                              </div>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="accordion-item">
                        <h2 class="accordion-header" id="headingTwo">
                          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#size_room" aria-expanded="false" aria-controls="size_room">
                            Tamaño de la habitación
                          </button>
                        </h2>
                        <div id="size_room" class="accordion-collapse collapse" aria-labelledby="headingTwo">
                          <div class="accordion-body">
                            <select class="form-select mb-3" name="ASTamaño" aria-label=".form-select-lg example">
                              <option value="Pequeña">Pequeña</option>
                              <option value="Mediana" selected>Mediana</option>
                              <option value="Grande">Grande</option>
                              <option value="Piso ejecutivo">Piso ejecutivo</option>
                            </select>                           
                          </div>
                        </div>
                      </div>
                      <div class="accordion-item">
                        <h2 class="accordion-header" id="headingThree">
                          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseThree" aria-expanded="false" aria-controls="collapseThree">
                            Caracteristicas especiales
                          </button>
                        </h2>
                        <div id="collapseThree" class="accordion-collapse collapse" aria-labelledby="headingThree">
                          <div class="accordion-body">
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" name="ASMascotas">
                              <label class="form-check-label" for="gridCheck">
                                Posibilidad de mascotas
                              </label>
                            </div>
                            <div class="form-check">
                              <input class="form-check-input" type="checkbox" name="ASBañosDiscapacitados">
                              <label class="form-check-label" for="gridCheck">
                                Baño para personas discapacitadas
                              </label>
                            </div>
                          </div>
                        </div>
                      </div>
                      <div class="accordion-item">
                        <h2 class="accordion-header" id="headingFourth">
                          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFourth" aria-expanded="false" aria-controls="collapseFourth">
                            Numero de camas
                          </button>
                        </h2>
                        <div id="collapseFourth" class="accordion-collapse collapse" aria-labelledby="headingFourth">
                          <div class="accordion-body">
                            <input type="range" name="camasrange" class="form-range" min="1" max="6" id="customRange2">
                            <label for="customRange2" name="camasrange_label" class="form-label"><b>Numero de camas: </b>1</label>
                          </div>
                        </div>
                      </div>
                      <div class="accordion-item">
                        <h2 class="accordion-header" id="headingFifth">
                          <button class="accordion-button collapsed" type="button" data-bs-toggle="collapse" data-bs-target="#collapseFifth" aria-expanded="false" aria-controls="collapseFifth">
                            Numero de estrellas
                          </button>
                        </h2>
                        <div id="collapseFifth" class="accordion-collapse collapse" aria-labelledby="headingFifth">
                          <div class="accordion-body">
                              <p id="ASEstrellasLabel">Se buscaran habitaciones con un puntaje mayor a 0 estrellas.</p>
                          <div class="rating"> <input type="radio" name="rating" value="5" id="5"><label for="5">☆</label> <input type="radio" name="rating" value="4" id="4"><label for="4">☆</label> <input type="radio" name="rating" value="3" id="3"><label for="3">☆</label> <input type="radio" name="rating" value="2" id="2"><label for="2">☆</label> <input type="radio" name="rating" value="1" id="1"><label for="1">☆</label></div>
                              <input type="hidden" name="ASEstrellas" value="" />
                          </div>
                        </div>
                      </div>
                    </div> 
                    <div class="d-flex flex-row justify-content-center mt-3">
                    <div class="dropdown">
                      <button class="btn btn-primary dropdown-toggle" name="button-advanceSearch" data-initializedb="false" type="button" id="dropdownMenuButton1" data-bs-toggle="dropdown" aria-expanded="false">
                        Terminos de busqueda avanzada
                      </button>
                      <ul class="dropdown-menu" aria-labelledby="dropdownMenuButton1">
                        <li><button class="dropdown-item" id="AplicarBusquedaAvanzada" type="button">Aplicar criterios de busqueda avanzada</button></li>
                        <li><button class="dropdown-item" id="DescartarBusquedaAvanzada" type="button">Descartar criterios de busqueda avanzada</button></li>
                      </ul>
                    </div>
                    </div>        
                  </div>
                </div>
              </div>
              <div class="col-xxl-7 mt-xxl-0 mt-3">
                <div class="container-fluid habitaciones-contenido pt-2 pb-3 ">
                  <h2 class="text-center fw-bold">Habitaciones disponibles</h2>
                  <div class="habitaciones-ruler d-flex flex-column flex-sm-row justify-content-evenly align-items-center">
                    <p class="active sorter" id="Precio" data-orderby="Precio" data-sort="asc"><i class="fa fa-sort-numeric-up-alt" aria-hidden="true"></i> Precio</p>
                    <p class="sorter" id="NumeroCamas" data-orderby="NumeroCamas">Cantidad de camas</p>
                    <p class="sorter" id="Puntaje" data-orderby="Puntaje">Puntaje</p>
                  </div>
                    <div runat="server" id="habitaciones_cartas_lugar" class="mt-3" name="habitaciones_cartas_lugar">
                  <!-- Comienzan las tarjeta de las diferentes habitaciones -->  
                  <div class="habitacion-card">
                    <div class="container-fluid">
                      <div class="row g-1">
                        <div class="col-xxl-3 text-center text-xxl-start">
                          <img src="/img/HabitacionEjemplo.png" class="img-fluid rounded-3 img-thumbnail" alt="..." width="210" height="210">
                        </div>
                        <div class="col-xxl-9">
                          <div class="row g-0">
                            <div class="col-lg-8 col-sm-8">
                              <div class="d-flex flex-column">
                                <div class="d-flex">
                                  <div class="habitacion-puntaje">20 opiniones
                                    <div class="stars-outer">
                                      <div class="stars-inner" style="width: 80%;"></div>
                                    </div>
                                  </div>
                                  <div class="fs-12 fc-gray fw-bold ff-oswaldo">4</div>
                                </div>
                                <div class="habitacion-titulo">Habitación 509</div>
                                <div class="habitacion-subtitulo">Mediana</div>
                              </div>
                            </div>
                            <div class="col-lg-4 col-sm-4 mb-2">
                              <div class="d-flex text-start text-lg-end flex-column">
                                <div class="d-flex justify-content-lg-end">
                                    <div class="habitacion-info-precio text-decoration-line-through text-muted fs-5">
                                    $460.300 COP
                                    </div>
                                    <span class="fc-blue ff-oswaldo">50% OFF</span>
                                </div>
                                <div class="habitacion-info-precio fc-orange">
                                    $230.150 COP
                                </div>
                                <div class="habitacion-precio-desc">Por noche</div>
                              </div>
                            </div>
                          </div>
                          <hr>
                          <div class="row">
                            <p class="habitacion-descripcion">
                              Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin eget mattis velit. Interdum et malesuada fames ac ante ipsum primis in faucibus. Quisque enim ligula, cursus at molestie sit amet, porta ac ipsum. Mauris vitae felis efficitur, tempus nulla a, sagittis mauris. Phasellus commodo auctor nisi, sit amet sodales enim lobortis sed. In cursus sapien ut orci viverra, a semper sem elementum. Pellentesque tincidunt suscipit cursus. Cras non dictum neque. Mauris a gravida turpis. Donec fringilla sit amet tellus vitae posuere.
                            </p>
                          </div>
                        </div>
                      </div>
                      <div class="row">
                        <div class="col-lg-8">
                          <div class="row mb-1">
                            <div class="habitacion-services-title">Características especiales</div>
                          </div>
                          <div class="row d-flex">
                            <span class="fa-stack fa-2x fs-5" data-bs-toggle="tooltip" data-bs-placement="top" title="No posee baños para discapacitados">
                              <i class="fas fa-square fa-stack-2x iconbackground-false"></i>
                              <i class="fab fa-accessible-icon fa-stack-1x fa-inverse"></i>
                            </span>
                            <span class="fa-stack fa-2x fs-5" data-bs-toggle="tooltip" data-bs-placement="top" title="Admite mascota">
                              <i class="fas fa-square fa-stack-2x iconbackground-true"></i>
                              <i class="fa fa-dog fa-stack-1x fa-inverse"></i>
                            </span>
                          </div>
                        </div>
                        <div class="col-lg-4 d-flex justify-content-center justify-content-md-end">
                          <button type="button" class="btn btn-primary btn-lg mt-2 mt-md-0"><i class="fa fa-eye" aria-hidden="true"></i> Ver mas detalles</button>
                        </div>
                      </div>
                    </div>
                  </div>      
                  <!-- Finalizan las tarjeta de las habitaciones -->
                        </div>
                    <div runat="server" id="seccion_paginacion" name="seccion_paginacion" class="d-flex flex-row justify-content-end mt-2">
<%--<nav aria-label="Page navigation example mt-3">
  <ul class="pagination justify-content-end">
    <li class="page-item">
      <a class="page-link" href="#" tabindex="-1" aria-disabled="true"><i class="fas fa-angle-left"></i></a>
    </li>
    <li class="page-item"><a class="page-link" href="#">1</a></li>
    <li class="page-item"><a class="page-link" href="#">2</a></li>
    <li class="page-item"><a class="page-link" href="#">3</a></li>
    <li class="page-item">
      <a class="page-link" href="#"><i class="fas fa-angle-right"></i></a>
    </li>
  </ul>
</nav>--%>
                    </div>
                </div>
              </div>
          </div>
      </div>
<!-- Optional JavaScript -->
    <script src="../js/SortHabitaciones.js"></script>
        <script type="text/javascript" src="/js/RangeSlider.js"></script>
      <script>
          $(window).scroll(function () {
              $('nav').toggleClass('scrolled', $(this).scrollTop() > 50);
              $('nav').toggleClass('scrolled-nav', $(this).scrollTop() > 50);
          });
          $("[name='camasrange']").on('input', function () {
              val = $("[name='camasrange']").val();
              $("[name='camasrange_label']").html("<b>Numero de camas:</b> " + val);
          });
          $(document).ready(function () {
              $("[name='camasrange']").val(1);
              $('input[name="ASEstrellas"]').val(0);
              var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle="tooltip"]'))
              var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {
                  return new bootstrap.Tooltip(tooltipTriggerEl)
              })
          });
          $("[name=rating]").change(function () {
              $('input[name="ASEstrellas"]').val($(this).val());
              $("#ASEstrellasLabel").text("Se buscaran habitaciones con un puntaje mayor a " + $(this).val() + " estrellas.");
          });
      </script>
</asp:Content>
