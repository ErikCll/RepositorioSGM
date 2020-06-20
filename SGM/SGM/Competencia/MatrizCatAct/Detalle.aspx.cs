﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.MatrizCatAct
{
    public partial class Consulta : System.Web.UI.Page
    {
        Clase.CategoriaActividad categoriaAct = new Clase.CategoriaActividad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                MostrarGrid();
            }
        }


        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.Master.Site1).IdInstalacion.ToString());

            gridMatriz.DataSource = categoriaAct.MostrarGeneral(IdInstalacion);
            gridMatriz.DataBind();
            //foreach (GridViewRow row in gridMatriz.Rows)
            //{
            //    for (int i = 1; i < gridMatriz.Columns.Count; i++)
            //    {
            //        string celda = row.Cells[i].Text;
            //        if (celda != "&nbsp;")

            //        {
            //            row.Cells[i].Text = string.Empty;
            //            row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
            //            row.Cells[i].Attributes.Add("class", "fas fa-circle text-green");

            //        }
            //    }

          

            //}

        }

        protected void gridMatriz_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
               
                for (int i = 1; i < e.Row.Cells.Count; i++)
                {
                    string celda = e.Row.Cells[i].Text;
                    if (celda != "&nbsp;")

                    {

                        e.Row.Cells[i].Text = "Agregado";
                        e.Row.Cells[i].Attributes.Add("class","text-green");
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    }
                 

                }
            }

            }
    }
}