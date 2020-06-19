using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Area
{
    
    public partial class Index : System.Web.UI.Page
    {
        Clase.Area area = new Clase.Area();
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
            gridArea.DataSource = area.Mostrar(txtSearch.Text.Trim());
            gridArea.DataBind();
        }

        protected void gridArea_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridArea.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }


        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridArea_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdArea = (int)gridArea.DataKeys[row.RowIndex].Value;
                if (area.Eliminar(IdArea))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "ocurrio un error.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdArea = (int)gridArea.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdArea.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }

            else if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdArea = (int)gridArea.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdArea.ToString())));

                Response.Redirect("Detalle.aspx?id=" + encodedString + "");
            }
        }
    }
}