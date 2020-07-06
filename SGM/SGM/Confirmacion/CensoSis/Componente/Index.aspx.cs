using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Confirmacion.CensoSis.Componente
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.SistemaComponente componente = new Clase.SistemaComponente();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdSistema = Convert.ToInt32(decodedString);
                componente.LeerDatosSistema(IdSistema);
                lblCensoSistema.Text = componente.Sistema;
            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdSistema = Convert.ToInt32(decodedString);
            gridComponente.DataSource = componente.Mostrar(IdSistema);
            gridComponente.DataBind();
        }

        protected void gridComponente_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridComponente.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }
        protected void CrearComponente(Object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void gridComponente_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdComponente = (int)gridComponente.DataKeys[row.RowIndex].Value;
                if (componente.Eliminar(IdComponente))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdComponente = (int)gridComponente.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdComponente.ToString())));


                Response.Redirect("Editar.aspx?id=" + encodedString + "&sis=" + Request.QueryString["id"] + "");
            }
      


        }

    }
}