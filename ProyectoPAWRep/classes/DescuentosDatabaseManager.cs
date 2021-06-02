using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Globalization;

namespace ProyectoPAWRep.classes
{
    public class DescuentosDatabaseManager : DatabaseManager
    {
        public DescuentosDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }

        public bool AddDatabaseRecord(Descuento descuento)
        {
            string strSQL = "INSERT INTO " + base.Table + "([ID] ,[Porcentaje] ,[FechaInicio] ,[FechaFinalizacion] ,[Nombre]) VALUES " +
            "(NEWID()," +
            descuento.Porcentaje + ",'" +
            descuento.FechaInicio.ToString("yyy-MM-dd") + "','" +
            descuento.FechaFinalizacion.ToString("yyy-MM-dd") + "','" +
            descuento.Nombre + "')";


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

        public string GetDescuentoIDByName(string name)
        {
            DataSet data = ReadDatabaseRecord(new string[] { "ID" }, new string[,] { { "Nombre", "=", "'"+ name + "'" } }, null);
            return data.Tables[0].Rows[0]["ID"].ToString();
        }
    }
}