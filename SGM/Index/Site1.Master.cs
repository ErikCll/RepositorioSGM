using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            if(HttpContext.Current.User.Identity.IsAuthenticated)

            {

            }
            else
            {
                FormsAuthentication.SignOut();
                Response.Redirect(Request.UrlReferrer.ToString());

            }

            if (!IsPostBack)
            {
                string Usuario = Page.User.Identity.Name;
                master.LeerDatosUsuario(Usuario);
                lblIdSuscripcion.Text = master.IdSuscripcion;
                lblUsuario.Text = Usuario;
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

            }
        }

        protected void CerrarSesion(Object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
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

    }
}