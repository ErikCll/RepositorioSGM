using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.Regulador
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Regulador regulador = new Clase.Regulador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;



            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdSuscripcion.ToString());

            string Nombre = txtNombre.Text;
            string NombreCorto = txtNombreCorto.Text;

            if (regulador.Insertar(IdSuscripcion, Nombre, NombreCorto))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }
    }
}