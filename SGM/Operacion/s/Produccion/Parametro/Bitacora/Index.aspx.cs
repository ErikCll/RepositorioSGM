using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Parametro.Bitacora
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Parametro parametro = new Clase.Parametro();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as Operacion.s.Site1).OcultarDrop = false;
                (this.Master as Operacion.s.Site1).OcultarLabel = false;
                string Fecha = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["fec"]));

                txtFecha.Text = Fecha;
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEquipo = Convert.ToInt32(decodedString);
                parametro.LeerDatosEquipo(IdEquipo);
                lblEquipo.Text = parametro.Equipo;

            }
        }

        public void MostrarGrid()
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            string FechaActual = txtFecha.Text;

            gridBitacora.DataSource = parametro.MostrarBitacora(FechaActual,IdEquipo);
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
            Response.Redirect("Crear.aspx?id=" + Request.QueryString["id"] + "&fec=" + Request.QueryString["fec"] + "");
        }

        protected void gridBitacora_RowCommand(object sender, GridViewCommandEventArgs e)
        {

            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdParametro = (int)gridBitacora.DataKeys[row.RowIndex].Value;
                if (parametro.Eliminar(IdParametro))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
          
        }
    }
}