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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
                disponibilidad.LeerDatosTotalEquipos(IdInstalacion);
                lblTotal.Text = disponibilidad.TotalEquipos;
                disponibilidad.LeerDatosTotalOperando(IdInstalacion);
                lblOperando.Text = disponibilidad.TotalEquiposOperando;

                decimal Operando = Convert.ToDecimal(lblOperando.Text );
                decimal Total = Convert.ToDecimal(lblTotal.Text);

                if(Operando==0 && Total == 0)
                {
                    lblPorcentaje.Text = "0";
                }
                else
                {
                    decimal porcentaje = (int)((100 * Operando) / Total);
                    lblPorcentaje.Text = porcentaje.ToString();
                    int val = (int)((100 * Operando) / Total);

                    divprogress1.Style.Add("width", val.ToString() + "%");

                }




            }
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}