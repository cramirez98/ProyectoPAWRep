using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;
using System.Xml.Serialization;
using ProyectoPAWRep.classes;
using System.Data;
namespace ProyectoPAWRep.pages
{
    public partial class CrearHabitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

                DataSet data = descuentosDatabaseManager.ReadDatabaseRecord(
                    new string[] { "Nombre" },
                    null,
                    null
                );

                CHabitacionDescuentoDropdown.DataTextField = data.Tables[0].Columns["Nombre"].ToString();
                CHabitacionDescuentoDropdown.DataValueField = data.Tables[0].Columns["Nombre"].ToString();
                CHabitacionDescuentoDropdown.DataSource = data.Tables[0];
                CHabitacionDescuentoDropdown.DataBind();

                CHabitacionDescuentoDropdown.Items.Insert(0, new ListItem("Sin descuento", "Sin Descuento"));
                CHabitacionDescuentoDropdown.SelectedValue = "Sin Descuento";
            }
        }

        protected void BtnCrearHabitacion_Click(object sender, EventArgs e)
        {
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");
            string descuento_id;
            if (CHabitacionDescuentoDropdown.SelectedValue.ToString() == "Sin Descuento")
            {
                descuento_id = "";
            }
            else
            {
                DataSet data_descuentos = descuentosDatabaseManager.ReadDatabaseRecord(
                    new string[] { "ID" },
                    new string[,] { { "Nombre", "=", "'" + CHabitacionDescuentoDropdown.SelectedValue.ToString() + "'" } },
                    null
                );
                descuento_id = data_descuentos.Tables[0].Rows[0]["ID"].ToString();
            }
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            string[] valores_a_seleccionar = new string[] { "ID" };
            string[,] condiciones_para_seleccionar = new string[,] { { "Numero", "=", CHabitacionNumero.Text } };
            string[] logic_conditions = null;
            
            int n_datos_encontrados = habitacionesDatabaseManager.CountFetchedData(valores_a_seleccionar, condiciones_para_seleccionar, logic_conditions);

            if ((CHabitacionImg.PostedFile != null) && (CHabitacionImg.PostedFile.ContentLength > 0) && CHabitacionImg.PostedFiles.Count == 3 && (CHabitacionIcon.PostedFile != null) && (CHabitacionIcon.PostedFile.ContentLength > 0) && n_datos_encontrados == 0)
            {
                ValFotos.Visible = false;
                ValIcono.Visible = false;
                Val3NumeroH.Visible = false;

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
                Habitacion habitacion = new Habitacion(int.Parse(CHabitacionNumero.Text), CHabitacionDescripcion.Text, document, double.Parse(CHabitacionPrecio.Text), CHabitacionSize.SelectedValue.ToString(), 0, int.Parse(CHabitacionCamas.SelectedValue.ToString()), CHabitacionMascotas.Checked ? 1 : 0, CHabitacionDiscapacitados.Checked ? 1 : 0, 0, "", descuento_id);

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
                if (n_datos_encontrados != 0)
                {
                    Val3NumeroH.Visible = true;
                }
                
            }
        }
    }
}