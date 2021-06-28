using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Material
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.ResumenMaterial resumenMaterial = new Clase.ResumenMaterial();
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
            if (accesos.ValidarMaterialProducido(IdUsuario))
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
          
                MostrarGridHora();
            
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
                gridHora.DataSource = resumenMaterial.MostrarHoras(IdInstalacion, Anio, Mes);
                gridHora.DataBind();
                GraficaHora.DataSource = resumenMaterial.MostrarHoras(IdInstalacion, Anio, Mes);
                GraficaHora.DataBind();
            }
            else
            {
                gridHora.DataSource = resumenMaterial.MostrarHorasPorEquipo(IdEquipo, Anio, Mes);
                gridHora.DataBind();
                GraficaHora.DataSource = resumenMaterial.MostrarHorasPorEquipo(IdEquipo, Anio, Mes);
                GraficaHora.DataBind();
            }




        }
 
        public void LlenarDropEquipo()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            ddl_Equipo.DataSource = resumenMaterial.MostrarEquipo(IdInstalacion);
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

            ddl_Anio.DataSource = resumenMaterial.MostrarAnios(IdInstalacion);
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

                if (T1 != "&nbsp;")
                {
                    divisor = divisor + 1;
                    double Turno1 = Convert.ToDouble(e.Row.Cells[1].Text);
                    Total = Turno1;
                    double valor = 6.8;
                    //if (Turno1 < valor)
                    //{
                    //    e.Row.Cells[1].Attributes.Add("class", "bg-danger");
                    //}


                }


                if (T2 != "&nbsp;")
                {
                    divisor = divisor + 1;

                    double Turno2 = Convert.ToDouble(e.Row.Cells[2].Text);
                    Total = Total + Turno2;
                    double valor = 6.8;
                    //if (Turno2 < valor)
                    //{
                    //    e.Row.Cells[2].Attributes.Add("class", "bg-danger");
                    //}


                }

                if (T3 != "&nbsp;")
                {
                    divisor = divisor + 1;

                    double Turno3 = Convert.ToDouble(e.Row.Cells[3].Text);
                    Total = Total + Turno3;
                    double valor = 6.8;
                    //if (Turno3 < valor)
                    //{
                    //    e.Row.Cells[3].Attributes.Add("class", "bg-danger");
                    //}


                }
                if(Total==0 && divisor == 0)
                {
                    lblPromedio.Text = "";
                }
                else
                {
                    double Promedio = Total / divisor;

                    lblPromedio.Text = Math.Round(Promedio, 2).ToString();
                }
            

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
                resumenMaterial.LeerDatosHorasTurno(IdInstalacion, Anio, Mes);

            }

            else
            {
                resumenMaterial.LeerDatosHorasTurnoPorEquipo(IdEquipo, Anio, Mes);
            }
            lblTurno1.Text = resumenMaterial.Turno1;
            double HTurno1 = Convert.ToDouble(lblTurno1.Text);
            decimal porcentajeHorasTurno1 = (int)((100 * HTurno1)/3000 );

            if (HTurno1.ToString() != "0")
            {
                progresTurno1.Style.Add("width", porcentajeHorasTurno1.ToString() + "%");
            }
            else
            {
                progresTurno1.Style.Add("width", "0%");
            }

            lblTurno2.Text = resumenMaterial.Turno2;
            double HTurno2 = Convert.ToDouble(lblTurno2.Text);
            decimal porcentajeHorasTurno2 = (int)((100 * HTurno2)/3000 );
            if (HTurno2.ToString() != "0")
            {
                progresTurno2.Style.Add("width", porcentajeHorasTurno2.ToString() + "%");
            }
            else
            {
                progresTurno2.Style.Add("width", "0%");
            }

            lblTurno3.Text = resumenMaterial.Turno3;
            double HTurno3 = Convert.ToDouble(lblTurno3.Text);
            decimal porcentajeHorasTurno3 = (int)((100 * HTurno3)/3000);
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