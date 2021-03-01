using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Parametro
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Parametro parametro = new Clase.Parametro();
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

            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion);
            gridEquipo.DataSource = parametro.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
            gridEquipo.DataBind();
        }

        protected void gridEquipo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridEquipo.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridEquipo_RowCommand(object sender, GridViewCommandEventArgs e)
        {


        
            if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdEquipo = (int)gridEquipo.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEquipo.ToString())));
                Label lblFecha = (Label)row.FindControl("lblFecha");
                string encodedString2 = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(lblFecha.Text.ToString())));

                Response.Redirect("Bitacora/Index.aspx?id=" + encodedString + "&fec=" + encodedString2 + "");
            }



        }

    }
}