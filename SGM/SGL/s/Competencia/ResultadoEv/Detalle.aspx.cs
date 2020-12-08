using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Competencia.ResultadoEv
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.ResultadoEvaluacion resultado = new Clase.ResultadoEvaluacion();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarResultadoEvaluacion(IdUsuario))
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
                (this.Master as SGL.s.Site1).OcultarDrop = false;
                (this.Master as SGL.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEmpleado = Convert.ToInt32(decodedString);
                resultado.LeerDatosEmpleado(IdEmpleado);
                lblEmpleado.Text = resultado.Empleado;
                MostrarGrid();
            }

        }

        public void MostrarGrid()
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEmpleado = Convert.ToInt32(decodedString);
            gridResultadoDetalle.DataSource = resultado.MostrarDetalle(IdEmpleado);
            gridResultadoDetalle.DataBind();
        }


        protected void gridResultadoDetalle_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridResultadoDetalle.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }


    

    }
}