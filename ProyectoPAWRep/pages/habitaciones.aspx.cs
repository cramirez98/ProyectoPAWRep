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

            int elementos_por_pagina = 1;

            double division = (double)total_habitaciones / elementos_por_pagina;
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
            else
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
        }
        [WebMethod]
        public static string SayHello(PaginationObject paginationobj)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            string response;
            if (paginationobj.AdvanceSearch)
            {
                response = "boton_advanceSearch";
            }
            else
            {
                if (paginationobj.Changed_order)
                {
                    response = "botones_orden";
                }
                else
                {
                    int offcet = (paginationobj.Pagina_a_cargar - 1) * paginationobj.Elementos_por_pagina;
                    int fetchnext = paginationobj.Elementos_por_pagina;

                    string orderby = paginationobj.Order_by;
                    string direction = paginationobj.Direction;

                    DataSet habitaciones = habitacionesDatabaseManager.ReadDatabaseRecord(
                      new string[] { "*" },
                      new string[,] { { "Ocupada", "=", "0" } },
                      null,
                      "Precio",
                      "ASC",
                      offcet,
                      fetchnext
                    );

                    response = Utilities.GenerateHabitacionCards(habitaciones);
    
                    response += "||@@||" + Utilities.GeneratePagination(paginationobj.Numero_paginas, paginationobj.Elementos_por_pagina, paginationobj.Pagina_a_cargar);
                }
            }

            return response;
        }
    }
}