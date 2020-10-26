using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Procedimiento
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
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarProcedimientoInstructivo(IdUsuario))
            {
                if (accesos.ValidarCensoActividad(IdUsuario))
                {
                    censoactividad.Visible = true;
                    MostrarGraficaAct();

                }
                if (accesos.ValidarInstalacionActividad(IdUsuario))
                {
                    instalacionactividad.Visible = true;

                }

                if (accesos.ValidarCategoriaActividad(IdUsuario))
                {
                    categoriaactividad.Visible = true;

                }

                if (accesos.ValidarCategoriaEmpleado(IdUsuario))
                {
                    categoriaempleado.Visible = true;

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
            int IdInstalacion = Convert.ToInt32((this.Master as SGL.s.Site1).IdInstalacion.ToString());
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