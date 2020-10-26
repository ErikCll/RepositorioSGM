using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.Regulador
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Regulador regulador = new Clase.Regulador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdRegulador = Convert.ToInt32(decodedString);
                regulador.LeerDatos(IdRegulador);
                txtNombre.Text = regulador.Nombre;
                txtNombreCorto.Text = regulador.NombreCorto;


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdRegulador = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            string NombreCorto = txtNombreCorto.Text;
            if (regulador.Editar(IdRegulador, Nombre,NombreCorto))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }

    }
}