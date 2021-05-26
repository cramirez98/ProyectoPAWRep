using ProyectoPAWRep.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace ProyectoPAWRep.pages
{
    public partial class inicio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Session["User_ID"] as string))
            {
                UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
                string[] datos_a_seleccionar = new string[] { "ImagenPerfil", "Tipo" };
                string[,] condiciones = new string[,] { { "ID", "=", "'" + Session["User_ID"] as string + "'" } };
                string[] logic = null;

                DataSet user_data = userDatabaseManager.ReadDatabaseRecord(datos_a_seleccionar, condiciones, logic);

                if (user_data.Tables[0].Rows[0]["Tipo"].ToString().Equals("Cliente"))
                {
                    navbar_changing.InnerHtml = Utilities.GenerateUserDropdown(user_data.Tables[0].Rows[0]["ImagenPerfil"].ToString());
                }
                else
                {
                    navbar_changing.InnerHtml = Utilities.GenerateAdminDropdown(user_data.Tables[0].Rows[0]["ImagenPerfil"].ToString());
                }
            }
            else
            {
                navbar_changing.InnerHtml = Utilities.GenerateNormalDropdown();
            }

            AboutUsDatabaseManager aboutUsDatabaseManager = new AboutUsDatabaseManager("SQLConnection", "[dbo].[AboutUs]");

            DataSet aboutusinfo = aboutUsDatabaseManager.ReadDatabaseRecord(
                new string[] {"*"},
                null,
                null
            );

            if(aboutusinfo.Tables[0].Rows.Count > 0)
            {
                aboutushistoria.InnerText = aboutusinfo.Tables[0].Rows[0]["Historia"].ToString();
                aboutusmisionvision.InnerHtml = "<b>Mision: </b>" + aboutusinfo.Tables[0].Rows[0]["Mision"].ToString() + "<br>" + "<b>Vision: </b>" + aboutusinfo.Tables[0].Rows[0]["Vision"].ToString();
                aboutusprincipios.InnerText = aboutusinfo.Tables[0].Rows[0]["Principios"].ToString();
            }
        }
    }
}