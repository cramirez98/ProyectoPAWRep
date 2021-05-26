<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="checkout.aspx.cs" Inherits="ProyectoPAWRep.pages.checkout" %>

<!DOCTYPE html>

<!doctype html>
<html lang="en">
  <head>
    <title>Checkout</title>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1, shrink-to-fit=no">
    <!-- CSS -->
    <link rel="stylesheet" href="../css/bootstrap.css" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/custom.css" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
    <link rel="stylesheet" href="../css/RangeSlider.css">
    <link href="../css/estilos_tarjeta_credito.css" rel="stylesheet" />
    <!-- Javascript -->
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
    <script src="/js/bootstrap.bundle.min.js"></script>
    <script src="https://kit.fontawesome.com/7e4e3039b1.js" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
    <script type="text/javascript" src="/js/RangeSlider.js"></script>
    <!-- Load google fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;300;500;700&family=Recursive:wght@300;400&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,700;0,900;1,100&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Recursive:wght@300;400&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Oswald:wght@300;400;500;600&display=swap" rel="stylesheet">
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
  <body class="body-roboto-font-family bg-lgray">
    <div class="checkout-titulo">
        Checkout
    </div>
      <div id="alertseccion" class="px-5">

      </div>
      <div class="container-fluid container-lg mt-5">
        <div class="row">
            <div class="col-lg-4 order-lg-2">
                <div class="checkout-body bt-orange">
                    <div class="row">
                        <h1>Tu reserva</h1>
                        <hr>
                        <div class="d-flex justify-content-between mb-4">
                            <div class="d-flex flex-column justify-content-start">
                                <div class="checkout-item" runat="server" id="CheckoutNumeroHabitacion" data-numeroh="" data-precioh="" data-fechainicio="" data-fechafinalizacion="" data-correou="">
                                    Habitacion 409
                                </div>
                                <ul class="checkout-item-desc">
                                    <li runat="server" id="CheckoutSize">Habitacion mediana</li>
                                    <li runat="server" id="CheckoutNumeroCamas">5 camas</li>
                                    <li runat="server" id="CheckoutBañosDiscapacitados">Sin baños para discapacitados</li>
                                    <li runat="server" id="CheckoutMascotas">Con posibilidad de mascota</li>
                                </ul>
                            </div>
                            <div class="d-flex flex-column justify-content-start text-end">
                                <div class="checkout-price" runat="server" id="CheckoutPrecio1">
                                    $200.150 COP
                                </div>
                                <div class="checkout-price-desc fc-blue">Por noche</div>
                            </div>
                        </div>
                        <h1>Costo de la reserva</h1>
                        <div runat="server" id="seccion_precio_descuento">
                            <hr>
                            <div class="d-flex justify-content-between mb-2">
                                <div class="d-flex flex-column justify-content-start">
                                    <div class="checkout-item" runat="server" id="CheckoutNumeroHabitacion2">
                                        Habitacion 409
                                    </div>
                                </div>
                                <div class="d-flex flex-column justify-content-start text-end">
                                    <div class="checkout-price" runat="server" id="CheckoutPrecio2">
                                        $200.000 COP
                                    </div>
                                    <div class="checkout-price-desc fc-blue">Por noche</div>
                                </div>
                            </div>
                            <div class="d-flex justify-content-between mb-2">
                                <div class="d-flex flex-column justify-content-start">
                                    <div class="checkout-item fc-green" runat="server" id="CheckoutDescuento">
                                        Descuento 20%
                                    </div>
                                </div>
                                <div class="d-flex flex-column justify-content-start text-end">
                                    <div class="checkout-price fc-green" runat="server" id="CheckoutValorDescuento">
                                        -$40.000 COP
                                    </div>
                                </div>
                            </div>
                            <div class="d-flex justify-content-between mb-2">
                                <div class="d-flex flex-column justify-content-start">
                                    <div class="checkout-item" runat="server" id="CheckoutNumeroHabitacion3">
                                        Habitacion 409
                                    </div>
                                </div>
                                <div class="d-flex flex-column justify-content-start text-end">
                                    <div class="checkout-price" runat="server" id="CheckoutPrecioConDescuento">
                                        $160.000 COP
                                    </div>
                                    <div class="checkout-price-desc fc-blue">Por noche</div>
                                </div>
                            </div>
                        </div>
                        <hr>
                        <div class="d-flex justify-content-between">
                            <div class="d-flex flex-column justify-content-start">
                                <div class="checkout-item">
                                    Total
                                </div>
                            </div>
                            <div class="d-flex flex-column justify-content-start text-end">
                                <div class="checkout-price" runat="server" id="CheckoutPrecioTotal">
                                    $800.000 COP
                                </div>
                                <div class="checkout-price-desc fc-blue" runat="server" id="CheckoutNumeroNoches">5 noches y 5 personas</div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
            <div class="col-lg-8 order-lg-1 mt-3 mt-lg-0">
                <div class="checkout-body bt-blue">
                    <div class="row">
                        <h1><i class="fa fa-user-circle 2x" aria-hidden="true"></i> Datos de facturación</h1>
                        <hr>
                    </div>
                    <form runat="server">
                    <div class="row">
                        <div class="col-md-6">
                            <div class="custom-input">
                                <label for="CheckoutNombres">Nombre:</label>
                                <asp:TextBox ID="CheckoutNombres" ClientIDMode="Static" runat="server"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValNombres">Debe ingresar un valor.</div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="custom-input">
                                <label for="CheckoutApellidos">Apellidos:</label>
                                <asp:TextBox ID="CheckoutApellidos" ClientIDMode="Static" runat="server"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValApellidos">Debe ingresar un valor.</div>
                            </div>
                        </div>
                        <div class="col-md-4">
                            <div class="custom-input">
                                <label for="CheckoutTelefono">Numero de telefono:</label>
                                <asp:TextBox ID="CheckoutTelefono" ClientIDMode="Static" runat="server"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValTelefono">Debe ingresar un valor.</div>
                            </div>
                        </div>
                        <div class="col-md-8">
                            <div class="custom-input">
                                <label for="CheckoutCorreo">Correo electrónico:</label>
                                <asp:TextBox ID="CheckoutCorreo" ClientIDMode="Static" runat="server" placeholder="alguien@hotmail.com"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValCorreo">Debe ingresar un valor.</div>
                            </div>
                        </div>
                        <div class="col-md-6">
                            <div class="custom-input">
                                <label for="CheckoutDireccion">Dirección:</label>
                                <asp:TextBox ID="CheckoutDireccion" ClientIDMode="Static" runat="server" placeholder="Calle 4D #45 67"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValDireccion">Debe ingresar un valor.</div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="custom-input">
                                <label for="CheckoutCiudad">Ciudad:</label>
                                <asp:TextBox ID="CheckoutCiudad" ClientIDMode="Static" runat="server"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValCiudad">Debe ingresar un valor.</div>
                            </div>
                        </div>
                        <div class="col-md-3">
                            <div class="custom-input">
                                <label for="CheckoutCedula">Cedula:</label>
                                <asp:TextBox ID="CheckoutCedula" ClientIDMode="Static" runat="server"></asp:TextBox>
                                <div class="text-danger small validacion-text d-none" id="ValCedula">Debe ingresar un valor.</div>
                            </div>
                        </div>
                    </div>
                    </form>
                    <div class="row mt-4">
                        <h1><i class="fa fa-money-bill-wave 2x" aria-hidden="true"></i> Metodo de pago</h1>
                        <hr>
                        <div class="col-md-12">
                            <nav>
                                <div class="nav navigation-tabs-checkout" id="nav-tab" role="tablist">
                                  <button class="navigation-link-checkout active" id="nav-home-tab" data-bs-toggle="tab" data-bs-target="#nav-home" type="button" role="tab" aria-controls="nav-home" aria-selected="true">
                                      <div class="d-flex flex-column">
                                          <i class="fa fa-credit-card" aria-hidden="true"></i>
                                          Tarjeta de credito
                                      </div>
                                  </button>
                                  <button class="navigation-link-checkout" id="nav-profile-tab" data-bs-toggle="tab" data-bs-target="#nav-profile" type="button" role="tab" aria-controls="nav-profile" aria-selected="false">
                                    <div class="d-flex flex-column">
                                        <i class="fa fa-paypal" aria-hidden="true"></i>
                                        Paypal
                                    </div>
                                  </button>
                                  <button class="navigation-link-checkout" id="nav-contact-tab" data-bs-toggle="tab" data-bs-target="#nav-contact" type="button" role="tab" aria-controls="nav-contact" aria-selected="false">
                                    <div class="d-flex flex-column">
                                        <i class="fa fa-money-bill" aria-hidden="true"></i>
                                        Pse
                                    </div>
                                  </button>
                                </div>
                              </nav>
                              <div class="tab-content tab-contenido-checkout" id="nav-tabContent">
                                <div class="tab-pane fade show active" id="nav-home" role="tabpanel" aria-labelledby="nav-home-tab"> 
	                                <div class="contenedor" style="padding-bottom:-20pt;">

		                                <!-- Tarjeta -->
		                                <section class="tarjeta" id="tarjeta">
			                                <div class="delantera">
				                                <div class="logo-marca" id="logo-marca">
					                                <!-- <img src="img/logos/visa.png" alt=""> -->
				                                </div>
				                                <img src="img/chip-tarjeta.png" class="chip" alt="">
				                                <div class="datos">
					                                <div class="grupo" id="numero">
						                                <p class="label">Número Tarjeta</p>
						                                <p class="numero">#### #### #### ####</p>
					                                </div>
					                                <div class="flexbox">
						                                <div class="grupo" id="nombre">
							                                <p class="label">Nombre Tarjeta</p>
							                                <p class="nombre">Jhon Doe</p>
						                                </div>

						                                <div class="grupo" id="expiracion">
							                                <p class="label">Expiracion</p>
							                                <p class="expiracion"><span class="mes">MM</span> / <span class="year">AA</span></p>
						                                </div>
					                                </div>
				                                </div>
			                                </div>

			                                <div class="trasera">
				                                <div class="barra-magnetica"></div>
				                                <div class="datos">
					                                <div class="grupo" id="firma">
						                                <p class="label">Firma</p>
						                                <div class="firma"><p></p></div>
					                                </div>
					                                <div class="grupo" id="ccv">
						                                <p class="label">CCV</p>
						                                <p class="ccv"></p>
					                                </div>
				                                </div>
				                                <p class="leyenda">Lorem ipsum dolor sit amet consectetur adipisicing elit. Accusamus exercitationem, voluptates illo.</p>
				                                <a href="#" class="link-banco">www.tubanco.com</a>
			                                </div>
		                                </section>

		                                <!-- Contenedor Boton Abrir Formulario -->
		                                <div class="contenedor-btn">
			                                <button class="btn-abrir-formulario" id="btn-abrir-formulario">
				                                <i class="fas fa-plus"></i>
			                                </button>
		                                </div>

		                                <!-- Formulario -->
		                                <form id="formulario-tarjeta" class="formulario-tarjeta">
			                                <div class="grupo">
				                                <label for="inputNumero">Número Tarjeta</label>
				                                <input type="text" id="inputNumero" maxlength="19" autocomplete="off">
                                                <div class="text-danger small validacion-text d-none" id="ValTarjetaNumero">Debe ingresar un valor.</div>
			                                </div>
			                                <div class="grupo">
				                                <label for="inputNombre">Nombre</label>
				                                <input type="text" id="inputNombre" maxlength="19" autocomplete="off">
                                                <div class="text-danger small validacion-text d-none" id="ValNombreTarjeta">Debe ingresar un valor.</div>
			                                </div>
			                                <div class="flexbox">
				                                <div class="grupo expira">
					                                <label for="selectMes">Expiracion</label>
					                                <div class="flexbox">
						                                <div class="grupo-select">
							                                <select name="mes" id="selectMes">
								                                <option disabled selected>Mes</option>
							                                </select>
							                                <i class="fas fa-angle-down"></i>
						                                </div>
						                                <div class="grupo-select">
							                                <select name="year" id="selectYear">
								                                <option disabled selected>Año</option>
							                                </select>
							                                <i class="fas fa-angle-down"></i>
						                                </div>
					                                </div>
				                                </div>

				                                <div class="grupo ccv">
					                                <label for="inputCCV">CCV</label>
					                                <input type="text" id="inputCCV" maxlength="3">
				                                </div>
			                                </div>
			                                <button type="button" name="complete_checkout_button" data-metodo="Tarjeta de credito" class="btn-enviar">Pagar la reserva</button>
		                                </form>
	                                </div>                                 
                                </div> 
                                 
                                <div class="tab-pane fade" id="nav-profile" role="tabpanel" aria-labelledby="nav-profile-tab">
                                    <div class="text-center">
                                        <img src="../img/logopaypal.png" alt="LogoPaypal" width="240" height="58" />
                                    </div>

                                    <div class="row mb-3 mt-2">
                                        <label for="paypalemail" class="col-sm-2 col-form-label">Correo</label>
                                        <div class="col-sm-10">
                                          <input type="email" class="form-control" id="paypalemail">
                                            <div class="text-danger small validacion-text d-none" id="ValCorreoPaypal">Debe ingresar un valor.</div>
                                        </div>
                                      </div>
                                      <div class="row mb-3">
                                        <label for="paypalpass" class="col-sm-2 col-form-label">Contraseña</label>
                                        <div class="col-sm-10">
                                          <input type="password" class="form-control" id="paypalpass">
                                            <div class="text-danger small validacion-text d-none" id="ValPassPaypal">Debe ingresar un valor.</div>
                                        </div>
                                      </div>
                                    <div class="d-grid gap-2 col-6 mx-auto">
                                      <button class="btn btn-primary" type="button" name="complete_checkout_button" data-metodo="Paypal"><i class="fa fa-paypal" aria-hidden="true"></i> Pagar la reserva con Paypal</button>
                                    </div>
                                </div>
                                <div class="tab-pane fade" id="nav-contact" role="tabpanel" aria-labelledby="nav-contact-tab">
                                    <div class="text-center">
                                        <img src="../img/logopse.png" alt="LogoPaypal" width="110" height="110" />
                                    </div>
                                    <h3 class="text-center">PSE - Pagos Seguros en Linea</h3>
                                    <div class="row g-0 d-flex justify-content-center">
                                        <div class="col-md-4 d-flex flex-column justify-content-center text-center">
                                            <div class="d-flex justify-content-center">
                                            <button class="btn-pse active" name="pse_tipo_persona" type="button"><i class="fa fa-user" aria-hidden="true"></i></button>
                                            </div>
                                                <p>Persona natural</p>
                                        </div>
                                        <div class="col-md-4 d-flex flex-column justify-content-center text-center">
                                            <div class="d-flex justify-content-center">
                                            <button class="btn-pse" name="pse_tipo_juridica" type="button"><i class="fa fa-building" aria-hidden="true"></i></button>
                                            </div>
                                                <p>Persona juridica</p>
                                        </div>
                                    </div>
                                    <div class="row mb-3 mt-2">
                                        <label for="pseemail" class="col-sm-2 col-form-label">E-mail</label>
                                        <div class="col-sm-10">
                                          <input type="email" class="form-control" id="pseemail" placeholder="E-mail registrado en PSE">
                                             <div class="text-danger small validacion-text d-none" id="ValEmailPSE">Debe ingresar un valor.</div>
                                        </div>
                                    </div>
                                    <div class="d-grid gap-2 d-md-flex justify-content-md-end">
                                      <button class="btn btn-outline-primary btn-lg me-md-2" type="button" name="complete_checkout_button" data-metodo="PSE">Ir al banco y pagar reserva</button>
                                    </div>
                                </div>
                              </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
      </div>

<!-- Optional JavaScript -->
<script src="/js/SorterLogic.js"></script>
<script src="../js/main.js"></script>  
<script src="../js/Checkout.js"></script>
  </body>
</html>

