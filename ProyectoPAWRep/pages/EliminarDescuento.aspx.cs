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
    public partial class EliminarDescuento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");
            DataSet datos = descuentosDatabaseManager.ReadDatabaseRecord(
                new string[] {"*"},
                null,
                null
            );

            if (datos.Tables[0].Rows.Count > 0)
            {
                if (!IsPostBack)
                {
                    DDescuentoNombre.DataTextField = datos.Tables[0].Columns["Nombre"].ToString();
                    DDescuentoNombre.DataValueField = datos.Tables[0].Columns["Nombre"].ToString();
                    DDescuentoNombre.DataSource = datos.Tables[0];
                    DDescuentoNombre.DataBind();
                }
            }
            else
            {
                DDescuentoNombre.Items.Clear();
                DDescuentoNombre.Items.Add(new ListItem("No hay descuentos.", "d"));
                submitbtneliminard.Visible = false;
            }

            alertaspace.InnerHtml = "";
        }

        protected void submitbtneliminard_ServerClick(object sender, EventArgs e)
        {
            string descuento_a_eliminar = DDescuentoNombre.SelectedValue.ToString();

            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

            string descuento_id = descuentosDatabaseManager.GetDescuentoIDByName(descuento_a_eliminar);

            bool success = descuentosDatabaseManager.RemoveDatabaseRecord(
                new string[,] { {"ID","=","'"+ descuento_id + "'"} },
                null
            );

            habitacionesDatabaseManager.UpdateDatabaseRecord(
                new string[,] { {"Descuento_ID","''"} },
                new string[,] { {"Descuento_ID","=","'"+descuento_id+"'"} },
                null
            );

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha borrado con exito el descuento", "Recuerda que esto no es reversible!", "success");
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se ha podido borrar con exito el descuento", "Esto puede deberse a un problema con el servidor!", "danger");
            }
        }
    }
}