using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s
{
    public partial class Login : System.Web.UI.Page
    {
        Clase.Login login = new Clase.Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnLogin = (Button)Login1.FindControl("LoginButton");
            Page.Form.DefaultButton = btnLogin.UniqueID;
        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string Usuario = Login1.UserName;
            string Contrasena = Login1.Password;

            if (login.AutenticarUsuario(Usuario, Contrasena))
            {
                login.LeerDatosUsuario(Usuario);
                int IdUsuario = Convert.ToInt32(login.IdUsuario);
                if (login.ValidarSASISOPA(IdUsuario))
                {
                    FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);

                }

                else
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "No cuentas con el acceso para este apartado.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }

            }
            else
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Usuario o contraseña incorrectos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
        }
    }
}