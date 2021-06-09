<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="VerHabitaciones.aspx.cs" Inherits="ProyectoPAWRep.pages.VerHabitaciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ver Habitaciones</title>
    <style>
        .table-order{
            cursor:pointer;
        }
        .table-order.active{
            cursor:pointer;
            text-decoration:underline;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Ver habitaciones</div>
                  <div class="admin-page-description mb-2">En esta sección podras visualizar todos las habitaciones que se han creado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Listado de todos las habitaciones que se han creado hasta el momento.</h1>
                              <table class="table">
                                <thead class="table-blue">
                                  <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Numero</th>
                                    <th scope="col">Descripción</th>
                                    <th scope="col" class="table-order active" data-ordering="true" data-order="Precio" data-direction="DESC"><i class="fas fa-sort-numeric-up"></i> Precio</th>
                                    <th scope="col" class="table-order" data-ordering="true" data-order="Tamaño">Tamaño</th>
                                    <th scope="col" class="table-order" data-ordering="true" data-order="NumeroCamas">Numero de camas</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col" class="table-order" data-ordering="true" data-order="Mascotas">Mascotas</th>
                                    <th scope="col" class="table-order" data-ordering="true" data-order="BañosPDiscapacitadas">Baños para discapacitados</th>
                                    <th scope="col">Descuento</th>
                                    <th scope="col" class="table-order" data-ordering="true" data-order="Puntaje">Puntaje</th>
                                    <th scope="col">Acciones</th>
                                  </tr>
                                </thead>
                                <tbody runat="server" id="ver_habitaciones_table_info" data-tablecontent="true">
                                  <tr>
                                       <td colspan="13">No hay habitaciones para mostrar.</td>
                                  </tr>
                                </tbody>
                              </table>
                  </div>
                </div>
              </div>

<div class="modal" tabindex="-1" id="ConfirmationModal" aria-labelledby="ConfirmationModalLabel" aria-hidden="true">
  <div class="modal-dialog">
    <div class="modal-content">
      <div class="modal-header">
        <h5 class="modal-title">Habitación eliminada</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <p>La habitación se ha eliminado correctamente!</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<script src="../js/OrderingTablePlugin.js"></script>
<script>
    var myModalEl = document.getElementById('ConfirmationModal')
    myModalEl.addEventListener('hidden.bs.modal', function (event) {
        location.href = location.href;
    })
    $('button[data-action="eliminar"]').click(function () {
        var item_to_delete_id = $('button[data-action="eliminar"]').children("input[type=hidden]").val();
        $.ajax({
            type: "POST",
            url: "VerHabitaciones.aspx/EliminarHabitacion",
            data: '{habitacion_id: "' + item_to_delete_id + '"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#ConfirmationModal').modal('show');
            }
        });
    });
</script>
</asp:Content>
