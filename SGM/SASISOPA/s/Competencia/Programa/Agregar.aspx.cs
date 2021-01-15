using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.Competencia.Programa
{
    public partial class Agregar : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
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
            if (accesos.ValidarProgramaCapacitacion6(IdUsuario))
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
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;

                LlenarDrop();
                MostrarGrid();

            }
        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            gridPrograma.DataSource = programa.MostrarEvaluaciones(IdEvaluacion, txtSearch.Text.Trim(), IdInstalacion);
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
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            if (programa.Insertar(IdEvaluacion, IdEmpleado, FechaEvaluacion, IdInstalacion))
            {
                programa.ObtenerIdPrograma(IdEvaluacion, IdEmpleado);
                int IdPrograma = Convert.ToInt32(programa.Id_Programa);
                string Clave = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdPrograma.ToString())));

                programa.EditarPrograma(IdPrograma, Clave);
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
                Label Calificacion = e.Row.FindControl("lblCalificacion") as Label;

                Label Calificacion2 = e.Row.FindControl("lblCalificacion2") as Label;

                Label CalMinima = e.Row.FindControl("lblCalMinima") as Label;

                Button btnEditar = e.Row.FindControl("btnEditar") as Button;

                if (Calificacion2.Text != "" && CalMinima.Text!="")
                {
                    double CalificacionFinal = Convert.ToDouble(Calificacion2.Text);
                    int CalMinimaFinal = Convert.ToInt32(CalMinima.Text);

                    if (CalificacionFinal >= CalMinimaFinal)
                    {
                        Calificacion.Attributes.Add("class", "text-green");
                    }
                    else
                    {
                        Calificacion.Attributes.Add("class", "text-red");
                    }
                }
              

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

                Response.Redirect("Editar.aspx?id=" + Request.QueryString["id"] + "&ev=" + Request.QueryString["ev"] + "&prog=" + encodedString + "");

            }

            else if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Control)e.CommandSource).Parent.Parent as GridViewRow;
                int IdPrograma = (int)gridPrograma.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdPrograma.ToString())));

                Response.Redirect("DetalleEv.aspx?id=" + Request.QueryString["id"] + "&ev=" + Request.QueryString["ev"] + "&prog="+encodedString+"");

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