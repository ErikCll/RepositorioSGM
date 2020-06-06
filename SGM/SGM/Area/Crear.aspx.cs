using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Area
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Area objIns = new Clase.Area();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrop();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Codigo = txtCodigo.Text;
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (objIns.Insertar(IdInstalacion, Nombre, Codigo))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {
            ddl_Instalacion.DataSource = objIns.MostrarInstalacion();
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
    }
}