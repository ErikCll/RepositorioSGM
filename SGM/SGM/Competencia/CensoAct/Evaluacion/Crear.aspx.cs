using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class CrearEv : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdControl = Convert.ToInt32(decodedString);
                evaluacion.LeerDatosControl(IdControl);
                lblCodigo.Text = evaluacion.Codigo;
            }
        }


        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("~/Competencia/CensoAct/Control/Index.aspx?id=" + Request.QueryString["act"] + "");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdControl = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            if (evaluacion.Insertar(IdControl, Nombre))
            {
                //string script = "alert('Evaluación creada exitosamente.'); window.location.href= 'Index.aspx';";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                evaluacion.ObtenerIdEvaluacion(IdControl);


                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(evaluacion.IdEvaluacion.ToString())));

                Response.Redirect("CrearCuestionario.aspx?ev=" + encodedString+ "");
            }
        }
    }
}