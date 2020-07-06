using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class VCuestionario : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
            }
            MostrarLista();


        }
        public void MostrarLista()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion =Convert.ToInt32( decodedString);
            lstPreguntas.DataSource = evaluacion.MostrarPregunta(IdEvaluacion);
            lstPreguntas.DataBind();
            if (lstPreguntas.Items.Count>=1){
                btnFinalizar.Visible = true;
            }

        }
        protected void Eliminar(object sender, EventArgs e)
        {
            ListViewItem item = (sender as LinkButton).NamingContainer as ListViewItem;
            Label Id_Pregunta = (Label)item.FindControl("lblIdPregunta");
            int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);
            evaluacion.EliminarPregunta(IdPregunta);
            MostrarLista();
        }

        protected void Editar(object sender, EventArgs e)
        {
            ListViewItem item = (sender as LinkButton).NamingContainer as ListViewItem;
            Label Id_Pregunta = (Label)item.FindControl("lblIdPregunta");
            Label Tipo_Pregunta = (Label)item.FindControl("lblTipoPregunta");

            int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);
            int TipoPregunta = Convert.ToInt32(Tipo_Pregunta.Text);


            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdPregunta.ToString())));
            string encodedString2 = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(TipoPregunta.ToString())));


            Response.Redirect("EditarCuestionario.aspx?preg=" + encodedString + "&tp=" + encodedString2+"&ev="+Request.QueryString["ev"]);
        }
        protected void lstPreguntas_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
          if (e.Item.ItemType == ListViewItemType.DataItem)
           {

                Label Id_Pregunta = (Label)e.Item.FindControl("lblIdPregunta");
                int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);
                RadioButtonList radioList = (RadioButtonList)e.Item.FindControl("radioList");
                radioList.DataSource = evaluacion.MostrarRespuesta(IdPregunta);
                radioList.DataBind();
                radioList.Items[0].Selected = true;

               
           }

        }

        protected void Finalizar(Object sender, EventArgs e)
        {
    
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('EvPrueba.aspx?ev=" + Request.QueryString["ev"] + "','mywindow','menubar=1,resizable=1');", true);

        }
        protected void Regresar(Object sender, EventArgs e)
        {


            Response.Redirect("CrearCuestionario.aspx?ev=" + Request.QueryString["ev"] + "");
        }
    }
}