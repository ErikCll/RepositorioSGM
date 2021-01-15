using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Parametro
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Parametro parametro = new Clase.Parametro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as Operacion.s.Site1).OcultarDrop = false;
                (this.Master as Operacion.s.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEquipo = Convert.ToInt32(decodedString);
                parametro.LeerDatos(IdEquipo);
                txtElasticidad.Text = parametro.Elasticidad;
                txtVelocidad.Text = parametro.Velocidad;
                ddl_NoPasada.SelectedValue = parametro.Id_Material;

            }
        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdSuscripcion);

            ddl_NoPasada.DataSource = parametro.MostrarMaterial(IdSuscripcion);
            ddl_NoPasada.DataBind();
            ddl_NoPasada.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            string Elasticidad = txtElasticidad.Text;
            string Velocidad = txtVelocidad.Text;
            int IdMaterial = Convert.ToInt32(ddl_NoPasada.SelectedValue);
            if (parametro.Editar(IdEquipo,Elasticidad,Velocidad,IdMaterial))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}