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
            if (!IsPostBack)
            {
                LlenarDropTipoFalla();
            }
        }

        public void MostrarGrid()
        {
            int TipoFalla = Convert.ToInt32(ddl_TipoFalla.SelectedValue);
            gridDescripcion.DataSource = bitacora.MostrarDescripcionFalla(TipoFalla);
            gridDescripcion.DataBind();

        }

        public void LlenarDropTipoFalla()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdSuscripcion.ToString());
            ddl_TipoFalla.DataSource = bitacora.MostrarTipoFalla(IdSuscripcion);
            ddl_TipoFalla.DataBind();
            int Total=  Convert.ToInt32( ddl_TipoFalla.Items.Count)+1;
            ddl_TipoFalla.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_TipoFalla.Items.Insert(Total, new ListItem("[Otra]","0"));
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            DateTime Hora = txtHora.SelectedDate.Value;
            string hora = Hora.ToString("HH:mm:ss");
            string fecha = txtFecha.Text;

            string FechaHora = fecha +" "+ hora;

            int TipoFalla = Convert.ToInt32(ddl_TipoFalla.SelectedValue);
            string Descripcion = txtDesc.Value;

            if (bitacora.Insertar(IdEquipo,FechaHora,TipoFalla,Descripcion))
            {
                string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Index.aspx?id=" + Request.QueryString["id"] + "'";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }

        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void ddl_TipoFalla_SelectedIndexChanged(object sender, EventArgs e)
        {

            string Falla = ddl_TipoFalla.SelectedValue;
            if (Falla == "[Seleccionar]")
            {

                divDescripcion.Visible = false;
                divInformacion.Visible = false;
                reqDescripcion.Enabled = false;
            }
            else
            {
                int TipoFalla = Convert.ToInt32(ddl_TipoFalla.SelectedValue);
                if (TipoFalla == 0)
                {
                    divDescripcion.Visible = true;
                    divInformacion.Visible = false;
                    reqDescripcion.Enabled = true;

                }
                else
                {
                    MostrarGrid();
                    divDescripcion.Visible = false;
                    divInformacion.Visible = true;
                    reqDescripcion.Enabled = false;
                }

            }



        }
    }
}