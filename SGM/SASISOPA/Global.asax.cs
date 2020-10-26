using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace SASISOPA
{
    public class Global : System.Web.HttpApplication
    {
        Clase.Correo correo = new Clase.Correo();
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {


            Exception objErr = Server.GetLastError().GetBaseException();
            string mensaje = "<b>Favor de corregir</b><hr><br>" +
        "<br><b>Error in: </b>" + Request.Url.ToString() +
        "<br><b>Error Message: </b>" + objErr.Message.ToString() +
        "<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString() +
               "<br><b>Usuario que ejecutó:</b><br>" + HttpContext.Current.User.Identity.Name.ToString();
            correo.EnviarCorreoError(mensaje);
            Server.ClearError();
            Response.Redirect("~/s/Error.aspx"); //direct user to error page




        }
    }
}