using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.ControlAct.CensoAct.Evaluacion
{
    public partial class CrearCuestionario : System.Web.UI.Page
    {
        Clase.Evaluacion evaluacion = new Clase.Evaluacion();
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
            if (accesos.ValidarCensoActividad10(IdUsuario))
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
                chkTrue.Checked = true;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ev"]));
                string IdEvaluacion = decodedString;
                string decodedString2 = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["ctr"]));
                int IdControl = Convert.ToInt32(decodedString2);
                evaluacion.LeerDatosControl(IdControl);
                lblVersion.Text = evaluacion.Codigo;
                lblIdEvaluacion.Text = IdEvaluacion;
                lblIdEvaluacion.Visible = false;
                LlenarDropTipo();

            }
            MostrarLista();

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
           

                if (ddl_Tipo.SelectedValue == "1")
                {
                   if(txt1.Text==string.Empty || txt2.Text==string.Empty|| txt3.Text==string.Empty|| txt4.Text == string.Empty)
                    {
                        string txtJS = String.Format("<script>alert('{0}');</script>", "Llenar todos los campos.");
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    }
                    else
                    {
                    int IdEvaluacion = Convert.ToInt32(lblIdEvaluacion.Text);
                    string Pregunta = txtPregunta.Value;
                    if (evaluacion.InsertarPregunta(IdEvaluacion, Pregunta,1))
                    {
                        evaluacion.ObtenerIdPregunta(IdEvaluacion);
                        int IdPregunta = Convert.ToInt32(evaluacion.IdPregunta);

                        string RCorrecta = txt1.Text;
                        string R2 = txt2.Text;
                        string R3 = txt3.Text;
                        string R4 = txt4.Text;
                        evaluacion.InsertarRespuestaMultiple(IdPregunta, RCorrecta, "1",1);
                        evaluacion.InsertarRespuestaMultiple(IdPregunta, R2, "0",2);
                        evaluacion.InsertarRespuestaMultiple(IdPregunta, R3, "0",3);
                        evaluacion.InsertarRespuestaMultiple(IdPregunta, R4, "0",4);
                        MostrarLista();
                        Limpiar();
                    }
                       

                    }
                   

                }
                else
                {
                int IdEvaluacion = Convert.ToInt32(lblIdEvaluacion.Text);
                string Pregunta = txtPregunta.Value;
                if (evaluacion.InsertarPregunta(IdEvaluacion, Pregunta,2))
                {
                    evaluacion.ObtenerIdPregunta(IdEvaluacion);
                    int IdPregunta = Convert.ToInt32(evaluacion.IdPregunta);

                    if (chkTrue.Checked == true)
                    {
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Verdadero", "1");
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Falso", "0");
                        MostrarLista();
                        Limpiar();
                    }
                    else if (chkFalse.Checked == true)
                    {
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Falso", "1");
                        evaluacion.InsertarRespuestaVoF(IdPregunta, "Verdadero", "0");
                        MostrarLista();
                        Limpiar();
                    }
                }

               

                }

                

            
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("~/s/ControlAct/CensoAct/Evaluacion/Crear.aspx?id=" + Request.QueryString["ctr"] + "&act=" + Request.QueryString["act"] + "");
        }
        public void Limpiar()
        {
            txtPregunta.Value = string.Empty;
            txt1.Text = string.Empty;
            txt2.Text = string.Empty;
            txt3.Text = string.Empty;
            txt4.Text = string.Empty;
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
            if (lstPreguntas.Items.Count >= 1)
            {
                btnTerminar.Visible = true;
            }
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

        protected void Eliminar(object sender, EventArgs e)
        {
            ListViewItem item = (sender as LinkButton).NamingContainer as ListViewItem;
            //int id = (int)lstPreguntas.DataKeys[item.DataItemIndex].Values["Id_Producto"];
            Label Id_Pregunta = (Label)item.FindControl("lblIdPregunta");
            int IdPregunta = Convert.ToInt32(Id_Pregunta.Text);
            evaluacion.EliminarPregunta(IdPregunta);
            MostrarLista();
        }

        protected void btnTerminar_Click(object sender, EventArgs e)
        {
            string IdEvaluacion = lblIdEvaluacion.Text;

            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEvaluacion.ToString())));

            Response.Redirect("VCuestionario.aspx?ev=" + encodedString + "&ctr=" + Request.QueryString["ctr"] + "&act=" + Request.QueryString["act"] + "");

        }
    }
}