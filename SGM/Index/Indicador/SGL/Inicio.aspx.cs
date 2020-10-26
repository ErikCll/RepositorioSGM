using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Indicador.SGL
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.IndicadorSGL indicadorSGL = new Clase.IndicadorSGL();
        Clase.Login login = new Clase.Login();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }
        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (login.ValidarSGL(IdUsuario))
            {
                if (indicadorSGL.ValidarAcreditacion(IdUsuario))
                {
                    acreditaciones.Visible = true;
                    IndicadorSGLAcreditacion();

                }

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
            }
        }


        public void IndicadorSGLAcreditacion()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());
            indicadorSGL.LeerDatosTotalInstalacionAcreditacion(IdSuscripcion);
            lblTotal.Text = indicadorSGL.TotalInstalacion;
            indicadorSGL.LeerDatosTotalDisponibleAcreditacion(IdSuscripcion);
            lblDisponible.Text = indicadorSGL.TotalDisponible;
            decimal Disponible = Convert.ToDecimal(lblDisponible.Text);
            decimal Total = Convert.ToDecimal(lblTotal.Text);
            if (Disponible == 0 && Total == 0)
            {
                lblPorcentajeAcreditacion.Text = "0";
                progressAcreditacion.Style.Add("width", "0%");

            }
            else
            {
                decimal porcentaje = (int)((100 * Disponible) / Total);
                lblPorcentajeAcreditacion.Text = porcentaje.ToString();
                int val = (int)((100 * Disponible) / Total);

                progressAcreditacion.Style.Add("width", val.ToString() + "%");

            }
        }
    }
}