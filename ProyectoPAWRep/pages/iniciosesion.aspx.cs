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
    public partial class iniciosesion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnLogin_Click(object sender, EventArgs e)
        {
            string contraseña_encriptada = Utilities.ComputarSHA256(Contraseña.Text);
            UserDatabaseManager UserDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            string[] valores_a_traer = new string[] { "ID" };
            string[,] condiciones = new string[,] { { "Correo", "=", "'"+Correo.Text+"'" },{"Contraseña", "=", "'"+ contraseña_encriptada + "'"} };
            string[] logic_condiciones = new string[] {"AND"};
            DataSet data = UserDatabaseManager.ReadDatabaseRecord(valores_a_traer, condiciones, logic_condiciones);

            if (data.Tables[0].Rows.Count > 0)
            {
                string uid = data.Tables[0].Rows[0]["ID"].ToString();
                Session["User_ID"] = uid;
            }
            else
            {
                alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "El correo electronico o la contraseña no son correctos", "Revisa la informacion ingresada", "danger");
            }
        }
    }
}