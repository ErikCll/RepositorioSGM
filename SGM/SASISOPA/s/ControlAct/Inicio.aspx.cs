using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.ControlAct
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.Actividad actividad = new Clase.Actividad();

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
            int IdUsuario = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarControlActividad(IdUsuario))
            {
                if (accesos.ValidarCensoActividad10(IdUsuario))
                {
                    censoactividad.Visible = true;
                    MostrarGraficaAct();

                }

                if (accesos.ValidarInstalacionActividad10(IdUsuario))
                {
                    instalacionactividad.Visible = true;
                }


            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
        }

        public void MostrarGraficaAct()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            graficaAct.DataSource = actividad.MostrarGrafica(IdInstalacion);
            graficaAct.DataBind();

        }
        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}