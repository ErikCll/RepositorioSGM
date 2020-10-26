using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM
{
    public partial class Recuperar : System.Web.UI.Page
    {
        Clase.Login login = new Clase.Login();
        Clase.Correo correo = new Clase.Correo();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            string Correo = txtCorreo.Value;
            //DateTime FechaActual = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);

            if (login.ValidarCorreo(Correo))
            {
                login.LeerDatos(Correo);
                string Contrasena = login.Contrasena;
                string Mensaje = "<!doctype html> <html>" +
             "<body>Tu contraseña es: <b>" + Contrasena + "</b>, se solicitó el día <b>"+ ".</b><hr>";
                if (correo.EnviarCorreo(Correo,Mensaje))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se envió correctamente el correo electrónico.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    txtCorreo.Value = String.Empty;

                }
                else
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Ocurrió un error al enviar el correo electrónico.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                
            }
            else
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "El correo que se ha ingresado no está registrado en el sistema.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
        }
    }
}