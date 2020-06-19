using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Actividad actividad = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)                     
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;

                LlenarDropInstalacion();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                actividad.LeerDatos(IdActividad);
                txtNombre.Text = actividad.Nombre;
                ddl_Instalacion.SelectedValue = actividad.IdInstalacion;
                LlenarDropArea();
                ddl_Area.SelectedValue = actividad.IdArea;
            }
        }

        public void LlenarDropInstalacion()

        {
            ddl_Instalacion.DataSource = actividad.MostrarInstalacion();
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]","0"));

        }

        public void LlenarDropArea()

        {
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            ddl_Area.DataSource = actividad.MostrarArea(IdInstalacion);
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (actividad.Editar(IdActividad, Nombre, IdArea))
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