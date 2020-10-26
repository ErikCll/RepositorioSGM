using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.RequisitoLegal.DocRegulador
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.DocRegulador docRegulador = new Clase.DocRegulador();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdDocRegulador = Convert.ToInt32(decodedString);
                docRegulador.LeerDatos(IdDocRegulador);
                txtNombre.Text = docRegulador.Nombre;
                ddl_Regulador.SelectedValue = docRegulador.IdRegulador;


            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdDocRegulador = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;
            int IdRegulador = Convert.ToInt32(ddl_Regulador.SelectedValue);
            if (docRegulador.Editar(IdDocRegulador, Nombre, IdRegulador))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdSuscripcion);
            ddl_Regulador.DataSource = docRegulador.MostrarRegulador(IdSuscripcion);
            ddl_Regulador.DataBind();
            ddl_Regulador.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

    }
}