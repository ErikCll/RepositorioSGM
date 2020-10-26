using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Empleado
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Empleado empleado = new Clase.Empleado();
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
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (accesos.ValidarEmpleado(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEmpleado = Convert.ToInt32(decodedString);
                empleado.LeerDatos(IdEmpleado);
                lblNombre.Text = empleado.Nombre.ToString();
                lblApellidoPaterno.Text = empleado.ApellidoPaterno.ToString();
                lblApellidoMaterno.Text = empleado.ApellidoMaterno.ToString();
                lblInstalacion.Text = empleado.Instalacion.ToString();
                lblCreacionFecha.Text = empleado.CreacionFecha.ToString();
            }
        }
    }
}