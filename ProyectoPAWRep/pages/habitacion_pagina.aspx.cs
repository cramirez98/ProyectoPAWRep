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
                    LlenarInformacionHabitacion(habitacion_data);
                }
                else
                {
                    //Response.Redirect("habitaciones.aspx");
                }
            }
            else
            {
                //Response.Redirect("habitaciones.aspx");
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
            foreach (XElement element in Fotos.Descendants("FotosHabitacion").Descendants("PaginaFotos").Nodes())
            {
                sources.Add(element.Attribute("src").Value);
            }

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

                PHabitacionConDescuento.Visible = true;
                PHabitacionSinDescuento.Visible = false;

                PHabitacionPrecioSinDescuento.InnerText = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString()).ToString("c0") + " COP";
                double precio_sin_descuento = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString());
                int porcentaje_descuento = int.Parse(data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString());
                double precio_con_descuento = precio_sin_descuento * (1 - (porcentaje_descuento/100.00));
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

    }
}