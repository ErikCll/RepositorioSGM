using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.Requisito
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Requisito requisito = new Clase.Requisito();
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
            if (accesos.ValidarRequisito3(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdRequisito = Convert.ToInt32(decodedString);
                requisito.LeerDatos(IdRequisito);

                int TieneVigencia = Convert.ToInt32(requisito.TieneVigencia);
                txtNombre.Text = requisito.Nombre;
                if (TieneVigencia == 1)
                {
                    LlenarDropd();
                    Div1.Visible = true;
                    Div2.Visible = true;
                    Div3.Visible = true;
                    Div4.Visible = true;
                    reqRegulatoria.Enabled = true;
                    reqOperativa.Enabled = true;
                    txtOperativa.Text = requisito.VigenciaOpe;
                    txtRegulatoria.Text = requisito.VigenciaReg;

                }

            }
        }

        public void LlenarDropd()
        {
            ddl_Regulatoria.Items.Insert(0, new ListItem("Mes", "1"));
            ddl_Regulatoria.Items.Insert(1, new ListItem("Año", "2"));

            ddl_Operativa.Items.Insert(0, new ListItem("Mes", "1"));
            ddl_Operativa.Items.Insert(1, new ListItem("Año", "2"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdRequisito = Convert.ToInt32(decodedString);
            requisito.LeerDatos(IdRequisito);

            int TieneVigencia = Convert.ToInt32(requisito.TieneVigencia);
            string Nombre = txtNombre.Text;
            if (TieneVigencia == 1)
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


                        if (requisito.Editar(IdRequisito,Nombre, MesesRegulatoria, MeseseOperativa))
                        {
                            string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }
                    }
                }
            }
            else
            {
                int MesesRegulatoria = 0;
                int MeseseOperativa = 0;

                if (requisito.Editar(IdRequisito, Nombre, MesesRegulatoria, MeseseOperativa))
                {
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
            }
        }

    }
}