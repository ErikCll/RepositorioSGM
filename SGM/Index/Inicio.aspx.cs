using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM
{
    public partial class Inicio : System.Web.UI.Page
    {
       
        Clase.Login login = new Clase.Login();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string Usuario = Page.User.Identity.Name;

                if (login.ValidarSGM(Usuario))
                {
                    SitioSGM.Visible = true;
                }
                if (login.ValidarSASISOPA(Usuario))
                {
                    SitioSASISOPA.Visible = true;
                }
                if (login.ValidarOperacion(Usuario))
                {
                    SitioOperacion.Visible = true;
                }

                if (login.ValidarMantenimiento(Usuario))
                {
                    SitioMantenimiento.Visible = true;

                }

                if (login.ValidarSeguridadIndustrial(Usuario))
                {
                    SitioSeguridad.Visible = true;
                }

                if (login.ValidarAdministracion(Usuario))
                {
                    SitioAdministracion.Visible = true;
                }
            }

        }
    }
}