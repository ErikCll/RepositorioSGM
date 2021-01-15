using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

namespace SASISOPA.s
{
    public partial class Evaluacion : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        static int hh, mm, ss;
        static int con = 0;
        static string totalItems;
        static decimal cal = 0;
        static int expirado = 0;
        static int contador = 0;
        static DataTable data;
        static int EsRespuestaRepetida = 0;
        static int EsRespuestaRepetida2 = 0;


        static int estatus = 0;



        static double TimeAllSecondes = 0;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
                int IdPrograma = Convert.ToInt32(decodedString);
                programa.LeerDatosProgramaEmpleado(IdPrograma);
                lblEmpleado.Text = programa.Empleado;
                lblActividad.Text = programa.Actividad;

                MostrarLista();



                int min = 1 * 60;
                TimeAllSecondes = min;

                //foreach (ListViewItem itm in lstPreguntas.Items)
                //{
                //    Label Contador = (Label)itm.FindControl("lblContador");
                //    Contador.Text ="1".ToString();


                //}
                foreach (ListViewItem itm in lstPreguntas.Items)
                {
                    Label Contador = (Label)itm.FindControl("lblContador");

                    if (Contador.Text == totalItems)
                    {
                        btnFinalizar.Visible = true;
                    }


                }


            }
        }

        protected void Timer2_Tick(object sender, EventArgs e)
        {
            if (TimeAllSecondes > 0)
            {
                TimeAllSecondes = TimeAllSecondes - 1;
            }

            TimeSpan time_Span = TimeSpan.FromSeconds(TimeAllSecondes);
            hh = time_Span.Hours;
            mm = time_Span.Minutes;
            ss = time_Span.Seconds;
            foreach (ListViewItem itm in lstPreguntas.Items)
            {
                Button btnTime2 = (Button)itm.FindControl("btnTime");
                btnTime2.Text = "  " + hh + ":" + mm + ":" + ss;

            }

            if (TimeAllSecondes == 0)
            {
                //Timer2.Enabled = false;
                expirado = 1;

                //foreach (ListViewItem itm in lstPreguntas.Items)
                //{
                //    Label Contador = (Label)itm.FindControl("lblContador");
                //    contador = Convert.ToInt32(Contador.Text);




                //}
                //lstPreguntas_PagePropertiesChanging(null, new PagePropertiesChangingEventArgs(contador, 1));


                foreach (ListViewItem itm in lstPreguntas.Items)
                {
                    Label Contador = (Label)itm.FindControl("lblContador");
                    contador = Convert.ToInt32(Contador.Text);

                    if (Contador.Text == totalItems)
                    {
                        TimeAllSecondes = 60;

                        expirado = 0;

                        btnFinalizar.Visible = true;
                        btnFinalizar_Click(null, null);
                         
                    }

                    else
                    {
                        TimeAllSecondes = 60;

                        expirado = 0;

                        lstPreguntas_PagePropertiesChanging(null, new PagePropertiesChangingEventArgs(contador, 1));

                    }


                }
             
            }
        }

        public void MostrarLista()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
            int IdEvaluacion = Convert.ToInt32(decodedString);
            evaluacion.ObtenerTotalReactivos(IdEvaluacion);
            int TotalReactivos = Convert.ToInt32(evaluacion.TotalReactivos);
            lstPreguntas.DataSource = evaluacion.MostrarPreguntaAleatoria(IdEvaluacion, TotalReactivos);
            lstPreguntas.DataBind();

            data = evaluacion.dt2;

            //if (lstPreguntas.Items.Count >= 1)
            //{
            //    btnFinalizar.Visible = true;
            //}
            //evaluacion.ObtenerTotalItems(IdEvaluacion);
            totalItems = evaluacion.TotalReactivos.ToString();
            lblTotal.Text = evaluacion.TotalReactivos.ToString();


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
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
            int IdPrograma = Convert.ToInt32(decodedString);
          
            foreach (ListViewItem itm in lstPreguntas.Items)
            {
                Label Id_Pregunta = (Label)itm.FindControl("lblIdPregunta");
                int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);

                RadioButtonList radioList = (RadioButtonList)itm.FindControl("radioList");
                Label Id_Respuesta = (Label)itm.FindControl("lblIdRespuesta");

                string ValorSeleccionado = radioList.SelectedValue;
                string IdRespuesta = Id_Respuesta.Text;
                if (ValorSeleccionado == "" && expirado!=1)
                {
                    expirado = 0;
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Seleccionar una respuesta.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    DataPager1.SetPageProperties(e.StartRowIndex - 1, e.MaximumRows, false);

                }
                else
                {
                    if (ValorSeleccionado == IdRespuesta)
                    {
                        if (EsRespuestaRepetida==Convert.ToInt32(IdRespuesta))
                        {
                            TimeAllSecondes = 60;
                            expirado = 0;

                            EsRespuestaRepetida = 0;

                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es correcta.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                        }
                        else
                        {
                            TimeAllSecondes = 60;
                            expirado = 0;
                            EsRespuestaRepetida = Convert.ToInt32(IdRespuesta);
                            cal++;
                            programa.InsertarRespuestaEvaluacion(IdPrograma, IdPregunta, Convert.ToInt32(ValorSeleccionado),1);
                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es correcta.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                        }
                     
                   
                    }
                    else
                    {
                        if (EsRespuestaRepetida2 == Convert.ToInt32(IdRespuesta))
                        {
                            TimeAllSecondes = 60;
                            expirado = 0;

                            radioList.SelectedValue = IdRespuesta;
                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es incorrecta. La respuesta correcta es: " + radioList.SelectedItem.ToString() + "");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                        }
                        else
                        {
                            TimeAllSecondes = 60;
                            expirado = 0;
                            EsRespuestaRepetida2 = Convert.ToInt32(IdRespuesta);

                            radioList.SelectedValue = IdRespuesta;
                            programa.InsertarRespuestaEvaluacion(IdPrograma, IdPregunta, Convert.ToInt32(ValorSeleccionado),0);

                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es incorrecta. La respuesta correcta es: " + radioList.SelectedItem.ToString() + "");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                            DataPager1.SetPageProperties(e.StartRowIndex, e.MaximumRows, false);
                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                        }
                    
                    }
                }




            }



            foreach (ListViewItem itm in lstPreguntas.Items)
            {
                Label Contador = (Label)itm.FindControl("lblContador");

                if (Contador.Text == totalItems)
                {
                    btnFinalizar.Visible = true;
                }


            }






        }

       

        //protected void DataPager1_PreRender(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        MostrarLista();

        //    }
        //}




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
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
            int IdPrograma = Convert.ToInt32(decodedString);
          
            foreach (ListViewItem itm in lstPreguntas.Items)
            {
                Label Id_Pregunta = (Label)itm.FindControl("lblIdPregunta");
                int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);

                RadioButtonList radioList = (RadioButtonList)itm.FindControl("radioList");
                Label Id_Respuesta = (Label)itm.FindControl("lblIdRespuesta");

                string ValorSeleccionado = radioList.SelectedValue;
                string IdRespuesta = Id_Respuesta.Text;
                if (ValorSeleccionado == "" && expirado !=1)
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "Seleccionar una respuesta.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                }
                else
                {
                    if (ValorSeleccionado == IdRespuesta)
                    {
                        if (EsRespuestaRepetida == Convert.ToInt32(IdRespuesta))
                        {
                            EsRespuestaRepetida = 0;


                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es correcta.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                            Timer2.Enabled = false;

                        }
                        else
                        {
                            cal++;
                            EsRespuestaRepetida = Convert.ToInt32(IdRespuesta);
                            programa.InsertarRespuestaEvaluacion(IdPrograma, IdPregunta, Convert.ToInt32(ValorSeleccionado),1);

                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es correcta.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                            Timer2.Enabled = false;

                        }


                    }
                    else
                    {
                       

                        if (EsRespuestaRepetida2 == Convert.ToInt32(IdRespuesta))
                        {
                          
                            radioList.SelectedValue = IdRespuesta;
                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es incorrecta. La respuesta correcta es: " + radioList.SelectedItem.ToString() + "");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                            Timer2.Enabled = false;

                        }
                        else
                        {
                          

                            radioList.SelectedValue = IdRespuesta;
                            programa.InsertarRespuestaEvaluacion(IdPrograma, IdPregunta, Convert.ToInt32(ValorSeleccionado),0);

                            string txtJS = String.Format("<script>alert('{0}');</script>", "La respuesta es incorrecta. La respuesta correcta es: " + radioList.SelectedItem.ToString() + "");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                            lstPreguntas.DataSource = data;
                            lstPreguntas.DataBind();
                            Timer2.Enabled = false;

                        }
                    }

                    decimal cantidadPreguntas = Convert.ToDecimal(lblTotal.Text);
                    programa.LeerTotalCorrectas(IdPrograma);
                   int TotalCorrectas =Convert.ToInt32( programa.TotalCorrectas);

                    decimal calificacion = (TotalCorrectas / cantidadPreguntas) * 10;

                    decimal calFinal = Math.Round(calificacion, 2);

                    //string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
                    //int IdPrograma = Convert.ToInt32(decodedString);

                    programa.EditarProgramaEv(IdPrograma, calFinal);

                    RowEvaluacion.Visible = false;
                    RowCalificacion.Visible = true;
                    lblCalificacion.Text = calFinal.ToString().Replace(",", ".");
                }




            }


            //decimal cal = 0;

            //foreach (ListViewItem itm in lstPreguntas.Items)
            //{
            //    RadioButtonList radioList = (RadioButtonList)itm.FindControl("radioList");
            //    Label Id_Respuesta = (Label)itm.FindControl("lblIdRespuesta");

            //    string ValorSeleccionado = radioList.SelectedValue;
            //    string IdRespuesta =Id_Respuesta.Text;
            //    if(ValorSeleccionado == IdRespuesta)
            //    {
            //        cal++;
            //    }




            //}


            //string txtJS = String.Format("<script>alert('{0}');</script>", "Tu calificación es: " + calFinal + " ");
            //ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("vCuestionario.aspx?ev=" + Request.QueryString["ev"] + "");
        }
    }
}