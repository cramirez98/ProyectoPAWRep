<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="inicio.aspx.cs" Inherits="ProyectoPAWRep.pages.inicio" %>

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
  <body data-bs-spy="scroll" data-bs-target="#navbar-principal">
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
                  <a class="nav-link active" aria-current="page" href="#inicio"><i class="icon-camera-retro"></i>Inicio</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#SobreNosotros">Sobre nosotros</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#NuestrosServicios">Nuestros servicios</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="#DondeEncontrarnos">Donde encontrarnos</a>
                </li>
                <li class="nav-item">
                  <a class="nav-link" href="habitaciones.aspx">Ver Habitaciones</a>
                </li>
              </ul>
  
            <ul class="navbar-nav ml-auto" runat="server" id="navbar_changing">
              <li class="nav-item dropdown">
                <a class="nav-link" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                  <span class="fas fa-user"></span>
                </a>
                <ul class="dropdown-menu dropdown-menu-lg-end" aria-labelledby="navbarDropdown">
                  <li><a class="dropdown-item" href="login.html">Iniciar sesion</a></li>
                  <li><a class="dropdown-item" href="registro.html">Registrarse</a></li>
                </ul>
              </li>
            </ul>            
              
            </div>
          </div>
        </nav>
</div>

      <header class="tablero_bienvenida">
        <div class="container">
          <div class="row justify-content-center">
            <div class="col-xl-8">
              <div class="bienvenida-titulo">
                <span class="align-middle">Hospedate con nosotros y disfruta de una experiencia sin igual!</span>
              </div>
            </div>
          </div>
        </div>
      </header>
      <div class="seccion bg-white" id="SobreNosotros">
        <div class="seccion-titulo">Sobre nosotros</div>
        <div class="container-fluid">
          <div class="row no-gutter justify-content-md-center">
            <div class="col-xxl-6 order-xxl-2 col-lg-11 d-flex justify-content-center align-self-center">
              <img src="/img/Aboutus1.png" class="img-fluid rounded align-self-center" alt="...">
            </div>
            <div class="col-xxl-6 order-xxl-1 px-5 mb-2 align-self-center">
              <div class="aboutus-block-title">Nuestra historia</div>
              <div class="aboutus-block-p" runat="server" id="aboutushistoria">

              </div>
          </div>
          </div>
          <div class="row no-gutter justify-content-md-center">
            <div class="col-xxl-6 order-xxl-1 col-lg-11 d-flex justify-content-center align-self-center">
              <img src="/img/Aboutus2.png" class="img-fluid rounded align-self-center" alt="...">
            </div>
            <div class="col-xxl-6 order-xxl-2 px-5 mb-2 align-self-center">
              <div class="aboutus-block-title">Nuestra mision y vision</div>
              <div class="aboutus-block-p" runat="server" id="aboutusmisionvision">
              </div>
          </div>
          </div>  
          <div class="row no-gutter justify-content-md-center">
            <div class="col-xxl-6 order-xxl-2 col-lg-11 d-flex justify-content-center align-self-center">
              <img src="/img/Aboutus3.jpg" class="img-fluid rounded align-self-center" alt="...">
            </div>
            <div class="col-xxl-6 order-xxl-1 px-5 mb-2 align-self-center">
              <div class="aboutus-block-title">Nuestros principios</div>
              <div class="aboutus-block-p" runat="server" id="aboutusprincipios">

              </div>
          </div>
          </div>   
        </div>
      </div> 
      <div class="seccion bg-bblue" id="NuestrosServicios">
        <div class="container">
          <div class="seccion-titulo">Nuestros servicios</div>
          <div class="row">
            <div class="col-md align-self-center">
              <div class="text-center">
                <img src="/img/serv-piscina.png" class="img-fluid rounded-circle" alt="...">
              </div>
              <h1>Zona de piscina</h1>
              <p>En nuestro hotel podras tener acceso a una zona de piscina donde podras disfrutar de un ambiente con musica junto con acceso ilimitado a el bar</p>
            </div>
            <div class="col-md align-self-center">
              <div class="text-center">
              <img src="/img/serv-gym.png" class="img-fluid rounded-circle" alt="...">
              </div>  
              <h1>Gimnasio</h1>
              <p>Posees acceso a una zona de acondicionamiento fisico con un amplio equipamiento para que siempre te encuentres en buena forma</p>
            </div>
            <div class="col-md align-self-center">
              <div class="text-center">
              <img src="/img/serv-rest.png" class="img-fluid rounded-circle" alt="...">
              </div>
              <h1>Restaurante tipo buffet</h1>
              <p>Contamos con un ambiente tipo terraza donde podras disfrutar de todo tipo de comidas y platos</p>
            </div>
          </div>
        </div>
      </div>

      
<div class="seccion bg-white" id="DondeEncontrarnos">
  <div class="container-fluid">
    <div class="seccion-titulo">Donde nos encontramos</div>
        <div class="mapouter"><div class="gmap_canvas"><iframe height="500" width="100%" id="gmap_canvas" src="https://maps.google.com/maps?q=cali%20colombia%20intercontinental&t=&z=13&ie=UTF8&iwloc=&output=embed" frameborder="0" scrolling="no" marginheight="0" marginwidth="0"></iframe><a href="https://123movies-to.org"></a><br><style>.mapouter{position:relative;text-align:right;height:500px;width:100%;}</style><a href="https://www.embedgooglemap.net">google maps code for wordpress</a><style>.gmap_canvas {overflow:hidden;background:none!important;height:500px;width:100%;}</style></div></div> 
  </div>      
</div> 

<div class="seccion bg-bblue" id="Testimonios">
  <div class="seccion-titulo">Testimonios de nuestros clientes</div>
  <div id="carouselExampleFade" class="carousel slide carousel-fade" data-bs-ride="carousel">
        <div class="carousel-inner">
          <div class="container">
          <div class="carousel-item text-center active" data-bs-interval="100000000">

              <div class="opinion-cards">                
                <div class="testimonio">
                  <div class="container">
                    <div class="row align-items-center">
                      <div class="col-md-3" >
                        <div class="text-center">
                          <img src="/img/profile-mujer.jpg" class="img-fluid rounded-circle" alt="..." width="200" height="200">
                        </div>
                      </div>
                      <div class="col-md-9">
                        <div class="testimonio-cuerpo">
                          <div class="testimonio-nombre">Cristina Angulo Lopez</div>
                          <div class="testimonio-puntaje">
                            <i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i>
                          </div>
                          <div class="testimonio-texto">
                            Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin pharetra consectetur imperdiet. In sed augue sodales, mollis felis vel, consectetur massa. Praesent convallis velit eu odio gravida convallis. Vivamus molestie facilisis lacus a maximus. Fusce suscipit eleifend mi non venenatis. Etiam tincidunt mauris et tincidunt tristique.
                          </div>
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>

          </div>
          <div class="carousel-item text-center">

            <div class="opinion-cards">                
              <div class="testimonio">
                <div class="container">
                  <div class="row align-items-center">
                    <div class="col-md-3 my-auto" >
                      <div class="text-center">
                        <img src="/img/nelson.jpeg" class="img-fluid rounded-circle" alt="..." width="200" height="200">
                      </div>
                    </div>
                    <div class="col-md">
                      <div class="testimonio-cuerpo">
                        <div class="testimonio-nombre">Nelson Fabian Ortiz</div>
                        <div class="testimonio-puntaje">
                          <i class="fas fa-star"></i><i class="fas fa-star"></i><i class="fas fa-star"></i><i class="far fa-star"></i><i class="far fa-star"></i>
                        </div>
                        <div class="testimonio-texto">
                          Lorem ipsum dolor sit amet, consectetur adipiscing elit. Proin pharetra consectetur imperdiet. In sed augue sodales, mollis felis vel, consectetur massa. Praesent convallis velit eu odio gravida convallis. Vivamus molestie facilisis lacus a maximus. Fusce suscipit eleifend mi non venenatis. Etiam tincidunt mauris et tincidunt tristique.
                        </div>
                      </div>
                    </div>
                  </div>
                </div>
              </div>
            </div>

          </div>
        </div>
      </div>
    <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="prev">
      <span class="carousel-control-prev-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Previous</span>
    </button>
    <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleFade" data-bs-slide="next">
      <span class="carousel-control-next-icon" aria-hidden="true"></span>
      <span class="visually-hidden">Next</span>
    </button>
  </div>
</div>

<div class="seccion bg-dark">
  <div class="container-fluid">
    <div class="row justify-content-center">
      <div class="col-lg-2 col-6 align-self-center text-center">
        <img src="../img/logo/logonavbar.png" class="img-fluid" alt="..." width="300" height="300">
        <p class="text-white">Hospedate con nosotros!</p>
      </div>
      <div class="col-lg-10 d-flex flex-column">
        <h4 class="text-white">Links</h4>
        <a href="inicio.aspx">Inicio</a>
        <a href="habitaciones.aspx">Habitaciones</a>
        <a href="iniciosesion.aspx">Inicio de sesion</a>
        <a href="registro.aspx">Registro</a>
      </div>
    </div>
  </div>
</div>

<!-- Optional JavaScript -->
      <script>
        $(window).scroll(function(){
          $('nav').toggleClass('scrolled', $(this).scrollTop() > 100);
          $('nav').toggleClass('scrolled-nav', $(this).scrollTop() > 100);
        });
      </script>
  </body>
</html>