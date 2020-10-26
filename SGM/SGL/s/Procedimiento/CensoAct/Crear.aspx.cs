using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Procedimiento.CensoAct
{
    public partial class Crear : System.Web.UI.Page
    {

        Clase.Actividad objIns = new Clase.Actividad();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarCensoActividad(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                (this.Master as SGL.s.Site1).OcultarDrop = false;
                (this.Master as SGL.s.Site1).OcultarLabel = false;



            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SGL.s.Site1).IdSuscripcion.ToString());

            string Nombre = txtNombre.Text;
            int TipoSistema = Convert.ToInt32((this.Master as SGL.s.Site1).TipoSistema.ToString());
            if (objIns.Insertar(TipoSistema, Nombre, IdSuscripcion))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

    }
}