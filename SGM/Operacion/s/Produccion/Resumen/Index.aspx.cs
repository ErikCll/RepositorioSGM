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
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarProduccion(Usuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
                LlenarDropAnio();
                LlenarDropMes();
                LlenarDropEquipo();
                string Mes = DateTime.Now.AddHours(-5).ToString("MM");
                string Anio = DateTime.Now.AddHours(-5).ToString("yyyy");
                int Mess = Convert.ToInt32(Mes);
                int Anioo = Convert.ToInt32(Anio);

                ddl_Mes.SelectedValue = Mes;
                ddl_Anio.SelectedValue = Anio;
                //MostrarGrid();

                //MostrarGridProd();
                //MostrarGridEfic();
                MostrarGridHora();
                //int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
                //int Mess = Convert.ToInt32(ddl_Mes.SelectedValue);
                //int Anioo = Convert.ToInt32(ddl_Anio.SelectedValue);
                //LineChart.DataSource = resumen.MostrarGeneral2(IdInstalacion, Anioo, Mess);
                //LineChart.DataBind();
                LlenarIndicadores();

             
            }

        }

        public void MostrarGridHora()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            int Mes = Convert.ToInt32(ddl_Mes.SelectedValue);
            int Anio = Convert.ToInt32(ddl_Anio.SelectedValue);
            int IdEquipo = Convert.ToInt32(ddl_Equipo.SelectedValue);
            if (IdEquipo == 0)
            {
                gridHora.DataSource = resumen.MostrarHoras(IdInstalacion, Anio, Mes);
                gridHora.DataBind();
                GraficaHora.DataSource = resumen.MostrarHoras(IdInstalacion, Anio, Mes);
                GraficaHora.DataBind();
            }
            else
            {
                gridHora.DataSource = resumen.MostrarHorasPorEquipo(IdEquipo, Anio, Mes);
                gridHora.DataBind();
                GraficaHora.DataSource = resumen.MostrarHorasPorEquipo(IdEquipo, Anio, Mes);
                GraficaHora.DataBind();
            }
      



        }

        //public void MostrarGrid()
        //{
        //    int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
        //    int Mes = Convert.ToInt32(ddl_Mes.SelectedValue);
        //    int Anio = Convert.ToInt32(ddl_Anio.SelectedValue);
        //    gridResumen.DataSource = resumen.MostrarGeneral2(IdInstalacion,Anio,Mes);
        //    gridResumen.DataBind();




        //}

        //public void MostrarGridProd()
        //{
        //    gridProd.DataSource = resumen.MostrarResumenProd();
        //    gridProd.DataBind();


        //}

        public void MostrarGridEfic()
        {
            gridEfic.DataSource = resumen.MostrarResumenEfic();
            gridEfic.DataBind();


        }

        public void LlenarDropEquipo()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            ddl_Equipo.DataSource = resumen.MostrarEquipo(IdInstalacion);
            ddl_Equipo.DataBind();
            ddl_Equipo.Items.Insert(0, new ListItem("[Todos]", "0"));


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
                    if (celda != "&nbsp;" || celda != "0")

                    {
                        celda = celda.Replace(',', '.');
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;

                    }


                }


            }
        }

        protected void ddl_Mes_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGridHora();
            LlenarIndicadores();
        }

        protected void ddl_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGridHora();
            LlenarIndicadores();
        }

        protected void gridResumen_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;
                string Fecha = row.Cells[1].Text;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(Fecha.ToString())));

                Response.Redirect("Detalle.aspx?fec=" + encodedString + "");

            }
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }

        protected void gridHora_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridHora.PageIndex = e.NewPageIndex;

            MostrarGridHora();
        }

        protected void gridHora_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label lblPromedio = e.Row.FindControl("lblPromedio") as Label;
                int divisor = 0;
                double Total = 0;    
                string T1 = e.Row.Cells[1].Text;

                string T2 = e.Row.Cells[2].Text;

                string T3 = e.Row.Cells[3].Text;

                if(T1 != "&nbsp;" )
                {
                    divisor = divisor + 1;
                    double Turno1 = Convert.ToDouble(e.Row.Cells[1].Text);
                    Total = Turno1;
                    double valor = 6.8;
                    if (Turno1 < valor)
                    {
                        e.Row.Cells[1].Attributes.Add("class", "bg-danger");
                    }

                 
                }
                

                if (T2 != "&nbsp;")
                {
                    divisor = divisor + 1;

                    double Turno2 = Convert.ToDouble(e.Row.Cells[2].Text);
                    Total = Total + Turno2;
                    double valor = 6.8;
                    if (Turno2 < valor)
                    {
                        e.Row.Cells[2].Attributes.Add("class", "bg-danger");
                    }


                }

                if (T3 != "&nbsp;")
                {
                    divisor = divisor + 1;

                    double Turno3 = Convert.ToDouble(e.Row.Cells[3].Text);
                    Total = Total + Turno3;
                    double valor = 6.8;
                    if (Turno3 < valor)
                    {
                        e.Row.Cells[3].Attributes.Add("class", "bg-danger");
                    }


                }
                double Promedio = Total / divisor;
              
                lblPromedio.Text = Math.Round(Promedio, 2).ToString();

            }
        }

        protected void ddl_Equipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGridHora();
            LlenarIndicadores();
        }

        public void LlenarIndicadores()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            int Mes = Convert.ToInt32(ddl_Mes.SelectedValue);
            int Anio = Convert.ToInt32(ddl_Anio.SelectedValue);
            int IdEquipo = Convert.ToInt32(ddl_Equipo.SelectedValue);

            if (IdEquipo == 0)
            {
                resumen.LeerDatosHorasTurno(IdInstalacion, Anio, Mes);

            }

            else
            {
                resumen.LeerDatosHorasTurnoPorEquipo(IdEquipo, Anio, Mes);
            }
            lblTurno1.Text = resumen.Turno1;
            double HTurno1 = Convert.ToDouble(lblTurno1.Text);
            decimal porcentajeHorasTurno1 = (int)((10 * HTurno1) + 20);

            if (HTurno1.ToString() != "0")
            {
                progresTurno1.Style.Add("width", porcentajeHorasTurno1.ToString() + "%");
            }
            else
            {
                progresTurno1.Style.Add("width", "0%");
            }

            lblTurno2.Text = resumen.Turno2;
            double HTurno2 = Convert.ToDouble(lblTurno2.Text);
            decimal porcentajeHorasTurno2 = (int)((10 * HTurno2) + 20);
            if (HTurno2.ToString() != "0")
            {
                progresTurno2.Style.Add("width", porcentajeHorasTurno2.ToString() + "%");
            }
            else
            {
                progresTurno2.Style.Add("width", "0%");
            }

            lblTurno3.Text = resumen.Turno3;
            double HTurno3 = Convert.ToDouble(lblTurno3.Text);
            decimal porcentajeHorasTurno3 = (int)((10 * HTurno3) + 20);
            if (HTurno3.ToString() != "0")
            {
                progresTurno3.Style.Add("width", porcentajeHorasTurno3.ToString() + "%");
            }
            else
            {
                progresTurno3.Style.Add("width", "0%");
            }
        }
    }
}