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
        public static string GenerateBigAlarm(string title, string body, string footer, string alarm_type)
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
            alarm += "<p class='mb-0'>"+footer+ "</p><button type='button' class='btn-close' data-bs-dismiss='alert' aria-label='Close'></button></div>";

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
        public static string GenerateNormalDropdown()
        {
            string userDropdown = "<li class='nav-item dropdown'><a class='nav-link dropdown-toggle' href='#' id='navbarDropdown' role='button' data-bs-toggle='dropdown' aria-expanded='false'>";
            userDropdown += "<span class='fas fa-user'></span>";
            userDropdown += "</a><ul class='dropdown-menu dropdown-menu-lg-end' aria-labelledby='navbarDropdown'>";
            userDropdown += "<li><a class='dropdown-item' href='iniciosesion.aspx'>Iniciar sesion</a></li><li><a class='dropdown-item' href='registro.aspx'>Registrarse</a></li>";
            userDropdown += "</ul></li>";

            return userDropdown;
        }

        public static string GenerateHabitacionCards(DataSet data, bool unica_pagina)
        {
            string cards = "";

            foreach (DataRow row in data.Tables[0].Rows)
            {

                cards += "<div class='habitacion-card mt-3'> <div class='container-fluid'> <div class='row g-1'> <div class='col-xxl-3 text-center text-xxl-start'>";
                cards += "<img src='" + GetIconPhoto(XDocument.Parse(row["Fotos"].ToString())) + "' class='img-fluid rounded-3 img-thumbnail' alt='...' width='210' height='210'>";
                cards += "</div> <div class='col-xxl-9'> <div class='row g-0'> <div class='col-lg-8 col-sm-8'> <div class='d-flex flex-column'> <div class='d-flex'>";

                TestimoniosDatabaseManager testimoniosDatabaseManager = new TestimoniosDatabaseManager("SQLConnection", "[dbo].[Testimonios]");

                DataSet testimonios_data = testimoniosDatabaseManager.ReadDatabaseRecord(
                    new string[] {"*"},
                    new string[,] { {"Habitacion_ID","=","'"+row["ID"]+"'"} },
                    null
                );
                if (testimonios_data.Tables[0].Rows.Count > 0)
                {
                    double promedio = CalculateTestimonialsMean(testimonios_data);
                    double width_star = (promedio / 5)*100;
                    string width_star_s = width_star.ToString("0.00", System.Globalization.CultureInfo.InvariantCulture);
                    cards += "<div class='habitacion-puntaje'>"+ testimonios_data.Tables[0].Rows.Count.ToString() + " opiniones <div class='stars-outer'> <div class='stars-inner' style='width: " + width_star_s + "%;'></div> </div> </div> <div class='fs-12 fc-gray fw-bold ff-oswaldo'>" + promedio.ToString() + "</div> </div>";
                }
                else
                {
                    cards += "<div class='habitacion-puntaje'>No hay opiniones <div class='stars-outer'> <div class='stars-inner' style='width: " + "0" + "%;'></div> </div> </div> <div class='fs-12 fc-gray fw-bold ff-oswaldo'>" + "0" + "</div> </div>";
                }

                cards += "<div class='habitacion-titulo'>Habitación " + row["Numero"].ToString() + "</div> <div class='habitacion-subtitulo'>" + row["Tamaño"].ToString() + "</div> </div> </div> <div class='col-lg-4 col-sm-4 mb-2'> ";
                
                // Agregar precio con descuento o sin descuento
                if(row["Descuento_ID"].ToString() == "")
                {
                    cards += "<div class='d-flex text-start text-lg-end flex-column'> <div class='habitacion-info-precio'> "+ MoneyFormat(row["Precio"].ToString()) + " </div> <div class='habitacion-precio-desc'>Por noche</div> </div>";
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
                        cards += "<div class='d-flex text-start text-lg-end flex-column'> <div class='d-flex justify-content-lg-end'> <div class='habitacion-info-precio text-decoration-line-through text-muted fs-5'> "+ MoneyFormat(row["Precio"].ToString()) + " </div> <span class='fc-blue ff-oswaldo'>"+ data_descuento.Tables[0].Rows[0]["Porcentaje"].ToString() + "% OFF</span> </div> <div class='habitacion-info-precio fc-orange'> "+MoneyFormat(precio_con_descuento.ToString())+" </div> <div class='habitacion-precio-desc'>Por noche</div> </div>";
                    }
                    else
                    {
                        cards += "<div class='d-flex text-start text-lg-end flex-column'> <div class='habitacion-info-precio'> " + MoneyFormat(row["Precio"].ToString()) + " </div> <div class='habitacion-precio-desc'>Por noche</div> </div>";
                    }
                }

                cards += "</div> </div> <hr> <div class='row'> <p class='habitacion-descripcion'>"+row["Descripcion"]+ "</p> </div> </div> </div> <div class='row'> <div class='col-lg-8'> <div class='row mb-1'> <div class='habitacion-services-title'>Características especiales</div> </div>";

                cards += "<div class='row d-flex'> <span class='fa-stack fa-2x fs-5' data-bs-toggle='tooltip' data-bs-placement='top' title='"+ (row["BañosPDiscapacitadas"].ToString() == "1" ? "Si posee baños para discapacitados" : "No posee baños para discapacitados") + "'> <i class='fas fa-square fa-stack-2x iconbackground-" + (row["BañosPDiscapacitadas"].ToString() == "1" ? "true" : "false") + "'></i> <i class='fab fa-accessible-icon fa-stack-1x fa-inverse'></i> </span> <span class='fa-stack fa-2x fs-5' data-bs-toggle='tooltip' data-bs-placement='top' title='" + (row["Mascotas"].ToString() == "1" ? "Si admite mascotas" : "No admite mascotas") + "'> <i class='fas fa-square fa-stack-2x iconbackground-" + (row["Mascotas"].ToString() == "1" ? "true" : "false") + "'></i> <i class='fa fa-dog fa-stack-1x fa-inverse'></i> </span> </div> </div>";

                cards += "<div class='col-lg-4 d-flex justify-content-center justify-content-md-end'> <a href='habitacion_pagina.aspx?h="+row["Numero"].ToString()+"' class='btn btn-primary btn-lg mt-2 mt-md-0'><i class='fa fa-eye' aria-hidden='true'></i> Ver mas detalles</a> </div> </div> </div> </div>";
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
    }
}