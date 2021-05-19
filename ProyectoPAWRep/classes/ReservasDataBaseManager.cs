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
    public class ReservasDataBaseManager : DatabaseManager
    {
        public ReservasDataBaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }
    }
}