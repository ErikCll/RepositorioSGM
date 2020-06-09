using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Actividad
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Actividad actividad = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                actividad.LeerDatos(IdActividad);
                txtNombre.Text = actividad.Nombre;
                txtCodigo.Text = actividad.Codigo;
                ddl_Area.SelectedValue = actividad.IdArea;
            }
        }

        public void LlenarDrop()
        {
            ddl_Area.DataSource = actividad.MostrarArea();
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            string Codigo = txtCodigo.Text;
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (actividad.Editar(IdActividad, Nombre, Codigo, IdArea))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}