using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM
{
    public partial class Login : System.Web.UI.Page
    {
        Clase.Login login = new Clase.Login();

        protected void Page_Load(object sender, EventArgs e)
        {
            Button btnLogin  = (Button)Login1.FindControl("LoginButton");
            Page.Form.DefaultButton = btnLogin.UniqueID;




        }

        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string Usuario = Login1.UserName;
            string Contrasena = Login1.Password;

            if (login.AutenticarUsuario(Usuario, Contrasena))
            {
                FormsAuthentication.RedirectFromLoginPage(Login1.UserName, Login1.RememberMeSet);


            }
            else
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Usuario o contraseña incorrectos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
        }
    }
}