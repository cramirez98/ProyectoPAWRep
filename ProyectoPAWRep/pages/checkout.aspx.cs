using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyectoPAWRep.classes;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace ProyectoPAWRep.pages
{
    public partial class checkout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Request.Form["formnumerohabitacion"]) && !String.IsNullOrEmpty(Request.Form["formfechainiciofinalizacion"]) && !String.IsNullOrEmpty(Request.Form["formnumeropersonas"]) && !String.IsNullOrEmpty(Session["User_ID"] as string))
            {
                UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
                HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
                DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

                DataSet data_usuario = userDatabaseManager.ReadDatabaseRecord(
                    new string[] {"*"},
                    new string[,] { {"ID", "=", "'"+ Session["User_ID"] as string + "'"} },
                    null
                );

                DataSet data_habitacion = habitacionesDatabaseManager.ReadDatabaseRecord(
                    new string[] {"*"},
                    new string[,] { {"Numero","=","'"+ Request.Form["formnumerohabitacion"] + "'"} },
                    null
                );

                DataSet data_descuento = new DataSet();
                if (!String.IsNullOrEmpty(data_habitacion.Tables[0].Rows[0]["Descuento_ID"].ToString()))
                {
                    data_descuento = descuentosDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Porcentaje", "FechaFinalizacion", "FechaInicio" },
                        new string[,] { { "ID", "=", "'" + data_habitacion.Tables[0].Rows[0]["Descuento_ID"] + "'" } },
                        null
                    );
                }
                else
                {
                    data_descuento.Tables.Add(new DataTable());
                }

                LlenarInformacion(data_usuario, data_habitacion, data_descuento);
            }
            else
            {
                if (!IsPostBack)
                {
                    Response.Redirect("habitaciones.aspx");
                }
            }
        }

        public void LlenarInformacion(DataSet data_usuario, DataSet data_habitacion, DataSet data_descuento)
        {
            CheckoutNombres.Text = data_usuario.Tables[0].Rows[0]["Nombres"].ToString();
            CheckoutApellidos.Text = data_usuario.Tables[0].Rows[0]["Apellidos"].ToString();
            CheckoutCorreo.Text = data_usuario.Tables[0].Rows[0]["Correo"].ToString();
            CheckoutDireccion.Text = data_usuario.Tables[0].Rows[0]["Direccion"].ToString();
            CheckoutCedula.Text = data_usuario.Tables[0].Rows[0]["Cedula"].ToString();
            CheckoutCiudad.Text = data_usuario.Tables[0].Rows[0]["Ciudad"].ToString();
            CheckoutTelefono.Text = data_usuario.Tables[0].Rows[0]["Celular"].ToString();

            CheckoutNumeroHabitacion.Attributes["data-numeroh"] = data_habitacion.Tables[0].Rows[0]["Numero"].ToString();
            CheckoutNumeroHabitacion.InnerText = CheckoutNumeroHabitacion2.InnerText = CheckoutNumeroHabitacion3.InnerText = "Habitación " + data_habitacion.Tables[0].Rows[0]["Numero"].ToString();
            CheckoutSize.InnerText = "Habitación " + data_habitacion.Tables[0].Rows[0]["Tamaño"].ToString();
            CheckoutNumeroCamas.InnerText = data_habitacion.Tables[0].Rows[0]["NumeroCamas"].ToString() + " camas";
            CheckoutBañosDiscapacitados.InnerText = data_habitacion.Tables[0].Rows[0]["BañosPDiscapacitadas"].ToString() == "1" ? "Con baños para discapacitados" : "Con baños para discapacitados";
            CheckoutMascotas.InnerText = data_habitacion.Tables[0].Rows[0]["Mascotas"].ToString() == "1" ? "Con posibilidad de mascota" : "Sin posibilidad de mascota";

            CheckoutPrecio1.InnerText = CheckoutPrecio2.InnerText = Utilities.MoneyFormat(data_habitacion.Tables[0].Rows[0]["Precio"].ToString());

            int numero_personas = int.Parse(Request.Form["formnumeropersonas"]);

            string[] fechas = Request.Form["formfechainiciofinalizacion"].Split(new string[] { " - " }, StringSplitOptions.None);
            DateTime fecha_inicio = DateTime.Parse(fechas[0]);
            DateTime fecha_finalizacion = DateTime.Parse(fechas[1]);

            int total_days = (fecha_finalizacion - fecha_inicio).Days;

            double precio_base;
            if (data_descuento.Tables[0].Rows.Count > 0)
            {
                if ( Utilities.CheckIfDiscountIsValid( DateTime.Parse(data_descuento.Tables[0].Rows[0]["FechaFinalizacion"].ToString()), DateTime.Parse(data_descuento.Tables[0].Rows[0]["FechaInicio"].ToString())) )
                {
                    CheckoutDescuento.InnerText = "Descuento " + data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString() + "%";
                    CheckoutValorDescuento.InnerText = "-" + Utilities.MoneyFormat((double.Parse(data_habitacion.Tables[0].Rows[0]["Precio"].ToString()) * double.Parse(data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString())/100.00).ToString());
                    double valor_con_descuento = Utilities.CalculateDiscountPrice(double.Parse(data_habitacion.Tables[0].Rows[0]["Precio"].ToString()), int.Parse(data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString()));
                    CheckoutPrecioConDescuento.InnerText = Utilities.MoneyFormat(valor_con_descuento.ToString());
                    precio_base = valor_con_descuento;
                }
                else
                {
                    seccion_precio_descuento.Visible = false;
                    precio_base = double.Parse(data_habitacion.Tables[0].Rows[0]["Precio"].ToString());
                }
            }
            else
            {
                precio_base = double.Parse(data_habitacion.Tables[0].Rows[0]["Precio"].ToString());
                seccion_precio_descuento.Visible = false;
            }

            double precio_total = (precio_base * total_days) * numero_personas;

            CheckoutPrecioTotal.InnerText = Utilities.MoneyFormat(precio_total.ToString());
            CheckoutNumeroHabitacion.Attributes["data-precioh"] = precio_total.ToString();
            CheckoutNumeroHabitacion.Attributes["data-fechainicio"] = fecha_inicio.ToString("yyyy-MM-dd");
            CheckoutNumeroHabitacion.Attributes["data-fechafinalizacion"] = fecha_finalizacion.ToString("yyyy-MM-dd");
            CheckoutNumeroHabitacion.Attributes["data-npersonas"] = numero_personas.ToString();
            CheckoutNumeroHabitacion.Attributes["data-correou"] = data_usuario.Tables[0].Rows[0]["Correo"].ToString();

            CheckoutNumeroNoches.InnerText = total_days.ToString() + " noches y " + numero_personas.ToString() + " personas";
        }

        [WebMethod]
        public static string Procesarpago(PaymentObject paymentobj)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DataSet habitacion_data = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] {"ID"},
                new string[,] { {"Numero","=", paymentobj.Numerohabitacion.ToString()} },
                null
            );

            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            DataSet usuario_data = userDatabaseManager.ReadDatabaseRecord(
                new string[] {"ID"},
                new string[,] { {"Correo","=","'"+ paymentobj.Correou+"'"} },
                null
            );
            bool succes_r = true;
            Reserva reserva = new Reserva(habitacion_data.Tables[0].Rows[0]["ID"].ToString(), usuario_data.Tables[0].Rows[0]["ID"].ToString(), DateTime.Parse(paymentobj.Fechainicio), DateTime.Parse(paymentobj.Fechafinalizacion), paymentobj.Valorpago, paymentobj.Numeropersonas);
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
            succes_r = reservasDatabaseManager.AddDatabaseRecord(reserva);

            Pago pago = new Pago(paymentobj.Nombres, paymentobj.Apellidos, paymentobj.Correo, paymentobj.Telefono, paymentobj.Cedula, paymentobj.Ciudad, paymentobj.Direccion, paymentobj.Valorpago, paymentobj.Metododepago, "Reserva habitación " + paymentobj.Numerohabitacion.ToString());
            PagoDatabaseManager pagoDatabaseManager = new PagoDatabaseManager("SQLConnection", "[dbo].[Pagos]");

            bool succes_p = pagoDatabaseManager.AddDatabaseRecord(pago);

            if(succes_p && succes_r)
            {
                return Utilities.GenerateBigAlarm("Exito!", "Se ha procesado correctamente tu reserva", "Si quieres ver tus reservas activas, da <a href='usuario.aspx'>click aquí</a>", "success");
            }
            else
            {
                return Utilities.GenerateBigAlarm("Error!", "Se ha producido un error procesando correctamente tu reserva", "Intentalo mas tarde", "error");
            }
        }
    }
}