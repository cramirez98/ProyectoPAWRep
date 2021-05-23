using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyectoPAWRep.classes;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
using System.Data.SqlClient;

namespace ProyectoPAWRep.pages
{
    public partial class HabitacionPagina : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string numero_habitacion_a_cargar = Request.QueryString["h"];
            if (!String.IsNullOrEmpty(numero_habitacion_a_cargar))
            {
                HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
                string[] valores_a_seleccionar = new string[] { "*" };
                string[,] condiciones = new string[,] { { "Numero", "=", numero_habitacion_a_cargar } };
                string[] logic = null;
                DataSet habitacion_data = habitacionesDatabaseManager.ReadDatabaseRecord(valores_a_seleccionar,condiciones,logic);

                if (habitacion_data.Tables[0].Rows.Count > 0)
                {
                    if (!IsPostBack)
                    {
                        LlenarInformacionHabitacion(habitacion_data);
                    }
                }
                else
                {
                    Response.Redirect("habitaciones.aspx");
                }
            }
            else
            {
                Response.Redirect("habitaciones.aspx");
            }
        }

        public void LlenarInformacionHabitacion(DataSet data) {

            PHabitacionNumero.InnerText = "Habitación " + data.Tables[0].Rows[0]["Numero"].ToString();
            PHabitacionTamaño.InnerText = data.Tables[0].Rows[0]["Tamaño"].ToString();
            PHabitacionTamaño2.InnerText = data.Tables[0].Rows[0]["Tamaño"].ToString();
            PHabitacionDescripcion.InnerText = data.Tables[0].Rows[0]["Descripcion"].ToString();
            PHabitacionDiscapacitados.InnerText = data.Tables[0].Rows[0]["BañosPDiscapacitadas"].ToString() == "1" ? "Si posee" : "No posee";
            PHabitacionMascota.InnerText = data.Tables[0].Rows[0]["Mascotas"].ToString() == "1" ? "Si posee" : "No posee";
            PHabitacionCamas.InnerText = data.Tables[0].Rows[0]["NumeroCamas"].ToString() + " camas";

            XDocument Fotos = XDocument.Parse(data.Tables[0].Rows[0]["Fotos"].ToString());

            List<string> sources = new List<string>();

            // Obtener las 3 fotos
            Utilities.GetImagesHabitacion(Fotos, out sources);

            PHabitacionFoto1.Attributes["src"] = sources[0];
            PHabitacionFoto2.Attributes["src"] = sources[1];
            PHabitacionFoto3.Attributes["src"] = sources[2];

            string descuento_id = data.Tables[0].Rows[0]["Descuento_ID"].ToString();

            if (!String.IsNullOrEmpty(descuento_id) && !String.IsNullOrWhiteSpace(descuento_id))
            {
                DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

                string[] valores_descuentos = new string[] { "*" };
                string[,] condiciones_descuentos = new string[,] { { "ID", "=", "'" + descuento_id + "'" } };
                string[] logic_descuentos = null;
                DataSet data_descuento = descuentosDatabaseManager.ReadDatabaseRecord(valores_descuentos,condiciones_descuentos,logic_descuentos);

                if (Utilities.CheckIfDiscountIsValid( DateTime.Parse(data_descuento.Tables[0].Rows[0]["FechaFinalizacion"].ToString()), DateTime.Parse(data_descuento.Tables[0].Rows[0]["FechaInicio"].ToString())))
                {
                    PHabitacionConDescuento.Visible = true;
                    PHabitacionSinDescuento.Visible = false;

                    PHabitacionPrecioSinDescuento.InnerText = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString()).ToString("c0") + " COP";
                    double precio_sin_descuento = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString());
                    int porcentaje_descuento = int.Parse(data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString());
                    double precio_con_descuento = precio_sin_descuento * (1 - (porcentaje_descuento / 100.00));
                    PHabitacionPrecioConDescuento.InnerText = precio_con_descuento.ToString("c0") + " COP";
                    PHabitacionDescuento.InnerText = porcentaje_descuento.ToString() + "%";
                }
                else
                {
                    PHabitacionConDescuento.Visible = false;
                    PHabitacionSinDescuento.Visible = true;
                    PHabitacionPrecioSinDescuento2.InnerText = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString()).ToString("c0") + " COP";
                }
            }
            else
            {
                PHabitacionConDescuento.Visible = false;
                PHabitacionSinDescuento.Visible = true;
                PHabitacionPrecioSinDescuento2.InnerText = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString()).ToString("c0") + " COP";
            }

            TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");

            DataSet testimonios_data = testimoniosDatabaseManager.ReadDatabaseRecord(
                new string[] { "*" },
                new string[,] { { "Habitacion_ID", "=", "'" + data.Tables[0].Rows[0]["ID"] + "'" } },
                null
            );

            if (testimonios_data.Tables[0].Rows.Count > 0)
            {
                double promedio = Utilities.CalculateTestimonialsMean(testimonios_data);
                double width_star = (promedio / 5) * 100;
                string width_star_s = width_star.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                PHabitacionNumOpiniones.InnerText = testimonios_data.Tables[0].Rows.Count.ToString() + " opiniones";
                PHabitacionPorcentajeEstrellas.Style["width"] = width_star_s + "%";
                PHabitacionPromedioEstrellas.InnerText = promedio.ToString();

                seccion_comentarios_load.InnerHtml = Utilities.GenerateTestimoniosCards(testimonios_data);
            }
            else
            {
                PHabitacionNumOpiniones.InnerText = "No hay opiniones";
                PHabitacionPorcentajeEstrellas.Style["width"] = "0%";
                PHabitacionPromedioEstrellas.InnerText = "0";

                seccion_comentarios_load.InnerHtml = "<div class='fw-bold ff-oswaldo text-uppercase text-muted mt-2 fc-2'>No hay testimonios</div>";
            }

            if (!String.IsNullOrEmpty(Session["User_ID"] as string))
            {
                ReservasDataBaseManager reservasDataBaseManager = new ReservasDataBaseManager("SQLConnection", "[dbo].[Reservas]");

                bool exists_reserva = reservasDataBaseManager.CheckIfExists(
                    new string[] { "*" },
                    new string[,] {
                        { "Cliente_ID", "=", "'" + Session["User_ID"] as string + "'" },
                        { "Habitacion_ID", "=", "'" + data.Tables[0].Rows[0]["ID"] + "'" },
                        { "Cancelada", "!=", "1" },
                    },
                    new string[] { "AND", "AND" }
                );

                bool exists_testimonio = testimoniosDatabaseManager.CheckIfExists(
                    new string[] { "ID" },
                    new string[,] {
                        {"Cliente_ID","=","'"+Session["User_ID"] as string+"'"},
                        {"Habitacion_ID","=","'"+data.Tables[0].Rows[0]["ID"]+"'"}
                    },
                    new string[] { "AND", "AND" }
                );

                if (exists_reserva)
                {
                    if (!exists_testimonio)
                    {
                        seccion_dejar_comentario.Visible = true;
                    }
                    else
                    {
                        seccion_dejar_comentario_formulario.InnerHtml = Utilities.GenerateAlarm("<i class='fas fa-info-circle'></i> Ya ingresaste una reseña.", "warning", false);
                        seccion_dejar_comentario_formulario.Style["margin-top"] = "5pt";
                    }
                }
                else
                {
                    seccion_dejar_comentario.Visible = false;
                }
            }
            else
            {
                seccion_dejar_comentario.Visible = false;
            }
        }

        protected void EnviarComentarios_ServerClick(object sender, EventArgs e)
        {
            string num_habitacion = Request.QueryString["h"];
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DataSet data_habitacion = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] { "ID" },
                new string[,] { { "Numero", "=", num_habitacion } },
                null
            );

            if (!String.IsNullOrEmpty(Session["User_ID"] as string) && data_habitacion.Tables[0].Rows.Count > 0)
            {
                Testimonio testimonio = new Testimonio(Session["User_ID"] as string, CComentarioDescripcion.Text, int.Parse(CCComentarioRating.Text), data_habitacion.Tables[0].Rows[0]["ID"].ToString());

                TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");

                bool success = testimoniosDatabaseManager.AddDatabaseRecord(testimonio);

                if (success)
                {
                    alertaspace_comentario.InnerHtml = Utilities.GenerateAlarm("<i class='fas fa-check-circle'></i> Se ha enviado de forma satisfactoria tu reseña!, si no puedes verla, actualiza la pagina.","success",true);
                    alertaspace_comentario.Style["margin-top"] = "5pt";
                    seccion_dejar_comentario_formulario.Visible = false;
                }
                else
                {
                    alertaspace_comentario.InnerHtml = Utilities.GenerateAlarm("<i class='fas fa-exclamation-circle'></i> Ha habido un error y no se pudo enviar tu reseña.", "danger", true);
                }
            }

        }
    }
}