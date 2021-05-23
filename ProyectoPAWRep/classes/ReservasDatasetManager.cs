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
    public class ReservasDatasetManager : DatabaseManager
    {
        public ReservasDatasetManager(string connectionString, string table) : base(connectionString, table)
        {
        }

        public bool AddDatabaseRecord(Reserva reserva)
        {
            string strSQL = "INSERT INTO " + base.Table + "([ID] ,[Habitacion_ID] ,[Cliente_ID] ,[FechaInicio] ,[FechaFinalizacion] ,[ValorPago] ,[FechaPago] ,[Cancelada]) VALUES " +
            "(NEWID(),'" +
            reserva.Habitacion_id + "','" +
            reserva.Cliente_id + "','" +
            reserva.Fechainicio.ToString("yyy-MM-dd") + "','" +
            reserva.Fechafinalizacion.ToString("yyy-MM-dd") + "'," +
            reserva.Valorpago + "," +
            "CURRENT_TIMESTAMP," +
            "0)";

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