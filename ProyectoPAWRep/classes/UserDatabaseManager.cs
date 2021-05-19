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
            string profilepicture_directory = "../img/profile/default-user.png";
            string contraseña_encriptada = Utilities.ComputarSHA256(usuario.Contraseña);
            string strSQL = "INSERT INTO " + table + "([ID],[Nombres],[Apellidos],[Correo],[Contraseña],[Celular],[Cedula],[Direccion],[Ciudad],[Edad],[Tipo],[FechaRegistro],[ImagenPerfil]) VALUES " +
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
        public DataSet ReadDatabaseRecord(string[] values, string[,] conditions, string[] logic_conditionals, string orderby = null, string direction = null)
        {
            string formatted_values;
            string formatted_conditions;
            string formatted_order = " ORDER BY ";

            // Darle formato a los valores a traer de la base de datos
            formatted_values = FormatValuestoSelect(values);

            // Darle formato a las condiciones a traer de la base de datos
            formatted_conditions = FormatConditiontoSelect(conditions, logic_conditionals);

            // Darle formato al orden en el que se traera la informacion
            if (!String.IsNullOrEmpty(orderby))
            {
                formatted_order += orderby + " " + direction;
            }
            else
            {
                formatted_order = "";
            }

            string strSQL = "SELECT " + formatted_values + " FROM " + table + formatted_conditions + formatted_order;

            var cmd = new SqlCommand(strSQL, sqlConnection);

            var ds = new DataSet();
            var da = new SqlDataAdapter(cmd);
            sqlConnection.Open();
            da.Fill(ds, "tb_Usuarios");
            sqlConnection.Close();

            return ds;
        }
        public string UpdateDatabaseRecord(List<Usuario> usuarios)
        {
            return "hola";
        }
        public string UpdateDatabaseRecord(Usuario usuario)
        {
            return "hola";
        }
        string FormatValuestoSelect(string[] values)
        {
            string formatted_values = "";

            if (values.Length > 1)
            {
                for (int i = 0; i < values.Length; i++)
                {
                    if (i < values.Length-1)
                    {
                        formatted_values += "[" + values[i] + "],";
                    }
                    else
                    {
                        formatted_values += "[" + values[i] + "]";
                    }
                }
            }
            else if (values.Length == 1)
            {
                formatted_values += values[0] == "*" ? "*" : "[" + values[0] + "]";
            }
            else
            {
                formatted_values += "*";
            }
            return formatted_values;
        }
        string FormatConditiontoSelect(string[,] conditions, string[] logic_conditionals)
        {
            string formatted_conditions = " WHERE ";

            if (conditions.GetLength(0)>1)
            {
                for (int i = 0; i < conditions.GetLength(0); i++)
                {
                    if (i < conditions.GetLength(0)-1)
                    {
                        formatted_conditions += conditions[i,0] + conditions[i, 1] + conditions[i,2] + " "+ logic_conditionals[i] + " ";
                    }
                    else
                    {
                        formatted_conditions += conditions[i,0] + conditions[i, 1] + conditions[i,2];
                    }
                }
            }
            else if (conditions.GetLength(0) == 1)
            {
                formatted_conditions += conditions[0, 0] + conditions[0, 1] + conditions[0, 2];
            }
            else
            {
                formatted_conditions = "";
            }
            return formatted_conditions;
        }
    }
}