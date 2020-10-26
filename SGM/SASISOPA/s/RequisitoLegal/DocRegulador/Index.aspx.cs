using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.DocRegulador
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.DocRegulador docRegulador = new Clase.DocRegulador();
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
            gridDocRegulador.DataSource = docRegulador.Mostrar(txtSearch.Text.Trim(), IdSuscripcion);
            gridDocRegulador.DataBind();
        }

        protected void gridDocRegulador_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridDocRegulador.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridDocRegulador_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdDocRegulador = (int)gridDocRegulador.DataKeys[row.RowIndex].Value;
                if (docRegulador.Eliminar(IdDocRegulador))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdDocRegulador = (int)gridDocRegulador.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdDocRegulador.ToString())));

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