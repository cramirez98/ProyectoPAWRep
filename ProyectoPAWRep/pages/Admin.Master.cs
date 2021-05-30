using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyectoPAWRep.classes;

namespace ProyectoPAWRep.pages
{
    public partial class Admin1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Session["User_ID"] as string))
            {
                UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");

                DataSet user_data = userDatabaseManager.ReadDatabaseRecord(
                    new string[] {"Tipo","ImagenPerfil"}, 
                    new string[,]{ {"ID","=","'"+ Session["User_ID"] as string + "'"} },
                    null
                );

                if (user_data.Tables[0].Rows[0]["Tipo"].ToString() == "Administrador")
                {
                    imagen_perfil_load.Attributes["src"] = user_data.Tables[0].Rows[0]["ImagenPerfil"].ToString();
                }
                else
                {
                    Response.Redirect("usuario.aspx");
                }
            }
            else
            {
                Response.Redirect("iniciosesion.aspx");
            }
        }
    }
}