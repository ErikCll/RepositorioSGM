﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class Index : System.Web.UI.Page
    {

        Clase.Actividad actividad = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            gridActividad.DataSource = actividad.Mostrar(txtSearch.Text.Trim());
            gridActividad.DataBind();
        }

        protected void gridActividad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridActividad.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }
        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridActividad_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                if (actividad.Eliminar(IdActividad))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
              


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdActividad.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }

      

            else if (e.CommandName == "AgregarVer")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdActividad.ToString())));

                Response.Redirect("Control.aspx?id=" + encodedString + "");
            }
        }

        protected void gridActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IdArchivo = e.Row.FindControl("lblArchivo") as Label;

                HyperLink lnk = e.Row.FindControl("lnkArchivo") as HyperLink;
                if (Convert.ToInt32(IdArchivo.Text) == 0)
                {
                    lnk.Visible = false;
                }
                lnk.NavigateUrl = "https://er2020.blob.core.windows.net/controlvers/" + IdArchivo.Text.ToString() + ".pdf";

            }
        }
    }
}