using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class AboutUsDatabaseManager : DatabaseManager
    {
        public AboutUsDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }

        public bool AddDatabaseRecord(string historia, string mision, string vision, string principios)
        {
            string strSQL = "INSERT INTO " + base.Table + "([ID],[Historia],[Mision],[Vision],[Principios]) VALUES " +
            "(NEWID(),'" +
            historia + "','" +
            mision + "','" +
            vision + "','" +
            principios + "')";

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

    }
}