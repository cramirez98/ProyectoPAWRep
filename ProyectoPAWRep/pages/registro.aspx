<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registro.aspx.cs" Inherits="ProyectoPAWRep.pages.registro" %>

<!DOCTYPE html>
<html lang="en">
<head>
    <meta charset="UTF-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <!-- CSS -->
    <link rel="stylesheet" href="../css/bootstrap.css" crossorigin="anonymous">
    <link rel="stylesheet" href="../css/custom.css" crossorigin="anonymous">
    <link rel="stylesheet" type="text/css" href="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.css" />
    <!-- Javascript -->
    <script src="https://code.jquery.com/jquery-3.6.0.js" integrity="sha256-H+K7U5CnXl1h5ywQfKtSj8PCmoN9aaq30gDh27Xc0jk=" crossorigin="anonymous"></script>
    <script src="../js/bootstrap.bundle.min.js"></script>
    <script src="https://kit.fontawesome.com/7e4e3039b1.js" crossorigin="anonymous"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/momentjs/latest/moment.min.js"></script>
    <script type="text/javascript" src="https://cdn.jsdelivr.net/npm/daterangepicker/daterangepicker.min.js"></script>
    <!-- Load google fonts -->
    <link rel="preconnect" href="https://fonts.gstatic.com">
    <link href="https://fonts.googleapis.com/css2?family=Montserrat:wght@100;300;500;700&family=Recursive:wght@300;400&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Roboto:ital,wght@0,100;0,300;0,700;0,900;1,100&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Recursive:wght@300;400&display=swap" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Pacifico&display=swap" rel="stylesheet">
    <title>Registro</title>
</head>
<body class="body-roboto-font-family">
    <div class="container-fluid">
        <div class="row no-gutter">
            <div class="col-md-6 bg-light">
                <div class="env-login d-flex align-items-center py-5">
                <div class="container-fluid">
                    <div class="row">
                        <div class="col-lg-10 col-xl-10 mx-auto">
                            <form class="row g-3" runat="server">
                            <div class="text-center">
                            <img src="../img/logo/logodark.png" class="" alt="..." width="290" height="120">
                                <asp:ScriptManager ID="ScriptManager1" runat="server">
                                </asp:ScriptManager>
                          </div>
                                <h1>Registrate</h1>

                                  <div id="alerta" runat="server"></div>
                                    <div class="col-xl-6">
                                      <label for="Nombres" class="form-label">Nombres</label>
                                        <asp:TextBox ID="Nombres" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValNombres" class="text-danger small validacion-text" runat="server" ControlToValidate="Nombres" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-6">
                                      <label for="Apellidos" class="form-label">Apellidos</label>
                                      <asp:TextBox ID="Apellidos" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="ValApellidos" class="text-danger small validacion-text" runat="server" ControlToValidate="Apellidos" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-xl-5">
                                        <label for="Celular" class="form-label">Numero de celular o telefono fijo</label>
                                        <asp:TextBox ID="Celular" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCelular" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Celular" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Celular" class="text-danger small validacion-text" runat="server" ControlToValidate="Celular" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                      

                                    </div>
                                      <div class="col-xl-4">
                                        <label for="Cedula" class="form-label">Numero de cedula</label>
                                        <asp:TextBox ID="Cedula" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCedula" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admite valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Cedula" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Cedula" class="text-danger small validacion-text" runat="server" ControlToValidate="Cedula" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                      <div class="col-xl-3">
                                        <label for="Edad" class="form-label">Edad</label>
                                        <asp:TextBox ID="Edad" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                          <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValEdad" class="text-danger small validacion-text" runat="server" ErrorMessage="Solo se admiten valores numericos" ValidationExpression="^([0-9])*$" ControlToValidate="Edad" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Edad" class="text-danger small validacion-text" runat="server" ControlToValidate="Edad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator> 
                                            <asp:RangeValidator ID="Val3Edad" class="text-danger small validacion-text" runat="server" MaximumValue="80" MinimumValue="18" ValidationGroup="Requeridos" ControlToValidate="Edad" Display="Dynamic">Debe ser mayor de edad (+18 años)</asp:RangeValidator>
                                          </div>
                                      </div>
                                      <div class="col-xl-9">
                                        <label for="Direccion" class="form-label">Dirección de residencia</label>
                                        <asp:TextBox ID="Direccion" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                        <div class="d-flex flex-column justify-content-start">

                                            <asp:RequiredFieldValidator ID="Val2Direccion" class="text-danger small validacion-text" runat="server" ControlToValidate="Direccion" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>
                                      </div>
                                    <div class="col-xl-3">
                                      <label for="Ciudad" class="form-label">Ciudad de residencia</label>
                                      <asp:TextBox ID="Ciudad" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                            <asp:RequiredFieldValidator ID="ValCiudad" class="text-danger small validacion-text" runat="server" ControlToValidate="Ciudad" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                    </div>
                                    <div class="col-12">
                                        <label for="Correo" class="form-label">Correo electronico</label>
                                        <asp:TextBox ID="Correo" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCorreo" class="text-danger small validacion-text" runat="server" ErrorMessage="Debe ingresar un correo valido" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" ControlToValidate="Correo" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Correo" class="text-danger small validacion-text" runat="server" ControlToValidate="Correo" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>      
                                            <div runat="server" class="text-danger small validacion-text" id="Val3Correo" Visible="false">El correo ingresado ya esta en uso.</div>
                                        </div>
                                      </div>
                                      <div class="col-xl-6">
                                        <label for="Contraseña" class="form-label">Contraseña</label>
                                        <asp:TextBox ID="Contraseña" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                      </div>
                                      <div class="col-xl-6">
                                        <label for="RContraseña" class="form-label">Repetir contraseña</label>
                                        <asp:TextBox ID="RContraseña" TextMode="Password" class="form-control form-control-lg" runat="server"></asp:TextBox>
                                      </div>
                                    <div class="col-12 text-center">
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:CompareValidator ID="ValPass" class="text-danger small" runat="server" ErrorMessage="Las contraseñas no coinciden" ControlToCompare="Contraseña" ControlToValidate="RContraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:CompareValidator>
                                            <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small" runat="server" ControlToValidate="Contraseña" ErrorMessage="Debe ingresar una contraseña" ValidationGroup="Requeridos"></asp:RequiredFieldValidator> 
                                        </div>                                    

                                    </div>
                                    <div class="col-12 text-center">
                                      <asp:Button ID="BtnRegistrarse" class="btn btn-primary btn-lg w-75" runat="server" Text="Registrarse" OnClick="BtnRegistrarse_Click" ValidationGroup="Requeridos"/>
                                    </div>
                                  </form>


                                <div class="mb-3 text-center m-3">
                                    <p>Ya posee una cuenta? <a href="iniciosesion.aspx">Ingrese aquí</a></p>
                                </div>
                        </div>
                    </div>
                </div>
                </div>
            </div><!-- End -->
            <div class="col-md-6 d-none d-md-flex login-form-image"></div>
        </div>
    </div>
</body>
</html>
