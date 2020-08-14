﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Catalogo.Medidor
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Medidor medidor = new Clase.Medidor();
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as SGM.s.Site1).OcultarDrop = false;
                (this.Master as SGM.s.Site1).OcultarLabel = false;
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SGM.s.Site1).IdSuscripcion.ToString());

            gridMedidor.DataSource = medidor.Mostrar(txtSearch.Text.Trim(),IdSuscripcion);
            gridMedidor.DataBind();
        }

        protected void gridMedidor_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMedidor.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }


        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridMedidor_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdMedidor = (int)gridMedidor.DataKeys[row.RowIndex].Value;
                if (medidor.Eliminar(IdMedidor))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
             


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdMedidor = (int)gridMedidor.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdMedidor.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }

            else if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdMedidor = (int)gridMedidor.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdMedidor.ToString())));

                Response.Redirect("Detalle.aspx?id=" + encodedString + "");
            }
        }
    }
}