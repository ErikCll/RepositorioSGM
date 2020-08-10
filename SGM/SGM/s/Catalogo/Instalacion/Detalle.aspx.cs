using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Instalacion
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Instalacion objIns = new Clase.Instalacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
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