<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="iniciosesion.aspx.cs" Inherits="ProyectoPAWRep.pages.iniciosesion" %>
<!DOCTYPE html>
<html lang="en">
<head>
    <title>Inicio de sesion</title>
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
</head>
<body class="body-roboto-font-family">
    <div class="container-fluid">
        <div class="row no-gutter">
            <div class="col-md-6 d-none d-md-flex login-form-image"></div>
            <div class="col-md-6 bg-light">
                <div class="env-login d-flex align-items-center py-5">
                <div class="container">
                    <div class="row">
                        <div class="col-lg-10 col-xl-7 mx-auto">
                            <div class="text-center">
                            <img src="../img/logo/logodark.png" class="m-2" alt="..." width="290" height="120">
                            </div>
                            <div runat="server" class="text-left" id="alertaspace"></div>
                            <form runat="server">
                                    <asp:ScriptManager ID="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
                                    <div class="mb-3">
                                        <div class="form-group has-search ">
                                            <span class="fa fa-envelope form-control-feedback"></span>
                                             <asp:TextBox ID="Correo" class="form-control form-control-lg round-edges" placeholder="Correo electronico" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RegularExpressionValidator ID="ValCorreo" class="text-danger small validacion-text" runat="server" ErrorMessage="Debe ingresar un correo valido" ValidationExpression="^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$" ControlToValidate="Correo" ValidationGroup="Requeridos" Display="Dynamic"></asp:RegularExpressionValidator>
                                            <asp:RequiredFieldValidator ID="Val2Correo" class="text-danger small validacion-text" runat="server" ControlToValidate="Correo" ErrorMessage="No puede estar vacío" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>                                        
                                        </div>
                                    </div>
                                    <div class="mb-3">
                                        <div class="form-group has-search has-validation">
                                            <span class="fa fa-lock form-control-feedback"></span>
                                             <asp:TextBox ID="Contraseña" TextMode="Password" class="form-control form-control-lg round-edges" placeholder="Contraseña" runat="server"></asp:TextBox>
                                        </div>
                                        <div class="d-flex flex-column justify-content-start">
                                            <asp:RequiredFieldValidator ID="Val2Pass" class="text-danger small validacion-text" runat="server" ControlToValidate="Contraseña" ErrorMessage="Debe escribir una contraseña" ValidationGroup="Requeridos" Display="Dynamic"></asp:RequiredFieldValidator>                                        
                                        </div>
                                    </div>
                                    <div class="d-grid gap-2">
                                        <asp:Button ID="BtnLogin" class="btn btn-primary btn-lg btn-lg-height" runat="server" Text="Iniciar Sesion" ValidationGroup="Requeridos" OnClick="BtnLogin_Click"/>
                                      </div>
                                </form>
                                <div class="mb-3 mt-3 text-center">
                                    <p>No posee una cuenta? <a href="registro.aspx">Registrese aquí</a></p>
                                </div>
                        </div>
                    </div>
                </div>
                </div>
            </div><!-- End -->
    
        </div>
    </div>
</body>
</html>