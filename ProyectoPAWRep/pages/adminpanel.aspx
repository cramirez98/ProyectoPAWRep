<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="adminpanel.aspx.cs" Inherits="ProyectoPAWRep.pages.adminpanel" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
        <title>Panel de administrador</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
              <div class="container-fluid px-4 py-3">
                <div class="row d-flex flex-column">
                  <div class="admin-page-title">Panel de informacion</div>
                </div>
                <div class="row">
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-blue mb-2 mb-xl-0">
                      <div class="d-flex flex-column">
                        <div class="title">Ganancias</div>
                        <div class="value">20</div>
                      </div>
                      <i class="fa fa-dollar-sign icon"></i>
                    </div>
                  </div>
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-green mb-2 mb-xl-0">
                      <div class="d-flex flex-column">
                        <div class="title">Habitaciones reservadas</div>
                        <div class="value">20</div>
                      </div>
                      <i class="fas fa-door-closed icon"></i>
                    </div>
                  </div>
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-magenta">
                      <div class="d-flex flex-column">
                        <div class="title">Habitaciones libres</div>
                        <div class="value">20</div>
                      </div>
                      <i class="fa fa-door-open icon"></i>
                    </div>                    
                  </div>
                  <div class="col-xl-3 col-sm-6 col-xs-12">
                    <div class="admin-cards border-orange">
                      <div class="d-flex flex-column">
                        <div class="title">Descuentos vigentes</div>
                        <div class="value">20</div>
                      </div>
                      <i class="fas fa-tags icon"></i>
                    </div>  
                  </div>
                </div>
              </div>
</asp:Content>
