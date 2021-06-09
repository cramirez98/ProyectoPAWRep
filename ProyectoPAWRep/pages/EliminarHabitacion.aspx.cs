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
    public partial class EliminarHabitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            string[] valores_a_traer = new string[] { "Numero" };
            string[,] condiciones = null;
            string[] logic_conditions = null;
            DataSet datos = habitacionesDatabaseManager.ReadDatabaseRecord(valores_a_traer,condiciones,logic_conditions);

            if(datos.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    DHabitacionNumero.DataTextField = datos.Tables[0].Columns["Numero"].ToString();
                    DHabitacionNumero.DataValueField = datos.Tables[0].Columns["Numero"].ToString();
                    DHabitacionNumero.DataSource = datos.Tables[0];
                    DHabitacionNumero.DataBind();
                }
            }
            else
            {
                DHabitacionNumero.Items.Clear();
                DHabitacionNumero.Items.Add(new ListItem("No hay habitaciones", "h"));
                submitbtneliminarh.Visible = false;
            }

            alertaspace.InnerHtml = "";

        }

        protected void BtnEliminar_Click(object sender, EventArgs e)
        {
            int habitacion_a_eliminar = int.Parse(DHabitacionNumero.SelectedValue.ToString());

            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
            TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");

            string habitacion_a_eliminar_id = habitacionesDatabaseManager.GetHabitacionIDByNumber(habitacion_a_eliminar.ToString());

            string[,] conditions = new string[,] { { "Numero", "=", habitacion_a_eliminar.ToString() } };
            string[] logic_conditions = null;

            bool success = habitacionesDatabaseManager.RemoveDatabaseRecord(conditions, logic_conditions);

            reservasDatabaseManager.RemoveDatabaseRecord(
                new string[,] { {"Habitacion_ID","=","'"+ habitacion_a_eliminar_id + "'"} },
                null
            );

            testimoniosDatabaseManager.RemoveDatabaseRecord(new string[,] { { "Habitacion_ID", "=", "'" + habitacion_a_eliminar_id + "'" } }, null);

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha borrado con exito la habitación", "Recuerda que esto no es reversible!", "success");
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se ha podido borrar con exito la habitación", "Esto puede deberse a un problema con el servidor!", "danger");
            }
        }
    }
}