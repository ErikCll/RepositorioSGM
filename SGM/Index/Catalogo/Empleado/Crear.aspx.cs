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
        Clase.Accesos accesos = new Clase.Accesos();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }

        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (accesos.ValidarEmpleado(IdUsuario))
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
                LlenarDropSexo();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string ApellidoPaterno = txtApellidoPaterno.Text;
            string ApellidoMaterno = txtApellidoMaterno.Text;
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            string NoEmpleado = txtNoEmpleado.Text;
            string FechaNacimiento = txtFecha.Text;
            string Sexo = ddl_Sexo.SelectedValue;
            string Direccion = txtDireccion.Text;
            if (empleado.Insertar(IdInstalacion, Nombre, ApellidoPaterno,ApellidoMaterno,NoEmpleado,FechaNacimiento,Sexo,Direccion))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }
        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario);

            ddl_Instalacion.DataSource = empleado.MostrarInstalacion(IdSuscripcion,IdUsuario);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }


        public void LlenarDropSexo()
        {

            ddl_Sexo.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_Sexo.Items.Insert(1, new ListItem("M"));
            ddl_Sexo.Items.Insert(1, new ListItem("F"));





        }

    }
}