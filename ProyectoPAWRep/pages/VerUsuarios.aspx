<%@ Page Title="" Language="C#" MasterPageFile="~/pages/Admin.Master" AutoEventWireup="true" CodeBehind="VerUsuarios.aspx.cs" Inherits="ProyectoPAWRep.pages.VerUsuarios" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>Ver Usuarios</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
               <div class="container-fluid px-4 py-3">
                <div class="row">
                  <div class="admin-page-title">Ver usuarios</div>
                  <div class="admin-page-description mb-2">En esta sección podras visualizar todos los usuarios que se han registrado.</div>
                </div>
                <div class="row">
                  <div class="admin-content">
                      <h1>Listado de todos los usuarios que se han registrado hasta el momento.</h1>
                              <table class="table">
                                <thead class="table-blue">
                                  <tr>
                                    <th scope="col">#</th>
                                    <th scope="col">Nombres</th>
                                    <th scope="col">Apellidos</th>
                                    <th scope="col">Correo</th>
                                    <th scope="col">Celular</th>
                                    <th scope="col">Cedula</th>
                                    <th scope="col">Direccion</th>
                                    <th scope="col">Ciudad</th>
                                    <th scope="col">Edad</th>
                                    <th scope="col">Tipo</th>
                                    <th scope="col">Fecha de registro</th>
                                    <th scope="col">Acciones</th>
                                  </tr>
                                </thead>
                                <tbody runat="server" id="ver_usuarios_table_info">
                                  <tr>
                                       <td colspan="8">No hay usuarios para mostrar.</td>
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
        <h5 class="modal-title">Usuario eliminado</h5>
        <button type="button" class="btn-close" data-bs-dismiss="modal" aria-label="Close"></button>
      </div>
      <div class="modal-body">
        <p>El usuario se ha eliminado correctamente!</p>
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
            url: "VerUsuarios.aspx/EliminarUsuario",
            data: '{usuario_id: "' + item_to_delete_id +'"}',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            success: function (msg) {
                $('#ConfirmationModal').modal('show');
            }
        });
    });
</script>
</asp:Content>
