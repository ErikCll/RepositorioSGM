using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion.s.Almacen.InventarioMaterial
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.InventarioMaterial inventario = new Clase.InventarioMaterial();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarAlmacen(Usuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdMaterial = Convert.ToInt32(decodedString);
                inventario.LeerDatos(IdMaterial);
                lblMaterial.Text = inventario.Material;

                MostrarGrid();
            }
        }
        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdMaterial = Convert.ToInt32(decodedString);
            gridInventario.DataSource = inventario.MostrarDetalle(IdMaterial);
            gridInventario.DataBind();
        }

        protected void gridInventario_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridInventario.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }
        protected void gridInventario_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if(e.Row.RowType == DataControlRowType.DataRow)
            {
               Image img = e.Row.FindControl("imageBarCode") as Image;
                Label code = e.Row.FindControl("lblCode") as Label;
                img.Height = 50;
                img.Width = 50;
                img.ImageUrl= "data:image/png;base64,"+code.Text;

            }
        }

        protected void gridInventario_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdInventario = (int)gridInventario.DataKeys[row.RowIndex].Value;
                if (inventario.Eliminar(IdInventario))
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
        }
    }
}