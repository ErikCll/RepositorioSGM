using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct.Evaluacion
{
    public partial class EvPrueba : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
        static int hh, mm, ss;
        static int con = 0;
        string totalItems;

        static double TimeAllSecondes = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                MostrarLista();
       
                int min = 1 * 60;
                TimeAllSecondes = min;
               
                //foreach (ListViewItem itm in lstPreguntas.Items)
                //{
                //    Label Contador = (Label)itm.FindControl("lblContador");
                //    Contador.Text ="1".ToString();


                //}


            }
        }

        protected void Timer1_Tick(object sender, EventArgs e)
        {
            if (TimeAllSecondes > 0)
            {
                TimeAllSecondes = TimeAllSecondes - 1;
            }

            TimeSpan time_Span = TimeSpan.FromSeconds(TimeAllSecondes);
            hh = time_Span.Hours;
            mm = time_Span.Minutes;
            ss = time_Span.Seconds;
            btnTime.Text = "  " + hh + ":" + mm + ":" + ss;
            if (TimeAllSecondes == 0)
            {
                Timer1.Enabled = false;
                btnFinalizar_Click(null, null);

            }
        }

        public void MostrarLista()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            lstPreguntas.DataSource = evaluacion.MostrarPreguntaAleatoria(IdEvaluacion);
            lstPreguntas.DataBind();

            //if (lstPreguntas.Items.Count >= 1)
            //{
            //    btnFinalizar.Visible = true;
            //}
            evaluacion.ObtenerTotalItems(IdEvaluacion);
            totalItems = evaluacion.TotalItems.ToString();
            lblTotal.Text = evaluacion.TotalItems.ToString();


        }

        protected void lstPreguntas_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label Id_Pregunta = (Label)e.Item.FindControl("lblIdPregunta");
                Label Id_Respuesta = (Label)e.Item.FindControl("lblIdRespuesta");
                RadioButtonList radioList = (RadioButtonList)e.Item.FindControl("radioList");

                int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);
                evaluacion.ObtenerIdRespuesta(IdPregunta);
                Id_Respuesta.Text = evaluacion.IdRespuesta;
                radioList.DataSource = evaluacion.MostrarRespuestaAleatoria(IdPregunta);
                radioList.DataBind();


            }

        }

        protected void lstPreguntas_PagePropertiesChanging(object sender, PagePropertiesChangingEventArgs e)
        {

           
                DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
            MostrarLista(); //rebind listView



            foreach (ListViewItem itm in lstPreguntas.Items)
            {
                Label Contador = (Label)itm.FindControl("lblContador");

                if (Contador.Text == totalItems)
                {
                    btnFinalizar.Visible = true;
                }


            }






        }

        //protected void Unnamed_PreRender(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        DataPager pager = lstPreguntas.FindControl("DataPager1") as DataPager;
        //        if (pager != null)
        //        {
        //            //pager.PageSize = pager.TotalRowCount;
        //            pager.PageSize = 1;
        //            pager.SetPageProperties(0 * pager.PageSize, pager.MaximumRows, true);
        //        }
        //    }
        //}

        protected void btnFinalizar_Click(object sender, EventArgs e)
        {
            decimal cal = 0;

            foreach (ListViewItem itm in lstPreguntas.Items)
            {
                RadioButtonList radioList = (RadioButtonList)itm.FindControl("radioList");
                Label Id_Respuesta = (Label)itm.FindControl("lblIdRespuesta");

                string ValorSeleccionado = radioList.SelectedValue;
                string IdRespuesta =Id_Respuesta.Text;
                if(ValorSeleccionado == IdRespuesta)
                {
                    cal++;
                }
                



            }
            decimal cantidadPreguntas = Convert.ToDecimal(lstPreguntas.Items.Count);


            decimal calificacion = (cal / cantidadPreguntas) * 10;

          decimal calFinal=  Math.Round(calificacion, 2);

            string txtJS = String.Format("<script>alert('{0}');</script>", "Tu calificación es: " + calFinal +" ");
            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("vCuestionario.aspx?ev=" + Request.QueryString["ev"] + "");
        }
    }
}