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
            int IdUsuario = Convert.ToInt32((this.Master as Operacion.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarHorasPorTurno(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnConsultar.UniqueID;

            if (!IsPostBack)
            {
                DateTime FechaActual = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                txtFecha.Text = FechaActual.ToString("dd-MM-yyyy");
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {



            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            string Fecha = txtFecha.Text;
            gridHora.DataSource = resumen.MostrarDetalleHoras(IdInstalacion,Fecha);
            gridHora.DataBind();
            graficaHoraDetalle.DataSource = resumen.MostrarDetalleHoras(IdInstalacion, Fecha);
            graficaHoraDetalle.DataBind();

        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridHora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridHora.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        //protected void gridResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        //{

        //    if (e.Row.RowType == DataControlRowType.DataRow)
        //    {

        //        for (int i = 1; i < e.Row.Cells.Count; i++)
        //        {
        //            string celda = e.Row.Cells[i].Text;
        //            if (celda != "&nbsp;" || celda != "0")

        //            {
        //                celda = celda.Replace(',', '.');
        //                e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;

        //            }


        //        }
        //    }
        //}
    }
}