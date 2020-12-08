using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.Programa
{
    public partial class Ver : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarProgramaCapacitacion(IdUsuario))
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
                programa.LeerDatosProgramaEvaluacion(IdPrograma);
                lblEmpleado.Text = programa.Empleado;
                lblActividad.Text = programa.Actividad;
                lblEstatus.Text = programa.Estatus;
                lblFechaEvaluacion.Text = programa.FechaEvaluacion;
                lblFechaRealizado.Text = programa.FechaRealizado;
                lblCalificacion.Text = programa.Calificacion;
            }
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Agregar.aspx?id=" + Request.QueryString["id"] + "&ev="+ Request.QueryString["ev"] + "");
        }
    }
}