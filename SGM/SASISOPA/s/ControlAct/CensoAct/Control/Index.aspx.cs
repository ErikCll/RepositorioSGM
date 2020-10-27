using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace SASISOPA.s.ControlAct.CensoAct.Control
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.ActividadControl control = new Clase.ActividadControl();
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
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                control.LeerDatosActividad(IdActividad);
                lblCensoAct.Text = control.Actividad;
            }
             

        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            gridControl.DataSource = control.Mostrar(IdActividad);
            gridControl.DataBind();
        }

        protected void gridControl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridControl.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void CrearVersion(Object sender, EventArgs e)
        {
            Response.Redirect("Crear.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void gridControl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdControl = (int)gridControl.DataKeys[e.Row.RowIndex].Value;
                Label FechaEmision = e.Row.FindControl("lblFechaEmision") as Label;
                Label FechaVigencia = e.Row.FindControl("lblFechaVigencia") as Label;
                Label Meses = e.Row.FindControl("lblMeses") as Label;
                Label TieneVigencia= e.Row.FindControl("lblTieneVigencia") as Label;

                HtmlControl Vig = e.Row.FindControl("Vigente") as HtmlControl;
                HtmlControl Ven = e.Row.FindControl("Vencido") as HtmlControl;
                HyperLink lnk = e.Row.FindControl("lnk") as HyperLink;
                lnk.NavigateUrl = "https://er2020.blob.core.windows.net/sasisopa/10/" + IdControl.ToString() + ".pdf";
                HtmlControl Vig2 = e.Row.FindControl("Vigente") as HtmlControl;

            

                if (TieneVigencia.Text == "1")
                {
                   

                    DateTime FechaActual = DateTime.ParseExact(DateTime.Now.AddHours(-5).ToString("dd-MM-yyyy"), "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime Fecha_Emision = DateTime.ParseExact(FechaEmision.Text, "dd-MM-yyyy", System.Globalization.CultureInfo.InvariantCulture);
                    DateTime Fecha_Vigencia = Fecha_Emision.AddMonths(Convert.ToInt32(Meses.Text));
                    FechaVigencia.Text = Fecha_Vigencia.ToString("dd-MM-yyyy");
                    if (FechaActual < Fecha_Vigencia)
                    {
                        Vig.Visible = true;
                    }
                    else if (FechaActual >= Fecha_Vigencia)
                    {
                        Ven.Visible = true;
                    }
                }

                if (FechaEmision.Text != "" && FechaVigencia.Text == "")
                {
                    FechaVigencia.Text = "N/A";
                    Vig.Visible = true;

                }
                //else
                //{
                //    Vig.Visible = false;

                //}

            }
        }

        protected void gridControl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                if (control.Eliminar(IdControl))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
              


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdControl.ToString())));


                Response.Redirect("Editar.aspx?id=" + encodedString + "&act="+ Request.QueryString["id"] + "");
            }
            else if (e.CommandName == "AgregarEv")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdControl.ToString())));

                Response.Redirect("~/s/ControlAct/CensoAct/Evaluacion/Crear.aspx?id=" + encodedString + "&act=" + Request.QueryString["id"] +"");
            }
            

        }
    }
}