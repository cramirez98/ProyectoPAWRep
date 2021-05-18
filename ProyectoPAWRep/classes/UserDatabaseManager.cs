using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using System.Security.Cryptography;

namespace ProyectoPAWRep.classes
{
    public class UserDatabaseManager
    {
        private SqlConnection sqlConnection;
        private string table;
        
        public UserDatabaseManager(string connectionString, string table)
        {
            sqlConnection = new SqlConnection(ConfigurationManager.ConnectionStrings[connectionString].ConnectionString);
            this.table = table;
        }

        public bool AddDatabaseRecord(Usuario usuario)
        {
            string contraseña_encriptada = ComputeSha256Hash(usuario.Contraseña);
            string strSQL = "INSERT INTO " + table + "([ID],[Nombres],[Apellidos],[Correo],[Contraseña],[Celular],[Cedula],[Direccion],[Ciudad],[Edad],[Tipo],[FechaRegistro]) VALUES " +
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
            "',CURRENT_TIMESTAMP)";

            var cmd = new SqlCommand(strSQL, sqlConnection);

            try
            {
                sqlConnection.Open();
                cmd.ExecuteNonQuery();
                sqlConnection.Close();
                return true;
            }
            catch (Exception er)
            {
                return false;
            }
        }
        public string RemoveDatabaseRecord(List<string> id_datos)
        {
            return "Prueba";
        }
        public DataSet ReadDatabaseRecord()
        {
            DataSet data = new DataSet();
            return data;
        }
        public string UpdateDatabaseRecord(List<Usuario> usuarios)
        {
            return "hola";
        }
        public string UpdateDatabaseRecord(Usuario usuario)
        {
            return "hola";
        }
        string ComputeSha256Hash(string rawData)
        {
            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            // Convert byte array to a string   
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
    }
}