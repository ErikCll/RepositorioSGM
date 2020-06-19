using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Instalacion
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Instalacion objIns = new Clase.Instalacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdInstalacion = Convert.ToInt32(decodedString);
                objIns.LeerDatos(IdInstalacion);
                txtNombre.Text = objIns.Nombre;
                txtLocalizacion.Text = objIns.Localizacion;
                ddl_Region.SelectedValue = objIns.IdRegion;
            }
        }

        public void LlenarDrop()
        {
            ddl_Region.DataSource = objIns.MostrarRegion();
            ddl_Region.DataBind();
            ddl_Region.Items.Insert(0, new ListItem("[Seleccionar]"));
           
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdInstalacion = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            string Localizacion = txtLocalizacion.Text;
            int IdRegion = Convert.ToInt32(ddl_Region.SelectedValue);
            if (objIns.Editar(IdInstalacion, Nombre, Localizacion, IdRegion)){
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}