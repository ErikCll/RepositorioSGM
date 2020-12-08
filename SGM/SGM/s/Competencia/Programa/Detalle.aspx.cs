using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.Programa
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarProgramaCapacitacion(IdUsuario))
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

            gridActividad.DataSource = programa.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
            gridActividad.DataBind();


        }

        protected void gridActividad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridActividad.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridActividad_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "AgregarEv")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdActividad.ToString())));

                Label IdEvidencia = (Label)row.FindControl("lblIdEvaluacion");

                string encodedString2 = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEvidencia.Text.ToString())));


                Response.Redirect("Agregar.aspx?id=" + encodedString + "&ev=" + encodedString2 + "");
            }
        }

        protected void gridActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdActividad = (int)gridActividad.DataKeys[e.Row.RowIndex].Value;
                Label IdEvaluacion = e.Row.FindControl("lblIdEvaluacion") as Label;
                Label lblActividad = e.Row.FindControl("lblActividad") as Label;
                LinkButton lnkActividad = e.Row.FindControl("lnkActividad") as LinkButton;

                if (IdEvaluacion.Text == "")
                {

                    lblActividad.Visible = true;
                }
                else
                {
                    lnkActividad.Visible = true;
                }

            }
        }
    }
}