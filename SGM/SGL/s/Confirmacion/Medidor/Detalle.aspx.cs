using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Confirmacion.Medidor
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Medidor medidor = new Clase.Medidor();
        Clase.Accesos accesos = new Clase.Accesos();
        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        ValidarAccesos();
        //    }

        //}

        //public void ValidarAccesos()
        //{
        //    int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
        //    if (accesos.ValidarMedidor(IdUsuario))
        //    {

        //    }
        //    else
        //    {
        //        Response.Redirect("~/s/Inicio.aspx");
        //    }

        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as SGL.s.Site1).OcultarDrop = false;
            (this.Master as SGL.s.Site1).OcultarLabel = false;
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdMedidor = Convert.ToInt32(decodedString);
            medidor.LeerDatos(IdMedidor);
            lblNombre.Text = medidor.Nombre.ToString();
            lblVariable.Text = medidor.VariableMedir.ToString();
            lblCalibracion.Text = medidor.PeriodoCalibracion.ToString();
            lblVerificacion.Text = medidor.PeriodoVerificacion.ToString();
        }
    }
}