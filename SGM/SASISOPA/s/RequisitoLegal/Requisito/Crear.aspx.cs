using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.Requisito
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Requisito requisito = new Clase.Requisito();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                checkSin.Checked = true;
               if( checkSin.Checked == true)
                {
                    reqRegulatoria.Enabled = false;
                    reqOperativa.Enabled = false;
                    Div1.Visible = false;
                    Div2.Visible = false;
                    Div3.Visible = false;
                    Div4.Visible = false;
                    checkCon.Checked = false;
                }
                LlenarDropd();
                LlenarDropRegulador();
                LlenarDropDocRegulador();

            }

        }

        public void LlenarDropRegulador()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdSuscripcion);
            ddl_Regulador.DataSource = requisito.MostrarRegulador(IdSuscripcion);
            ddl_Regulador.DataBind();
            ddl_Regulador.Items.Insert(0, new ListItem("[Seleccionar]","0"));

        }

        public void LlenarDropDocRegulador()
        {
            int IdRegulador = Convert.ToInt32(ddl_Regulador.SelectedValue);
            ddl_DocRegulador.DataSource = requisito.MostrarDocRegulador(IdRegulador);
            ddl_DocRegulador.DataBind();
            ddl_DocRegulador.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        public void LlenarDropd()
        {
            //ddl_Regulatoria.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddl_Regulatoria.Items.Insert(0, new ListItem("Mes", "1"));
            ddl_Regulatoria.Items.Insert(1, new ListItem("Año", "2"));

            //ddl_Operativa.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
            ddl_Operativa.Items.Insert(0, new ListItem("Mes", "1"));
            ddl_Operativa.Items.Insert(1, new ListItem("Año", "2"));

        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            
            int IdDocRegulador = Convert.ToInt32(ddl_DocRegulador.SelectedValue);
            
           
            int TieneVigencia = 0;
       
            if (checkSin.Checked == true)
            {
                int MesesRegulatoria=0;
                int MeseseOperativa=0;
                if (requisito.Insertar(Nombre,MesesRegulatoria,MeseseOperativa,TieneVigencia,IdDocRegulador))
                {
                    string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                }

            }

            else if (checkCon.Checked == true)
            {
                int MesesRegulatoria = Convert.ToInt32(txtRegulatoria.Text);
                int MeseseOperativa = Convert.ToInt32(txtOperativa.Text);
                 TieneVigencia = 1;

                if (ddl_Regulatoria.SelectedValue == "2")
                {
                    MesesRegulatoria = MesesRegulatoria * 12;
                }
                if (ddl_Operativa.SelectedValue == "2")
                {
                    MeseseOperativa = MeseseOperativa * 12;
                }

                if (MeseseOperativa > MesesRegulatoria)
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "La vigencia Operativa no puede ser mayor a la Vigencia Regulatoria.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else
                {
                    if (MesesRegulatoria == 0 || MeseseOperativa == 0)
                    {
                        string txtJS = String.Format("<script>alert('{0}');</script>", "La cantidad debe ser mayor a 0.");
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                    }
                    else
                    {
                       

                        if (requisito.Insertar(Nombre, MesesRegulatoria, MeseseOperativa, TieneVigencia, IdDocRegulador))
                        {
                            string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                        }
                    }
                }
               
            }
      
   

        }

        protected void ddl_Regulador_SelectedIndexChanged(object sender, EventArgs e)
        {
            int IdRegulador = Convert.ToInt32(ddl_Regulador.SelectedValue);
            ddl_DocRegulador.DataSource = requisito.MostrarDocRegulador(IdRegulador);
            ddl_DocRegulador.DataBind();
            ddl_DocRegulador.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        protected void ddl_DocRegulador_SelectedIndexChanged(object sender, EventArgs e)
        {

          

        }

        protected void checkSin_CheckedChanged(object sender, EventArgs e)
        {
            if (checkSin.Checked == true)
            {
                reqRegulatoria.Enabled = false;
                reqOperativa.Enabled = false;
                Div1.Visible = false;
                Div2.Visible = false;
                Div3.Visible = false;
                Div4.Visible = false;
                checkCon.Checked = false;


            }
            else
            {
                reqRegulatoria.Enabled = true;
                reqOperativa.Enabled = true;
                Div1.Visible = true;
                Div2.Visible = true;
                Div3.Visible = true;
                Div4.Visible = true;
                checkCon.Checked = true;
            }
        }

        protected void checkCon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkCon.Checked == true)
            {
                reqRegulatoria.Enabled = true;
                reqOperativa.Enabled = true;
                Div1.Visible = true;
                Div2.Visible = true;
                Div3.Visible = true;
                Div4.Visible = true;
                checkSin.Checked = false;
            }
            else
            {
                reqRegulatoria.Enabled = false;
                reqOperativa.Enabled = false;
                Div1.Visible = false;
                Div2.Visible = false;
                Div3.Visible = false;
                Div4.Visible = false;
                checkSin.Checked = true;
            }
        }
    }
}