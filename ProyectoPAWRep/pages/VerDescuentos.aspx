<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="VerDescuentos.aspx.cs" Inherits="ProyectoPAWRep.pages.VerDescuentos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ver Descuentos</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Ver descuentos</div>
                  <div class="admin-page-description mb-2">En esta sección podras visualizar todos los descuentos que se han creado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Listado de todos los descuentos que se han creado hasta el momento.</h1>
                              <table class="table">
                                <thead class="table-blue">
                                  <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Nombre</th>
                                    <th scope="col">Porcentaje</th>
                                    <th scope="col">Fecha de inicio</th>
                                    <th scope="col">Fecha de finalización</th>
                                    <th scope="col">Estado</th>
                                    <th scope="col">Acciones</th>
                                  </tr>
                                </thead>
                                <tbody runat="server" id="ver_descuentos_table_info">
                                  <tr>
                                       <td colspan="8">No hay descuentos para mostrar.</td>
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
        <h5 class="modal-title">Descuento eliminado</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <p>El descuento se ha eliminado correctamente!</p>
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
            url: "VerDescuentos.aspx/EliminarDescuento",
            data: '{descuento_id: "' + item_to_delete_id +'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#ConfirmationModal').modal('show');
            }
        });
    });
</script>
</asp:Content>
