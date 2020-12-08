using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.s.Competencia
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
            if (accesos.ValidarCompetencia(IdUsuario))
            {
                if (accesos.ValidarCensoActividad(IdUsuario))
                {
                    censoact.Visible = true;

                }

                if (accesos.ValidarCategoriaActividad(IdUsuario))
                {
                    categoriaactividad.Visible = true;

                }

                if (accesos.ValidarCategoriaEmpleado(IdUsuario))
                {
                    categoriaempleado.Visible = true;

                }

                if (accesos.ValidarProgramaCapacitacion(IdUsuario))
                {
                    programacapacitacion.Visible = true;

                }
            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
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