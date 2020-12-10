using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace SGM.Competencia.CensoAct
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Actividad actividad = new Clase.Actividad();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarCensoActividad(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Form.DefaultButton = btnBuscar.UniqueID;

            if (!IsPostBack)
            {
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.s.Site1).IdInstalacion.ToString());
            gridActividad.DataSource = actividad.Mostrar(txtSearch.Text.Trim(),IdInstalacion);
            gridActividad.DataBind();
        }

        protected void gridActividad_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridActividad.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }
        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridActividad_RowCommand(object sender, GridViewCommandEventArgs e)
        {


            if (e.CommandName == "Eliminar")
            {
                //GridViewRow row = (GridViewRow)(((LinkButton)e.CommandSource).NamingContainer);
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                if (actividad.Eliminar(IdActividad))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
              


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdActividad.ToString())));

                Response.Redirect("Editar.aspx?id=" + encodedString + "");
            }

      

            else if (e.CommandName == "AgregarVer")
            {
                GridViewRow row = ((LinkButton)e.CommandSource).Parent.Parent as GridViewRow;
                int IdActividad = (int)gridActividad.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdActividad.ToString())));

                Response.Redirect("Control/Index.aspx?id=" + encodedString + "");
            }
        }

        protected void gridActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                Label IdArchivo = e.Row.FindControl("lblArchivo") as Label;
                Label FechaEmision = e.Row.FindControl("lblFechaEmision") as Label;
                Label FechaVigencia = e.Row.FindControl("lblFechaVigencia") as Label;
                Label Meses = e.Row.FindControl("lblMeses") as Label;


                HtmlControl Vig = e.Row.FindControl("Vigente") as HtmlControl;
                HtmlControl Ven = e.Row.FindControl("Vencido") as HtmlControl;


                HyperLink lnk = e.Row.FindControl("lnkArchivo") as HyperLink;
                if (Convert.ToInt32(IdArchivo.Text) == 0)
                {
                    lnk.Visible = false;
                }

                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdArchivo.Text)));
                lnk.NavigateUrl = "~/s/Competencia/Doc.aspx?id=" + encodedString;



                if (Meses.Text!="0")
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

                if (FechaEmision.Text != "" && FechaVigencia.Text=="")
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
        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}