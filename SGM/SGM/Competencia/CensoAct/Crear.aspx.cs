using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class Crear : System.Web.UI.Page
    {

        Clase.Actividad objIns = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;



                LlenarDropInstalacion();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (objIns.Insertar(IdArea, Nombre))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDropInstalacion()
        {
            ddl_Instalacion.DataSource = objIns.MostrarInstalacion();
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]","0"));
        }

        public void LlenarDropArea()
        {
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            ddl_Area.DataSource = objIns.MostrarArea(IdInstalacion);
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]"));
        }

        protected void ddl_Instalacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropArea();
        }
    }
}