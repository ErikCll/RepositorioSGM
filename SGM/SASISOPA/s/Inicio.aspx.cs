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
            if (accesos.ValidarPolitica(IdUsuario))
            {
                politica.Visible = true;

            }

            if (accesos.ValidarRiesgo(IdUsuario))
            {
                riesgo.Visible = true;
            }

            if (accesos.ValidarRequisito(IdUsuario))
            {
                requisito.Visible = true;
            }

            if (accesos.ValidarMeta(IdUsuario))
            {
                meta.Visible = true;
            }

            if (accesos.ValidarFuncion(IdUsuario))
            {
                funcion.Visible = true;
            }

            if (accesos.ValidarCompetencia(IdUsuario))
            {
                competencia.Visible = true;
                IndicadorElemento6();

            }

            if (accesos.ValidarComunicacion(IdUsuario))
            {
                comunicacion.Visible = true;
            }

            if (accesos.ValidarControlDocumento(IdUsuario))
            {
                controldoc.Visible = true;
            }

            if (accesos.ValidarPractica(IdUsuario))
            {
                practica.Visible = true;
            }

            if (accesos.ValidarControlActividad(IdUsuario))
            {
                controlact.Visible = true;
                IndicadorElemento10();

            }

            if (accesos.ValidarIntegridad(IdUsuario))
            {
                integridad.Visible = true;
            }

            if (accesos.ValidarSeguridad(IdUsuario))
            {
                seguridad.Visible = true;
            }

            if (accesos.ValidarRespuesta(IdUsuario))
            {
                respuesta.Visible = true;
            }

            if (accesos.ValidarMonitoreo(IdUsuario))
            {
                monitoreo.Visible = true;
            }

            if (accesos.ValidarAuditoria(IdUsuario))
            {
                auditoria.Visible = true;
            }

            if (accesos.ValidarInvestigacion(IdUsuario))
            {
                investigacion.Visible = true;
            }

            if (accesos.ValidarRevision(IdUsuario))
            {
                revision.Visible = true;
            }

            if (accesos.ValidarInforme(IdUsuario))
            {
                informe.Visible = true;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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