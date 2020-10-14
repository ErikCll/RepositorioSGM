using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SAM
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Clase.Master master = new Clase.Master();
        Clase.Login login = new Clase.Login();
        protected void Page_Init(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)

            {
                string Usuario = Page.User.Identity.Name;
                if (master.ValidarCatalogo(Usuario))
                {
                    menu_catalogo1.Visible = true;
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
                LlenarDrop();
                if (RadInstalacion.Items.Count == 1)
                {
                    int IdSuscripcion = Convert.ToInt32(lblIdSuscripcion.Text);
                    master.LeerDatosInstalacion(IdSuscripcion,Usuario);
                    RadInstalacion.SelectedValue = master.IdInstalacion;
                    lblIDInstalacion.Text = master.IdInstalacion;
                    RadInstalacion.Enabled = false;
                }
                if (login.ValidarSGM(Usuario))
                {
                    SGM.Visible = true;
                }
                if (login.ValidarSASISOPA(Usuario))
                {
                    SASISOPA.Visible = true;
                }
                if (login.ValidarOperacion(Usuario))
                {
                    Operacion.Visible = true;
                }

                if (login.ValidarMantenimiento(Usuario))
                {
                    Mantenimiento.Visible = true;

                }

                if (login.ValidarSeguridadIndustrial(Usuario))
                {
                    Seguridad.Visible = true;
                }

                if (login.ValidarAdministracion(Usuario))
                {
                    Administracion.Visible = true;
                }

                if (login.ValidarSGL(Usuario))
                {
                    SGL.Visible = true;
                }
            }
            
        }

        protected void Page_Load(object sender, EventArgs e)
        {
           
            if (!IsPostBack)
            {

              
               



                string activepage = Request.RawUrl;

                if (activepage.Contains("/Catalogo/Instalacion/Index.aspx") || activepage.Contains("/Catalogo/Instalacion/Crear.aspx") || activepage.Contains("/Catalogo/Instalacion/Detalle.aspx") || activepage.Contains("/Catalogo/Instalacion/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    instalacion1.Attributes.Add("class", "nav-link active");



                }

                else if (activepage.Contains("/Catalogo/Area/Index.aspx") || activepage.Contains("/Catalogo/Area/Crear.aspx") || activepage.Contains("/Catalogo/Area/Detalle.aspx") || activepage.Contains("/Catalogo/Area/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    area1.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Catalogo/Empleado/Index.aspx") || activepage.Contains("/Catalogo/Empleado/Crear.aspx") || activepage.Contains("/Catalogo/Empleado/Detalle.aspx") || activepage.Contains("/Catalogo/Empleado/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    empleado1.Attributes.Add("class", "nav-link active");

                }
                else if (activepage.Contains("/Catalogo/Categoria/Index.aspx") || activepage.Contains("/Catalogo/Categoria/Crear.aspx") || activepage.Contains("/Catalogo/Categoria/Detalle.aspx") || activepage.Contains("/Catalogo/Categoria/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    categoria1.Attributes.Add("class", "nav-link active");

                }
                else if (activepage.Contains("/Catalogo/Cliente/Index.aspx") || activepage.Contains("/Catalogo/Cliente/Crear.aspx") || activepage.Contains("/Catalogo/Cliente/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    cliente.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Catalogo/Material/Index.aspx") || activepage.Contains("/Catalogo/Material/Crear.aspx") || activepage.Contains("/Catalogo/Material/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    material.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Catalogo/Equipo/Index.aspx") || activepage.Contains("/Catalogo/Equipo/Crear.aspx") || activepage.Contains("/Catalogo/Equipo/Detalle.aspx") || activepage.Contains("/Catalogo/Equipo/Editar.aspx"))
                {
                    menu_catalogo1.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo1.Attributes.Add("class", "nav-link active");
                    equipo.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Indicador/SGL/Inicio.aspx") || activepage.Contains("/Indicador/SGL/Acreditacion/Detalle.aspx"))
                {
                    menu_indicador.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    indicador.Attributes.Add("class", "nav-link active");
                    sgl2.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Indicador/SASISOPA/Inicio.aspx"))
                {
                    menu_indicador.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    indicador.Attributes.Add("class", "nav-link active");
                    sasisopa2.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Usuario/Index.aspx") || activepage.Contains("/Usuario/Crear.aspx") || activepage.Contains("/Usuario/Editar.aspx") || activepage.Contains("/Usuario/Agregar.aspx"))
                {
                    menu_usuario.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    usuario.Attributes.Add("class", "nav-link active");

                }



            }
        }

        protected void CerrarSesion(Object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();
            Response.Redirect(Request.UrlReferrer.ToString());
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


        public string IdInstalacion
        {
            
            get
            {

                return lblIDInstalacion.Text;
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
            string Usuario = Page.User.Identity.Name;

            RadInstalacion.DataSource = master.MostrarInstalacion(IdSuscripcion, Usuario);
            RadInstalacion.DataBind();

        }

        protected void RadInstalacion_SelectedIndexChanged(object sender, RadComboBoxSelectedIndexChangedEventArgs e)
        {
            string IdInstalacion = RadInstalacion.SelectedValue;
            lblIDInstalacion.Text = IdInstalacion;
            Session["IdInstalacion"] = IdInstalacion;
            Response.Redirect(Request.UrlReferrer.ToString());
        }

    }
}