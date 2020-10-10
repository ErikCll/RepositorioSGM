using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.Resumen resumen = new Clase.Resumen();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IndicadorHoras();
            }
        }
        public void IndicadorHoras()
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