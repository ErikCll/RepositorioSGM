using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Infraestructura
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.Disponibilidad disponibilidad = new Clase.Disponibilidad();
        Clase.Accesos accesos = new Clase.Accesos();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

            }
        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as Operacion.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarInfraestructura(IdUsuario))
            {
                if (accesos.ValidarDisponibilidadDeEquipos(IdUsuario))
                {
                    disponibilidadequipos.Visible = true;
                    IndicadorDisponibilidad();

                }
            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }
          

        }
        public void IndicadorDisponibilidad()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            disponibilidad.LeerDatosTotalEquipos(IdInstalacion);
            lblTotal.Text = disponibilidad.TotalEquipos;
            disponibilidad.LeerDatosTotalOperando(IdInstalacion);
            lblOperando.Text = disponibilidad.TotalEquiposOperando;
            string Mes = DateTime.Now.AddHours(-5).ToString("MM");
            string Anio = DateTime.Now.AddHours(-5).ToString("yyyy");
            decimal Operando = Convert.ToDecimal(lblOperando.Text);
            decimal Total = Convert.ToDecimal(lblTotal.Text);

            if (Operando == 0 && Total == 0)
            {
                lblPorcentaje.Text = "0";
                divprogress1.Style.Add("width", "0%");

            }
            else
            {
                decimal porcentaje = (int)((100 * Operando) / Total);
                lblPorcentaje.Text = porcentaje.ToString();
                int val = (int)((100 * Operando) / Total);

                divprogress1.Style.Add("width", val.ToString() + "%");

            }
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}