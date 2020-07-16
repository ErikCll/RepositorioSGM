using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct.Evaluacion
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
                int IdEvaluacion = Convert.ToInt32( decodedString);

                evaluacion.ObtenerTotalReactivos(IdEvaluacion);
                txtCantidad.Text = evaluacion.TotalReactivos;

            }
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("~/Competencia/CensoAct/Control/Index.aspx?id=" + Request.QueryString["act"] + "");
        }

        protected void Regresar2(Object sender, EventArgs e)
        {
            Response.Redirect("~/Competencia/CensoAct/Evaluacion/Crear.aspx?id=" + Request.QueryString["ctr"] + "&act=" + Request.QueryString["act"] + "");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            evaluacion.ObtenerTotalItems(IdEvaluacion);

            int TotalReactivos = Convert.ToInt32(txtCantidad.Text);
            int TotalItems = Convert.ToInt32(evaluacion.TotalItems);

            if (TotalReactivos>TotalItems)
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "La cantidad de reactivos debe ser menor o igual a "+TotalItems.ToString()+".");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
            else
            {
                if (evaluacion.ModificarEvaluacion(IdEvaluacion, TotalReactivos))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
            }
        }
    }
}