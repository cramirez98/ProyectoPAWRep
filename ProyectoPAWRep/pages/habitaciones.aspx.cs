using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyectoPAWRep.classes;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace ProyectoPAWRep.pages
{
    public partial class habitaciones : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            int total_habitaciones = habitacionesDatabaseManager.CountFetchedData(
                new string[] { "*" },
                new string[,] { {"Ocupada","=","0"} },
                null
            );

            int elementos_por_pagina = 2;
            int numero_paginas = Utilities.CalculateNumberOfPages(total_habitaciones, elementos_por_pagina);

            if(numero_paginas == 1)
            {
                DataSet habitaciones = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] { "*" },
                new string[,] { { "Ocupada", "=", "0" } },
                null,
                "Precio",
                "ASC",
                0,
                0
                );

                habitaciones_cartas_lugar.InnerHtml = Utilities.GenerateHabitacionCards(habitaciones);

                seccion_paginacion.InnerHtml = Utilities.GeneratePagination(10, elementos_por_pagina);
            }
            else if(numero_paginas > 1)
            {
                DataSet habitaciones = habitacionesDatabaseManager.ReadDatabaseRecord(
               new string[] { "*" },
               new string[,] { { "Ocupada", "=", "0" } },
               null,
               "Precio",
               "ASC",
               0,
               elementos_por_pagina
               );

                habitaciones_cartas_lugar.InnerHtml = Utilities.GenerateHabitacionCards(habitaciones);

                seccion_paginacion.InnerHtml = Utilities.GeneratePagination(numero_paginas, elementos_por_pagina);
            }
            else
            {
                habitaciones_cartas_lugar.InnerHtml = Utilities.GenerateAlarm("<i class='fas fa-exclamation-circle'></i> No hay habitaciones para mostrar.", "secondary", false);
            }
        }
        [WebMethod]
        public static string ActualizarInformacion(PaginationObject paginationobj)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            string response = "";
            DataSet data_sorted = new DataSet();
            DataSet habitaciones = new DataSet();

            int numero_paginas;
            int offcet = (paginationobj.Pagina_a_cargar - 1) * paginationobj.Elementos_por_pagina;
            int fetchTop = paginationobj.Elementos_por_pagina;
            if (paginationobj.AdvanceSearch)
            {
                habitaciones = habitacionesDatabaseManager.ReadDatabaseRecord(
                    new string[] { "*" },
                    new string[,] { { "Ocupada", "=", "0" } },
                    null
                );

                offcet = 0;
                numero_paginas = Utilities.CalculateNumberOfPages(habitaciones.Tables[0].Rows.Count, paginationobj.Elementos_por_pagina);
            }
            else
            {
                habitaciones = habitacionesDatabaseManager.ReadDatabaseRecord(
                    new string[] { "*" },
                    new string[,] { { "Ocupada", "=", "0" } },
                    null
                );
            }

            string orderby = paginationobj.Order_by;
            string direction = paginationobj.Direction;
            if (orderby == "Precio")
            {
                data_sorted = Utilities.OrderByPrice(habitaciones, direction);
            }
            else if(orderby == "NumeroCamas")
            {

            }
            else
            {

            }


            if (paginationobj.Changed_order)
            {
                offcet = 0;
                response = Utilities.GenerateHabitacionCards(Utilities.ManuallyOffcet(data_sorted, offcet, paginationobj.Elementos_por_pagina));

                response += "<---CambioDePagina--->" + Utilities.GeneratePagination(paginationobj.Numero_paginas, paginationobj.Elementos_por_pagina, 1);
            }
            else
            {

            }
  

            return response;
        }
    }
}