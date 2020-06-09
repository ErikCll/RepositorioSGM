using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Actividad
{
    public partial class Crear : System.Web.UI.Page
    {

        Clase.Actividad objIns = new Clase.Actividad();

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
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (objIns.Insertar(IdArea, Nombre, Codigo))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {
            ddl_Area.DataSource = objIns.MostrarArea();
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
    }
}