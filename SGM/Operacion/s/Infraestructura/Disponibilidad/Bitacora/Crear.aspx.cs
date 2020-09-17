using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Infraestructura.Disponibilidad.Bitacora
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Bitacora bitacora = new Clase.Bitacora();

        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarInfraestructura(Usuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            DateTime Hora = txtHora.SelectedDate.Value;
            string hora = Hora.ToString("HH:mm:ss");
            string fecha = txtFecha.Text;

            string FechaHora = fecha +" "+ hora;

            string Descripcion = txtDesc.Value;


            if (bitacora.Insertar(IdEquipo,FechaHora,Descripcion))
            {
                string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Index.aspx?id=" + Request.QueryString["id"] + "'";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }

        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["id"] + "");
        }
    }
}