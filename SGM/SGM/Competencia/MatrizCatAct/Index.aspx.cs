using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.MatrizCatAct
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.CategoriaActividad categoriaAct = new Clase.CategoriaActividad();
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
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.Master.Site1).IdInstalacion.ToString());

            gridCategoria.DataSource = categoriaAct.Mostrar(txtSearch.Text.Trim(),IdInstalacion);
            gridCategoria.DataBind();

          
        }


        protected void gridCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCategoria.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {

             if (e.CommandName == "AgregarAct")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

                int IdCategoria = (int)gridCategoria.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdCategoria.ToString())));

                Response.Redirect("Agregar.aspx?id=" + encodedString + "");
            }
        }

    }
}