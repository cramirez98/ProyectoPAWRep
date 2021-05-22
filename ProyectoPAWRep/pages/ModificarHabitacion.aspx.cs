using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using ProyectoPAWRep.classes;
using System.Xml.Linq;

namespace ProyectoPAWRep.pages
{
    public partial class ModificarHabitacion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string numero_habitacion_a_cargar = Request.QueryString["h"];
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            if (!String.IsNullOrEmpty(numero_habitacion_a_cargar))
            {
                seleccionar_habitacion.Visible = false;
                int fetched_data = habitacionesDatabaseManager.CountFetchedData(
                    new string[] { "ID" },
                    new string[,] { {"Numero","=",numero_habitacion_a_cargar} },
                    null
                );

                if(fetched_data > 0)
                {
                    DataSet data = habitacionesDatabaseManager.ReadDatabaseRecord(
                        new string[] { "*" },
                        new string[,] { { "Numero", "=", numero_habitacion_a_cargar } },
                        null
                    );
                    CargarInformacionHabitacion(data);
                }
                else
                {
                    Response.Redirect("VerHabitaciones.aspx");
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    DataSet data = habitacionesDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Numero" },
                        null,
                        null
                    );
                    MHabitacionNumeroToLoad.DataTextField = data.Tables[0].Columns["Numero"].ToString();
                    MHabitacionNumeroToLoad.DataValueField = data.Tables[0].Columns["Numero"].ToString();
                    MHabitacionNumeroToLoad.DataSource = data.Tables[0];
                    MHabitacionNumeroToLoad.DataBind();
                }

                seleccionar_habitacion.Visible = true;
            }

            alertaspace.InnerHtml = "";
        }

        protected void BtnModificarHabitacion_Click(object sender, EventArgs e)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");
            string descuento_id;
            if(MHabitacionDescuentoDropdown.SelectedValue.ToString() == "Sin Descuento")
            {
                descuento_id = "";
            }
            else
            {
                DataSet data_descuentos = descuentosDatabaseManager.ReadDatabaseRecord(
                    new string[] { "ID" },
                    new string[,] { {"Nombre","=","'"+ MHabitacionDescuentoDropdown.SelectedValue.ToString() + "'"} },
                    null
                );
                descuento_id = data_descuentos.Tables[0].Rows[0]["ID"].ToString();
            }
            if (MHabitacionImg.PostedFile.ContentLength > 0)
            {
                if(MHabitacionImg.PostedFiles.Count == 3)
                {
                    ValFotos.Visible = false;
                    string numero_habitacion_encriptada = Utilities.ComputarSHA128(MHabitacionNumero.Text);
                    var count = 0;

                    string[] direccion_imagenes = new string[3];

                    // Subir las fotos de la pagina de habitacion

                    foreach (HttpPostedFile uploadedFile in MHabitacionImg.PostedFiles)
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

                    if (MHabitacionIcon.PostedFile.ContentLength > 0)
                    {
                        string fn_icono_antes = System.IO.Path.GetFileName(MHabitacionIcon.PostedFile.FileName);
                        string[] string_dividido_icon = fn_icono_antes.Split('.');
                        string fn_final_icon = numero_habitacion_encriptada + "_icon" + "." + string_dividido_icon[1];
                        string SaveLocation_icon = Server.MapPath(@"\img\habitaciones") + "\\" + fn_final_icon;

                        MHabitacionIcon.PostedFile.SaveAs(SaveLocation_icon);
                    }


                    bool success = habitacionesDatabaseManager.UpdateDatabaseRecord(
                        new string[,] {
                        {"Numero", MHabitacionNumero.Text },
                        {"Tamaño", "'"+MHabitacionSize.SelectedValue.ToString()+"'"},
                        {"Precio", double.Parse(MHabitacionPrecio.Text).ToString()},
                        {"Descripcion", "'"+MHabitacionDescripcion.Text+"'"},
                        {"NumeroCamas", MHabitacionCamas.Text},
                        {"Mascotas", MHabitacionMascotas.Checked ? "1" : "0"},
                        {"BañosPDiscapacitadas", MHabitacionDiscapacitados.Checked ? "1" : "0"},
                        {"Descuento_ID", MHabitacionDescuentoDropdown.SelectedValue.ToString() == "''" ? "" : "'" + descuento_id + "'"}
                        },
                        new string[,] { { "Numero", "=", MHabitacionNumero.Text } },
                        null
                    );

                    if (success)
                    {
                        alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha modificado con exito la habitacion", "Puedes ver las habitaciones dando <a href='VerHabitaciones.aspx'>click aqui</a>", "success");
                    }
                    else
                    {
                        alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No ha sido posible modificar con exito la habitacion", "Esto puede deberse a un error con el servidor", "danger");
                    }
                }
                else
                {
                    ValFotos.Visible = true;
                }
            }
            else
            {
                if (MHabitacionIcon.PostedFile.ContentLength > 0)
                {
                    string numero_habitacion_encriptada = Utilities.ComputarSHA128(MHabitacionNumero.Text);
                    string fn_icono_antes = System.IO.Path.GetFileName(MHabitacionIcon.PostedFile.FileName);
                    string[] string_dividido_icon = fn_icono_antes.Split('.');
                    string fn_final_icon = numero_habitacion_encriptada + "_icon" + "." + string_dividido_icon[1];
                    string SaveLocation_icon = Server.MapPath(@"\img\habitaciones") + "\\" + fn_final_icon;

                    MHabitacionIcon.PostedFile.SaveAs(SaveLocation_icon);
                }
                bool success = habitacionesDatabaseManager.UpdateDatabaseRecord(
                    new string[,] {
                        {"Numero", MHabitacionNumero.Text },
                        {"Tamaño", "'"+MHabitacionSize.SelectedValue.ToString()+"'"},
                        {"Precio", double.Parse(MHabitacionPrecio.Text).ToString()},
                        {"Descripcion", "'"+MHabitacionDescripcion.Text+"'"},
                        {"NumeroCamas", MHabitacionCamas.Text},
                        {"Mascotas", MHabitacionMascotas.Checked ? "1" : "0"},
                        {"BañosPDiscapacitadas", MHabitacionDiscapacitados.Checked ? "1" : "0"},
                        {"Descuento_ID", MHabitacionDescuentoDropdown.SelectedValue.ToString() == "''" ? "" : "'" + descuento_id + "'"}
                    },
                    new string[,] { { "Numero", "=", MHabitacionNumero.Text } },
                    null
                );

                if (success)
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se ha modificado con exito la habitacion", "Puedes ver las habitaciones dando <a href='VerHabitaciones.aspx'>click aqui</a>", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No ha sido posible modificar con exito la habitacion", "Esto puede deberse a un error con el servidor", "danger");
                }
            }
 
        }

        protected void cargarinformacionhabitacion_ServerClick(object sender, EventArgs e)
        {
            HabitacionesDatabaseManager habitacionesDatabaseManager = new HabitacionesDatabaseManager("SQLConnection", "[dbo].[Habitaciones]");

            string numero_habitacion_a_cargar = MHabitacionNumeroToLoad.SelectedValue.ToString();

            DataSet data = habitacionesDatabaseManager.ReadDatabaseRecord(
                new string[] { "*" },
                new string[,] { { "Numero", "=", numero_habitacion_a_cargar } },
                null
            );
            CargarInformacionHabitacion(data);
        }

        public void CargarInformacionHabitacion(DataSet data)
        {
            MHabitacionCamas.SelectedValue = data.Tables[0].Rows[0]["NumeroCamas"].ToString();
            MHabitacionNumero.Text = data.Tables[0].Rows[0]["Numero"].ToString();
            MHabitacionNumero.Attributes["placeholder"] = data.Tables[0].Rows[0]["Numero"].ToString();
            MHabitacionPrecio.Text = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString()).ToString("N0");
            MHabitacionPrecio.Attributes["placeholder"] = double.Parse(data.Tables[0].Rows[0]["Precio"].ToString()).ToString("N0");
            MHabitacionSize.SelectedValue = data.Tables[0].Rows[0]["Tamaño"].ToString();
            MHabitacionDescripcion.Text = data.Tables[0].Rows[0]["Descripcion"].ToString();
            MHabitacionDescripcion.Attributes["placeholder"] = data.Tables[0].Rows[0]["Descripcion"].ToString();

            if (data.Tables[0].Rows[0]["Mascotas"].ToString() == "1")
            {
                MHabitacionMascotas.Checked = true;
            }
            else
            {
                MHabitacionMascotas.Checked = false;
            }

            if (data.Tables[0].Rows[0]["BañosPDiscapacitadas"].ToString() == "1")
            {
                MHabitacionDiscapacitados.Checked = true;
            }
            else
            {
                MHabitacionDiscapacitados.Checked = false;
            }
            DescuentosDatabaseManager descuentosDatabaseManager = new DescuentosDatabaseManager("SQLConnection", "[dbo].[Descuentos]");

            DataSet data_descuentos = descuentosDatabaseManager.ReadDatabaseRecord(
                new string[] { "Nombre" },
                null,
                null
            );

            MHabitacionDescuentoDropdown.DataTextField = data_descuentos.Tables[0].Columns["Nombre"].ToString();
            MHabitacionDescuentoDropdown.DataValueField = data_descuentos.Tables[0].Columns["Nombre"].ToString();
            MHabitacionDescuentoDropdown.DataSource = data_descuentos.Tables[0];
            MHabitacionDescuentoDropdown.DataBind();

            MHabitacionDescuentoDropdown.Items.Insert(0, new ListItem("Sin descuento", "Sin Descuento"));

            if(data.Tables[0].Rows[0]["Descuento_ID"].ToString() == "")
            {
                MHabitacionDescuentoDropdown.SelectedValue = "Sin Descuento";
            }
            else
            {
                 DataSet data_descuentos_drop = descuentosDatabaseManager.ReadDatabaseRecord(
                    new string[] { "Nombre" },
                    new string[,] { {"ID","=","'"+ data.Tables[0].Rows[0]["Descuento_ID"].ToString() + "'"} },
                    null
                );
                MHabitacionDescuentoDropdown.SelectedValue = data_descuentos_drop.Tables[0].Rows[0]["Nombre"].ToString();
            }


        }
    }
}