using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM
{
    public partial class Contrasena : System.Web.UI.Page
    {
        Clase.Usuario usuario = new Clase.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            
                if (!IsPostBack)
                {
                    (this.Master as SAM.Site1).OcultarDrop = false;
                    (this.Master as SAM.Site1).OcultarLabel = false;
                }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Correo = Page.User.Identity.Name;
            string ContrasenaActual = txtActual.Text;
            string ContrasenaNueva = txtNueva.Text;

            if (usuario.ValidarContrasena(Correo, ContrasenaActual))
            {
                if (usuario.EditarContrasena(Correo, ContrasenaNueva, ContrasenaActual))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se cambió la contraseña correctamente.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
            }
            else
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "La contraseña actual es incorrecta.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}