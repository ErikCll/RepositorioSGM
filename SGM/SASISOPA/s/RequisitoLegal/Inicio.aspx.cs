using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal
{
    public partial class Inicio : System.Web.UI.Page
    {

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
            if (accesos.ValidarRequisito(IdUsuario))
            {
                int contador = 0;
                if (accesos.ValidarRegulador3(IdUsuario))
                {
                    //regulador.Visible = true;
                    lnkRegulador.Visible = true;
                    contador++;
                }

                if (accesos.ValidarDocumentoRegulador3(IdUsuario))
                {
                    //documentoregulador.Visible = true;
                    lnkDocRegulador.Visible = true;
                    contador++;
                }

                if (accesos.ValidarRequisito3(IdUsuario))
                {
                    //requisito.Visible = true;
                    lnkRequisito.Visible = true;
                    contador++;
                }
                if (contador>0)
                {
                    configuracion.Visible = true;
                }
                else
                {
                    configuracion.Visible = false;
                }
            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}