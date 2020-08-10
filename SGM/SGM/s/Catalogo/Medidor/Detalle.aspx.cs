using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Medidor
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Medidor medidor = new Clase.Medidor();
        protected void Page_Load(object sender, EventArgs e)
        {
            (this.Master as SGM.Master.Site1).OcultarDrop = false;
            (this.Master as SGM.Master.Site1).OcultarLabel = false;
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