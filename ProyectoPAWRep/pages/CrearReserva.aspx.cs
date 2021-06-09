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
    public partial class CrearReserva : System.Web.UI.Page
    {
        public ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
        public HabitacionesDatabaseManager HabitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
        public UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataSet habitaciones_data = HabitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null);

                DataSet usuarios_data = userDatabaseManager.ReadDatabaseRecord(new string[] {"*"}, null,null);

                CReservaCliente.DataTextField = usuarios_data.Tables[0].Columns["Nombres"].ToString();
                CReservaCliente.DataValueField = usuarios_data.Tables[0].Columns["Correo"].ToString();
                CReservaCliente.DataSource = usuarios_data.Tables[0];
                CReservaCliente.DataBind();

                CReservaHabitacion.DataTextField = habitaciones_data.Tables[0].Columns["Numero"].ToString();
                CReservaHabitacion.DataValueField = habitaciones_data.Tables[0].Columns["Numero"].ToString();
                CReservaHabitacion.DataSource = habitaciones_data.Tables[0];
                CReservaHabitacion.DataBind();

                if (habitaciones_data.Tables[0].Rows.Count == 0 || usuarios_data.Tables[0].Rows.Count == 0)
                {
                    BtnCrearReserva.Attributes["class"] = "btn btn-primary btn-lg disabled";
                }
            }
        }

        protected void BtnCrearReserva_Click(object sender, EventArgs e)
        {
            bool habitacion_disponible;
            bool cliente_sin_reserva;

            string[] fechas = CReservaFechas.Text.Split(new string[] { " - " }, StringSplitOptions.None);

            DateTime fechaInicio = DateTime.Parse(fechas[0]);
            DateTime fechaFinalizacion = DateTime.Parse(fechas[1]);

            int num_noches = (fechaFinalizacion - fechaInicio).Days;

            string habitacion_id = HabitacionesDatabaseManager.GetHabitacionIDByNumber(CReservaHabitacion.SelectedValue.ToString());

            DataSet reservas_data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "Habitacion_ID", "=", "'" + habitacion_id + "'" },{"Cancelada","=","0"} }, new string[] { "AND" });

            if (reservas_data.Tables[0].Rows.Count > 0)
            {
                habitacion_disponible = Utilities.CheckIfHabitacionEstaDisponible(reservas_data, fechaInicio, fechaFinalizacion);
            }
            else
            {
                habitacion_disponible = true;
            }

            string usuario_id = userDatabaseManager.GetIDByCorreo("'" + CReservaCliente.SelectedValue.ToString() + "'");
            reservas_data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "Cliente_ID", "=", "'" + usuario_id + "'" }, { "Cancelada", "=", "0" } }, new string[]{"AND"});

            if (reservas_data.Tables[0].Rows.Count > 0)
            {
                cliente_sin_reserva = Utilities.CheckIfHabitacionEstaDisponible(reservas_data, fechaInicio, fechaFinalizacion);
            }
            else
            {
                cliente_sin_reserva = true;
            }

            if (!cliente_sin_reserva || !habitacion_disponible)
            {
                ValCliente.Visible = !cliente_sin_reserva ? true : false;
                ValHabitacion.Visible = !habitacion_disponible ? true : false;
                alertaspace.InnerHtml = "";
            }
            else
            {
                DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

                ValCliente.Visible = ValHabitacion.Visible = false;

                DataSet habitaciones_data = HabitacionesDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "ID", "=", "'" + habitacion_id + "'" } }, null);
                bool posee_descuento = false;
                double precio_total;
                double precio_por_noche_base = double.Parse(habitaciones_data.Tables[0].Rows[0]["Precio"].ToString());
                DataSet descuentos_data;
                if (!habitaciones_data.Tables[0].Rows[0]["Descuento_ID"].ToString().Equals(""))
                {
                    descuentos_data = descuentosDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "ID", "=", "'" + habitaciones_data.Tables[0].Rows[0]["Descuento_ID"] + "'" } }, null);
                    if (descuentos_data.Tables[0].Rows.Count > 0)
                    {
                        posee_descuento = Utilities.CheckIfDiscountIsValid(DateTime.Parse(descuentos_data.Tables[0].Rows[0]["FechaFinalizacion"].ToString()), DateTime.Parse(descuentos_data.Tables[0].Rows[0]["FechaInicio"].ToString()));
                    }

                    if (posee_descuento)
                    {
                        double precio_por_noche_con_descuento = Utilities.CalculateDiscountPrice(precio_por_noche_base, int.Parse(descuentos_data.Tables[0].Rows[0]["Porcentaje"].ToString()));
                        precio_total = precio_por_noche_con_descuento * num_noches * (int.Parse(CReservaNumeroPersonas.Text));
                    }
                    else
                    {
                        precio_total = precio_por_noche_base * num_noches * (int.Parse(CReservaNumeroPersonas.Text));
                    }
                }
                else
                {
                    precio_total = precio_por_noche_base * num_noches * (int.Parse(CReservaNumeroPersonas.Text));
                }

                Reserva reserva = new Reserva(habitacion_id, usuario_id, fechaInicio, fechaFinalizacion, precio_total, int.Parse(CReservaNumeroPersonas.Text));
                bool success = reservasDatabaseManager.AddDatabaseRecord(reserva);

                if (success)
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha creado la reserva de forma satisfactoria.", "Podras revisar la reserva en la seccion de reservas.", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se ha creado la reserva de forma satisfactoria.", "Esto puede deberse a un error con el servidor.", "danger");
                }
            }
        }
    }
}