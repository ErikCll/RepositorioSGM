using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.Competencia
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        Clase.ResultadoEvaluacion resultado = new Clase.ResultadoEvaluacion();

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
            if (accesos.ValidarCompetencia(IdUsuario))
            {
                if (accesos.ValidarProgramaCapacitacion6(IdUsuario))
                {
                    programacapacitacion.Visible = true;
                    IndicadorProgramaCapacitacion();

                }

                if (accesos.ValidarResultadoEvaluacion6(IdUsuario))
                {
                    resultadoevaluacion.Visible = true;
                    IndicadorResultadoEvaluacion();
                }


                if (accesos.Configuracion6(IdUsuario))
                {
                    configuracion.Visible = true;
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

        public void IndicadorProgramaCapacitacion()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            string Anio = DateTime.Now.ToString("yyyy");
            int Anioo = Convert.ToInt32(Anio);

            programa.LeerDatosIndicador(IdInstalacion, Anioo);
            lblPorcentajeCapacitacion.Text = programa.Porcentaje;
            double Porcentaje = Convert.ToDouble(lblPorcentajeCapacitacion.Text);

            if (Porcentaje.ToString() != "0")
            {
                progressCapacitacion.Style.Add("width", Porcentaje.ToString() + "%");
            }
            else
            {
                progressCapacitacion.Style.Add("width", "0%");
            }
        }

        public void IndicadorResultadoEvaluacion()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            string Anio = DateTime.Now.ToString("yyyy");
            int Anioo = Convert.ToInt32(Anio);
            resultado.LeerDatosPromedio(IdInstalacion);
            lblPromedio.Text = resultado.Promedio;
            double Promedio = Convert.ToDouble(lblPromedio.Text) * 10;
            if (Promedio.ToString() != "0")
            {
                progressPromedio.Style.Add("width", Promedio.ToString() + "%");
            }
            else
            {
                progressPromedio.Style.Add("width", "0%");
            }
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}