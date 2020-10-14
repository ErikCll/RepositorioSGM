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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarGraficaAct();
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