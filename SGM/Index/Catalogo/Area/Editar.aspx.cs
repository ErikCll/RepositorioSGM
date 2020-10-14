using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Area
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Area area = new Clase.Area();
        Clase.Master master = new Clase.Master();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCatalogo(Usuario))
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
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            string Usuario = Page.User.Identity.Name;

            ddl_Instalacion.DataSource = area.MostrarInstalacion(IdSuscripcion,Usuario);
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