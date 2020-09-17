using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct.Evaluacion
{
    public partial class EditarCuestionario : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
        Clase.Master master = new Clase.Master();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCompetencia(Usuario))
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
                (this.Master as SGM.s.Site1).OcultarDrop = false;
                (this.Master as SGM.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["preg"]));
                int IdPregunta = Convert.ToInt32(decodedString);
                string decodedString2 = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["tp"]));
                evaluacion.ObtenerPregunta(IdPregunta);
                txtPregunta.Value = evaluacion.Pregunta;
                int TipoPregunta = Convert.ToInt32(decodedString2);
                if (TipoPregunta == 1)
                {
                  
                    evaluacion.ObtenerR1(IdPregunta);
                    txt1.Text = evaluacion.R1;
                    IdR1.Text = evaluacion.IdRespuesta;
                    evaluacion.ObtenerR2(IdPregunta);
                    txt2.Text = evaluacion.R2;
                    IdR2.Text = evaluacion.IdRespuesta;
                    evaluacion.ObtenerR3(IdPregunta);
                    txt3.Text = evaluacion.R3;
                    IdR3.Text = evaluacion.IdRespuesta;
                    evaluacion.ObtenerR4(IdPregunta);
                    txt4.Text = evaluacion.R4;
                    IdR4.Text = evaluacion.IdRespuesta;
                }
                else
                {
                 
                    evaluacion.EsRespuesta(IdPregunta);
                    if (evaluacion.Respuesta == "Verdadero")
                    {
                        chkTrue.Checked = true;
                    }
                    else
                    {
                        chkFalse.Checked = true;
                    }
                    evaluacion.IdVerdadero(IdPregunta);
                    IdTrue.Text = evaluacion.IdRespuesta;
                    evaluacion.IdFalso(IdPregunta);
                    IdFalse.Text = evaluacion.IdRespuesta;
                    DivTrue.Visible = true;
                   divMultiple.Visible = false;
                }
            
            }

        }
        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("VCuestionario.aspx?ev=" + Request.QueryString["ev"] + "&ctr=" + Request.QueryString["ctr"] + "&act=" + Request.QueryString["act"] + "");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString2 = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["tp"]));
            int TipoPregunta = Convert.ToInt32(decodedString2);


            if (TipoPregunta == 1)
            {
                if (txt1.Text == string.Empty || txt2.Text == string.Empty || txt3.Text == string.Empty || txt4.Text == string.Empty)
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Llenar todos los campos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else
                {
                    string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["preg"]));
                    int IdPregunta = Convert.ToInt32(decodedString);
                    evaluacion.ObtenerPregunta(IdPregunta);
                    evaluacion.ObtenerR1(IdPregunta);
                    evaluacion.ObtenerR2(IdPregunta);
                    evaluacion.ObtenerR3(IdPregunta);
                    evaluacion.ObtenerR4(IdPregunta);
                    if (txtPregunta.Value != evaluacion.Pregunta)
                    {
                        string PreguntaValue = txtPregunta.Value;
                        evaluacion.ModificarPregunta(IdPregunta, PreguntaValue);
                        string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    }
                      int IdRespuesta = Convert.ToInt32(IdR1.Text);
                        string R1 = txt1.Text;
                        evaluacion.ModificarRespuesta(IdRespuesta, R1);
                    
                 
                        int IdRespuesta2 = Convert.ToInt32(IdR2.Text);
                        string R2 = txt2.Text;
                        evaluacion.ModificarRespuesta(IdRespuesta2, R2);
                    
                  
                        int IdRespuesta3 = Convert.ToInt32(IdR3.Text);
                        string R3 = txt3.Text;
                        evaluacion.ModificarRespuesta(IdRespuesta3, R3);
                    
                 
                        int IdRespuesta4 = Convert.ToInt32(IdR4.Text);
                        string R4 = txt4.Text;
                        evaluacion.ModificarRespuesta(IdRespuesta4, R4);
                    string txtJS2 = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS2, false);

                }


            }
            else
            {
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["preg"]));
                int IdPregunta = Convert.ToInt32(decodedString);
                evaluacion.ObtenerPregunta(IdPregunta);

                if (txtPregunta.Value != evaluacion.Pregunta)
                {
                    string PreguntaValue = txtPregunta.Value;
                    evaluacion.ModificarPregunta(IdPregunta, PreguntaValue);
                    string txtJS2 = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS2, false);
                }
                if (chkTrue.Checked == true)
                {
                    int IdRespuestaTrue = Convert.ToInt32(IdTrue.Text);
                    int IdRespuestaFalse = Convert.ToInt32(IdFalse.Text);

                    evaluacion.ModificarRespuestaToF(IdRespuestaTrue, 1);
                    evaluacion.ModificarRespuestaToF(IdRespuestaFalse, 0);
                    string txtJS2 = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS2, false);

                }
                else if (chkFalse.Checked == true)
                {
                    int IdRespuestaTrue = Convert.ToInt32(IdTrue.Text);
                    int IdRespuestaFalse = Convert.ToInt32(IdFalse.Text);

                    evaluacion.ModificarRespuestaToF(IdRespuestaTrue, 0);
                    evaluacion.ModificarRespuestaToF(IdRespuestaFalse, 1);
                    string txtJS2 = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS2, false);
                }

            }
         



        }
    }
}