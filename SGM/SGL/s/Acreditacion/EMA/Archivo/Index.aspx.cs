using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Acreditacion.EMA.Archivo
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.Archivo archivo = new Clase.Archivo();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarEma(IdUsuario))
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
                (this.Master as SGL.s.Site1).OcultarDrop = false;
                (this.Master as SGL.s.Site1).OcultarLabel = false;

                //LlenarDrop();

            }
        }

        public void MostrarGrid()
        {
            //string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            //int IdAcreditacion = Convert.ToInt32(decodedString);
            //gridAcreditacion.DataSource = ema.Mostrar(txtSearch.Text.Trim(), IdInstalacion);
            //gridAcreditacion.DataBind();
        }

        protected void gridAcreditacion_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridAcreditacion.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void Buscar(Object sender, EventArgs e)
        {
            MostrarGrid();
        }
    }
}