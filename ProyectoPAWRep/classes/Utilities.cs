using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Security.Cryptography;
using System.Data;
using System.Xml.Linq;

namespace ProyectoPAWRep.classes
{
    public static class Utilities
    {
        public static string ComputarSHA256(string rawData)
        {
            SHA256 sha256Hash = SHA256.Create();

            byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
  
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public static string ComputarSHA128(string rawData)
        {
            SHA1 sha128Hash = SHA1.Create();

            byte[] bytes = sha128Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2"));
            }
            return builder.ToString();
        }
        public static string GenerateBigAlarm(string title, string body, string footer, string alarm_type, bool button = true)
        {
            string alarm;
            switch (alarm_type)
            {
                case "success":
                    alarm = "<div class='alert alert-success alert-dismissible fade show' role='alert'>";
                    break;
                case "danger":
                    alarm = "<div class='alert alert-danger alert-dismissible fade show' role='alert'>";
                    break;
                case "primary":
                    alarm = "<div class='alert alert-primary alert-dismissible fade show' role='alert'>";
                    break;
                case "secondary":
                    alarm = "<div class='alert alert-secondary alert-dismissible fade show' role='alert'>";
                    break;
                case "warning":
                    alarm = "<div class='alert alert-warning alert-dismissible fade show' role='alert'>";
                    break;
                default:
                    alarm = "<div class='alert alert-dark alert-dismissible fade show' role='alert'>";
                    break;
            }
            alarm += "<h4 class='alert-heading'>"+title+"</h4>";
            alarm += "<p>"+body+"</p><hr>";
            alarm += "<p class='mb-0'>"+footer+ "</p>";

            if (button)
            {
                alarm += "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";
            }
            else
            {
                alarm += "</div>";
            }

            return alarm;
        }
        public static string GenerateAlarm(string body, string alarm_type, bool button)
        {
            string alarm;
            switch (alarm_type)
            {
                case "success":
                    alarm = "<div class='alert alert-success d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "danger":
                    alarm = "<div class='alert alert-danger d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "primary":
                    alarm = "<div class='alert alert-primary d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "secondary":
                    alarm = "<div class='alert alert-secondary d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                case "warning":
                    alarm = "<div class='alert alert-warning d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
                default:
                    alarm = "<div class='alert alert-dark d-flex align-items-center alert-dismissible fade show' role='alert'>";
                    break;
            }
            alarm += "<div>" + body + "</div>";
            if (button)
            {
                alarm += "<button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button> </div>";
            }
            else
            {
                alarm += "</div>";
            }

            return alarm;
        }
        public static string GenerateUserDropdown(string profilepic_src)
        {
            string userDropdown = "<li class='nav-item dropdown'><a class='nav-link dropdown-toggle' href='#' id='navbarDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>";
            userDropdown += "<img src='"+profilepic_src+ "' class='rounded-circle' alt='...' width='50' height='50'>";
            userDropdown += "</a><ul class='dropdown-menu dropdown-menu-lg-end' aria-labelledby='navbarDropdown'>";
            userDropdown += "<li><a class='dropdown-item' href='usuario.aspx'>Perfil</a></li><li><a class='dropdown-item' href='cerrarsesion.aspx'>Cerrar sesion</a></li>";
            userDropdown += "</ul></li>";

            return userDropdown;
        }

        public static string GenerateAdminDropdown(string profilepic_src)
        {
            string userDropdown = "<li class='nav-item dropdown'><a class='nav-link dropdown-toggle' href='#' id='navbarDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>";
            userDropdown += "<img src='" + profilepic_src + "' class='rounded-circle' alt='...' width='50' height='50'>";
            userDropdown += "</a><ul class='dropdown-menu dropdown-menu-lg-end' aria-labelledby='navbarDropdown'>";
            userDropdown += "<li><a class='dropdown-item' href='adminpanel.aspx'>Panel de administrador</a></li><li><a class='dropdown-item' href='usuario.aspx'>Perfil</a></li><li><a class='dropdown-item' href='cerrarsesion.aspx'>Cerrar sesion</a></li>";
            userDropdown += "</ul></li>";

            return userDropdown;
        }
        public static string GenerateNormalDropdown()
        {
            string userDropdown = "<li class='nav-item dropdown'><a class='nav-link dropdown-toggle' href='#' id='navbarDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>";
            userDropdown += "<span class='fas fa-user'></span>";
            userDropdown += "</a><ul class='dropdown-menu dropdown-menu-lg-end' aria-labelledby='navbarDropdown'>";
            userDropdown += "<li><a class='dropdown-item' href='iniciosesion.aspx'>Iniciar sesion</a></li><li><a class='dropdown-item' href='registro.aspx'>Registrarse</a></li>";
            userDropdown += "</ul></li>";

            return userDropdown;
        }

        public static string GenerateReservasHistory(DataSet reservas_data)
        {
            string table_rows = "";
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DataSet habitacion_data = new DataSet();
            int contador = 1;
            if (reservas_data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in reservas_data.Tables[0].Rows)
                {
                    table_rows += "<tr>";
                    habitacion_data = habitacionesDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Numero" },
                        new string[,] { { "ID", "=", "'" + row["Habitacion_ID"] + "'" } },
                        null
                    );

                    table_rows += "<th scope='row'>" + contador + "</th>";
                    table_rows += "<td>" + DateTime.Parse(row["FechaInicio"].ToString()).ToString("yyy/MM/dd") + "</td>";
                    table_rows += "<td>" + DateTime.Parse(row["FechaFinalizacion"].ToString()).ToString("yyy/MM/dd") + "</td>";
                    table_rows += "<td>" + DateTime.Parse(row["FechaPago"].ToString()).ToString("yyy/MM/dd") + "</td>";
                    table_rows += "<td>" + MoneyFormat(row["ValorPago"].ToString()) + "</td>";
                    table_rows += "<td class='text-center'>" + row["NumeroPersonas"] + "</td>";

                    if (row["Cancelada"].ToString().Equals("1"))
                    {
                        table_rows += "<td><span class='badge bg-danger'>Cancelada</span></td>";
                    }
                    else
                    {
                        if (CheckIfReservaIsValid(DateTime.Parse(row["FechaFinalizacion"].ToString())))
                        {
                            table_rows += "<td><span class='badge bg-success'>Activa</span></td>";
                        }
                        else
                        {
                            table_rows += "<td><span class='badge bg-secondary'>Vencida</span></td>";
                        }
                    }

                    table_rows += "<td><button type='button' name='CargarDatosModal' class='btn btn-outline-primary round-edges-20' data-bs-toggle='modal' data-numeroh='" + habitacion_data.Tables[0].Rows[0]["Numero"].ToString() + "' data-bs-target='#exampleModal'> <i class='fa fa-eye' aria-hidden='true'></i> Ver habitación </button></td>";
                    table_rows += "</tr>";
                    contador++;
                }
            }
            else
            {
                table_rows += "<tr><td colspan='8'>No hay reservas para mostrar</td></tr>";
            }
            return table_rows;
        }

        public static string GenerateHabitacionModal(DataSet data)
        {
            string modal_part1 = "";
            string modal_part2 = "";

            List<string> sources = new List<string>();

            GetImagesHabitacion(XDocument.Parse(data.Tables[0].Rows[0]["Fotos"].ToString()), out sources);

            modal_part1 += "<div class='carousel-item active'> <img src='" + sources[0] + "' class='d-block w-100' alt='...'> </div>";
            modal_part1 += "<div class='carousel-item'> <img src='" + sources[1] + "' class='d-block w-100' alt='...'> </div>";
            modal_part1 += "<div class='carousel-item'> <img src='" + sources[2] + "' class='d-block w-100' alt='...'> </div>";

            modal_part2 += "<div class='col-sm-4 mb-2'> <div class='usuario-info-label-sidebar text-start'>Habitación:</div> </div>";
            modal_part2 += "<div class='col-sm-8 mb-2'> <div class='usuario-info-text-sidebar text-start'>"+data.Tables[0].Rows[0]["Numero"]+"</div> </div>";

            modal_part2 += "<div class='col-sm-4 mb-2'> <div class='usuario-info-label-sidebar text-start'>Tamaño de habitacion:</div> </div>";
            modal_part2 += "<div class='col-sm-8 mb-2'> <div class='usuario-info-text-sidebar text-start'>" + data.Tables[0].Rows[0]["Tamaño"] + "</div> </div>";

            modal_part2 += "<div class='col-sm-4 mb-2'> <div class='usuario-info-label-sidebar text-start'>Numero de camas de la habitacion:</div> </div>";
            modal_part2 += "<div class='col-sm-8 mb-2'> <div class='usuario-info-text-sidebar text-start'>" + data.Tables[0].Rows[0]["NumeroCamas"] + "</div> </div>";

            modal_part2 += "<div class='col-sm-4 mb-2'> <div class='usuario-info-label-sidebar text-start'>Baño para discapacitados:</div> </div>";
            modal_part2 += "<div class='col-sm-8 mb-2'> <div class='usuario-info-text-sidebar text-start'>"+(data.Tables[0].Rows[0]["BañosPDiscapacitadas"].ToString().Equals("1") ? "Si" : "No") +"</div> </div>";

            modal_part2 += "<div class='col-sm-4 mb-2'> <div class='usuario-info-label-sidebar text-start'>Admite mascotas:</div> </div>";
            modal_part2 += "<div class='col-sm-8 mb-2'> <div class='usuario-info-text-sidebar text-start'>" + (data.Tables[0].Rows[0]["Mascotas"].ToString().Equals("1") ? "Si" : "No") + "</div> </div>";

            return modal_part1 + "<--CambioDeInformacion-->" + modal_part2;
        }
        public static string GenerateHabitacionCards(DataSet data)
        {
            string cards = "";

            if(data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {

                    cards += "<div class='habitacion-card mb-2'> <div class='container-fluid'> <div class='row g-1'> <div class='col-xxl-3 text-center text-xxl-start'>";
                    cards += "<img src='" + GetIconPhoto(XDocument.Parse(row["Fotos"].ToString())) + "' class='img-fluid rounded-3 img-thumbnail' alt='...' width='210' height='210'>";
                    cards += "</div> <div class='col-xxl-9'> <div class='row g-0'> <div class='col-lg-8 col-sm-8'> <div class='d-flex flex-column'> <div class='d-flex'>";

                    TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");

                    DataSet testimonios_data = testimoniosDatabaseManager.ReadDatabaseRecord(
                        new string[] { "*" },
                        new string[,] { { "Habitacion_ID", "=", "'" + row["ID"] + "'" } },
                        null
                    );
                    if (testimonios_data.Tables[0].Rows.Count > 0)
                    {
                        double promedio = CalculateTestimonialsMean(testimonios_data);
                        double width_star = (promedio / 5) * 100;
                        string width_star_s = width_star.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                        cards += "<div class='habitacion-puntaje'>" + testimonios_data.Tables[0].Rows.Count.ToString() + " opiniones <div class='stars-outer'> <div class='stars-inner' style='width: " + width_star_s + "%;'></div> </div> </div> <div class='fs-12 fc-gray fw-bold ff-oswaldo'>" + promedio.ToString() + "</div> </div>";
                    }
                    else
                    {
                        cards += "<div class='habitacion-puntaje'>No hay opiniones <div class='stars-outer'> <div class='stars-inner' style='width: " + "0" + "%;'></div> </div> </div> <div class='fs-12 fc-gray fw-bold ff-oswaldo'>" + "0" + "</div> </div>";
                    }

                    cards += "<div class='habitacion-titulo'>Habitación " + row["Numero"].ToString() + "</div> <div class='habitacion-subtitulo'>" + row["Tamaño"].ToString() + "</div> </div> </div> <div class='col-lg-4 col-sm-4 mb-2'> ";

                    // Agregar precio con descuento o sin descuento
                    if (row["Descuento_ID"].ToString() == "")
                    {
                        cards += "<div class='d-flex text-start text-lg-end flex-column'> <div class='habitacion-info-precio'> " + MoneyFormat(row["Precio"].ToString()) + " </div> <div class='habitacion-precio-desc'>Por noche</div> </div>";
                    }
                    else
                    {
                        DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

                        DataSet data_descuento = descuentosDatabaseManager.ReadDatabaseRecord(
                            new string[] { "*" },
                            new string[,] { { "ID", "=", "'" + row["Descuento_ID"] + "'" } },
                            null
                        );

                        bool validDiscount = CheckIfDiscountIsValid(DateTime.Parse(data_descuento.Tables[0].Rows[0]["FechaFinalizacion"].ToString()), DateTime.Parse(data_descuento.Tables[0].Rows[0]["FechaInicio"].ToString()));

                        if (validDiscount)
                        {
                            double precio_con_descuento = CalculateDiscountPrice(double.Parse(row["Precio"].ToString()), int.Parse(data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString()));
                            cards += "<div class='d-flex text-start text-lg-end flex-column'> <div class='d-flex justify-content-lg-end'> <div class='habitacion-info-precio text-decoration-line-through text-muted fs-5'> " + MoneyFormat(row["Precio"].ToString()) + " </div> <span class='fc-blue ff-oswaldo'>" + data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString() + "% OFF</span> </div> <div class='habitacion-info-precio fc-orange'> " + MoneyFormat(precio_con_descuento.ToString()) + " </div> <div class='habitacion-precio-desc'>Por noche</div> </div>";
                        }
                        else
                        {
                            cards += "<div class='d-flex text-start text-lg-end flex-column'> <div class='habitacion-info-precio'> " + MoneyFormat(row["Precio"].ToString()) + " </div> <div class='habitacion-precio-desc'>Por noche</div> </div>";
                        }
                    }

                    cards += "</div> </div> <hr> <div class='row'> <p class='habitacion-descripcion'>" + row["Descripcion"] + "</p> </div> </div> </div> <div class='row'> <div class='col-lg-8'> <div class='row mb-1'> <div class='habitacion-services-title'>Características especiales</div> </div>";

                    cards += "<div class='row d-flex'> <span class='fa-stack fa-2x fs-5' data-bs-toggle='tooltip' data-bs-placement='top' title='" + (row["BañosPDiscapacitadas"].ToString() == "1" ? "Si posee baños para discapacitados" : "No posee baños para discapacitados") + "'> <i class='fas fa-square fa-stack-2x iconbackground-" + (row["BañosPDiscapacitadas"].ToString() == "1" ? "true" : "false") + "'></i> <i class='fab fa-accessible-icon fa-stack-1x fa-inverse'></i> </span> <span class='fa-stack fa-2x fs-5' data-bs-toggle='tooltip' data-bs-placement='top' title='" + (row["Mascotas"].ToString() == "1" ? "Si admite mascotas" : "No admite mascotas") + "'> <i class='fas fa-square fa-stack-2x iconbackground-" + (row["Mascotas"].ToString() == "1" ? "true" : "false") + "'></i> <i class='fa fa-dog fa-stack-1x fa-inverse'></i> </span> <span class='fa-stack fa-2x fs-5' data-bs-toggle='tooltip' data-bs-placement='top' title='" + row["NumeroCamas"].ToString() + " camas" + "'> <i class='fas fa-square fa-stack-2x icon-caracteristicas-outter'></i> <i class='fas fa-bed fa-stack-1x fa-inverse'></i> </span> </div> </div>";

                    cards += "<div class='col-lg-4 d-flex justify-content-center justify-content-md-end'> <a href='habitacion_pagina.aspx?h=" + row["Numero"].ToString() + "' class='btn btn-primary btn-lg mt-2 mt-md-0' target='_blank'><i class='fa fa-eye' aria-hidden='true'></i> Ver mas detalles</a> </div> </div> </div> </div>";
                }
            }
            else
            {
                cards += GenerateAlarm("<i class='fas fa-exclamation-circle'></i> No hay habitaciones para mostrar", "secondary",false);
            }

            return cards;
        }

        public static string GenerateTestimoniosCards(DataSet testimonios_data)
        {
            string cards = "";
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            DataSet usuario_data;
            foreach (DataRow row in testimonios_data.Tables[0].Rows)
            {
                cards += "<div class='comentario-body mt-3'> <div class='container-fluid'> <div class='row'> <div class='col-lg-2 my-auto text-center'>";

                usuario_data = userDatabaseManager.ReadDatabaseRecord(
                    new string[]{"Nombres","Apellidos","ImagenPerfil"},
                    new string[,] { {"ID","=","'"+row["Cliente_ID"]+"'"} },
                    null
                );

                cards += "<img src='"+usuario_data.Tables[0].Rows[0]["ImagenPerfil"]+"' class='border border-5 img-fluid rounded-circle' alt='...' width='200' height='200'> </div> <div class='col-lg-10'> <div class='d-flex flex-column'>";
                cards += "<div class='comentario-title fc-blue'>"+usuario_data.Tables[0].Rows[0]["Nombres"]+" " + usuario_data.Tables[0].Rows[0]["Apellidos"] + "</div>";

                double width_star = (double.Parse(row["Puntaje"].ToString()) / 5) * 100;
                string width_star_s = width_star.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);

                cards += "<div class='d-flex'> <div class='stars-outer'> <div class='stars-inner' style='width: "+ width_star_s + "%;'></div> </div> <div class='fc-gray fw-bold ff-oswaldo'>"+ row["Puntaje"].ToString() + "</div> </div>";
                cards += "<div class='comentario mt-2'>" + row["Comentario"] + "</div> </div> </div> </div> </div> </div>";
            }

            return cards;
        }

        public static string GetIconPhoto(XDocument fotos)
        {
            return fotos.Root.Element("Icono").Attribute("src").Value;
        }

        public static string MoneyFormat(string number)
        {
            return double.Parse(number).ToString("c0") + " COP";
        }

        public static double CalculateDiscountPrice(double initial_price, int discount_percentage)
        {
            return initial_price * (1 - (double)discount_percentage / 100.0);
        }

        public static void GetImagesHabitacion(XDocument Fotos, out List<string> sources)
        {
            List<string> sources_images = new List<string>();
            foreach (XElement element in Fotos.Descendants("FotosHabitacion").Descendants("PaginaFotos").Nodes())
            {
                sources_images.Add(element.Attribute("src").Value);
            }

            sources = sources_images;
        }

        public static bool CheckIfDiscountIsValid(DateTime fecha_finalizacion, DateTime fecha_inicio)
        {
            DateTime fechaActual = DateTime.Now;
            if ((fechaActual-fecha_inicio).TotalSeconds > 0 && (fecha_finalizacion-fechaActual).TotalSeconds > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckIfTestimonioReservaIsValid(DateTime fecha_inicio)
        {
            DateTime fechaActual = DateTime.Now;
            if ((fechaActual - fecha_inicio).TotalSeconds > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckIfReservaIsValid(DateTime fecha_finalizacion)
        {
            DateTime fechaActual = DateTime.Now;
            if ((fecha_finalizacion - fechaActual).TotalSeconds > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool CheckIfBookingIsActive(DateTime fecha_inicio)
        {
            DateTime fechaActual = DateTime.Now;
            if ((fechaActual - fecha_inicio).TotalSeconds > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static double CalculateTestimonialsMean(DataSet testimonials)
        {
            List<int> testimonials_puntaje = new List<int>();

            testimonials_puntaje = (from DataRow row in testimonials.Tables[0].Rows select int.Parse(row["Puntaje"].ToString())).ToList();

            double promedio;

            if(testimonials_puntaje.Count == 0)
            {
                promedio = 0.0;
            }else if(testimonials_puntaje.Count == 1)
            {
                promedio = testimonials_puntaje[0];
            }
            else
            {
                promedio = testimonials_puntaje.Average();
            }

            return promedio;
        }

        public static string GeneratePagination(int numero_paginas, int elementos_por_pagina, int? pagina_actual = null)
        {
            string button_style = "primary";
            string pagination_buttons = "";
            if (numero_paginas > 1)
            {
                pagination_buttons += "<div class='btn-group me-2' name='pagination-markup' role='group' aria-label='First group' data-total-pages='"+numero_paginas.ToString()+"' data-elements-page='"+elementos_por_pagina.ToString()+"'>";

                if (pagina_actual == 1 || pagina_actual == null)
                {
                    pagination_buttons += "<button type='button' name='button-pagination-before' data-button-page='izq' class='btn btn-" + button_style + "' disabled ><i class='fas fa-angle-left'></i></button>";
                }
                else
                {
                    pagination_buttons += "<button type='button' name='button-pagination-before' data-button-page='izq' class='btn btn-" + button_style + "'><i class='fas fa-angle-left'></i></button>";
                }

                for (int i = 1; i <= numero_paginas; i++)
                {
                    if(pagina_actual != null)
                    {
                        if(i == pagina_actual)
                        {
                            pagination_buttons += "<button type='button' name='button-page' data-button-page='" + i.ToString() + "' class='btn btn-" + button_style + "' disabled>" + i.ToString() + "</button>";
                        }
                        else
                        {
                            pagination_buttons += "<button type='button' name='button-page' data-button-page='" + i.ToString() + "' class='btn btn-" + button_style + "'>" + i.ToString() + "</button>";
                        }
                    }
                    else 
                    {
                        if (i == 1)
                        {
                            pagination_buttons += "<button type='button' name='button-page' data-button-page='" + i.ToString() + "' class='btn btn-" + button_style + "' disabled>" + i.ToString() + "</button>";
                        }
                        else
                        {
                            pagination_buttons += "<button type='button' name='button-page' data-button-page='" + i.ToString() + "' class='btn btn-" + button_style + "'>" + i.ToString() + "</button>";
                        }
                    }
                }

                if(pagina_actual == numero_paginas)
                {
                    pagination_buttons += "<button type='button' name='button-pagination-after' data-button-page='der' class='btn btn-" + button_style + "' disabled><i class='fas fa-angle-right'></i></button>";
                }
                else
                {
                    pagination_buttons += "<button type='button' name='button-pagination-after' data-button-page='der' class='btn btn-" + button_style + "'><i class='fas fa-angle-right'></i></button>";
                }
                pagination_buttons += "</div>";
            }
            return pagination_buttons;
        }

        public static DataSet ManuallyOffcet(DataSet data, int offcet, int fetchtop)
        {
            DataSet cropped_data = new DataSet();

            if(data.Tables[0].Rows.Count > 0)
            {
                if (offcet + fetchtop > data.Tables[0].Rows.Count)
                {
                    fetchtop = data.Tables[0].Rows.Count - offcet;
                }

                DataTable dtNew = data.Tables[0].Select().Skip(offcet).Take(fetchtop).CopyToDataTable();

                cropped_data.Tables.Add(dtNew);
            }
            else
            {
                cropped_data.Tables.Add(data.Tables[0].Clone());
            }

            return cropped_data;
        }

        public static DataSet OrderByPrice(DataSet data, string direction)
        {
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");
            DataSet data_descuentos;
            //System.Diagnostics.Debug.WriteLine(data.Tables[0].Columns["Precio"].DataType.Name.ToString());
            data.Tables[0].Columns.Add(new DataColumn("PrecioConDescuento", typeof(decimal)));
            foreach  (DataRow row in data.Tables[0].Rows)
            {
                if (!String.IsNullOrEmpty(row["Descuento_ID"] as string))
                {
                    data_descuentos = descuentosDatabaseManager.ReadDatabaseRecord(
                        new string[] {"*"},
                        new string[,] { {"ID","=","'"+ row["Descuento_ID"] as string + "'"} },
                        null
                    );

                    if (CheckIfDiscountIsValid(DateTime.Parse(data_descuentos.Tables[0].Rows[0]["FechaFinalizacion"].ToString()), DateTime.Parse(data_descuentos.Tables[0].Rows[0]["FechaInicio"].ToString())))
                    {
                        row["PrecioConDescuento"] = Convert.ToDecimal(CalculateDiscountPrice(double.Parse(row["Precio"].ToString()), int.Parse(data_descuentos.Tables[0].Rows[0]["Porcentaje"].ToString())));
                    }
                    else
                    {
                        row["PrecioConDescuento"] = row["Precio"];
                    }
                }
                else
                {
                    row["PrecioConDescuento"] = row["Precio"];
                }
            }
            DataSet sorted_data = new DataSet();
            DataView dv = data.Tables[0].DefaultView;
            dv.Sort = "PrecioConDescuento " + direction;

            sorted_data.Tables.Add(dv.ToTable());

            return sorted_data;
        }
        public static DataSet OrderByPuntaje(DataSet data, string direction)
        {
            TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");
            DataSet data_testimonios;
            //System.Diagnostics.Debug.WriteLine(data.Tables[0].Columns["Precio"].DataType.Name.ToString());
            data.Tables[0].Columns.Add(new DataColumn("PuntajePromedio", typeof(decimal)));
            foreach (DataRow row in data.Tables[0].Rows)
            {
                data_testimonios = testimoniosDatabaseManager.ReadDatabaseRecord(
                    new string[] {"*"},
                    new string[,] { {"Habitacion_ID","=","'"+row["ID"]+"'"} },
                    null
                );

                if(data_testimonios.Tables[0].Rows.Count > 0)
                {
                    row["PuntajePromedio"] = CalculateTestimonialsMean(data_testimonios);
                }
                else
                {
                    row["PuntajePromedio"] = 0;
                }
            }
            DataSet sorted_data = new DataSet();
            DataView dv = data.Tables[0].DefaultView;
            dv.Sort = "PuntajePromedio " + direction;

            sorted_data.Tables.Add(dv.ToTable());

            return sorted_data;
        }
        public static DataSet OrderByNumeroCamas(DataSet data, string direction)
        {
            DataSet sorted_data = new DataSet();
            DataView dv = data.Tables[0].DefaultView;
            dv.Sort = "NumeroCamas " + direction;

            sorted_data.Tables.Add(dv.ToTable());

            return sorted_data;
        }
        public static DataSet FilterData(DataSet habitacion_data, PaginationObject paginationObject)
        {
            TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");

            DataSet filtered_data = new DataSet();
            DataSet descuentos_data = new DataSet();
            DataSet testimonios_data = new DataSet();
            DataSet reservas_data = new DataSet();

            habitacion_data.Tables[0].Columns.Add(new DataColumn("PuntajePromedio", typeof(decimal)));
            habitacion_data.Tables[0].Columns.Add(new DataColumn("Reservada", typeof(int)));
            habitacion_data.Tables[0].Columns.Add(new DataColumn("PrecioConDescuento", typeof(decimal)));

            foreach (DataRow row in habitacion_data.Tables[0].Rows)
            {
                testimonios_data = testimoniosDatabaseManager.ReadDatabaseRecord(
                    new string[] { "*" },
                    new string[,] { { "Habitacion_ID", "=", "'" + row["ID"] + "'" } },
                    null
                );

                if (testimonios_data.Tables[0].Rows.Count > 0)
                {
                    row["PuntajePromedio"] = CalculateTestimonialsMean(testimonios_data);
                }
                else
                {
                    row["PuntajePromedio"] = 0;
                }

                if (!String.IsNullOrEmpty(row["Descuento_ID"] as string))
                {
                    descuentos_data = descuentosDatabaseManager.ReadDatabaseRecord(
                        new string[] { "*" },
                        new string[,] { { "ID", "=", "'" + row["Descuento_ID"] as string + "'" } },
                        null
                    );

                    if (CheckIfDiscountIsValid(DateTime.Parse(descuentos_data.Tables[0].Rows[0]["FechaFinalizacion"].ToString()), DateTime.Parse(descuentos_data.Tables[0].Rows[0]["FechaInicio"].ToString())))
                    {
                        row["PrecioConDescuento"] = Convert.ToDecimal(CalculateDiscountPrice(double.Parse(row["Precio"].ToString()), int.Parse(descuentos_data.Tables[0].Rows[0]["Porcentaje"].ToString())));
                    }
                    else
                    {
                        row["PrecioConDescuento"] = row["Precio"];
                    }
                }
                else
                {
                    row["PrecioConDescuento"] = row["Precio"];
                }

                reservas_data = reservasDatabaseManager.ReadDatabaseRecord(
                    new string[] {"*"},
                    new string[,] { 
                        {"Habitacion_ID","=","'"+row["ID"]+"'"},
                        {"Cancelada","=","0" },
                    },
                    new string[] {"AND"}
                );

                if(reservas_data.Tables[0].Rows.Count > 0)
                {
                    bool disponible = CheckIfHabitacionEstaDisponible(reservas_data, paginationObject.FechaInicio, paginationObject.FechaFinalizacion);

                    row["Reservada"] = disponible ? 0 : 1;
                }
                else
                {
                    row["Reservada"] = 0;
                }
            }
            filtered_data.Tables.Add(habitacion_data.Tables[0].Clone());
            DataRow[] datarows = habitacion_data.Tables[0].Select("Reservada = 0 AND PrecioConDescuento <= " + paginationObject.MaxPrecio + " AND PrecioConDescuento >= " + paginationObject.MinPrecio + " AND Tamaño = '" + paginationObject.Tamaño + "' AND BañosPDiscapacitadas = " + paginationObject.BañosPDiscapacitadas + " AND Mascotas = " + paginationObject.Mascotas + " AND NumeroCamas = " + paginationObject.NumeroCamas + " AND PuntajePromedio >= " + paginationObject.NumeroEstrellas);

            foreach (DataRow row in datarows)
            {
                filtered_data.Tables[0].ImportRow(row);
            }

            filtered_data.Tables[0].Columns.Remove("PrecioConDescuento");
            filtered_data.Tables[0].Columns.Remove("PuntajePromedio");
            return filtered_data;
        }
        public static bool CheckIfHabitacionEstaDisponible(DataSet reservas_data, DateTime fechainicio, DateTime fechafinalizacion)
        {
            bool disponible = true;

            foreach (DataRow row in reservas_data.Tables[0].Rows)
            {
                DateTime fechaInicio_reserva = DateTime.Parse(row["FechaInicio"].ToString());
                DateTime fechaFinalizacion_reserva = DateTime.Parse(row["FechaFinalizacion"].ToString());

                if((fechafinalizacion - fechaInicio_reserva).TotalSeconds > 0 && (fechaFinalizacion_reserva - fechafinalizacion).TotalSeconds > 0)
                {
                    disponible = false;
                }else if((fechainicio - fechaInicio_reserva).TotalSeconds >= 0)
                {
                    if ((fechaFinalizacion_reserva - fechainicio).TotalSeconds >= 0)
                    {
                        disponible = false;
                    }
                }else if((fechaInicio_reserva - fechainicio).TotalSeconds >= 0 && (fechafinalizacion - fechaFinalizacion_reserva).TotalSeconds >= 0)
                {
                    disponible = false;
                }
            }

            return disponible;
        }
        public static int CalculateNumberOfPages(int total_habitaciones, int elementos_por_pagina)
        {
            double division = (double)total_habitaciones / elementos_por_pagina;
            int numero_paginas;
            if (division <= 1 && division > 0)
            {
                numero_paginas = 1;
            }
            else if (division > 1)
            {
                numero_paginas = (int)Math.Ceiling(division);
            }
            else
            {
                numero_paginas = 0;
            }

            return numero_paginas;
        }

        public static DataSet SeleccionarHabitacionesOcupadas(DataSet habitaciones_data, DateTime fecha_inicio, DateTime fecha_finalizacion)
        {
            DataSet habitaciones_disponibles = new DataSet();
            ReservasDatabaseManager reservasDatabaseManager = new ReservasDatabaseManager("SQLConnection", "[dbo].[Reservas]");
            DataSet reservas_data = new DataSet();

            habitaciones_data.Tables[0].Columns.Add(new DataColumn("Disponible", typeof(int)));

            foreach (DataRow row in habitaciones_data.Tables[0].Rows)
            {
                reservas_data = reservasDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "Habitacion_ID", "=", "'" + row["ID"] + "'" } }, null);


                if (reservas_data.Tables[0].Rows.Count > 0)
                {
                    bool disponible = CheckIfHabitacionEstaDisponible(reservas_data, fecha_inicio, fecha_finalizacion);

                    row["Disponible"] = disponible ? 1 : 0;
                }
                else
                {
                    row["Disponible"] = 1;
                }
            }

            habitaciones_disponibles.Tables.Add(habitaciones_data.Tables[0].Clone());
            DataRow[] datarows = habitaciones_data.Tables[0].Select("Disponible = 0");

            foreach (DataRow row in datarows)
            {
                habitaciones_disponibles.Tables[0].ImportRow(row);
            }

            return habitaciones_disponibles;

        }

        public static string GenerateTableModificarReserva(DataSet data)
        {
            string table_rows = "";
            UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            DataSet usuario_data = new DataSet();
            int contador = 1;

            if (data.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in data.Tables[0].Rows)
                {
                    table_rows += "<tr>";
                    usuario_data = userDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Nombres", "Apellidos" },
                        new string[,] { { "ID", "=", "'" + row["Cliente_ID"] + "'" } },
                        null
                    );

                    table_rows += "<th scope='row'>" + contador + "</th>";
                    table_rows += "<td>" + usuario_data.Tables[0].Rows[0]["Nombres"] + " " + usuario_data.Tables[0].Rows[0]["Apellidos"] + "</td>";
                    table_rows += "<td>" + DateTime.Parse(row["FechaInicio"].ToString()).ToString("yyy/MM/dd") + "</td>";
                    table_rows += "<td>" + DateTime.Parse(row["FechaFinalizacion"].ToString()).ToString("yyy/MM/dd") + "</td>";
                    table_rows += "<td class='text-center'>" + row["NumeroPersonas"] + "</td>";
                    if (row["Cancelada"].ToString().Equals("1"))
                    {
                        table_rows += "<td><span class='badge bg-danger'>Cancelada</span></td>";
                    }
                    else
                    {
                        if (CheckIfReservaIsValid(DateTime.Parse(row["FechaFinalizacion"].ToString())))
                        {
                            table_rows += "<td><span class='badge bg-success'>Activa</span></td>";
                        }
                        else
                        {
                            table_rows += "<td><span class='badge bg-secondary'>Vencida</span></td>";
                        }
                    }
                    table_rows += "<td>" + MoneyFormat(row["ValorPago"].ToString()) + "</td>";
                    table_rows += "<td>" + DateTime.Parse(row["FechaPago"].ToString()).ToString("yyy/MM/dd") + "</td>";
                    table_rows += "<td><button type='button' name='CargarDatosModificarReserva' class='btn btn-outline-primary round-edges-20' data-loadreserva='" + row["ID"].ToString() + "'> <i class='fa fa-eye' aria-hidden='true'></i> Seleccionar reserva </button></td>";

                    table_rows += "</tr>";
                    contador++;
                }
            }
            else
            {
                table_rows = "<tr><td colspan='8'>No se han encontrado reservas para la habitación seleccionada.</td><tr>";
            }

            return table_rows;
        }
    }
}