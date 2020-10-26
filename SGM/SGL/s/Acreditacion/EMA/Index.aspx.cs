using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Acreditacion.EMA
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.EMA ema = new Clase.EMA();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarEma(IdUsuario))
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
              
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGL.s.Site1).IdInstalacion.ToString());
            gridAcreditacion.DataSource = ema.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
            gridAcreditacion.DataBind();
        }

        protected void gridAcreditacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAcreditacion.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridAcreditacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdAcreditacion = (int)gridAcreditacion.DataKeys[row.RowIndex].Value;
                if (ema.Eliminar(IdAcreditacion))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdAcreditacion = (int)gridAcreditacion.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdAcreditacion.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }



            else if (e.CommandName == "AgregarVer")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                int IdAcreditacion = (int)gridAcreditacion.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdAcreditacion.ToString())));

                Response.Redirect("Archivo/Index.aspx?id=" + encodedString + "");
            }
        }

        protected void gridAcreditacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IdArchivo = e.Row.FindControl("lblArchivo") as Label;
           
      
                HyperLink lnk = e.Row.FindControl("lnkArchivo") as HyperLink;
                if (Convert.ToInt32(IdArchivo.Text) == 0)
                {
                    lnk.Visible = false;
                }
                lnk.NavigateUrl = "https://er2020.blob.core.windows.net/sgl/Acreditacion/" + IdArchivo.Text.ToString() + ".pdf";






            }
        }
        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}