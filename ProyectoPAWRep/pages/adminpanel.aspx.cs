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
    public partial class adminpanel : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            PagoDatabaseManager pagoDatabaseManager = new PagoDatabaseManager("SQLConnection", "[dbo].[Pagos]");

            DataSet pagos = pagoDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null, "FechaPago", "Desc");

            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

            DataSet habitaciones_data = habitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null);
            DataSet reservas_data = new DataSet();
            DataSet descuentos_data = new DataSet();

            int habitaciones_reservada = 0;
            int habitaciones_libres = 0;
            int descuentos_vigentes = 0;

            foreach (DataRow row in habitaciones_data.Tables[0].Rows)
            {
                reservas_data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "Habitacion_ID", "=", "'" + row["ID"] + "'" }, {"Cancelada","=","0"} }, new string[] {"AND"});
                if (reservas_data.Tables[0].Rows.Count > 0)
                {
                    //habitaciones_reservada++;
                    bool disponible = Utilities.CheckIfHabitacionEstaDisponible(reservas_data, DateTime.Now, DateTime.Now.AddDays(1));
                    if (disponible)
                    {
                        habitaciones_libres++;
                    }
                    else
                    {
                        habitaciones_reservada++;
                    }
                }
                else
                {
                    habitaciones_libres++;
                }
            }

            numhabitacionesdisponibles.InnerText = habitaciones_libres.ToString();
            numhabitacionesocupadas.InnerText = habitaciones_reservada.ToString();

            descuentos_data = descuentosDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null);

            if (descuentos_data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in descuentos_data.Tables[0].Rows)
                {
                    if (Utilities.CheckIfDiscountIsValid(DateTime.Parse(row["FechaFinalizacion"].ToString()), DateTime.Parse(row["FechaInicio"].ToString()))) 
                    {
                        descuentos_vigentes++;
                    }
                }
            }

            numdescuentosvigentes.InnerText = descuentos_vigentes.ToString();

            pagos_table_info.InnerHtml = Utilities.GeneratePagosTable(pagos);
        }
    }
}