using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Text;
using ProyectoPAWRep.classes;

namespace ProyectoPAWRep.classes
{
    public class HabitacionesDatabaseManager : DatabaseManager
    {
        public HabitacionesDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {

        }

        public bool AddDatabaseRecord(Habitacion habitacion)
        {
            string strSQL = "INSERT INTO " + base.Table + "([ID] ,[Numero] ,[Descripcion] ,[Fotos] ,[Precio] ,[Tamaño] ,[NumeroCamas] ,[Mascotas] ,[BañosPDiscapacitadas] ,[Descuento_ID]) VALUES " +
            "(NEWID()," +
            habitacion.Numero + ",'" +
            habitacion.Descripcion + "',N'" +
            habitacion.Fotos.ToString() + "'," +
            habitacion.Precios + ",'" +
            habitacion.Tamaño + "'," +
            habitacion.Camas + "," +
            habitacion.Mascotas + "," +
            habitacion.Bañosdiscapacitados + ",'" +
            habitacion.Descuento_id + "')";


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

        public string GetHabitacionIDByNumber(string numero)
        {
            DataSet data = base.ReadDatabaseRecord(new string[] { "ID" }, new string[,] { { "Numero", "=", numero } },null);
            return data.Tables[0].Rows[0]["ID"].ToString();
        }
    }
}