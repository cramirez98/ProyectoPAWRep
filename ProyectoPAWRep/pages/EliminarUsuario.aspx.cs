using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPAWRep.classes;
using System.Data;
namespace ProyectoPAWRep.pages
{
    public partial class EliminarUsuario : System.Web.UI.Page
    {
        UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
        protected void Page_Load(object sender, EventArgs e)
        {
            string[] valores_a_traer = new string[] { "Nombres","Apellidos","Correo","ID" };
            string[,] condiciones = null;
            string[] logic_conditions = null;
            DataSet datos = userDatabaseManager.ReadDatabaseRecord(valores_a_traer, condiciones, logic_conditions);

            if (datos.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    datos.Tables[0].Columns.Add(new DataColumn("NombresApellidosyCorreo", typeof(string)));

                    foreach (DataRow row in datos.Tables[0].Rows)
                    {
                        row["NombresApellidosyCorreo"] = row["Nombres"].ToString() + " " + row["Apellidos"].ToString() + " - " + row["Correo"];
                    }

                    EUUsuario.DataTextField = datos.Tables[0].Columns["NombresApellidosyCorreo"].ToString();
                    EUUsuario.DataValueField = datos.Tables[0].Columns["Correo"].ToString();
                    EUUsuario.DataSource = datos.Tables[0];
                    EUUsuario.DataBind();
                }
            }
            else
            {
                EUUsuario.Items.Clear();
                EUUsuario.Items.Add(new ListItem("No hay usuarios", "h"));
                submitbtneliminaru.Visible = false;
            }

            alertaspace.InnerHtml = "";
        }

        protected void submitbtneliminaru_ServerClick(object sender, EventArgs e)
        {
            string user_id = userDatabaseManager.GetIDByCorreo("'"+ EUUsuario.SelectedValue.ToString() + "'");

            bool success = userDatabaseManager.RemoveDatabaseRecord(new string[,] { { "ID", "=", "'" + user_id + "'" } }, null);

            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            reservasDatabaseManager.RemoveDatabaseRecord(new string[,] { { "Cliente_ID", "=", "'" + user_id + "'" } }, null);

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha borrado con exito el usuario", "Recuerda que esto no es reversible!", "success");
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se ha podido borrar con exito el usuario", "Esto puede deberse a un problema con el servidor!", "danger");
            }
        }
    }
}