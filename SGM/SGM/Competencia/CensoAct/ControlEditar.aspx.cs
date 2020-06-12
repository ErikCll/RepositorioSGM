using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SGM.Competencia.CensoAct
{
    public partial class ControlEditar : System.Web.UI.Page
    {

        Clase.ActividadControl control = new Clase.ActividadControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdControl = Convert.ToInt32(decodedString);
                control.LeerDatosControl(IdControl);
                txtCodigo.Text = control.Codigo;

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdControl = Convert.ToInt32(decodedString);
            string Codigo = txtCodigo.Text;


            if (control.Editar(IdControl, Codigo))
            {

                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

            }



        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Control.aspx?id=" + Request.QueryString["act"] + "");
        }

    }
}