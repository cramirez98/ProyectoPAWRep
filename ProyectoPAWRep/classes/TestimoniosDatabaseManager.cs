using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ProyectoPAWRep.classes
{
    public class TestimoniosDatabaseManager : DatabaseManager
    {
        public TestimoniosDatabaseManager(string connectionString, string table) : base(connectionString, table)
        {
        }
    }
}