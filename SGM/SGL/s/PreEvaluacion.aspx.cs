using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s
{
    public partial class PreEvaluacion : System.Web.UI.Page
    {

        static int Id_programaG;
        static int Id_EmpleadoG;
        static int Id_EvaluacionG;
        static string FechaEvaluacionG;
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        protected void Page_Load(object sender, EventArgs e)
        {


            if (!IsPostBack)
            {

            }
        }

        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            //string Clave = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(txtClave.Text));
            string Clave = txtClave.Text;

            if (programa.ValidarClave(Clave))
            {
                int Id_Programa = Convert.ToInt32(System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(txtClave.Text)));
                Id_programaG = Id_Programa;
                programa.LeerDatosPrograma(Id_Programa);
                programa.EditarIngreso(Id_Programa);

                Id_EmpleadoG = Convert.ToInt32(programa.Id_Empleado);
                Id_EvaluacionG = Convert.ToInt32(programa.Id_Evaluacion);
                FechaEvaluacionG = programa.FechaEvaluacion;

                btnValidar2_Click(null, null);

                string IdPrograma = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Id_programaG.ToString())));
                string IdEmpleado = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(programa.Id_Empleado.ToString())));
                string IdEvaluacion = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(programa.Id_Evaluacion.ToString())));
                //string script = "window.close();";
                //ScriptManager.RegisterStartupScript(Page, Page.GetType(), "closewindows", script, true);
                RadWindow1.NavigateUrl = "Evaluacion.aspx?ev=" + IdEvaluacion + "&emp=" + IdEmpleado + "&prog=" + IdPrograma + "";
                RadWindow1.VisibleOnPageLoad = true;
                //ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('Evaluacion.aspx?ev=" +IdEvaluacion + "&emp="+IdEmpleado +"&prog="+IdPrograma+"','mywindow','menubar=1,resizable=1');", true);
            }
            else
            {
                RadWindow1.VisibleOnPageLoad = false;
                string txtJS = String.Format("<script>alert('{0}');</script>", "La Clave es incorrecta o la Evaluación no está disponible.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
        }

        protected void btnValidar2_Click(object sender, EventArgs e)
        {
            RadWindow1.VisibleOnPageLoad = false;
            if (programa.ValidarRealizado(Id_programaG))
            {
                programa.EliminarValidacion(Id_programaG);
                if (programa.Insertar(Id_EvaluacionG, Id_EmpleadoG, FechaEvaluacionG))
                {

                    programa.ObtenerIdPrograma(Id_EvaluacionG, Id_EmpleadoG);
                    int IdPrograma = Convert.ToInt32(programa.Id_Programa);
                    Id_programaG = IdPrograma;
                    string Clave = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdPrograma.ToString())));
                    
                    programa.EditarPrograma(IdPrograma, Clave);


                }
            }
        }
    }
}