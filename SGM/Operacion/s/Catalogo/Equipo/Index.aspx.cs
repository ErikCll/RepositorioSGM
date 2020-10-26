using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Catalogo.Equipo
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Equipo equipo = new Clase.Equipo();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            //if (master.ValidarCatalogo(Usuario))
            //{

            //}
            //else
            //{
            //    Response.Redirect("~/s/Inicio.aspx");
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                //(this.Master as SGM.Master.Site1).OcultarDrop = false;
                //(this.Master as SGM.Master.Site1).OcultarLabel = false;
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {

            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion);
            gridEquipo.DataSource = equipo.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
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


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdEquipo = (int)gridEquipo.DataKeys[row.RowIndex].Value;
                if (equipo.Eliminar(IdEquipo))
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

                int IdEquipo = (int)gridEquipo.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEquipo.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }

            else if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdEquipo = (int)gridEquipo.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEquipo.ToString())));

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