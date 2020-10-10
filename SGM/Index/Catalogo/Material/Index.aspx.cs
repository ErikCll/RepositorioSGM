﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Material
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Material material = new Clase.Material();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCatalogo(Usuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }

            if (Request.QueryString["url"] == null)
            {
                //Response.Redirect("~/Inicio.aspx");

            }
            else
            {
                string url = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["url"]));
                Session["url"] = url;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {

            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            gridMaterial.DataSource = material.Mostrar(txtSearch.Text.Trim(), IdSuscripcion);
            gridMaterial.DataBind();
        }

        protected void gridMaterial_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridMaterial.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }


        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridMaterial_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdMaterial = (int)gridMaterial.DataKeys[row.RowIndex].Value;
                if (material.Eliminar(IdMaterial))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "ocurrio un error.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdMaterial = (int)gridMaterial.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdMaterial.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }


        }
        protected void btnRegresar_Click(object sender, EventArgs e)
        {
            if (Session["url"] == null)
            {
                Response.Redirect("~/Inicio.aspx");

            }
            else
            {
                Response.Redirect(Session["url"].ToString());
            }



        }


    }
}