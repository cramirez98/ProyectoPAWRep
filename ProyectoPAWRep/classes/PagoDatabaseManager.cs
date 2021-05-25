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
    public class PagoDatabaseManager : DatabaseManager
    {
        public PagoDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }

        public bool AddDatabaseRecord(Pago pago)
        {
            string strSQL = "INSERT INTO " + base.Table + "([ID] ,[Nombres] ,[Apellidos] ,[Correo] ,[Cedula] ,[Direccion] ,[Telefono] ,[Ciudad] ,[Metodo] ,[ValorPago] ,[FechaPago] ,[Concepto]) VALUES " +
            "(NEWID(),'" +
            pago.Nombres + "','" +
            pago.Apellidos + "','" +
            pago.Correo + "','" +
            pago.Cedula + "','" +
            pago.Direccion + "','" +
            pago.Telefono + "','" +
            pago.Ciudad + "','" +
            pago.Metodo + "'," +
            pago.Valorpago + "," +
            "CURRENT_TIMESTAMP,'" +
            pago.Concepto + "')";

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