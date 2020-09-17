using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SASISOPA.s
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Clase.Master master = new Clase.Master();
        Clase.Login login = new Clase.Login();

        protected void Page_Init(object sender, EventArgs e)
        {

            if (HttpContext.Current.User.Identity.IsAuthenticated)

            {
                string Usuario = Page.User.Identity.Name;
                if (login.ValidarSASISOPA(Usuario))
                {

                }
                else
                {
                    FormsAuthentication.SignOut();
                    Response.Redirect(Request.UrlReferrer.ToString());
                }

            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect(Request.UrlReferrer.ToString());

            }

            if (RadInstalacion.SelectedIndex == -1)
            {
                lblIDInstalacion.Text = "0";

            }

            if (Session["IdInstalacion"] != null)
            {
                RadInstalacion.SelectedValue = Session["IdInstalacion"].ToString();
                lblIDInstalacion.Text = Session["IdInstalacion"].ToString();

            }

            if (!IsPostBack)
            {
                string Usuario = Page.User.Identity.Name;
                master.LeerDatosUsuario(Usuario);
                lblIdSuscripcion.Text = master.IdSuscripcion;
                lblTitulo.Text = master.Nombre;

                lblUsuario.Text = Usuario;
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                LlenarDrop();

                string activepage = Request.RawUrl;

              
                if (activepage.Contains("/Competencia/Inicio.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Competencia/CensoAct/Index.aspx") || activepage.Contains("/Competencia/CensoAct/Crear.aspx") || activepage.Contains("/Competencia/CensoAct/Detalle.aspx") || activepage.Contains("/Competencia/CensoAct/Editar.aspx") || activepage.Contains("/Competencia/CensoAct/Control/Index.aspx") || activepage.Contains("/Competencia/CensoAct/Control/Crear.aspx") || activepage.Contains("/Competencia/CensoAct/Control/Editar.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/Crear.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/CrearCuestionario.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/Editar.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/EditarCuestionario.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/VCuestionario.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }
                else if (activepage.Contains("/Competencia/MatrizCatAct/Index.aspx") || activepage.Contains("/Competencia/MatrizCatAct/Agregar.aspx") || activepage.Contains("/Competencia/MatrizCatAct/Detalle.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //catact.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Competencia/MatrizInsAct/Index.aspx") || activepage.Contains("/Competencia/MatrizInsAct/Agregar.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //catact.Attributes.Add("class", "nav-link active");

                }
                else if (activepage.Contains("/Competencia/Programa/Index.aspx") || activepage.Contains("/Competencia/Programa/Agregar.aspx") || activepage.Contains("/Competencia/Programa/Detalle.aspx") || activepage.Contains("/Competencia/Programa/DetalleEv.aspx") || activepage.Contains("/Competencia/Programa/Editar.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //prog.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Competencia/MatrizCatEmp/Index.aspx") || activepage.Contains("/Competencia/MatrizCatEmp/Agregar.aspx") || activepage.Contains("/Competencia/MatrizCatEmp/Detalle.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //catemp.Attributes.Add("class", "nav-link active");

                }


                //else if (activepage.Contains("/Confirmacion/CensoSis/Index.aspx") || activepage.Contains("/Confirmacion/CensoSis/Crear.aspx") || activepage.Contains("/Confirmacion/CensoSis/Editar.aspx") || activepage.Contains("/Confirmacion/CensoSis/Componente/Index.aspx") || activepage.Contains("/Confirmacion/CensoSis/Componente/Editar.aspx") || activepage.Contains("/Confirmacion/CensoSis/Componente/Crear.aspx"))
                //{
                //    menu_confirmacion.Attributes.Add("class", "  nav-item has-treeview menu-open");
                //    confirmacion.Attributes.Add("class", "nav-link active");
                //    sistema.Attributes.Add("class", "nav-link active");

                //}


            }

        }
        public string IdInstalacion
        {
            get
            {


                return lblIDInstalacion.Text;
            }
        }

        public string TipoSistema
        {
            get
            {


                return IdTipoSistema.Text;
            }
        }

        public bool OcultarDrop
        {
            get { return RadInstalacion.Visible; }
            set { RadInstalacion.Visible = value; }
        }
        public bool OcultarLabel
        {
            get { return lblInstalacion.Visible; }
            set { lblInstalacion.Visible = value; }
        }


        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32(lblIdSuscripcion.Text);

            RadInstalacion.DataSource = master.MostrarInstalacion(IdSuscripcion);
            RadInstalacion.DataBind();

        }

        //protected void RadComboBox1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
        //{
        // var ss= RadInstalacion.SelectedItem;
        // var sss= RadInstalacion.SelectedValue;
        //  var tt= RadInstalacion.SelectedIndex;


        //}

        protected void RadInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string IdInstalacion = RadInstalacion.SelectedValue;
            lblIDInstalacion.Text = IdInstalacion;
            Session["IdInstalacion"] = IdInstalacion;
            Response.Redirect(Request.UrlReferrer.ToString());
        }


        protected void CerrarSesion(Object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();

            Response.Redirect(Request.UrlReferrer.ToString());
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }

        public string IdSuscripcion
        {

            set
            {
                lblIdSuscripcion.Text = value;
            }

            get
            {

                return lblIdSuscripcion.Text;
            }


        }

        protected void lnkInstalacion_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Instalacion/Index.aspx?url=" + encodedString + "");
        }

        protected void lnkArea_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Area/Index.aspx?url=" + encodedString + "");
        }

        protected void lnkCategoria_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Categoria/Index.aspx?url=" + encodedString + "");
        }

        protected void lnkEmpleado_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Empleado/Index.aspx?url=" + encodedString + "");
        }
    }
}