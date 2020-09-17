using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.MatrizCatEmp
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.CategoriaEmpleado categoriaEmp = new Clase.CategoriaEmpleado();
        Clase.Master master = new Clase.Master();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCompetencia(Usuario))
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
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.s.Site1).IdInstalacion.ToString());

            gridCategoria.DataSource = categoriaEmp.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
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