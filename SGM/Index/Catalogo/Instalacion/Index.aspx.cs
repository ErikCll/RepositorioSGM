﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Instalacion
{
    public partial class Index : System.Web.UI.Page
    {
       Clase.Instalacion objIns = new Clase.Instalacion();
        Clase.Accesos accesos = new Clase.Accesos();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
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

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (accesos.ValidarInstalacion(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
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
            gridInstalacion.DataSource = objIns.Mostrar(txtSearch.Text.Trim(),IdSuscripcion);
            gridInstalacion.DataBind();
        }

        protected void gridInstalacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridInstalacion.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }


        protected void Buscar( Object sender,EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridInstalacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            

            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdInstalacion = (int)gridInstalacion.DataKeys[row.RowIndex].Value;
                if (objIns.Eliminar(IdInstalacion)){
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                  ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "ocurrio un error.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
              

            }
            else if (e.CommandName=="Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdInstalacion = (int)gridInstalacion.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdInstalacion.ToString())));

                Response.Redirect("Editar.aspx?id="+encodedString+"");
            }

            else if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdInstalacion = (int)gridInstalacion.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdInstalacion.ToString())));

                Response.Redirect("Detalle.aspx?id=" + encodedString + "");
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