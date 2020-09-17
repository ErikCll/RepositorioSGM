using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion.s.Personal.ControlAsist
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.ControlAsistencia asist = new Clase.ControlAsistencia();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarPersonal(Usuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnConsultar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as Administracion.s.Site1).OcultarDrop = false;
                (this.Master as Administracion.s.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdUsuario = Convert.ToInt32(decodedString);
                asist.LeerDatosEmpleado(IdUsuario);
                lblEmpleado.Text = asist.Empleado;

                DateTime FechaActual = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtFechaInicial.Text = FechaActual.ToString("dd-MM-yyyy");

                txtFechaFinal.Text = FechaActual.ToString("dd-MM-yyyy");


                MostrarGrid();


            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdUsuario = Convert.ToInt32(decodedString);

            DateTime FechaInicial = DateTime.ParseExact(txtFechaInicial.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
            DateTime FechaFinal = DateTime.ParseExact(txtFechaFinal.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);


            gridAsistenciaEmpleado.DataSource = asist.MostrarAsistenciaEmpleado(IdUsuario, FechaInicial.ToString("yyyy-MM-dd"), FechaFinal.ToString("yyyy-MM-dd"));
            gridAsistenciaEmpleado.DataBind();
        }

        protected void gridAsistenciaEmpleado_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAsistenciaEmpleado.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            MostrarGrid();
        }
    }
}