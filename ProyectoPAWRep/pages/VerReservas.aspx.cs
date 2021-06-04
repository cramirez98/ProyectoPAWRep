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
    public partial class VerReservas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            DataSet reservas_data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null, "FechaPago", "DESC");

            filas_tabla_reservas.InnerHtml = Utilities.GenerateTableReservas(reservas_data);
        }

        [WebMethod]
        public static void EliminarReserva(string reserva_id)
        {
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            reservasDatabaseManager.RemoveDatabaseRecord(new string[,] { { "ID", "=", "'" + reserva_id + "'" } }, null);
        }
    }
}