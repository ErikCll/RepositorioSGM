using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion.s
{
    public partial class Inicio : System.Web.UI.Page
    {
        Clase.InventarioMaterial inventario = new Clase.InventarioMaterial();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                int IdSuscripcion = Convert.ToInt32((this.Master as Administracion.s.Site1).IdSuscripcion.ToString());

                inventario.LeerDatosTotalAlmacen(IdSuscripcion);
                double TotalInventario = Convert.ToDouble(inventario.TotalInventario);
                lblTotal.Text = TotalInventario.ToString();
            }
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}