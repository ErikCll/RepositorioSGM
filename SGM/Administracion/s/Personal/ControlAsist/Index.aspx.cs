using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion.s.Personal.ControlAsist
{
    public partial class Index : System.Web.UI.Page
    {

        Clase.ControlAsistencia asist = new Clase.ControlAsistencia();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                //(this.Master as SGM.s.Site1).OcultarDrop = false;
                //(this.Master as SGM.s.Site1).OcultarLabel = false;
                DateTime FechaActual = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtFecha.Text = FechaActual.ToString("dd-MM-yyyy");
                MostrarGrid();
            }
        }

        protected void btnConsultar_Click(object sender, EventArgs e)
        {
            

            MostrarGrid();
          
        }

        public void MostrarGrid()
        {
            string Fecha = txtFecha.Text;

            gridAsistencia.DataSource = asist.Mostrar(txtSearch.Text.Trim(), Fecha);
            gridAsistencia.DataBind();
        }

        protected void gridAsistencia_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAsistencia.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridAsistencia_RowCommand(object sender, GridViewCommandEventArgs e)
        {
             if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdUser = (int)gridAsistencia.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdUser.ToString())));
                Response.Redirect("Detalle.aspx?id=" + encodedString + "");
            }
        }
    }
}