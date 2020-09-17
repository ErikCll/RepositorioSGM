using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Administracion.s.Catalogo.Material
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Material material = new Clase.Material();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarCatalogo(Usuario))
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
                (this.Master as Administracion.s.Site1).OcultarDrop = false;
                (this.Master as Administracion.s.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdMaterial = Convert.ToInt32(decodedString);
                material.LeerDatos(IdMaterial);
                txtNombre.Text = material.Nombre;
                txtCodigo.Text = material.Codigo;
                txtNumParte.Text = material.NumParte;
                txtCosto.Text = material.Costo;
                ddl_TipoUnidad.SelectedValue = material.TipoUnidad;
               
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
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdMaterial = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            string Codigo = txtCodigo.Text;
            string NumParte = txtNumParte.Text;
            string Costo = txtCosto.Text;
            string TipoUnidad = ddl_TipoUnidad.SelectedValue;
            if (material.Editar(IdMaterial,Nombre, Codigo, NumParte,Costo,TipoUnidad))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}