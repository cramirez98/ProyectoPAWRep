<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="EliminarHabitacion.aspx.cs" Inherits="ProyectoPAWRep.pages.EliminarHabitacion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div id="topbaradmin">
              <nav class="navbar navbar-expand-lg navbar-light bg-light">
                <div class="container-fluid">
                  <button class="colapse-button" data-collapsed-navbar="collapse"><i class="fa fa-chevron-left"></i></button>
                  <span class="navbar-brand mb-0 h1 fw-bold">Sun Paradise Hotel</span>
                  <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarText" aria-controls="navbarText" aria-expanded="false" aria-label="Toggle navigation">
                    <span class="navbar-toggler-icon"></span>
                  </button>
                  <div class="collapse navbar-collapse" id="navbarText">
                    <span class="navbar-nav me-auto mb-2 mb-lg-0 navbar-text">
                      Panel de administrador
                    </span>
                    <ul class="navbar-nav ml-auto">
                      <li class="nav-item dropdown">
                        <a class="nav-link dropdown-toggle" href="#" id="navbarDropdown" role="button" data-bs-toggle="dropdown" aria-expanded="false">
                            <img src="../img/nelson.jpeg" class="rounded-circle" alt="..." width="50" height="50">
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
              <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Eliminar habitación</div>
                  <div class="admin-page-description mb-2">En esta seccion podras eliminar las habitaciones que desees, ten en cuenta que cuando elimines una habitaciones, tambien se eliminara la reserva en caso de que esta tenga una.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Habitación a eliminar</h1>
                    <form class="row g-3" action="" runat="server">
                      
                      <div class="row">
                        <label for="LoadI" class="col-sm-2 col-form-label">Numero de la habitación</label>
                        <div class="col-sm-4">
                          <select id="LoadI" class="form-select">
                            <option value="1" selected>1</option>
                            <option>...</option>
                          </select>
                        </div>
                      </div>
                      <div class="col-12">
                        <button type="submit" class="btn btn-danger"><i class="fa fa-remove"></i> Eliminar habitación</button>
                      </div>
                    </form>
                  </div>
                </div>
              </div>
</asp:Content>
