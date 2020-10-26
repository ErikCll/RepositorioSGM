using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Material
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Material material = new Clase.Material();
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
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (accesos.ValidarMaterial(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }


        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                LlenarDrop();
            }
        }

        public void LlenarDrop()
        {

            ddl_TipoUnidad.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_TipoUnidad.Items.Insert(1, new ListItem("Pieza"));
            ddl_TipoUnidad.Items.Insert(2, new ListItem("Metro"));
            ddl_TipoUnidad.Items.Insert(3, new ListItem("Litro"));
            ddl_TipoUnidad.Items.Insert(4, new ListItem("Gramo"));
            ddl_TipoUnidad.Items.Insert(5, new ListItem("Lote"));
            ddl_TipoUnidad.Items.Insert(6, new ListItem("Paquete"));




        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Codigo = txtCodigo.Text;
            string NumParte = txtNumParte.Text;
            //decimal decimalMoneyValue = Convert.ToDecimal(txtCosto.Text);
            //string Costo = String.Format("{0:C}", decimalMoneyValue);
            string Costo = txtCosto.Text;
            string TipoUnidad = ddl_TipoUnidad.SelectedValue;

            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());
            if (material.Insertar(Nombre, Codigo, NumParte, IdSuscripcion, Costo, TipoUnidad))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }
    }
}