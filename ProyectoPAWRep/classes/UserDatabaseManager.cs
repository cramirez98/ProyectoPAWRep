using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;
using ProyectoPAWRep.classes;

namespace ProyectoPAWRep.classes
{
    public class UserDatabaseManager : DatabaseManager
    {       
        public UserDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }

        public bool AddDatabaseRecord(Usuario usuario)
        {
            string profilepicture_directory = "../img/profile/default-user.png";
            string contraseña_encriptada = Utilities.ComputarSHA256(usuario.Contraseña);
            string strSQL = "INSERT INTO " + base.Table + "([ID],[Nombres],[Apellidos],[Correo],[Contraseña],[Celular],[Cedula],[Direccion],[Ciudad],[Edad],[Tipo],[FechaRegistro],[ImagenPerfil]) VALUES " +
            "(NEWID(),'" +
            usuario.Nombres + "','" +
            usuario.Apellidos + "','" + 
            usuario.Correo + "','" +
            contraseña_encriptada + "','" +
            usuario.Celular + "','" +
            usuario.Cedula + "','" +
            usuario.Direccion + "','" +
            usuario.Ciudad + "'," +
            usuario.Edad.ToString() +",'"+
            usuario.Tipo+
            "',CURRENT_TIMESTAMP,"+
            "'"+ profilepicture_directory + "')";

            var cmd = new SqlCommand(strSQL, base.SqlConnection);

            try
            {
                base.SqlConnection.Open();
                cmd.ExecuteNonQuery();
                base.SqlConnection.Close();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }

        public string GetIDByCorreo(string correo)
        {
            DataSet data = ReadDatabaseRecord(new string[] { "ID" }, new string[,] { { "Correo", "=", correo } }, null);
            return data.Tables[0].Rows[0]["ID"].ToString();
        }
    }
}