using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Cliente
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Cliente cliente = new Clase.Cliente();
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
            if (accesos.ValidarCliente(IdUsuario))
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
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (cliente.Insertar(IdInstalacion, Nombre))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario);

            ddl_Instalacion.DataSource = cliente.MostrarInstalacion(IdSuscripcion,IdUsuario);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
    }
}