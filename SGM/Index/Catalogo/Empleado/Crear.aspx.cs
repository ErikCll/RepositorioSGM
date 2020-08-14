using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Empleado
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Empleado empleado = new Clase.Empleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                //(this.Master as SGM.Master.Site1).OcultarDrop = false;
                //(this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDrop();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string ApellidoPaterno = txtApellidoPaterno.Text;
            string ApellidoMaterno = txtApellidoMaterno.Text;
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (empleado.Insertar(IdInstalacion, Nombre, ApellidoPaterno,ApellidoMaterno))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }
        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            ddl_Instalacion.DataSource = empleado.MostrarInstalacion(IdSuscripcion);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

    }
}