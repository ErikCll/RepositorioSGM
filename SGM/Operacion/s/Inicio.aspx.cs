using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.Disponibilidad disponibilidad = new Clase.Disponibilidad();
        Clase.Master master = new Clase.Master();
        Clase.Resumen resumen = new Clase.Resumen();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarInfraestructura(Usuario))
            {
                infraestructura.Visible = true;
            }
            if (master.ValidarProduccion(Usuario))
            {
                produccion.Visible = true;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                IndicadorInfraestructura();
                IndicadorProduccion();
            }
        }

        public void IndicadorInfraestructura()
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

        public void IndicadorProduccion()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());

            string Mes = DateTime.Now.AddHours(-5).ToString("MM");
            string Anio = DateTime.Now.AddHours(-5).ToString("yyyy");
            int Mess = Convert.ToInt32(Mes);
            int Anioo = Convert.ToInt32(Anio);

            resumen.LeerDatosHoras(IdInstalacion, Anioo, Mess);
            lblHoras.Text = resumen.PromedioHora;
            double Horas = Convert.ToDouble(lblHoras.Text);
            decimal porcentajeHoras = (int)((10 * Horas) + 20);
            if (Horas.ToString() != "0")
            {
                progresHora.Style.Add("width", porcentajeHoras.ToString() + "%");
            }
            else
            {
                progresHora.Style.Add("width", "0%");
            }

        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}