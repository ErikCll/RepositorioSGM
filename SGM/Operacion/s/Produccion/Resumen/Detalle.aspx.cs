using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Resumen
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Resumen resumen = new Clase.Resumen();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as Operacion.s.Site1).OcultarDrop = false;
                (this.Master as Operacion.s.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["fec"]));
                string Fecha = decodedString;
                txtFecha.Text = Fecha;
                MostrarGrid();

            }
        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());



            string Fecha = txtFecha.Text;
            gridResumen.DataSource = resumen.MostrarResumenDetalle(IdInstalacion, Fecha);
            gridResumen.DataBind();

        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridResumen_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridResumen.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void gridResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    string celda = e.Row.Cells[i].Text;
                    if (celda != "&nbsp;" || celda != "0")

                    {
                        celda = celda.Replace(',', '.');
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;

                    }


                }
            }
        }
    }
}