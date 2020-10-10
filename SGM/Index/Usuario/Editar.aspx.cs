using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Usuario
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Usuario usuario = new Clase.Usuario();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdUsuario = Convert.ToInt32(decodedString);
                usuario.LeerDatos(IdUsuario);
                txtNombre.Text = usuario.Nombre;
                txtApellidoPaterno.Text = usuario.ApellidoPaterno;
                txtApellidoMaterno.Text = usuario.ApellidoMaterno;
                txtCorreo.Value = usuario.Correo;
                  
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdUsuario = Convert.ToInt32(decodedString);
            usuario.LeerDatos(IdUsuario);
            string Correo = txtCorreo.Value;

            if (usuario.Correo != Correo)
            {
                if (usuario.ValidarCorreo(Correo))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Ya existe un usuario con este correo electrónico.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else
                {
                    string Nombre = txtNombre.Text;
                    string ApellidoPaterno = txtApellidoPaterno.Text;
                    string ApellidoMaterno = txtApellidoMaterno.Text;

                    if (usuario.Editar(IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, Correo))
                    {
                        string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    }
                }
            }
            else
            {
                string Nombre = txtNombre.Text;
                string ApellidoPaterno = txtApellidoPaterno.Text;
                string ApellidoMaterno = txtApellidoMaterno.Text;

                if (usuario.Editar(IdUsuario, Nombre, ApellidoPaterno, ApellidoMaterno, Correo))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
            }
         
      
        }
    }
}