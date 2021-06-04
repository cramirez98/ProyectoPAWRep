using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPAWRep.classes;
using System.Data;
using System.Web.Services;

namespace ProyectoPAWRep.pages
{
    public partial class VerUsuarios : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].Usuarios");

            DataSet user_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, null, null, "FechaRegistro", "DESC");

            ver_usuarios_table_info.InnerHtml = Utilities.GenerateUsersTable(user_data);
        }
        [WebMethod]
        public static void EliminarUsuario(string usuario_id)
        {
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            userDatabaseManager.RemoveDatabaseRecord(new string[,] { { "ID", "=", "'" + usuario_id + "'" } }, null);

            reservasDatabaseManager.RemoveDatabaseRecord(new string[,] { { "Cliente_ID", "=", "'" + usuario_id + "'" } }, null);
        }
    }
}