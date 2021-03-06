﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.FuncionRes.MatrizCatAct
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.CategoriaActividad categoriaAct = new Clase.CategoriaActividad();
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
            if (accesos.ValidarCategoriaActividad5(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }

        }
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
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());

            gridCategoria.DataSource = categoriaAct.Mostrar(txtSearch.Text.Trim(),IdInstalacion);
            gridCategoria.DataBind();

          
        }


        protected void gridCategoria_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridCategoria.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridCategoria_RowCommand(object sender, GridViewCommandEventArgs e)
        {

             if (e.CommandName == "AgregarAct")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

                int IdCategoria = (int)gridCategoria.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdCategoria.ToString())));

                Response.Redirect("Agregar.aspx?id=" + encodedString + "");
            }
        }

    }
}