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
using System.Web.Services;
using System.Web.Script.Serialization;

namespace ProyectoPAWRep.pages
{
    public partial class usuario1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Contraseña.Attributes["type"] = "password";
            RContraseña.Attributes["type"] = "password";
            // Cargar informacion
            if (!String.IsNullOrEmpty(Session["User_ID"] as string))
            {
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

                    

                ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

                DataSet reservas_data = reservasDatabaseManager.ReadDatabaseRecord(
                    new string[] { "*" },
                    new string[,] { { "Cliente_ID", "=", "'" + Session["User_ID"] as string + "'" } },
                    null,
                    "FechaFinalizacion",
                    "DESC"
                );

                if (!IsPostBack)
                {
                    ShowReservasInformation(reservas_data);
                    ShowUserInformation(user_data);
                }
            }
            else
            {
                Response.Redirect("iniciosesion.aspx");
            }
        }

        protected void BtnGuardarInformacion_Click(object sender, EventArgs e)
        {

            string user_id = Session["User_ID"] as string;

            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            string[] valores_a_traer = new string[] { "Contraseña" };
            string[,] condiciones_primero = new string[,] { { "ID", "=", "'" + user_id + "'" } };
            string[] logic_condiciones_primero = new string[] { "" };
            DataSet user_data = userDatabaseManager.ReadDatabaseRecord(valores_a_traer, condiciones_primero, logic_condiciones_primero);

            string[,] valores_a_modificar;

            bool modificar_foto_perfil = false;
            string direccion_imagen = "../img/profile/default-user.png";

            if ((FotoPerfil.PostedFile != null) && (FotoPerfil.PostedFile.ContentLength > 0))
            {
                modificar_foto_perfil = true;
                string nombre_image_encriptada = Utilities.ComputarSHA128(user_id);

                string fn_icono_antes = System.IO.Path.GetFileName(FotoPerfil.PostedFile.FileName);
                string[] string_dividido = fn_icono_antes.Split('.');
                string fn_final_icon = nombre_image_encriptada + "." + string_dividido[1];
                string SaveLocation_icon = Server.MapPath(@"\img\profile") + "\\" + fn_final_icon;

                FotoPerfil.PostedFile.SaveAs(SaveLocation_icon);

                direccion_imagen = "../img/profile/" + fn_final_icon;
            }

            if (user_data.Tables[0].Rows[0]["Contraseña"].ToString() == Contraseña.Text)
            {
                if (modificar_foto_perfil)
                {
                    valores_a_modificar = new string[,] { {"Nombres", "'"+Nombres.Text+"'"},
                                                                {"Apellidos", "'"+Apellidos.Text+"'"},
                                                                {"Celular", "'"+Celular.Text+"'"},
                                                                {"Cedula", "'"+Cedula.Text+"'"},
                                                                {"Direccion", "'"+Direccion.Text+"'"},
                                                                {"Ciudad", "'"+Cedula.Text+"'"},
                                                                {"Edad", "'"+Edad.Text+"'"},
                                                                {"ImagenPerfil", "'"+direccion_imagen+"'"}
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
                    };
                }
            }
            else
            {
                if (modificar_foto_perfil)
                {
                    valores_a_modificar = new string[,] { {"Nombres", "'"+Nombres.Text+"'"},
                                                                {"Apellidos", "'"+Apellidos.Text+"'"},
                                                                {"Celular", "'"+Celular.Text+"'"},
                                                                {"Cedula", "'"+Cedula.Text+"'"},
                                                                {"Direccion", "'"+Direccion.Text+"'"},
                                                                {"Ciudad", "'"+Cedula.Text+"'"},
                                                                {"Edad", "'"+Edad.Text+"'"},
                                                                {"Contraseña", "'"+Utilities.ComputarSHA256(Contraseña.Text)+"'"},
                                                                {"ImagenPerfil", "'"+direccion_imagen+"'"}
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
                                                                {"Contraseña", "'"+Utilities.ComputarSHA256(Contraseña.Text)+"'"}
                    };
                }
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
            ImagePerfilPaginaModificar.Attributes["src"] = data.Tables[0].Rows[0]["ImagenPerfil"].ToString();
            info_panel_tipo.InnerText = data.Tables[0].Rows[0]["Tipo"].ToString();


            DateTime FechaRegistro = (DateTime)data.Tables[0].Rows[0]["FechaRegistro"];
            CultureInfo culture = new System.Globalization.CultureInfo("es-ES");
            string fecha_registro = FechaRegistro.ToString("D", culture);
            info_panel_tiempo.InnerText = "Miembro desde " + fecha_registro;
        }

        private void ShowReservasInformation(DataSet reservas_data)
        {
            CultureInfo culture = new System.Globalization.CultureInfo("es-ES");
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            if (reservas_data.Tables[0].Rows.Count > 0)
            {
                bool reserva_vigente = false;

                int index_reserva_valida = 0;
                foreach (DataRow row in reservas_data.Tables[0].Rows)
                {
                    if (Utilities.CheckIfReservaIsValid(DateTime.Parse(row["FechaFinalizacion"].ToString())) && row["Cancelada"].ToString().Equals("0"))
                    {
                        reserva_vigente = true;
                        break;
                    }
                    index_reserva_valida++;
                }
                if (reserva_vigente)
                {
                    info_reserva_fechapago.InnerText = DateTime.Parse(reservas_data.Tables[0].Rows[index_reserva_valida]["FechaPago"].ToString()).ToString("yyy-MM-dd");
                    info_reserva_fechainicio.InnerText = DateTime.Parse(reservas_data.Tables[0].Rows[index_reserva_valida]["FechaInicio"].ToString()).ToString("yyy-MM-dd");
                    info_reserva_fechafinalizacion.InnerText = DateTime.Parse(reservas_data.Tables[0].Rows[index_reserva_valida]["FechaFinalizacion"].ToString()).ToString("yyy/MM/dd");
                    info_reserva_valorpago.InnerText = Utilities.MoneyFormat(reservas_data.Tables[0].Rows[index_reserva_valida]["ValorPago"].ToString());

                    DataSet habitacion_reserva = habitacionesDatabaseManager.ReadDatabaseRecord(
                        new string[] {"*"},
                        new string[,] { {"ID","=","'"+ reservas_data.Tables[0].Rows[index_reserva_valida]["Habitacion_ID"].ToString() + "'"} },
                        null
                    );

                    info_reserva_habitacion_numero.InnerText = habitacion_reserva.Tables[0].Rows[0]["Numero"].ToString();
                    info_reserva_habitacion_numerocamas.InnerText = habitacion_reserva.Tables[0].Rows[0]["NumeroCamas"].ToString();
                    info_reserva_habitacion_tamaño.InnerText = habitacion_reserva.Tables[0].Rows[0]["Tamaño"].ToString();
                    info_reserva_habitacion_bañodiscapacitados.InnerText = habitacion_reserva.Tables[0].Rows[0]["BañosPDiscapacitadas"].ToString().Equals("1") ? "Si" : "No";
                    info_reserva_habitacion_mascotas.InnerText = habitacion_reserva.Tables[0].Rows[0]["Mascotas"].ToString().Equals("1") ? "Si" : "No";

                    if(( DateTime.Parse(reservas_data.Tables[0].Rows[index_reserva_valida]["FechaInicio"].ToString()) - DateTime.Now ).Days < 1)
                    {
                        info_reserva_botoncancelar.Attributes.Add("disabled", "disabled");
                        info_reserva_alertacancelacion.Visible = true;
                    }
                    else
                    {
                        info_reserva_botoncancelar.Attributes.Remove("disabled");
                        info_reserva_alertacancelacion.Visible = false;
                    }
                }
                else
                {
                    info_reserva_seccion.InnerHtml = Utilities.GenerateBigAlarm("No hay reserva activa", "No hemos encontrado que poseas alguna reserva que se encuentre activa.", "Si deseas ver las habitaciones disponibles, da <a href='habitaciones.aspx'>click aquí</a>", "warning", false);
                }

                ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

                DataSet reservas_data_historial = reservasDatabaseManager.ReadDatabaseRecord(
                    new string[] { "*" },
                    new string[,] { { "Cliente_ID", "=", "'" + Session["User_ID"] as string + "'" } },
                    null,
                    "FechaPago",
                    "DESC"
                );

                reservas_table_info.InnerHtml = Utilities.GenerateReservasHistory(reservas_data_historial);
                
            }
            else
            {
                info_reserva_seccion.InnerHtml = Utilities.GenerateBigAlarm("No hay reserva activa", "No hemos encontrado que poseas alguna reserva que se encuentre activa", "Si deseas ver las habitaciones disponibles, da <a href='habitaciones.aspx'>click aquí</a>", "warning", false);
            }
        }

        protected void info_reserva_botoncancelar_ServerClick(object sender, EventArgs e)
        {
            string numero_habitacion = info_reserva_habitacion_numero.InnerText;
            string fecha_inicio = info_reserva_fechainicio.InnerText;
            string fecha_finalizacion = info_reserva_fechafinalizacion.InnerText;

            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");

            DataSet habitacion_data = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] {"ID"},
                new string[,] { { "Numero", "=", numero_habitacion } },
                null
            );

            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            bool success = reservasDatabaseManager.UpdateDatabaseRecord(
                new string[,] { {"Cancelada","1"} },
                new string[,] { 
                    {"Habitacion_ID","=","'"+habitacion_data.Tables[0].Rows[0]["ID"]+"'"},
                    {"FechaInicio","=","'"+fecha_inicio+"'"},
                    {"FechaFinalizacion","=","'"+fecha_finalizacion+"'"}
                },
                new string[] {"AND", "AND"}
            );

            if (success)
            {
                info_reserva_alertspace.InnerHtml = Utilities.GenerateAlarm("<b>Exito!</b> Se ha cancelado correctamente tu reserva.", "success", false);
                info_reserva_seccion.InnerHtml = "";
            }
            else
            {
                info_reserva_alertspace.InnerHtml = Utilities.GenerateAlarm("<b>Error!</b> Hubo un error cancelando correctamente tu reserva.", "danger", true);
            }
        }

        [WebMethod]
        public static string generarmodal(int numerohabitacion)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");

            DataSet data = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] {"*"},
                new string[,] { {"Numero","=",numerohabitacion.ToString()} },
                null
            );

            return Utilities.GenerateHabitacionModal(data);
        }
    }
}