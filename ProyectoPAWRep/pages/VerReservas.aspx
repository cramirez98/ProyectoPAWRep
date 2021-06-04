<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="VerReservas.aspx.cs" Inherits="ProyectoPAWRep.pages.VerReservas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ver Reservas</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Ver reservas</div>
                  <div class="admin-page-description mb-2">En esta sección podras visualizar todos las reservas que se han realizado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Listado de todas las reservas que se han realizado hasta el momento.</h1>
                                <table class="table">
                                  <thead class="table-blue">
                                    <tr>
                                      <th scope="col">#</th>
                                      <th scope="col">Cliente</th>
                                      <th scope="col">Fecha Inicio</th>
                                      <th scope="col">Fecha Finalizacion</th>
                                      <th scope="col">Numero de personas</th>
                                      <th scope="col">Estado</th>
                                      <th scope="col">Valor pagado</th>
                                      <th scope="col">Fecha de la reserva</th>
                                    <th scope="col">Acción</th>
                                    </tr>
                                  </thead>
                                  <tbody runat="server" id="filas_tabla_reservas">
                                    <tr>
                                      <td colspan="8">No se han encontrado reservas.</td>
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
        <h5 class="modal-title">Reserva eliminada</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <p>La reserva se ha eliminado correctamente!</p>
      </div>
      <div class="modal-footer">
        <button type="button" class="btn btn-danger" data-bs-dismiss="modal">Close</button>
      </div>
    </div>
  </div>
</div>
<script>
    var myModalEl = document.getElementById('ConfirmationModal')
    myModalEl.addEventListener('hidden.bs.modal', function (event) {
        location.href = location.href;
    })
    $('button[data-action="eliminar"]').click(function () {
        var item_to_delete_id = $('button[data-action="eliminar"]').children("input[type=hidden]").val();
        $.ajax({
            type: "POST",
            url: "VerReservas.aspx/EliminarReserva",
            data: '{reserva_id: "' + item_to_delete_id +'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#ConfirmationModal').modal('show');
            }
        });
    });
</script>
</asp:Content>
