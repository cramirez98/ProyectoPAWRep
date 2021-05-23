using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyectoPAWRep.classes;

namespace ProyectoPAWRep.pages
{
    public partial class habitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            int total_habitaciones = habitacionesDatabaseManager.CountFetchedData(
                new string[] { "*" },
                null,
                null
            );

            int numero_por_pagina = 5;

            double division = (double)total_habitaciones / numero_por_pagina;
            int numero_paginas;
            if(division <= 1)
            {
                numero_paginas = 1;
            }
            else
            {
                numero_paginas = (int)Math.Ceiling(division);
            }

            if(numero_paginas == 1)
            {
                DataSet habitaciones = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] { "*" },
                null,
                null
                );

                habitaciones_cartas_lugar.InnerHtml = Utilities.GenerateHabitacionCards(habitaciones, true);
            }
            else
            {
                
            }
        }
    }
}