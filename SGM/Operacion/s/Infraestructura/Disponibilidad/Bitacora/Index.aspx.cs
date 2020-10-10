using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Infraestructura.Disponibilidad.Bitacora
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Bitacora bitacora = new Clase.Bitacora();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarInfraestructura(Usuario))
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
                (this.Master as Operacion.s.Site1).OcultarDrop = false;
                (this.Master as Operacion.s.Site1).OcultarLabel = false;
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEquipo = Convert.ToInt32(decodedString);
                bitacora.LeerDatos(IdEquipo);
                lblEquipo.Text = bitacora.Nombre;
            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            gridBitacora.DataSource = bitacora.Mostrar(txtFecha.Text.Trim(), IdEquipo);
            gridBitacora.DataBind();

        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridBitacora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridBitacora.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void CrearBitacora(Object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void gridBitacora_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdBitacora = (int)gridBitacora.DataKeys[row.RowIndex].Value;
                if (bitacora.Eliminar(IdBitacora))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdBitacora = (int)gridBitacora.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdBitacora.ToString())));

                Response.Redirect("Editar.aspx?idbit=" + encodedString + "&id=" + Request.QueryString["id"] + "");
            }
        }
    }
}