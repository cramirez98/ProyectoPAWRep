using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using ProyectoPAWRep.classes;

namespace ProyectoPAWRep.classes
{
    public class TestimoniosDatabaseManager : DatabaseManager
    {
        public TestimoniosDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }

        public bool AddDatabaseRecord(Testimonio testimonio)
        {
            string strSQL = "INSERT INTO " + base.Table + " ([ID] ,[Cliente_ID] ,[Comentario] ,[Puntaje] ,[Habitacion_ID]) VALUES " +
            "(NEWID(),'" +
            testimonio.Cliente_id + "','" +
            testimonio.Comentario + "'," +
            testimonio.Puntaje.ToString() + ",'" +
            testimonio.Habitacion_id + "')";

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