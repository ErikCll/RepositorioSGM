using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Instalacion
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Instalacion objIns = new Clase.Instalacion();
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
            if (accesos.ValidarInstalacion(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdInstalacion = Convert.ToInt32(decodedString);
                objIns.LeerDatos(IdInstalacion);
                lblNombre.Text = objIns.Nombre.ToString();
                lblRegion.Text = objIns.Region.ToString();
                lblLocalizacion.Text = objIns.Localizacion.ToString();
            }
        }
    }
}