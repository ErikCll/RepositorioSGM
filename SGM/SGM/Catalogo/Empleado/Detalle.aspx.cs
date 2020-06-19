using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Empleado
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Empleado empleado = new Clase.Empleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
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