using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Usuario
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Usuario usuario = new Clase.Usuario();
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
            if (accesos.ValidarUsuario(IdUsuario))
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
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Correo = txtCorreo.Value;
            if (usuario.ValidarCorreo(Correo))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Ya existe un usuario con este correo electrónico.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
            else

            {
                int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);

                string Nombre = txtNombre.Text;
                string ApellidoPaterno = txtApellidoPaterno.Text;
                string ApellidoMaterno = txtApellidoMaterno.Text;
                string Contrasena = txtContrasena.Text;
                if (usuario.Insertar(IdSuscripcion,Nombre,ApellidoPaterno,ApellidoMaterno,Correo,Contrasena))
                {
                    string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                }
            }
        }
    }
}