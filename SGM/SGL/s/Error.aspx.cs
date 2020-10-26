using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s
{
    public partial class Error : System.Web.UI.Page
    {
        Clase.Correo correo = new Clase.Correo();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            //    Exception objErr = (Exception)Application["TheException"];
            //    string mensaje = "<b>Favor de corregir</b><hr><br>" +
            //"<br><b>Error in: </b>" + Session["URL"].ToString() +
            //"<br><b>Error Message: </b>" + objErr.Message.ToString() +
            //"<br><b>Stack Trace:</b><br>" + objErr.StackTrace.ToString() +
            //   "<br><b>Usuario que ejecutó:</b><br>" + Page.User.Identity.Name.ToString();
            //    correo.EnviarCorreoError(mensaje);
            //    Server.ClearError();
            }
        }

        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}