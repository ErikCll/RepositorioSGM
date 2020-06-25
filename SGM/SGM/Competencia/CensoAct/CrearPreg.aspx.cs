using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class CrearPreg : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
                string IdEvaluacion = decodedString;
                lblIdEvaluacion.Text = IdEvaluacion;
                LlenarDropTipo();
                MostrarLista();
            }
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            int IdEvaluacion = Convert.ToInt32(lblIdEvaluacion.Text);
            string Pregunta = txtPregunta.Value;
            if (evaluacion.InsertarPregunta(IdEvaluacion,Pregunta))
            {
                evaluacion.ObtenerIdPregunta(IdEvaluacion);

                int IdPregunta = Convert.ToInt32(evaluacion.IdPregunta);
                if (ddl_Tipo.SelectedValue == "1")
                {
                    string RCorrecta = txt1.Text;
                    string R2 = txt2.Text;
                    string R3 = txt3.Text;
                    string R4 = txt4.Text;
                    evaluacion.InsertarRespuestaMultiple(IdPregunta, RCorrecta, "1");
                    evaluacion.InsertarRespuestaMultiple(IdPregunta, R2, "0");
                    evaluacion.InsertarRespuestaMultiple(IdPregunta, R3, "0");
                    evaluacion.InsertarRespuestaMultiple(IdPregunta, R4, "0");
                    MostrarLista();

                }
                else
                {
                    if (chkTrue.Checked == true)
                    {
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Verdadero", "1");
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Falso", "0");
                        MostrarLista();
                    }
                    else if (chkFalse.Checked == true)
                    {
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Falso", "1");
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Verdadero", "0");
                        MostrarLista();

                    }

                }

                

            }
        }

        public void LlenarDropTipo()
        {
          
            ddl_Tipo.Items.Insert(0, new ListItem("Opción múltiple", "1"));
            ddl_Tipo.Items.Insert(1, new ListItem("Verdadero o Falso", "2"));

        }

        public void MostrarLista()
        {
            int IdEvaluacion = Convert.ToInt32(lblIdEvaluacion.Text);

            lstPreguntas.DataSource = evaluacion.MostrarPregunta(IdEvaluacion);
            lstPreguntas.DataBind();

        }

        protected void ddl_Tipo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddl_Tipo.SelectedValue == "1")
            {
                divMultiple.Visible = true;
                DivTrue.Visible = false;
            }
            else
            {
                DivTrue.Visible = true;
                divMultiple.Visible = false;
            }
        }
    }
}