﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace Administracion.s
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
                if (login.ValidarAdministracion(Usuario))
                {
                    if (master.ValidarCatalogo(Usuario))
                    {
                        menu_catalogo.Visible = true;

                    }

                    if (master.ValidarPersonal(Usuario))
                    {
                        menu_personal.Visible = true;
                    }

                    if (master.ValidarAlmacen(Usuario))
                    {
                        menu_almacen.Visible = true;
                    }
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
                LlenarDrop();
                if (RadInstalacion.Items.Count == 1)
                {
                    int IdSuscripcion = Convert.ToInt32(lblIdSuscripcion.Text);

                    master.LeerDatosInstalacion(IdSuscripcion,Usuario);
                    RadInstalacion.SelectedValue = master.IdInstalacion;
                    lblIDInstalacion.Text = master.IdInstalacion;
                    RadInstalacion.Enabled = false;
                }
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {


                string activepage = Request.RawUrl;

                if (activepage.Contains("/s/Personal/ControlAsist/Index.aspx") || activepage.Contains("/s/Personal/ControlAsist/Detalle.aspx"))
                {
                    menu_personal.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    personal.Attributes.Add("class", "nav-link active");
                    controlasist.Attributes.Add("class", "nav-link active");

                }

              else if (activepage.Contains("/s/Catalogo/Material/Index.aspx") || activepage.Contains("/s/Catalogo/Material/Crear.aspx") || activepage.Contains("/s/Catalogo/Material/Editar.aspx"))
                {
                    menu_catalogo.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo.Attributes.Add("class", "nav-link active");
                    material.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/s/Almacen/InventarioMaterial/Index.aspx") || activepage.Contains("/s/Almacen/InventarioMaterial/Detalle.aspx"))
                {
                    menu_almacen.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    almacen.Attributes.Add("class", "nav-link active");
                    inventario.Attributes.Add("class", "nav-link active");

                }

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