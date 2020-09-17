using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion.s.Almacen.InventarioMaterial
{
    public partial class Index : System.Web.UI.Page
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
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as Administracion.s.Site1).IdSuscripcion.ToString());
            gridMaterial.DataSource = inventario.Mostrar(txtSearch.Text.Trim(), IdSuscripcion);
            gridMaterial.DataBind();
        }

        protected void gridMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMaterial.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }
        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {


         
            if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdMaterial = (int)gridMaterial.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdMaterial.ToString())));

                Response.Redirect("Detalle.aspx?id=" + encodedString + "");
            }

         


        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }

    }
}