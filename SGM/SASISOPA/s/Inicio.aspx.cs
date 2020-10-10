using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        Clase.ResultadoEvaluacion resultado = new Clase.ResultadoEvaluacion();
        Clase.Actividad actividad = new Clase.Actividad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                IndicadorElemento6();
                IndicadorElemento10();
            }

        }

        public void IndicadorElemento6()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            string Anio = DateTime.Now.ToString("yyyy");
            int Anioo = Convert.ToInt32(Anio);

            programa.LeerDatosIndicador(IdInstalacion, Anioo);
            lblAvanceCapacitacion6.Text = programa.Porcentaje;
            double Porcentaje = Convert.ToDouble(lblAvanceCapacitacion6.Text);
            lblAvanceCapacitacion6.Text = programa.Porcentaje + "%";
            if (Porcentaje.ToString() != "0")
            {
                progressCapacitacion6.Style.Add("width", Porcentaje.ToString() + "%");
            }
            else
            {
                progressCapacitacion6.Style.Add("width", "0%");
            }


            resultado.LeerDatosPromedio(IdInstalacion);
            lblPromedioResultado6.Text = resultado.Promedio;
            double Promedio = Convert.ToDouble(lblPromedioResultado6.Text) * 10;
            if (Promedio.ToString() != "0")
            {
                progressPromedioResultado6.Style.Add("width", Promedio.ToString() + "%");
            }
            else
            {
                progressPromedioResultado6.Style.Add("width", "0%");
            }
        } 


        public void IndicadorElemento10()
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