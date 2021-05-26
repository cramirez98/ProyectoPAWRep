using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using ProyectoPAWRep.classes;
using System.Globalization;

namespace ProyectoPAWRep.pages
{
    public partial class usuario : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Contraseña.Attributes["type"] = "password";
            RContraseña.Attributes["type"] = "password";
            // Cargar informacion
            if(!IsPostBack)
            {
                if (!String.IsNullOrEmpty(Session["User_ID"] as string)) {
                    string user_id = Session["User_ID"] as string;
                    UserDatabaseManager UserDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
                    string[] valores_a_traer = new string[] { "Nombres",
                                                          "Apellidos",
                                                          "Correo",
                                                          "Contraseña",
                                                          "Celular",
                                                          "Cedula",
                                                          "Direccion",
                                                          "Ciudad",
                                                          "Edad",
                                                          "Tipo",
                                                          "FechaRegistro",
                                                          "ImagenPerfil"};
                    string[,] condiciones = new string[,] { { "ID", "=", "'" + user_id + "'" } };
                    string[] logic_condiciones = new string[] { "" };
                    DataSet user_data = UserDatabaseManager.ReadDatabaseRecord(valores_a_traer, condiciones, logic_condiciones);

                    ShowUserInformation(user_data);

                    ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

                    DataSet reservas_data = reservasDatabaseManager.ReadDatabaseRecord(
                        new string[] {"*"},
                        new string[,] { {"Cliente_ID","=","'"+ Session["User_ID"] as string + "'"} },
                        null,
                        "FechaFinalizacion",
                        "DESC"
                    );

                    ShowReservasInformation(reservas_data);
                }
                else
                {
                    Response.Redirect("iniciosesion.aspx");
                }
            }
        }

        protected void BtnGuardarInformacion_Click(object sender, EventArgs e)
        {

            string user_id = Session["User_ID"] as string;

            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            string[] valores_a_traer = new string[] {"Contraseña"};
            string[,] condiciones_primero = new string[,] { { "ID", "=", "'" + user_id + "'" } };
            string[] logic_condiciones_primero = new string[] { "" };
            DataSet user_data = userDatabaseManager.ReadDatabaseRecord(valores_a_traer, condiciones_primero, logic_condiciones_primero);

            string[,] valores_a_modificar;

            string name = Contraseña.Text;

            if (user_data.Tables[0].Rows[0]["Contraseña"].ToString() == Contraseña.Text)
            {
                valores_a_modificar = new string[,] { {"Nombres", "'"+Nombres.Text+"'"},
                                                                {"Apellidos", "'"+Apellidos.Text+"'"},
                                                                {"Celular", "'"+Celular.Text+"'"},
                                                                {"Cedula", "'"+Cedula.Text+"'"},
                                                                {"Direccion", "'"+Direccion.Text+"'"},
                                                                {"Ciudad", "'"+Cedula.Text+"'"},
                                                                {"Edad", "'"+Edad.Text+"'"},
                };
            }
            else
            {
                valores_a_modificar = new string[,] { {"Nombres", "'"+Nombres.Text+"'"},
                                                                {"Apellidos", "'"+Apellidos.Text+"'"},
                                                                {"Celular", "'"+Celular.Text+"'"},
                                                                {"Cedula", "'"+Cedula.Text+"'"},
                                                                {"Direccion", "'"+Direccion.Text+"'"},
                                                                {"Ciudad", "'"+Cedula.Text+"'"},
                                                                {"Edad", "'"+Edad.Text+"'"},
                                                                {"Contraseña", "'"+Contraseña.Text+"'"}
                };
            }

            string[,] condiciones = new string[,] { { "ID", "=", "'" + user_id + "'" } };
            string[] logic_condiciones = new string[] { "" };

            bool success = userDatabaseManager.UpdateDatabaseRecord(valores_a_modificar, condiciones, logic_condiciones);

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Los datos que ingresaste han sido actualizados", "Todo salio bien actualizando tu perfil, si no ves los cambios recarga la pagina", "success");
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "Los datos que ingresaste no han podido ser actualizados", "Este error pudo haber surgido por un problema con el servidor o tu solicitud", "danger");
            }
        }
        private void ShowUserInformation(DataSet data)
        {
            Nombres.Attributes["placeholder"] = data.Tables[0].Rows[0]["Nombres"].ToString();
            Nombres.Text = data.Tables[0].Rows[0]["Nombres"].ToString();
            Apellidos.Attributes["placeholder"] = data.Tables[0].Rows[0]["Apellidos"].ToString();
            Apellidos.Text = data.Tables[0].Rows[0]["Apellidos"].ToString();
            Celular.Attributes["placeholder"] = data.Tables[0].Rows[0]["Celular"].ToString();
            Celular.Text = data.Tables[0].Rows[0]["Celular"].ToString();
            Cedula.Attributes["placeholder"] = data.Tables[0].Rows[0]["Cedula"].ToString();
            Cedula.Text = data.Tables[0].Rows[0]["Cedula"].ToString();
            Edad.Attributes["placeholder"] = data.Tables[0].Rows[0]["Edad"].ToString();
            Edad.Text = data.Tables[0].Rows[0]["Edad"].ToString();
            Direccion.Attributes["placeholder"] = data.Tables[0].Rows[0]["Direccion"].ToString();
            Direccion.Text = data.Tables[0].Rows[0]["Direccion"].ToString();
            Ciudad.Attributes["placeholder"] = data.Tables[0].Rows[0]["Ciudad"].ToString();
            Ciudad.Text = data.Tables[0].Rows[0]["Ciudad"].ToString();
            Contraseña.Text = data.Tables[0].Rows[0]["Contraseña"].ToString();
            RContraseña.Text = data.Tables[0].Rows[0]["Contraseña"].ToString();

            info_panel_direccion.InnerText = data.Tables[0].Rows[0]["Direccion"].ToString();
            info_panel_correo.InnerText = data.Tables[0].Rows[0]["Correo"].ToString();
            info_panel_ciudad.InnerText = data.Tables[0].Rows[0]["Ciudad"].ToString();
            info_panel_cedula.InnerText = data.Tables[0].Rows[0]["Cedula"].ToString();
            info_panel_nombre.InnerText = data.Tables[0].Rows[0]["Nombres"].ToString() + " " + data.Tables[0].Rows[0]["Apellidos"].ToString();
            info_panel_image.Attributes["src"] = data.Tables[0].Rows[0]["ImagenPerfil"].ToString();
            info_panel_tipo.InnerText = data.Tables[0].Rows[0]["Tipo"].ToString();

            navbar_image_profile.Attributes["src"] = data.Tables[0].Rows[0]["ImagenPerfil"].ToString();

            DateTime FechaRegistro = (DateTime)data.Tables[0].Rows[0]["FechaRegistro"];
            CultureInfo culture = new System.Globalization.CultureInfo("es-ES");
            string fecha_registro = DateTime.Now.ToString("D", culture);
            info_panel_tiempo.InnerText = "Miembro desde "+fecha_registro;
        }

        private void ShowReservasInformation(DataSet reservas_data)
        {
            if (reservas_data.Tables[0].Rows.Count > 0)
            {
                bool reserva_vigente = false;

                foreach (DataRow row in reservas_data.Tables[0].Rows)
                {
                    if (Utilities.CheckIfReservaIsValid( DateTime.Parse(row["FechaFinalizacion"].ToString()) ))
                    {
                        reserva_vigente = true;
                    }
                }

                if (reserva_vigente)
                {
                    info_reserva_fechapago.InnerText = reservas_data.Tables[0].Rows[0]["FechaPago"].ToString();
                    info_reserva_fechainicio.InnerText = reservas_data.Tables[0].Rows[0]["FechaInicio"].ToString();
                    info_reserva_fechafinalizacion.InnerText = reservas_data.Tables[0].Rows[0]["FechaFinalizacion"].ToString();
                    info_reserva_valorpago.InnerText = Utilities.MoneyFormat(reservas_data.Tables[0].Rows[0]["ValorPago"].ToString());
                    

                }
                else
                {
                    info_reserva_seccion.InnerHtml = Utilities.GenerateBigAlarm("No hay reserva activa", "No hemos encontrado que poseas alguna reserva que se encuentre activa", "Si deseas ver las habitaciones disponibles, da <a href='habitaciones.aspx'>click aquí</a>", "warning");
                }
            }
            else
            {
                info_reserva_seccion.InnerHtml = Utilities.GenerateBigAlarm("No hay reserva activa", "No hemos encontrado que poseas alguna reserva que se encuentre activa", "Si deseas ver las habitaciones disponibles, da <a href='habitaciones.aspx'>click aquí</a>","warning");
            }
        }
    }
}