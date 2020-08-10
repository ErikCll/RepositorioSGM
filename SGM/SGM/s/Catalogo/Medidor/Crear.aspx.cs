using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Medidor
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Medidor medidor = new Clase.Medidor();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDrop();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string VariableMedir = ddl_Variable.SelectedValue;
            int calibracion = Convert.ToInt32(txtCalibracion.Text);
            int verificacion = Convert.ToInt32(txtVerificacion.Text);
            if (medidor.Insertar(Nombre, VariableMedir, calibracion,verificacion))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {
        
            ddl_Variable.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_Variable.Items.Insert(1, new ListItem("Flujo"));
            ddl_Variable.Items.Insert(2, new ListItem("Temperatura"));
            ddl_Variable.Items.Insert(3, new ListItem("Volumen"));
            ddl_Variable.Items.Insert(4, new ListItem("Presión"));


        }
    }
}