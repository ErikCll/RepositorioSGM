using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Actividad
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Actividad actividad = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                actividad.LeerDatos(IdActividad);
                lblNombre.Text = actividad.Nombre.ToString();
                lblArea.Text = actividad.Area.ToString();
                lblCodigo.Text = actividad.Codigo.ToString();
            }
        }
    }
}