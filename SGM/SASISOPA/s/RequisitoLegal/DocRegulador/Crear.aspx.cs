using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.DocRegulador
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.DocRegulador docRegulador = new Clase.DocRegulador();
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
            int IdUsuario = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarDocumentoRegulador3(IdUsuario))
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
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                LlenarDrop();


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string Nombre = txtNombre.Text;
            int IdRegulador = Convert.ToInt32(ddl_Regulador.SelectedValue);
            if (docRegulador.Insertar(IdRegulador, Nombre))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdSuscripcion);
            ddl_Regulador.DataSource = docRegulador.MostrarRegulador(IdSuscripcion);
            ddl_Regulador.DataBind();
            ddl_Regulador.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
    }
}