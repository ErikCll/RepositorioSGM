using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.Competencia.Programa
{
    public partial class Ver : System.Web.UI.Page
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
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
                int IdPrograma = Convert.ToInt32(decodedString);
                programa.LeerDatosProgramaEvaluacion(IdPrograma);
                lblEmpleado.Text = programa.Empleado;
                lblActividad.Text = programa.Actividad;
                lblEstatus.Text = programa.Estatus;
                lblFechaEvaluacion.Text = programa.FechaEvaluacion;
                lblFechaRealizado.Text = programa.FechaRealizado;
                lblCalificacion.Text = programa.Calificacion;
                MostrarLista();
            }
        }

        public void MostrarLista()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
            int IdPrograma = Convert.ToInt32(decodedString);
            lstPreguntas.DataSource = programa.MostrarPregunta(IdPrograma);
            lstPreguntas.DataBind();
       

        }
        protected void lstPreguntas_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["prog"]));
                int IdPrograma = Convert.ToInt32(decodedString);
                Label Id_Pregunta = (Label)e.Item.FindControl("lblIdPregunta");
                int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);

                Label Tipo_Pregunta = (Label)e.Item.FindControl("lblTipoPregunta");
                int TipoPregunta = Convert.ToInt32(Tipo_Pregunta.Text);

                programa.LeerRespuestaContestada(IdPregunta, IdPrograma);
                string IdRespuestaContestada =programa.Id_RespuestaIncorrecta;
                RadioButtonList radioList = (RadioButtonList)e.Item.FindControl("radioList");
                radioList.DataSource = programa.MostrarRespuesta(IdPregunta);
                radioList.DataBind();
                string IdRespuestaCorrecta = radioList.Items[0].Value;

                
                radioList.Items[0].Attributes.Add("style", "color:green");
                if (TipoPregunta == 1)
                {
                    string valor1 = radioList.Items[1].Value;
                    string valor2 = radioList.Items[2].Value;
                    string valor3 = radioList.Items[3].Value;


                    if (IdRespuestaContestada == IdRespuestaCorrecta)
                    {
                        radioList.Items[0].Selected = true;

                    }

                    else if (IdRespuestaContestada == valor1)
                    {
                        radioList.Items[1].Selected = true;

                        radioList.Items[1].Attributes.Add("style", "color:red");

                    }

                    else if (IdRespuestaContestada == valor2)
                    {
                        radioList.Items[2].Selected = true;

                        radioList.Items[2].Attributes.Add("style", "color:red");

                    }
                    else if (IdRespuestaContestada == valor3)
                    {
                        radioList.Items[3].Selected = true;

                        radioList.Items[3].Attributes.Add("style", "color:red");

                    }

                }
                else
                {
                    string valor1 = radioList.Items[1].Value;

                    if (IdRespuestaContestada == IdRespuestaCorrecta)
                    {
                        radioList.Items[0].Selected = true;

                    }

                    else if (IdRespuestaContestada == valor1)
                    {
                        radioList.Items[1].Selected = true;

                        radioList.Items[1].Attributes.Add("style", "color:red");

                    }
                }



            }

        }
        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Agregar.aspx?id=" + Request.QueryString["id"] + "&ev="+ Request.QueryString["ev"] + "");
        }
    }
}