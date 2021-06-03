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
    public partial class adminaboutus : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                AboutUsDatabaseManager aboutUsDatabaseManager = new AboutUsDatabaseManager("SQLConnection", "[dbo].[AboutUs]");

                DataSet aboutus_data = aboutUsDatabaseManager.ReadDatabaseRecord(
                    new string[] { "*" },
                    null,
                    null
                );

                AboutUsHistoria.Text = aboutus_data.Tables[0].Rows[0]["Historia"].ToString();
                AboutUsMision.Text = aboutus_data.Tables[0].Rows[0]["Mision"].ToString();
                AboutUsVision.Text = aboutus_data.Tables[0].Rows[0]["Vision"].ToString();
                AboutUsPrincipios.Text = aboutus_data.Tables[0].Rows[0]["Principios"].ToString();
            }
        }

        protected void BtnAboutUsSubmit_ServerClick(object sender, EventArgs e)
        {
            AboutUsDatabaseManager aboutUsDatabaseManager = new AboutUsDatabaseManager("SQLConnection", "[dbo].[AboutUs]");

            bool success = aboutUsDatabaseManager.UpdateDatabaseRecord(
                new string[,] { 
                    { "Historia", "'" + AboutUsHistoria.Text + "'" },
                    {"Mision","'"+AboutUsMision.Text+"'"},
                    {"Vision","'"+AboutUsVision.Text+"'"},
                    {"Principios","'"+AboutUsPrincipios.Text+"'"}
                },
                null,
                null
            );

            if (success)
            {
                alertaspace.InnerHtml = Utilities.GenerateAlarm("<b>Exito</b> Se ha modificado satisfactoriamente la información", "success", true);
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateAlarm("<b>Error</b> No se ha modificado satisfactoriamente la información", "danger", true);
            }
        }
    }
}