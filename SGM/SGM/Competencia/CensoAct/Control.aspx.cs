using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SGM.Competencia.CensoAct
{
    public partial class Control : System.Web.UI.Page
    {
        Clase.ActividadControl control = new Clase.ActividadControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                control.LeerDatosActividad(IdActividad);
                lblCensoAct.Text = control.Actividad;
            }
             

        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            gridControl.DataSource = control.Mostrar(IdActividad);
            gridControl.DataBind();
        }

        protected void gridControl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridControl.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void CrearVersion(Object sender, EventArgs e)
        {
            Response.Redirect("CrearControl.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void gridControl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdControl = (int)gridControl.DataKeys[e.Row.RowIndex].Value;

                HyperLink lnk = e.Row.FindControl("lnk") as HyperLink;
                lnk.NavigateUrl = "https://er2020.blob.core.windows.net/controlvers/" + IdControl.ToString() + ".pdf";

            }
        }

        protected void gridControl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                if (control.Eliminar(IdControl))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
              


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdControl.ToString())));


                Response.Redirect("ControlEditar.aspx?id=" + encodedString + "&act="+ Request.QueryString["id"] + "");
            }

        }
    }
}