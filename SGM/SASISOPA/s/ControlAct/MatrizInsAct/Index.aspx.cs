﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.ControlAct.MatrizInsAct
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.InstalacionActividad insact = new Clase.InstalacionActividad();
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
            int IdUsuario = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarInstalacionActividad10(IdUsuario))
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
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                MostrarGrid();
            }
            
        }


        public void MostrarGrid()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdSuscripcion.ToString());
            int IdUsuario = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IDUsuario.ToString());
            gridMatriz.DataSource = insact.MostrarGeneral(IdSuscripcion,IdUsuario);
            gridMatriz.DataBind();
        

        }

        protected void gridMatriz_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                e.Row.Cells[1].HorizontalAlign = HorizontalAlign.Center;
                string IdArchivo = e.Row.Cells[1].Text;

                HyperLink lnk = new HyperLink();


                lnk.Target = "_blank";
                lnk.ImageUrl = "~/dist/img/pdficon.svg";
                lnk.ImageHeight = 17;
                lnk.ImageWidth = 17;
                e.Row.Cells[1].Controls.Add(lnk);
                if (Convert.ToInt32(IdArchivo) == 0)
                {
                    lnk.Visible = false;
                }

                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdArchivo)));
                lnk.NavigateUrl = "~/s/ControlAct/Doc.aspx?id=" + encodedString;

                for (int i = 2; i < e.Row.Cells.Count; i++)
                {
                    string celda = e.Row.Cells[i].Text;
                    if (celda != "&nbsp;")

                    {

                        e.Row.Cells[i].Text = "✔";
                        e.Row.Cells[i].Attributes.Add("class", "text-green");
                        e.Row.Cells[i].HorizontalAlign = HorizontalAlign.Center;
                    }


                }
            }

            if (e.Row.RowType == DataControlRowType.Header)
            {
                for (int i = 2; i < e.Row.Cells.Count; i++)
                {
                    e.Row.Cells[i].Text = "<div class=\"VerticalHeaderText\">" + e.Row.Cells[i].Text + "</div>";
                }
            }

        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}