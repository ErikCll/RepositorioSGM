using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Resumen
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Resumen resumen = new Clase.Resumen();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                LlenarDropAnio();
                LlenarDropMes();
                string Mes = DateTime.Now.ToString("MM");
                string Anio = DateTime.Now.ToString("yyyy");


                ddl_Mes.SelectedValue = Mes;
                ddl_Anio.SelectedValue = Anio;
                MostrarGrid();

                int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
                int Mess = Convert.ToInt32(ddl_Mes.SelectedValue);
                int Anioo = Convert.ToInt32(ddl_Anio.SelectedValue);
                LineChart.DataSource = resumen.MostrarGeneral2(IdInstalacion, Anioo, Mess);
                LineChart.DataBind();


            }

        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            int Mes = Convert.ToInt32(ddl_Mes.SelectedValue);
            int Anio = Convert.ToInt32(ddl_Anio.SelectedValue);
            gridResumen.DataSource = resumen.MostrarGeneral(IdInstalacion, Anio, Mes);
            gridResumen.DataBind();
        }
        public void LlenarDropMes()
        {
            ddl_Mes.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddl_Mes.Items.Insert(1, new ListItem("Enero", "01"));
            ddl_Mes.Items.Insert(2, new ListItem("Febrero", "02"));
            ddl_Mes.Items.Insert(3, new ListItem("Marzo", "03"));
            ddl_Mes.Items.Insert(4, new ListItem("Abril", "04"));
            ddl_Mes.Items.Insert(5, new ListItem("Mayo", "05"));
            ddl_Mes.Items.Insert(6, new ListItem("Junio", "06"));
            ddl_Mes.Items.Insert(7, new ListItem("Julio", "07"));
            ddl_Mes.Items.Insert(8, new ListItem("Agosto", "08"));
            ddl_Mes.Items.Insert(9, new ListItem("Septiembre", "09"));
            ddl_Mes.Items.Insert(10, new ListItem("Octubre", "10"));
            ddl_Mes.Items.Insert(11, new ListItem("Noviembre", "11"));
            ddl_Mes.Items.Insert(12, new ListItem("Diciembre", "12"));

        }

        public void LlenarDropAnio()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());

            ddl_Anio.DataSource = resumen.MostrarAnios(IdInstalacion);
            ddl_Anio.DataBind();
            ddl_Anio.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        protected void gridResumen_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    string celda = e.Row.Cells[i].Text;
                    if (celda != "&nbsp;" || celda!="0")

                    {
                      celda=  celda.Replace(',', '.');
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;

                    }


                }

             
            }
        }

        protected void ddl_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void ddl_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridResumen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
              if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;
                string Fecha = row.Cells[1].Text;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Fecha.ToString())));

                Response.Redirect("Detalle.aspx?fec=" + encodedString +"");

            }
        }
    }
}