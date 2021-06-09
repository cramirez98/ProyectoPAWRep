using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPAWRep.classes;
namespace ProyectoPAWRep.pages
{
    public partial class AgregarUsuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void BtnCrearUsuario_Click(object sender, EventArgs e)
        {
            UserDatabaseManager UserDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");

            bool exists = UserDatabaseManager.CheckIfExists(new string[] { "*" }, new string[,] { { "Correo", "=", "'" + CUCorreo.Text + "'" } }, null);

            if (!exists)
            {
                Val3Correo.Visible = false;
                Usuario usuario = new Usuario(CUNombres.Text, CUApellidos.Text, CUCorreo.Text, CUContraseña.Text, CUCelular.Text, CUCedula.Text, CUCiudad.Text, int.Parse(CUEdad.Text), CUTipo.SelectedValue.ToString(), CUDireccion.Text);
                bool connection_success = UserDatabaseManager.AddDatabaseRecord(usuario);

                if (connection_success)
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Registro completado!", "El registro del usuario ha terminado con exito.", "Puedes ver los usuarios registrados dando <a href='VerUsuarios.aspx' class='alert-link'>click aquí</a>", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error en tu registro!", "El registro del usuario no ha sido posible de realizarse, esto puede ser debido a problemas con el servidor.", "Revisa los datos ingresados en el formulario!", "danger");
                }
            }
            else
            {
                Val3Correo.Visible = true;
            }
        }
    }
}