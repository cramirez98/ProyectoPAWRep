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
    public partial class ModificarDescuento : System.Web.UI.Page
    {
        public DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

        protected void Page_Load(object sender, EventArgs e)
        {
            string nombre_descuento_a_cargar = Request.QueryString["d"];
            if (!String.IsNullOrEmpty(nombre_descuento_a_cargar))
            {
                seleccionar_descuento.Visible = false;
                int fetched_data = descuentosDatabaseManager.CountFetchedData(
                    new string[] { "ID" },
                    new string[,] { { "Nombre", "=", "'"+ nombre_descuento_a_cargar + "'" } },
                    null
                );

                if (fetched_data > 0)
                {
                    if (!IsPostBack)
                    {
                        DataSet data = descuentosDatabaseManager.ReadDatabaseRecord(
                            new string[] { "*" },
                            new string[,] { { "Nombre", "=", "'" + nombre_descuento_a_cargar + "'" } },
                            null
                        );
                        CargarInformacionDescuento(data);
                    }
                }
                else
                {
                    Response.Redirect("VerDescuentos.aspx");
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    DataSet data = descuentosDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Nombre" },
                        null,
                        null
                    );
                    if(data.Tables[0].Rows.Count > 0)
                    {
                        MDescuentoNombreToLoad.DataTextField = data.Tables[0].Columns["Nombre"].ToString();
                        MDescuentoNombreToLoad.DataValueField = data.Tables[0].Columns["Nombre"].ToString();
                        MDescuentoNombreToLoad.DataSource = data.Tables[0];
                        MDescuentoNombreToLoad.DataBind();
                    }
                    else
                    {
                        MDescuentoNombreToLoad.Items.Clear();
                        MDescuentoNombreToLoad.Items.Add(new ListItem("No hay descuentos", "h"));
                        cargarinformaciondescuento.Visible = false;
                    }
                }

                seleccionar_descuento.Visible = true;
            }

            alertaspace.InnerHtml = "";
        }

        public void CargarInformacionDescuento(DataSet descuento_info)
        {
            BtnModificarDescuento.Attributes["class"] = "btn btn-primary btn-lg";
            MDescuentoFechaInicioHidden.Text = DateTime.Parse(descuento_info.Tables[0].Rows[0]["FechaInicio"].ToString()).ToString("yyy-MM-dd");
            MDescuentoFechaFinalizacionHidden.Text = DateTime.Parse(descuento_info.Tables[0].Rows[0]["FechaFinalizacion"].ToString()).ToString("yyy-MM-dd");

            MDescuentoNombre.Text = descuento_info.Tables[0].Rows[0]["Nombre"].ToString();
            MDescuentoPorcentaje.Text = descuento_info.Tables[0].Rows[0]["Porcentaje"].ToString();
        }

        protected void BtnModificarDescuento_ServerClick(object sender, EventArgs e)
        {
            bool success = descuentosDatabaseManager.UpdateDatabaseRecord(new string[,] {
                { "FechaInicio", "'" + MDescuentoFechaInicio.Text + "'" },
                { "FechaFinalizacion", "'"+MDescuentoFechaFinal.Text+"'" },
                {"Porcentaje", MDescuentoPorcentaje.Text}
                },
                new string[,] { {"Nombre","=","'"+MDescuentoNombre.Text+"'"} },
                null
            );

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "El descuento se ha modificado correctamente.", "Podras ver todos los descuentos en la seccion de ver descuentos.", "success");
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "El descuento no se ha modificado correctamente.", "Esto puede deberse a un error con el servidor.", "danger");
            }
        }

        protected void cargarinformaciondescuento_ServerClick(object sender, EventArgs e)
        {
            string nombre_descuento_a_cargar = MDescuentoNombreToLoad.SelectedValue.ToString();

            DataSet data = descuentosDatabaseManager.ReadDatabaseRecord(
                new string[] { "*" },
                new string[,] { { "Nombre", "=", "'"+ nombre_descuento_a_cargar + "'" } },
                null
            );
            CargarInformacionDescuento(data);
        }
    }
}