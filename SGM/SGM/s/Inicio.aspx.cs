using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.s
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.Accesos accesos = new Clase.Accesos();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }
        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarCatalogo(IdUsuario))
            {
                catalogo.Visible = true;
            }
            if (accesos.ValidarCompetencia(IdUsuario))
            {
                competencia.Visible = true;
            }
            if (accesos.ValidarConfirmacion(IdUsuario))
            {
                confirmacion.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}