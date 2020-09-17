using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.Competencia.CensoAct
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Actividad actividad = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                     
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                actividad.LeerDatos(IdActividad);
                txtNombre.Text = actividad.Nombre;
          
            }
        }

       

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            if (actividad.Editar(IdActividad, Nombre))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }

     
    }
}