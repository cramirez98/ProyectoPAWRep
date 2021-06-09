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
    public partial class VerHabitaciones : System.Web.UI.Page
    {
        HabitacionesDatabaseManager HabitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
        protected void Page_Load(object sender, EventArgs e)
        {
            DataSet habitaciones_data = HabitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null);

            ver_habitaciones_table_info.InnerHtml = Utilities.GenerateHabitacionesTable(habitaciones_data);
        }

        [WebMethod]
        public static void EliminarHabitacion(string habitacion_id)
        {
            HabitacionesDatabaseManager HabitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            HabitacionesDatabaseManager.RemoveDatabaseRecord(new string[,] { { "ID", "=", "'" + habitacion_id + "'" } }, null);

            TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            testimoniosDatabaseManager.RemoveDatabaseRecord(new string[,] { { "Habitacion_ID", "=", "'" + habitacion_id + "'" } }, null);
            reservasDatabaseManager.RemoveDatabaseRecord(new string[,] { { "Habitacion_ID", "=", "'" + habitacion_id + "'" } }, null);
        }

        [WebMethod]
        public static string OrdenarHabitaciones(string orderby, string direction)
        {
            string result = "";
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DataSet data_inicial = habitacionesDatabaseManager.ReadDatabaseRecord(new string[] {"*"}, null, null);
            DataSet data_organizada = new DataSet();
            if (orderby.Equals("Mascotas") || orderby.Equals("BañosPDiscapacitadas"))
            {

            }
            else
            {
                switch (orderby)
                {
                    case "Precio":
                        data_organizada = Utilities.OrderByPrice(data_inicial, direction);
                        break;
                    case "NumeroCamas":
                        data_organizada = Utilities.OrderByNumeroCamas(data_inicial, direction);
                        break;
                    case "Puntaje":
                        data_organizada = Utilities.OrderByPuntaje(data_inicial, direction);
                        break;
                    case "Tamaño":
                        data_organizada = habitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null, "case when [Tamaño] = 'Pequeña'");
                        break;
                    default:
                        data_organizada = data_inicial;
                        break;
                }
            }

            return result;
        }
    }
}