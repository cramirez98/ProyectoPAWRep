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
        public int elementos_por_pagina = 2;
        public static int elementos_por_pagina_web_method = 2;
        protected void Page_Load(object sender, EventArgs e)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            int total_habitaciones = habitacionesDatabaseManager.CountFetchedData(
                new string[] { "*" },
                new string[,] { {"Ocupada","=","0"} },
                null
            );
            int numero_paginas = Utilities.CalculateNumberOfPages(total_habitaciones, this.elementos_por_pagina);

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

                seccion_paginacion.InnerHtml = Utilities.GeneratePagination(0, elementos_por_pagina);
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
            HabitacionesDatabaseManager habitacionesDatabase = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DataSet habitaciones_data;
            DataSet habitaciones_data_ordered = new DataSet();
            int offset = (paginationobj.Pagina_a_cargar - 1) * paginationobj.Elementos_por_pagina;
            int fetchtop = paginationobj.Elementos_por_pagina;
            string direccion = paginationobj.Direction;
            string orderby = paginationobj.Order_by;
            string response = "";

            if (paginationobj.AdvanceSearch)
            {

                habitaciones_data = habitacionesDatabase.ReadDatabaseRecord(
                    new string[] {"*"},
                    null,
                    null
                );

                habitaciones_data = Utilities.FilterData(habitaciones_data, paginationobj);

                habitaciones_data_ordered = new DataSet();
                switch (orderby)
                {
                    case "Precio":
                        habitaciones_data_ordered = Utilities.OrderByPrice(habitaciones_data, direccion);
                        break;
                    case "Puntaje":
                        habitaciones_data_ordered = Utilities.OrderByPuntaje(habitaciones_data, direccion);
                        break;
                    case "NumeroCamas":
                        habitaciones_data_ordered = Utilities.OrderByNumeroCamas(habitaciones_data, direccion);
                        break;
                    default:
                        habitaciones_data_ordered = habitaciones_data;
                        break;
                }
                int numero_paginas = Utilities.CalculateNumberOfPages(habitaciones_data_ordered.Tables[0].Rows.Count, elementos_por_pagina_web_method);
                if (paginationobj.Changed_order || paginationobj.Changedsearchterms)
                {
                    if (numero_paginas > 0)
                    {
                        response += Utilities.GenerateHabitacionCards(Utilities.ManuallyOffcet(habitaciones_data_ordered, 0, elementos_por_pagina_web_method));
                    }
                    else
                    {
                        response += Utilities.GenerateAlarm("<i class='fas fa-exclamation-circle'></i> No hay habitaciones para mostrar.", "secondary", false);
                    }
                    response += "<---CambioDePagina--->" + Utilities.GeneratePagination(numero_paginas, fetchtop, 0);
                }
                else
                {
                    if (numero_paginas > 0)
                    {
                        response += Utilities.GenerateHabitacionCards(Utilities.ManuallyOffcet(habitaciones_data_ordered, offset, fetchtop));
                    }
                    else
                    {
                        response += Utilities.GenerateAlarm("<i class='fas fa-exclamation-circle'></i> No hay habitaciones para mostrar.", "secondary", false);
                    }
                    response += "<---CambioDePagina--->" + Utilities.GeneratePagination(paginationobj.Numero_paginas, fetchtop, paginationobj.Pagina_a_cargar);
                }
            }
            else
            {
                if (orderby.Equals("NumeroCamas"))
                {
                    habitaciones_data_ordered = habitacionesDatabase.ReadDatabaseRecord(
                        new string[] { "*" },
                        null,
                        null,
                        orderby,
                        direccion
                    );
                }
                else
                {
                    habitaciones_data = habitacionesDatabase.ReadDatabaseRecord(
                        new string[] { "*" },
                        null,
                        null
                    );
                    habitaciones_data_ordered = new DataSet();
                    switch (orderby)
                    {
                        case "Precio":
                            habitaciones_data_ordered = Utilities.OrderByPrice(habitaciones_data, direccion);
                            break;
                        case "Puntaje":
                            habitaciones_data_ordered = Utilities.OrderByPuntaje(habitaciones_data, direccion);
                            break;
                        default:
                            habitaciones_data_ordered = habitaciones_data;
                            break;
                    }
                }
                int numero_paginas = paginationobj.Numero_paginas > 0 ? paginationobj.Numero_paginas : Utilities.CalculateNumberOfPages(habitaciones_data_ordered.Tables[0].Rows.Count, elementos_por_pagina_web_method);
                if (paginationobj.Changed_order)
                {
                    response += Utilities.GenerateHabitacionCards(Utilities.ManuallyOffcet(habitaciones_data_ordered, 0, elementos_por_pagina_web_method));
                    response += "<---CambioDePagina--->" + Utilities.GeneratePagination(numero_paginas, elementos_por_pagina_web_method);
                }
                else
                {
                    response += Utilities.GenerateHabitacionCards(Utilities.ManuallyOffcet(habitaciones_data_ordered, offset, elementos_por_pagina_web_method));
                    response += "<---CambioDePagina--->" + Utilities.GeneratePagination(paginationobj.Numero_paginas, elementos_por_pagina_web_method, paginationobj.Pagina_a_cargar);
                }
            }
            return response;
        }
    }
}