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
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDropInstalacion();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdCategoria = Convert.ToInt32(decodedString);
                categoria.LeerDatos(IdCategoria);
                txtNombre.Text = categoria.Nombre;
                ddl_Instalacion.SelectedValue = categoria.IdInstalacion;
                LlenarDropArea();
                ddl_Area.SelectedValue = categoria.IdArea;
            }
        }

        public void LlenarDropInstalacion()

        {
            ddl_Instalacion.DataSource = categoria.MostrarInstalacion();
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        public void LlenarDropArea()

        {
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            ddl_Area.DataSource = categoria.MostrarArea(IdInstalacion);
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

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
        protected void ddl_Instalacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropArea();
        }
    }
}