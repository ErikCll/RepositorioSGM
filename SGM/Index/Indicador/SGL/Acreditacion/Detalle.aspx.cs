using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Indicador.SGL.Acreditacion
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.IndicadorSGL indicadorSGL = new Clase.IndicadorSGL();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }

        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (indicadorSGL.ValidarAcreditacion(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                LlenarDrop();
                MostrarGrid();
               
            }
        }

        public void MostrarGrid()
        {

            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            string Acreditador = ddl_Acreditador.SelectedValue;
    
                gridInstalacion.DataSource = indicadorSGL.MostrarDetalleAcreditacion(txtSearch.Text.Trim(), IdSuscripcion, Acreditador);
                gridInstalacion.DataBind();
            
       
        }
        public void LlenarDrop()
        {

            ddl_Acreditador.Items.Insert(0, new ListItem("EMA"));
            ddl_Acreditador.Items.Insert(1, new ListItem("CRE"));





        }

        protected void gridInstalacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridInstalacion.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }


        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();

        }

        protected void gridInstalacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IdArchivo = e.Row.FindControl("lblArchivo") as Label;
          
                HyperLink lnk = e.Row.FindControl("lnkArchivo") as HyperLink;
                if (Convert.ToInt32(IdArchivo.Text) == 0)
                {
                    lnk.Visible = false;
                }

                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdArchivo.Text)));
                lnk.NavigateUrl = "Doc.aspx?id=" + encodedString;

            }
        }

        protected void ddl_Acreditador_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();
        }
    }
}
