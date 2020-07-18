﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.Programa
{
    public partial class Agregar : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;

                LlenarDrop();
                MostrarGrid();

            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            gridPrograma.DataSource = programa.MostrarEvaluaciones(IdEvaluacion, txtSearch.Text.Trim());
            gridPrograma.DataBind();
        }

        public void LlenarDrop()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            ddl_Empleado.DataSource = programa.MostrarEmpleado(IdActividad);
            ddl_Empleado.DataBind();
            ddl_Empleado.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            int IdEmpleado = Convert.ToInt32(ddl_Empleado.SelectedValue);
            string FechaEvaluacion = txtFecha.Text;

            if (programa.Insertar(IdEvaluacion, IdEmpleado, FechaEvaluacion))
            {
                MostrarGrid();
                txtFecha.Text = String.Empty;
                ddl_Empleado.SelectedIndex = 0;
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se creó correctamente el registro.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }


        }

        protected void gridPrograma_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label Estatus = e.Row.FindControl("lblEstatus") as Label;
                Button btnEditar = e.Row.FindControl("btnEditar") as Button;

                if (Estatus.Text == "2")
                {
                    btnEditar.Visible = false;
                }

            }
        }

        protected void gridPrograma_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;

                int IdPrograma = (int)gridPrograma.DataKeys[row.RowIndex].Value;

                if (programa.Eliminar(IdPrograma))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;
                int IdPrograma = (int)gridPrograma.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdPrograma.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "&ev=" + Request.QueryString["ev"] + "");

            }
        }

        protected void gridPrograma_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridPrograma.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }
    }
  
}