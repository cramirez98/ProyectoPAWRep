using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPAWRep.classes;
using System.Globalization;
using System.Data;

namespace ProyectoPAWRep.pages
{
    public partial class CrearDescuento : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCrearDescuento_Click(object sender, EventArgs e)
        {
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");
            int fetched_data = descuentosDatabaseManager.CountFetchedData(new string[] { "ID" }, new string[,] { { "Nombre", "=", "'" + CDescuentoNombre.Text + "'" } }, null);
            if (int.Parse(CDescuentoPorcentaje.Text)<100 && int.Parse(CDescuentoPorcentaje.Text) > 1 && fetched_data == 0)
            {
                Val3Por.Visible = false;
                Val2DescNombre.Visible = false;
                DateTime fechainicio = DateTime.Parse(CDescuentoFechaInicio.Text);
                DateTime fechafinalizacion = DateTime.Parse(CDescuentoFechaFinal.Text);
                Descuento descuento = new Descuento(int.Parse(CDescuentoPorcentaje.Text), fechainicio, fechafinalizacion, CDescuentoNombre.Text);

                bool success = descuentosDatabaseManager.AddDatabaseRecord(descuento);

                if (success)
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha creado el descuento de forma correcta.", "Puedes ver los descuentos en la seccion de ver descuentos", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se ha creado el descuento de forma correcta.", "Esto puede deberse a un problema con el servidor", "danger");
                }
            }
            else
            {
                if (int.Parse(CDescuentoPorcentaje.Text) > 100 || int.Parse(CDescuentoPorcentaje.Text) < 1)
                {
                    Val3Por.Visible = true;
                }
                if (fetched_data > 0)
                {
                    Val2DescNombre.Visible = true;
                }
            }
        }
    }
}