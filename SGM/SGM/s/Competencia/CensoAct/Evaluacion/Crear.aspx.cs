using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class CrearEv : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                (this.Master as SGM.s.Site1).OcultarDrop = false;
                (this.Master as SGM.s.Site1).OcultarLabel = false;
                MostrarGrid();

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdControl = Convert.ToInt32(decodedString);
                evaluacion.LeerDatosControl(IdControl);
                lblCodigo.Text = evaluacion.Codigo;
                lblActividad.Text = evaluacion.Actividad;

            }

        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdControl = Convert.ToInt32(decodedString);
            gridEvaluacion.DataSource = evaluacion.MostrarEvaluacion(IdControl);
            gridEvaluacion.DataBind();
            if (gridEvaluacion.Rows.Count >= 1)
            {
                rowGrid.Visible = true;
                rowCaptura.Visible = false;
            }
            else
            {
                rowCaptura.Visible = true;
                rowGrid.Visible = false;
            }
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("~/s/Competencia/CensoAct/Control/Index.aspx?id=" + Request.QueryString["act"] + "");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdControl = Convert.ToInt32(decodedString);
            int Cantidad = Convert.ToInt32(txtCantidad.Text);
            int CalMinima = Convert.ToInt32(txtRange2.Value);


            if (evaluacion.Insertar(IdControl, Cantidad,1,CalMinima))
            {
                //string script = "alert('Evaluación creada exitosamente.'); window.location.href= 'Index.aspx';";

                //ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                evaluacion.ObtenerIdEvaluacion(IdControl);
                txtCantidad.Text = String.Empty;
                MostrarGrid();
                Update1.Update();

                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(evaluacion.IdEvaluacion.ToString())));

                Response.Redirect("CrearCuestionario.aspx?ev=" + encodedString+ "&ctr=" + Request.QueryString["id"] + "&act=" + Request.QueryString["act"] + "");
            }
        }

        protected void gridEvaluacion_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdEvaluacion = (int)gridEvaluacion.DataKeys[row.RowIndex].Value;
                if (evaluacion.EliminarEvaluacion(IdEvaluacion))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }



            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdEvaluacion = (int)gridEvaluacion.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEvaluacion.ToString())));


                Response.Redirect("Editar.aspx?ev=" + encodedString + "&ctr=" + Request.QueryString["id"] + "&act=" + Request.QueryString["act"] + "");
            }
            else if (e.CommandName == "Ver")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdEvaluacion = (int)gridEvaluacion.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEvaluacion.ToString())));


                Response.Redirect("CrearCuestionario.aspx?ev=" + encodedString + "&ctr=" + Request.QueryString["id"] + "&act=" + Request.QueryString["act"] + "");
            }

        }
    }
}