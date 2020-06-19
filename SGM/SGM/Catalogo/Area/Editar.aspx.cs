using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Area
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Area area = new Clase.Area();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdArea = Convert.ToInt32(decodedString);
                area.LeerDatos(IdArea);
                txtNombre.Text = area.Nombre;
                txtCodigo.Text = area.Codigo;
                ddl_Instalacion.SelectedValue = area.IdInstalacion;
            }
        }
        public void LlenarDrop()
        {
            ddl_Instalacion.DataSource = area.MostrarInstalacion();
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdArea = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            string Codigo = txtCodigo.Text;
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (area.Editar(IdArea, Nombre, Codigo, IdInstalacion))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}