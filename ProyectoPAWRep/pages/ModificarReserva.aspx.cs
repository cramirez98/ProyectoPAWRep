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
    public partial class ModificarReserva : System.Web.UI.Page
    {
        public ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
        public HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
        public UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
        protected void Page_Load(object sender, EventArgs e)
        {
            string reserva_id = Request.Form["reserva_id"];
            if (!String.IsNullOrEmpty(reserva_id))
            {
                seleccionar_reserva.Visible = false;
                int fetched_data = reservasDatabaseManager.CountFetchedData(
                    new string[] { "ID" },
                    new string[,] { { "ID", "=", "'" + reserva_id + "'" } },
                    null
                );

                if (fetched_data > 0)
                {
                    DataSet data = reservasDatabaseManager.ReadDatabaseRecord(
                        new string[] { "*" },
                        new string[,] { { "ID", "=", "'" + reserva_id + "'" } },
                        null
                    );
                   // CargarInformacionReserva(data);
                }
                else
                {
                    Response.Redirect("VerReservas.aspx");
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    DataSet data = habitacionesDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Numero" },
                        null,
                        null
                    );

                    DataSet user_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "Nombres","Correo" }, null, null);

                    seccion_tabla_info_reservas.Visible = true;

                    MReservaNumeroHabitacionesToLoad.DataTextField = data.Tables[0].Columns["Numero"].ToString();
                    MReservaNumeroHabitacionesToLoad.DataValueField = data.Tables[0].Columns["Numero"].ToString();
                    MReservaNumeroHabitacionesToLoad.DataSource = data.Tables[0];
                    MReservaNumeroHabitacionesToLoad.DataBind();

                    MReservaHabitacion.DataTextField = data.Tables[0].Columns["Numero"].ToString();
                    MReservaHabitacion.DataValueField = data.Tables[0].Columns["Numero"].ToString();
                    MReservaHabitacion.DataSource = data.Tables[0];
                    MReservaHabitacion.DataBind();

                    MReservaCliente.DataTextField = user_data.Tables[0].Columns["Nombres"].ToString();
                    MReservaCliente.DataValueField = user_data.Tables[0].Columns["Correo"].ToString();
                    MReservaCliente.DataSource = user_data.Tables[0];
                    MReservaCliente.DataBind();
                }

                seleccionar_reserva.Visible = true;
            }

            alertaspace.InnerHtml = "";
        }

        protected void BtnModificarReserva_Click(object sender, EventArgs e)
        {

        }

        protected void cargarinformacionreservas_ServerClick(object sender, EventArgs e)
        {
            string numero_habitacion = MReservaNumeroHabitacionesToLoad.SelectedValue.ToString();

            string habitacion_id = habitacionesDatabaseManager.GetHabitacionIDByNumber(numero_habitacion);

            DataSet data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "Habitacion_ID", "=", "'"+ habitacion_id + "'" } }, null);

            filas_tabla_reservas.InnerHtml = Utilities.GenerateTableModificarReserva(data);
        }

        [WebMethod]
        public static string CargarInformacionReserva(string reserva_id)
        {
            string results = "";
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            ReservasDatabaseManager reservasdatabase = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
            DataSet reserva_data = reservasdatabase.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "ID", "=", "'" + reserva_id + "'" } }, null);

            DataSet user_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "Correo" }, new string[,] { { "ID", "=", "'" + reserva_data.Tables[0].Rows[0]["Cliente_ID"].ToString() + "'" } }, null);
            DataSet habitacion_data = habitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "Numero" }, new string[,] { { "ID", "=", "'" + reserva_data.Tables[0].Rows[0]["Habitacion_ID"].ToString() + "'" } }, null);

            results += user_data.Tables[0].Rows[0]["Correo"].ToString() + ";";
            results += habitacion_data.Tables[0].Rows[0]["Numero"].ToString() + ";";
            results += DateTime.Parse(reserva_data.Tables[0].Rows[0]["FechaInicio"].ToString()).ToString("yyy-MM-dd") + ";";
            results += DateTime.Parse(reserva_data.Tables[0].Rows[0]["FechaFinalizacion"].ToString()).ToString("yyy-MM-dd") + ";";
            results += reserva_data.Tables[0].Rows[0]["NumeroPersonas"].ToString() + ";";
            results += reserva_data.Tables[0].Rows[0]["Cancelada"].ToString();

            return results;
        }

    }

}