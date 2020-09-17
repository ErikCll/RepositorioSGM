using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.MatrizCatAct
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        Clase.Master master = new Clase.Master();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCompetencia(Usuario))
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
                (this.Master as SGM.s.Site1).OcultarDrop = false;
                (this.Master as SGM.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
                int IdPrograma = Convert.ToInt32(decodedString);
                programa.LeerDatos(IdPrograma);
                txtFecha.Text = programa.FechaEvaluacion;

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
            int IdPrograma = Convert.ToInt32(decodedString);

            string FechaEvaluacion = txtFecha.Text;

            if (programa.Editar(IdPrograma, FechaEvaluacion))
            {

                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }


        }


        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Agregar.aspx?id=" + Request.QueryString["id"] + "&ev=" + Request.QueryString["ev"] + "");
        }

    }
}