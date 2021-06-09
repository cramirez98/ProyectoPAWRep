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
    public partial class ModificarUsuario : System.Web.UI.Page
    {
        UserDatabaseManager userDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
        protected void Page_Load(object sender, EventArgs e)
        {
            MUContraseña.Attributes["type"] = "password";
            MURContraseña.Attributes["type"] = "password";
            string usuario_id = Request.Form["usuario_id"];
            if (!String.IsNullOrEmpty(usuario_id))
            {
                seleccionar_usuario.Visible = false;
                int fetched_data = userDatabaseManager.CountFetchedData(
                    new string[] { "ID" },
                    new string[,] { { "ID", "=", "'" + usuario_id + "'" } },
                    null
                );

                if (fetched_data > 0)
                {
                    if (!IsPostBack)
                    {
                        DataSet data = userDatabaseManager.ReadDatabaseRecord(
                            new string[] { "*" },
                            new string[,] { { "ID", "=", "'" + usuario_id + "'" } },
                            null
                        );

                        CargarInformacionUsuario(data);

                        if (data.Tables[0].Rows.Count > 0)
                        {
                            data.Tables[0].Columns.Add(new DataColumn("NombresApellidosyCorreo", typeof(string)));

                            foreach (DataRow row in data.Tables[0].Rows)
                            {
                                row["NombresApellidosyCorreo"] = row["Nombres"].ToString() + " " + row["Apellidos"].ToString() + " - " + row["Correo"];
                            }

                            MUsuarioLoad.DataTextField = data.Tables[0].Columns["NombresApellidosyCorreo"].ToString();
                            MUsuarioLoad.DataValueField = data.Tables[0].Columns["Correo"].ToString();
                            MUsuarioLoad.DataSource = data.Tables[0];
                            MUsuarioLoad.DataBind();
                        }
                        else
                        {
                            MUsuarioLoad.Items.Clear();
                            MUsuarioLoad.Items.Add(new ListItem("No hay usuarios", "h"));
                            cargarinformacionusuario.Visible = false;
                        }
                    }
                }
                else
                {
                    Response.Redirect("VerUsuarios.aspx");
                }
            }
            else
            {
                if (!IsPostBack)
                {
                    DataSet data = userDatabaseManager.ReadDatabaseRecord(
                        new string[] { "Nombres", "Apellidos", "Correo" },
                        null,
                        null
                    );

                    if (data.Tables[0].Rows.Count > 0)
                    {
                        data.Tables[0].Columns.Add(new DataColumn("NombresApellidosyCorreo", typeof(string)));

                        foreach (DataRow row in data.Tables[0].Rows)
                        {
                            row["NombresApellidosyCorreo"] = row["Nombres"].ToString() + " " + row["Apellidos"].ToString() + " - " + row["Correo"];
                        }

                        MUsuarioLoad.DataTextField = data.Tables[0].Columns["NombresApellidosyCorreo"].ToString();
                        MUsuarioLoad.DataValueField = data.Tables[0].Columns["Correo"].ToString();
                        MUsuarioLoad.DataSource = data.Tables[0];
                        MUsuarioLoad.DataBind();
                    }
                    else
                    {
                        MUsuarioLoad.Items.Clear();
                        MUsuarioLoad.Items.Add(new ListItem("No hay usuarios", "h"));
                        cargarinformacionusuario.Visible = false;
                    }
                }
                else
                {
                    informacion_usuario.Attributes["class"] = "row";
                }

                seleccionar_usuario.Visible = true;
            }

            alertaspace.InnerHtml = "";
        }

        private void CargarInformacionUsuario(DataSet data)
        {
            DataRow row = data.Tables[0].Rows[0];
            IDUsuario.Text = row["ID"].ToString();

            MUNombres.Text = row["Nombres"].ToString();
            MUApellidos.Text = row["Apellidos"].ToString();
            MUCorreo.Text = row["Correo"].ToString();
            MUCelular.Text = row["Celular"].ToString();
            MUCedula.Text = row["Cedula"].ToString();
            MUEdad.Text = row["Edad"].ToString();
            MUCiudad.Text = row["Ciudad"].ToString();
            MUDireccion.Text = row["Direccion"].ToString();
            MUContraseña.Text = row["Contraseña"].ToString();
            ImagePerfilPaginaModificar.Attributes["src"] = row["ImagenPerfil"].ToString();

            MUTipo.SelectedValue = row["Tipo"].ToString();

            BtnModificarUsuario.Attributes["class"] = "btn btn-primary btn-lg mt-4";

            informacion_usuario.Attributes["class"] = "row";
        }

        protected void cargarinformacionusuario_ServerClick(object sender, EventArgs e)
        {
            string usuario_a_cargar = MUsuarioLoad.SelectedValue.ToString();

            DataSet data = userDatabaseManager.ReadDatabaseRecord(
                new string[] { "*" },
                new string[,] { { "Correo", "=", "'" + usuario_a_cargar + "'" } },
                null
            );
            CargarInformacionUsuario(data);
        }
        protected void BtnModificarUsuario_Click(object sender, EventArgs e)
        {
            string user_id = IDUsuario.Text;

            DataRow user_previus_data = userDatabaseManager.ReadDatabaseRecord(new string[] { "Contraseña", "Correo", "ImagenPerfil" }, new string[,] { { "ID", "=", "'" + user_id + "'" } }, null).Tables[0].Rows[0];
            string direccion_imagen = user_previus_data["ImagenPerfil"].ToString();

            string[,] valores_a_modificar = new string[,] { {"Nombres", "'"+MUNombres.Text+"'"},
                                                            {"Apellidos", "'"+MUApellidos.Text+"'"},
                                                            {"Contraseña", "'"+user_previus_data["Contraseña"].ToString()+"'"},
                                                            {"Celular", "'"+MUCelular.Text+"'"},
                                                            {"Cedula", "'"+MUCedula.Text+"'"},
                                                            {"Direccion", "'"+MUDireccion.Text+"'"},
                                                            {"Ciudad", "'"+MUCiudad.Text+"'"},
                                                            {"Edad", "'"+MUEdad.Text+"'"},
                                                            {"ImagenPerfil", "'"+direccion_imagen+"'"},
                                                            {"Tipo", "'"+MUTipo.SelectedValue.ToString()+"'"},
                                                            {"Correo", "'"+user_previus_data["Correo"].ToString()+"'"}
            };


            if ((MUFotoPerfil.PostedFile != null) && (MUFotoPerfil.PostedFile.ContentLength > 0))
            {
                string nombre_image_encriptada = Utilities.ComputarSHA128(user_id);

                string fn_icono_antes = System.IO.Path.GetFileName(MUFotoPerfil.PostedFile.FileName);
                string[] string_dividido = fn_icono_antes.Split('.');
                string fn_final_icon = nombre_image_encriptada + "." + string_dividido[1];
                string SaveLocation_icon = Server.MapPath(@"\img\profile") + "\\" + fn_final_icon;

                MUFotoPerfil.PostedFile.SaveAs(SaveLocation_icon);

                direccion_imagen = "../img/profile/" + fn_final_icon;

                valores_a_modificar[8, 1] = "'"+ direccion_imagen + "'";
            }

            if (!MUContraseña.Text.Equals(user_previus_data["Contraseña"].ToString()))
            {
                valores_a_modificar[2, 1] = "'"+Utilities.ComputarSHA256(MUContraseña.Text)+"'";
            }

            if (!MUCorreo.Text.Equals(user_previus_data["Correo"].ToString()))
            {
                bool exists = userDatabaseManager.CheckIfExists(new string[] { "ID" }, new string[,] { { "Correo", "=", "'" + MUCorreo.Text + "'" } }, null);

                if (!exists)
                {
                    valores_a_modificar[10, 1] = "'"+ MUCorreo.Text + "'";

                    bool success = userDatabaseManager.UpdateDatabaseRecord(valores_a_modificar, new string[,] { { "ID", "=", "'" + user_id + "'" } },null);

                    if (success)
                    {
                        alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "El usuario fue modificado correctamente.", "Puedes mirar los usuarios en la pagina de <a href='VerUsuarios.aspx'>Ver Usuarios</a>", "success");
                    }
                    else
                    {
                        alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "El usuario no pudo ser modificado.", "Esto puede deberse a un problema con el servidor", "danger");
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
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Exito!", "El usuario fue modificado correctamente.", "Puedes mirar los usuarios en la pagina de <a href='VerUsuarios.aspx'>Ver Usuarios</a>", "success");
                }
                else
                {
                    alertaspace.InnerHtml = Utilities.GenerateBigAlarm("Error!", "El usuario no pudo ser modificado.", "Esto puede deberse a un problema con el servidor", "danger");
                }
            }
        }
    }
}