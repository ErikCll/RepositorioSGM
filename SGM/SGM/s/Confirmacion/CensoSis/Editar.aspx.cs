using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Confirmacion.CensoSis
{
    public partial class Editar : System.Web.UI.Page
    {

        Clase.SistemaMed sistema = new Clase.SistemaMed();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                (this.Master as SGM.s.Site1).OcultarDrop = false;
                (this.Master as SGM.s.Site1).OcultarLabel = false;

                LlenarDropInstalacion();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdSistema = Convert.ToInt32(decodedString);
                sistema.LeerDatos(IdSistema);
                txtNombre.Text = sistema.Nombre;
                ddl_Instalacion.SelectedValue = sistema.IdInstalacion;
            }
          
           
        }


        public void LlenarDropInstalacion()

        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SGM.s.Site1).IdSuscripcion.ToString());

            ddl_Instalacion.DataSource = sistema.MostrarInstalacion(IdSuscripcion);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdSistema = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (sistema.Editar(IdSistema, Nombre, IdInstalacion))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}