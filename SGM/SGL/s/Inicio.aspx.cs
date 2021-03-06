﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s
{
    public partial class Inicio : System.Web.UI.Page
    {

        Clase.Accesos accesos = new Clase.Accesos();
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        Clase.ResultadoEvaluacion resultado = new Clase.ResultadoEvaluacion();
        Clase.CRE objacreditacion = new Clase.CRE();
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
            if (accesos.ValidarAcreditacion(IdUsuario))
            {
                acreditacion.Visible = true;
                IndicadorAcreditacion();

            }
            if (accesos.ValidarProcedimientoInstructivo(IdUsuario))
            {
                procedimientoinstructivo.Visible = true;
            }
            if (accesos.ValidarCompetencia(IdUsuario))
            {
                competencia.Visible = true;
                IndicadorCompetencia();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void IndicadorAcreditacion()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGL.s.Site1).IdInstalacion.ToString());
            gridAcreditacion.DataSource = objacreditacion.MostrarCreEma(IdInstalacion);
            gridAcreditacion.DataBind();
        }

        protected void gridAcreditacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IdArchivo = e.Row.FindControl("lblArchivo") as Label;


                HyperLink lnk = e.Row.FindControl("lnkArchivo") as HyperLink;
                if (Convert.ToInt32(IdArchivo.Text) == 0)
                {
                    lnk.Visible = false;
                }


                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdArchivo.Text)));
                lnk.NavigateUrl = "~/s/Acreditacion/Doc.aspx?id=" + encodedString;




            }
        }

        public void IndicadorCompetencia()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGL.s.Site1).IdInstalacion.ToString());
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

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}