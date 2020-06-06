using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Empleado
{
    public partial class Editar : System.Web.UI.Page
    {

        Clase.Empleado empleado = new Clase.Empleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
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
            ddl_Instalacion.DataSource = empleado.MostrarInstalacion();
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