using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.Regulador
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Regulador regulador = new Clase.Regulador();
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
            if (accesos.ValidarRegulador3(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdSuscripcion.ToString());
            gridRegulador.DataSource = regulador.Mostrar(txtSearch.Text.Trim(), IdSuscripcion);
            gridRegulador.DataBind();
        }

        protected void gridRegulador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridRegulador.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridRegulador_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdRegulador = (int)gridRegulador.DataKeys[row.RowIndex].Value;
                if (regulador.Eliminar(IdRegulador))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdRegulador = (int)gridRegulador.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdRegulador.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }



         
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }

    }
}