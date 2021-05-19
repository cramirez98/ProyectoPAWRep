﻿using ProyectoPAWRep.classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace ProyectoPAWRep.pages
{
    public partial class registro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegistrarse_Click(object sender, EventArgs e)
        {

            

            Usuario usuario = new Usuario(Nombres.Text, Apellidos.Text, Correo.Text, Contraseña.Text, Celular.Text, Cedula.Text, Ciudad.Text, int.Parse(Edad.Text), "Cliente", Direccion.Text);
            UserDatabaseManager UserDatabaseManager = new UserDatabaseManager("SQLConnection", "[dbo].[Usuarios]");
            bool connection_success = UserDatabaseManager.AddDatabaseRecord(usuario);

            if (connection_success)
            {
                alerta.InnerHtml = Utilities.GenerateBigAlarm("Registro completado!", "El registro de tu cuenta ha terminado con exito.", "Para iniciar sesion da <a href='iniciosesion.aspx' class='alert-link'>click aquí</a>","success");
            }
            else
            {
                alerta.InnerHtml = Utilities.GenerateBigAlarm("Error en tu registro!", "El registro de tu cuenta no ha sido posible de realizarse, esto puede ser debido a problemas con el servidor o a que no llenaste algun campo correctamente.", "Revisa los datos ingresados en el formulario!", "danger");
            }
        }
    }
}