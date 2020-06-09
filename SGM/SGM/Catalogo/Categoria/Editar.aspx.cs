using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Categoria
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Categoria categoria = new Clase.Categoria();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdCategoria = Convert.ToInt32(decodedString);
                categoria.LeerDatos(IdCategoria);
                txtNombre.Text = categoria.Nombre;
                ddl_Area.SelectedValue = categoria.IdArea;
            }
        }

        public void LlenarDrop()
        {
            ddl_Area.DataSource = categoria.MostrarArea();
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdCategoria = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;

            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (categoria.Editar(IdCategoria, Nombre, IdArea))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}