using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProyectoPAWRep.classes
{
    public class DescuentosDatabaseManager : DatabaseManager
    {
        public DescuentosDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }
    }
}