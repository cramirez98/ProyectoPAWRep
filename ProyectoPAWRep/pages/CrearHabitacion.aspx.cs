using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProyectoPAWRep.classes;

namespace ProyectoPAWRep.pages
{
    public partial class CrearHabitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCrearHabitacion_Click(object sender, EventArgs e)
        {
            if ((CHabitacionImg.PostedFile != null) && (CHabitacionImg.PostedFile.ContentLength > 0) && (CHabitacionImg.PostedFiles.Count > 1 && CHabitacionImg.PostedFiles.Count < 4) && (CHabitacionIcon.PostedFile != null) && (CHabitacionIcon.PostedFile.ContentLength > 0))
            {
                ValFotos.Visible = false;
                ValIcono.Visible = false;

                string numero_habitacion_encriptada = Utilities.ComputarSHA128(CHabitacionNumero.Text);
                var count = 0;

                string[] direccion_imagenes = new string[3];

                // Subir las fotos de la pagina de habitacion

                foreach (HttpPostedFile uploadedFile in CHabitacionImg.PostedFiles)
                {
                    string fn_antes = System.IO.Path.GetFileName(uploadedFile.FileName);
                    string[] string_dividido = fn_antes.Split('.');
                    string fn_final = numero_habitacion_encriptada + "_" + count + "." + string_dividido[1];
                    string SaveLocation = Server.MapPath(@"\img\habitaciones") + "\\" + fn_final;
                    direccion_imagenes[count] = "../img/habitaciones/" + fn_final;
                    try
                    {
                       uploadedFile.SaveAs(SaveLocation);
                        count++;
                    }
                    catch (Exception ex)
                    {
                    }
                }
                // Subir icono
                string fn_icono_antes = System.IO.Path.GetFileName(CHabitacionIcon.PostedFile.FileName);
                string[] string_dividido_icon = fn_icono_antes.Split('.');
                string fn_final_icon = numero_habitacion_encriptada + "_icon" + "." + string_dividido_icon[1];
                string SaveLocation_icon = Server.MapPath(@"\img\habitaciones") + "\\" + fn_final_icon;

                CHabitacionIcon.PostedFile.SaveAs(SaveLocation_icon);

                string direccion_icono = "../img/habitaciones/" + fn_final_icon;

                // Crear documento XML

                XDocument document = new XDocument(new XDeclaration("1.0", "utf-8", null));
                XElement nodoraiz = new XElement("FotosHabitacion");
                document.Add(nodoraiz);
                XElement imagen = new XElement("PaginaFotos");
                XElement foto1 = new XElement("Foto1");
                XElement foto2 = new XElement("Foto2");
                XElement foto3 = new XElement("Foto3");

                foto1.Add(new XAttribute("src", direccion_imagenes[0]));
                foto2.Add(new XAttribute("src", direccion_imagenes[1]));
                foto3.Add(new XAttribute("src", direccion_imagenes[2]));

                imagen.Add(foto1);
                imagen.Add(foto2);
                imagen.Add(foto3);

                XElement icono = new XElement("Icono");
                icono.Add(new XAttribute("src", direccion_icono));

                nodoraiz.Add(imagen);
                nodoraiz.Add(icono);


                string h = document.ToString();
                Habitacion habitacion = new Habitacion(int.Parse(CHabitacionNumero.Text), CHabitacionDescripcion.Text, document, double.Parse(CHabitacionPrecio.Text), CHabitacionSize.SelectedValue.ToString(), 0, int.Parse(CHabitacionCamas.SelectedValue.ToString()), CHabitacionMascotas.Checked ? 1 : 0, CHabitacionDiscapacitados.Checked ? 1 : 0, 0, "", "");

                HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");

                bool success = habitacionesDatabaseManager.AddDatabaseRecord(habitacion);

                if (success)
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha creado la habitación de forma correcta", "Puedes ver las habitaciones creadas en la seccion de ver habitaciones", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "Hubo un error creando la habitación", "Intentalo nuevamente", "danger");
                }
            }
            else
            {
                if (CHabitacionImg.PostedFiles.Count != 3)
                {
                    ValFotos.Visible = true;
                }
                if(CHabitacionIcon.PostedFile.ContentLength == 0)
                {
                    ValIcono.Visible = true;
                }
                
            }
        }
    }
}