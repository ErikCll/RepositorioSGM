using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Area
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Area area = new Clase.Area();
        Clase.Master master = new Clase.Master();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCatalogo(Usuario))
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
                int IdArea = Convert.ToInt32(decodedString);
                area.LeerDatos(IdArea);
                lblNombre.Text = area.Nombre.ToString();
                lblInstalacion.Text = area.Instalacion.ToString();
                lblCodigo.Text = area.Codigo.ToString();
            }
        }
    }
}