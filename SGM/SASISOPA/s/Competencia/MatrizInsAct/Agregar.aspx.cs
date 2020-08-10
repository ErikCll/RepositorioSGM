﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.Competencia.MatrizInsAct
{
    public partial class Agregar : System.Web.UI.Page
    {
        Clase.InstalacionActividad insact = new Clase.InstalacionActividad();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                LlenarDropInstalacion();
                LlenarDropArea();
            }
         
        }

      
        public void MostrarGrid()
        {
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (IdArea == 0)
            {
                gridActividad.Visible = false;
                btnGuardar.Visible = false;
            }
            else
            {
                gridActividad.Visible = true;
                btnGuardar.Visible = true;
            }
            gridActividad.DataSource = insact.MostrarActividades(IdArea);
            gridActividad.DataBind();
          
        }

        public void LlenarDropInstalacion()
        {
            ddl_Instalacion.DataSource = insact.MostrarInstalacion();
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        public void LlenarDropArea()
        {
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            ddl_Area.DataSource = insact.MostrarArea(IdInstalacion);
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]","0"));
        }

        protected void ddl_Instalacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropArea();
            MostrarGrid();
        }

        protected void ddl_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();

        }

        protected void gridActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("checkall") as CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("checkall") as CheckBox).ClientID + "')");
            }


        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridActividad.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
                    int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    int IdActividad = Convert.ToInt32(row.Cells[2].Controls.OfType<Label>().FirstOrDefault().Text);
                    int IdRegistro = Convert.ToInt32(row.Cells[3].Controls.OfType<Label>().FirstOrDefault().Text);

                    if (isChecked == true && IdActividad != IdRegistro)
                    {

                        if (insact.Insertar(IdInstalacion,IdArea, IdActividad))
                        {
                            string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron las actividades.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }

                    }
                    if (IdRegistro != 0)
                    {
                        if (isChecked == false)
                        {
                            if (insact.Eliminar(IdArea, IdActividad))
                            {
                                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron las actividades.");
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            }
                        }
                    }



                }

            }
            MostrarGrid();
        }
    }
}