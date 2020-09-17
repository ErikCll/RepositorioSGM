using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Empleado
{
    public partial class Editar : System.Web.UI.Page
    {

        Clase.Empleado empleado = new Clase.Empleado();
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
                //(this.Master as SGM.Master.Site1).OcultarDrop = false;
                //(this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEmpleado = Convert.ToInt32(decodedString);
                empleado.LeerDatos(IdEmpleado);
                txtNombre.Text = empleado.Nombre;
                txtApellidoPaterno.Text = empleado.ApellidoPaterno;
                txtApellidoMaterno.Text = empleado.ApellidoMaterno;
                ddl_Instalacion.SelectedValue = empleado.IdInstalacion;
            }
        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            ddl_Instalacion.DataSource = empleado.MostrarInstalacion(IdSuscripcion);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEmpleado = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            string ApellidoPaterno = txtApellidoPaterno.Text;
            string ApellidoMaterno = txtApellidoMaterno.Text;

            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (empleado.Editar(IdEmpleado, Nombre, ApellidoPaterno, ApellidoMaterno,IdInstalacion))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}