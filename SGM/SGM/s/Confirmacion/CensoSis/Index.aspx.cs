using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Confirmacion.CensoSis
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.SistemaMed sistema = new Clase.SistemaMed();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.s.Site1).IdInstalacion.ToString());
            gridSistema.DataSource = sistema.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
            gridSistema.DataBind();
        }

        protected void gridSistema_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridSistema.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }
        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridSistema_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdSistema = (int)gridSistema.DataKeys[row.RowIndex].Value;
                if (sistema.Eliminar(IdSistema))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdSistema = (int)gridSistema.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdSistema.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }

            else if (e.CommandName == "AgregarCom")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                int IdSistema = (int)gridSistema.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdSistema.ToString())));

                Response.Redirect("Componente/Index.aspx?id=" + encodedString + "");
            }


        }

    }
}