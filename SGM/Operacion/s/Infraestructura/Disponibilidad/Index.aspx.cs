using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Infraestructura.Disponibilidad
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Disponibilidad disponibilidad = new Clase.Disponibilidad();
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
            int IdUsuario = Convert.ToInt32((this.Master as Operacion.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarDisponibilidadDeEquipos(IdUsuario))
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
                MostrarLista();
            }
        }
    

        public void MostrarLista()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdInstalacion.ToString());
            listEquipos.DataSource = disponibilidad.MostrarEquipos(txtSearch.Text.Trim(),IdInstalacion);
            listEquipos.DataBind();
        }
        protected void listEquipos_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem)
            {

                Label Estatus = (Label)e.Item.FindControl("lblEstatus");
                System.Web.UI.HtmlControls.HtmlControl operando = (System.Web.UI.HtmlControls.HtmlControl)e.Item.FindControl("operando");
                System.Web.UI.HtmlControls.HtmlControl fallando = (System.Web.UI.HtmlControls.HtmlControl)e.Item.FindControl("fallando");

                if (Estatus.Text == "Operando")
                {
                    operando.Visible = true;
                }

                else if (Estatus.Text == "Falla")
                {
                    fallando.Visible = true;
                }

            }
        }



        protected void listEquipos_ItemCommand(object sender, ListViewCommandEventArgs e)
        {
            if (e.CommandName == "Ver")
            {
                ListViewDataItem item = (ListViewDataItem)e.Item;

                Label lblIdEquipo = (Label)item.FindControl("lblIdEquipo");
                Label lblFecha= (Label)item.FindControl("lblFecha");
                int IdEquipo = Convert.ToInt32(lblIdEquipo.Text);
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdEquipo.ToString())));
                string encodedString2 = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(lblFecha.Text.ToString())));


                Response.Redirect("Bitacora/Index.aspx?id=" + encodedString + "&fec="+encodedString2+"");
            }
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarLista();
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}