using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ProyectoPAWRep.classes;
using System.Data;

namespace ProyectoPAWRep.pages
{
    public partial class MiUsuario : System.Web.UI.Page
    {
        UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
        protected void Page_Load(object sender, EventArgs e)
        {
            MIContraseña.Attributes["type"] = "password";
            MIRContraseña.Attributes["type"] = "password";
            string user_id = Session["User_ID"] as string;

            if (!IsPostBack)
            {
                DataRow usuario_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "*" }, new string[,] { { "ID", "=", "'" + user_id + "'" } }, null).Tables[0].Rows[0];

                MINombres.Text = usuario_data["Nombres"].ToString();
                MIApellidos.Text = usuario_data["Apellidos"].ToString();
                MICedula.Text = usuario_data["Cedula"].ToString();
                MICelular.Text = usuario_data["Celular"].ToString();
                MIDireccion.Text = usuario_data["Direccion"].ToString();
                MIEdad.Text = usuario_data["Edad"].ToString();
                MICiudad.Text = usuario_data["Ciudad"].ToString();
                MICorreo.Text = usuario_data["Correo"].ToString();
                MIContraseña.Text = usuario_data["Contraseña"].ToString();

                MIImagePerfilPaginaModificar.Attributes["src"] = usuario_data["ImagenPerfil"].ToString();
            }
        }

        protected void BtnModificarMiInfo_Click(object sender, EventArgs e)
        {
            string user_id = Session["User_ID"] as string;

            DataRow user_previus_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "Contraseña", "Correo", "ImagenPerfil" }, new string[,] { { "ID", "=", "'" + user_id + "'" } }, null).Tables[0].Rows[0];
            string direccion_imagen = user_previus_data["ImagenPerfil"].ToString();

            string[,] valores_a_modificar = new string[,] { {"Nombres", "'"+MINombres.Text+"'"},
                                                            {"Apellidos", "'"+MIApellidos.Text+"'"},
                                                            {"Contraseña", "'"+user_previus_data["Contraseña"].ToString()+"'"},
                                                            {"Celular", "'"+MICelular.Text+"'"},
                                                            {"Cedula", "'"+MICedula.Text+"'"},
                                                            {"Direccion", "'"+MIDireccion.Text+"'"},
                                                            {"Ciudad", "'"+MICiudad.Text+"'"},
                                                            {"Edad", "'"+MIEdad.Text+"'"},
                                                            {"ImagenPerfil", "'"+direccion_imagen+"'"},
                                                            {"Correo", "'"+user_previus_data["Correo"].ToString()+"'"}
            };


            if ((MIFotoPerfil.PostedFile != null) && (MIFotoPerfil.PostedFile.ContentLength > 0))
            {
                string nombre_image_encriptada = Utilities.ComputarSHA128(user_id);

                string fn_icono_antes = System.IO.Path.GetFileName(MIFotoPerfil.PostedFile.FileName);
                string[] string_dividido = fn_icono_antes.Split('.');
                string fn_final_icon = nombre_image_encriptada + "." + string_dividido[1];
                string SaveLocation_icon = Server.MapPath(@"\img\profile") + "\\" + fn_final_icon;

                MIFotoPerfil.PostedFile.SaveAs(SaveLocation_icon);

                direccion_imagen = "../img/profile/" + fn_final_icon;

                valores_a_modificar[8, 1] = "'" + direccion_imagen + "'";
            }

            if (!MIContraseña.Text.Equals(user_previus_data["Contraseña"].ToString()))
            {
                valores_a_modificar[2, 1] = "'" + Utilities.ComputarSHA256(MIContraseña.Text) + "'";
            }

            if (!MICorreo.Text.Equals(user_previus_data["Correo"].ToString()))
            {
                bool exists = userDatabaseManager.CheckIfExists(new string[] { "ID" }, new string[,] { { "Correo", "=", "'" + MICorreo.Text + "'" } }, null);

                if (!exists)
                {
                    valores_a_modificar[10, 1] = "'" + MICorreo.Text + "'";

                    bool success = userDatabaseManager.UpdateDatabaseRecord(valores_a_modificar, new string[,] { { "ID", "=", "'" + user_id + "'" } }, null);

                    if (success)
                    {
                        alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se modifico tu información correctamente.", "Puedes mirar los usuarios en la pagina de <a href='VerUsuarios.aspx'>Ver Usuarios</a>", "success");
                    }
                    else
                    {
                        alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se pudo modificar tu información.", "Esto puede deberse a un problema con el servidor", "danger");
                    }
                }
                else
                {
                    Val3Correo.Visible = true;
                }
            }
            else
            {
                bool success = userDatabaseManager.UpdateDatabaseRecord(valores_a_modificar, new string[,] { { "ID", "=", "'" + user_id + "'" } }, null);

                if (success)
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "Se modifico tu información correctamente.", "Puedes mirar los usuarios en la pagina de <a href='VerUsuarios.aspx'>Ver Usuarios</a>", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "No se pudo modificar tu información.", "Esto puede deberse a un problema con el servidor", "danger");
                }
            }
        }
    }
}