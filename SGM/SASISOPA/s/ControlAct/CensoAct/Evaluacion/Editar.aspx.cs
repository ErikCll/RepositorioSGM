using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.ControlAct.CensoAct.Evaluacion
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
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
            if (accesos.ValidarCensoActividad10(IdUsuario))
            {

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
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
                int IdEvaluacion = Convert.ToInt32( decodedString);

                evaluacion.ObtenerTotalReactivos(IdEvaluacion);
                txtCantidad.Text = evaluacion.TotalReactivos;
                txtRange2.Value = evaluacion.CalMinima;
                range.Value = evaluacion.CalMinima;

            }
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("~/s/ControlAct/CensoAct/Control/Index.aspx?id=" + Request.QueryString["act"] + "");
        }

        protected void Regresar2(Object sender, EventArgs e)
        {
            Response.Redirect("~/s/ControlAct/CensoAct/Evaluacion/Crear.aspx?id=" + Request.QueryString["ctr"] + "&act=" + Request.QueryString["act"] + "");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            evaluacion.ObtenerTotalItems(IdEvaluacion);
            evaluacion.ObtenerEstatus(IdEvaluacion);
            int TotalReactivos = Convert.ToInt32(txtCantidad.Text);
            int CalMinima = Convert.ToInt32(txtRange2.Value);
            string Estatus = evaluacion.Estatus;

            if (Estatus == "1")
            {
                if (evaluacion.ModificarEvaluacion(IdEvaluacion, TotalReactivos, CalMinima))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
            }
            else
            {
                int TotalItems = Convert.ToInt32(evaluacion.TotalItems);

                if (TotalReactivos > TotalItems)
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "La cantidad de reactivos debe ser menor o igual a " + TotalItems.ToString() + ".");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else
                {
                    if (evaluacion.ModificarEvaluacion(IdEvaluacion, TotalReactivos, CalMinima))
                    {
                        string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    }
                }
            }
           
        }
    }
}