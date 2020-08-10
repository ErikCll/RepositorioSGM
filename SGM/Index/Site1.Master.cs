using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Index
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
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

    }
}