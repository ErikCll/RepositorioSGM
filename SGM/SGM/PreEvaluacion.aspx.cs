using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct.Evaluacion
{
    public partial class PreEvaluacion : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //string Clave = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(txtClave.Text));
            string Clave = txtClave.Text;

            if (programa.ValidarClave(Clave))
            {
                int Id_Programa = Convert.ToInt32( System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(txtClave.Text)));

                programa.LeerDatosPrograma(Id_Programa);
                programa.EditarIngreso(Id_Programa);

                string IdPrograma = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Id_Programa.ToString())));
                string IdEmpleado = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(programa.Id_Empleado.ToString())));
                string IdEvaluacion = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(programa.Id_Evaluacion.ToString())));
                //string script = "window.close();";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", script, true);
                txtClave.Text = string.Empty;
                RadWindow1.NavigateUrl = "Evaluacion.aspx?ev=" + IdEvaluacion + "&emp=" + IdEmpleado + "&prog=" + IdPrograma + "";
                RadWindow1.VisibleOnPageLoad = true;
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('Evaluacion.aspx?ev=" +IdEvaluacion + "&emp="+IdEmpleado +"&prog="+IdPrograma+"','mywindow','menubar=1,resizable=1');", true);
            }
            else
            {
                RadWindow1.VisibleOnPageLoad = false;
                string txtJS = String.Format("<script>alert('{0}');</script>", "La Clave es incorrecta o la Evaluación no esta disponible.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}