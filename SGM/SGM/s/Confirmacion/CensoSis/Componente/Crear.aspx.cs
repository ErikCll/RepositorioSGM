using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Confirmacion.CensoSis.Componente
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.SistemaComponente componente = new Clase.SistemaComponente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                LlenarDrop();
                chckMedidor.Checked = true;
            }
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["id"] + "");
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdSistema = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;

            if (componente.InsertarAccesorio (IdSistema, Nombre,2))
            {
                string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Index.aspx?id=" + Request.QueryString["id"] + "'";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }

           

        }

        protected void btnGuardar2_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdSistema = Convert.ToInt32(decodedString);
            int IdMedidor =Convert.ToInt32( ddl_Medidor.SelectedValue);

            if (componente.InsertarMedidor(IdSistema, IdMedidor,1))
            {
                string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Index.aspx?id=" + Request.QueryString["id"] + "'";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }



        }

        public void LlenarDrop()
        {
            ddl_Medidor.DataSource = componente.MostrarMedidor();
            ddl_Medidor.DataBind();
            ddl_Medidor.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
    }
}