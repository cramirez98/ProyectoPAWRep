using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoPAWRep.pages
{
    public partial class cerrarsesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!String.IsNullOrEmpty(Session["User_ID"] as string))
            {
                Session.Remove("User_ID");
                Response.Redirect("inicio.aspx");
            }
            else
            {
                Response.Redirect("iniciosesion.aspx");
            }
        }
    }
}