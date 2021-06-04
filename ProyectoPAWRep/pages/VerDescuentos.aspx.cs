using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPAWRep.classes;
using System.Data;
using System.Web.Services;

namespace ProyectoPAWRep.pages
{
    public partial class VerDescuentos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

            DataSet descuentos_data = descuentosDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null);

            ver_descuentos_table_info.InnerHtml = Utilities.GenerateDescuentosTable(descuentos_data);
        }

        [WebMethod]
        public static void EliminarDescuento(string descuento_id)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

            bool success = descuentosDatabaseManager.RemoveDatabaseRecord(
                new string[,] { { "ID", "=", "'" + descuento_id + "'" } },
                null
            );

            habitacionesDatabaseManager.UpdateDatabaseRecord(
                new string[,] { { "Descuento_ID", "''" } },
                new string[,] { { "Descuento_ID", "=", "'" + descuento_id + "'" } },
                null
            );
        }
    }
}