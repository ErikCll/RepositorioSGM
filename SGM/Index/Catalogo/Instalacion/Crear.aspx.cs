using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Instalacion
{
    public partial class Crear : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                LlenarDrop();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Localizacion = txtLocalizacion.Text;
            int IdRegion = Convert.ToInt32(ddl_Region.SelectedValue);
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());
            if (objIns.Insertar(IdRegion, Nombre, Localizacion,IdSuscripcion))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {
            ddl_Region.DataSource = objIns.MostrarRegion();
            ddl_Region.DataBind();
            ddl_Region.Items.Insert(0,  new ListItem("[Seleccionar]"));

        }
    }
}