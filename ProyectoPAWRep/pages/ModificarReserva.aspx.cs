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
        public static bool sended = false;
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
                    if (!IsCallback)
                    {
                        DataSet data = reservasDatabaseManager.ReadDatabaseRecord(
                            new string[] { "*" },
                            new string[,] { { "ID", "=", "'" + reserva_id + "'" } },
                            null
                        );
                        CargarInformacionReserva(data);
                    }
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

                    seccion_tabla_info_reservas.Visible = false;

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
                else
                {

                        seccion_info_reserva.Attributes["class"] = "row mt-2";

                    seccion_tabla_info_reservas.Visible = false;
                }

                seleccionar_reserva.Visible = true;
            }
        }

        public void CargarInformacionReserva(DataSet reserva_data)
        {
            reserva_id_input_hidden.Attributes["value"] = reserva_data.Tables[0].Rows[0]["ID"].ToString();
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            ReservasDatabaseManager reservasdatabase = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            DataSet data = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] { "Numero" },
                null,
                null
            );

            DataSet user_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "Nombres", "Correo" }, null, null);

            seccion_tabla_info_reservas.Visible = false;

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

            user_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "Correo" }, new string[,] { { "ID", "=", "'" + reserva_data.Tables[0].Rows[0]["Cliente_ID"].ToString() + "'" } }, null);
            DataSet habitacion_data = habitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "Numero" }, new string[,] { { "ID", "=", "'" + reserva_data.Tables[0].Rows[0]["Habitacion_ID"].ToString() + "'" } }, null);

            seleccionar_reserva.Visible = false;
            seccion_tabla_info_reservas.Visible = false;

            MReservaFechaInicioHidden.Text = DateTime.Parse(reserva_data.Tables[0].Rows[0]["FechaInicio"].ToString()).ToString("yyy-MM-dd");
            MReservaFechaFinalizacionHidden.Text = DateTime.Parse(reserva_data.Tables[0].Rows[0]["FechaFinalizacion"].ToString()).ToString("yyy-MM-dd");

            MReservaCliente.SelectedValue = user_data.Tables[0].Rows[0]["Correo"].ToString();
            MReservaHabitacion.SelectedValue = habitacion_data.Tables[0].Rows[0]["Numero"].ToString();
            MReservaNumeroPersonas.SelectedValue = reserva_data.Tables[0].Rows[0]["NumeroPersonas"].ToString();

            MReservaEstado.Checked = reserva_data.Tables[0].Rows[0]["Cancelada"].ToString().Equals("1") ? true : false;

            seccion_info_reserva.Attributes["class"] = "row mt-2";
        }
        protected void BtnModificarReserva_Click(object sender, EventArgs e)
        {
            sended = true;
            string reserva_id = reserva_id_input_hidden.Attributes["value"];
            string habitacion_id = habitacionesDatabaseManager.GetHabitacionIDByNumber(MReservaHabitacion.SelectedValue.ToString());
            string cliente_id = userDatabaseManager.GetIDByCorreo("'" + MReservaCliente.SelectedValue.ToString() + "'");

            string[] fechas = MReservaFechas.Text.Split(new string[] { " - " }, StringSplitOptions.None);

            bool success = reservasDatabaseManager.UpdateDatabaseRecord(
                new string[,] { 
                    {"Habitacion_ID","'"+habitacion_id+"'"},
                    {"Cliente_ID","'"+cliente_id+"'"},
                    {"FechaInicio", "'"+fechas[0]+"'"},
                    {"FechaFinalizacion","'"+fechas[1]+"'"},
                    {"Cancelada",MReservaEstado.Checked ? "1" : "0"},
                    {"NumeroPersonas",MReservaNumeroPersonas.SelectedValue.ToString()}
                },
                new string[,] { {"ID","=","'"+ reserva_id + "'"} },
                null
            );

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha modificado correctamente la reserva.", "Si deseas ver las reservas, ve a la seccion de Ver Reservas", "success");
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se ha podido modificar correctamente la reserva.", "Esto puede deberse a problemas con el servidor.", "danger");
            }
        }

        protected void cargarinformacionreservas_ServerClick(object sender, EventArgs e)
        {
            string numero_habitacion = MReservaNumeroHabitacionesToLoad.SelectedValue.ToString();

            string habitacion_id = habitacionesDatabaseManager.GetHabitacionIDByNumber(numero_habitacion);

            DataSet data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "Habitacion_ID", "=", "'"+ habitacion_id + "'" } }, null);

            filas_tabla_reservas.InnerHtml = Utilities.GenerateTableModificarReserva(data);
            seccion_tabla_info_reservas.Visible = true;
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
            results += reserva_data.Tables[0].Rows[0]["Cancelada"].ToString() + ";";
            results += reserva_data.Tables[0].Rows[0]["ID"].ToString();

            return results;
        }

    }

}