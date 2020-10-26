using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Equipo
{
    public partial class Detalle : System.Web.UI.Page
    {
        Clase.Equipo equipo = new Clase.Equipo();
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
            if (accesos.ValidarEquipo(IdUsuario))
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

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEquipo = Convert.ToInt32(decodedString);
                equipo.LeerDatos(IdEquipo);
                lblNombre.Text = equipo.Nombre;
                lblMarca.Text = equipo.Marca;
                lblModelo.Text = equipo.Modelo;
                lblTipo.Text = equipo.Tipo;
                lblNoInventario.Text = equipo.NoInventario;
                lblSerie.Text = equipo.Serie;
                lblPrueba.Text = equipo.Prueba;
                lblInstalacion.Text = equipo.IdInstalacion;
            }
        }
    }
}