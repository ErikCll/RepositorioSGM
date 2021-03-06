﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

public partial class s_Site1 : System.Web.UI.MasterPage
{
    Master master = new Master();
    Login login = new Login();
    protected void Page_Init(object sender, EventArgs e)
    {

        if (HttpContext.Current.User.Identity.IsAuthenticated)

        {


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
            lblIdUsuario.Text = master.IdUsuario;

            lblIdSuscripcion.Text = master.IdSuscripcion;
            lblTitulo.Text = master.Nombre;
            lblUsuario.Text = Usuario;
            ValidarAccesos();

            //LlenarDrop();
            if (RadInstalacion.Items.Count == 1)
            {
                int IdSuscripcion = Convert.ToInt32(lblIdSuscripcion.Text);
                int IdUsuario = Convert.ToInt32(lblIdUsuario.Text);

                master.LeerDatosInstalacion(IdSuscripcion, IdUsuario);
                RadInstalacion.SelectedValue = master.IdInstalacion;
                lblIDInstalacion.Text = master.IdInstalacion;
                RadInstalacion.Enabled = false;
            }
        }

    }

    public void ValidarAccesos()
    {
        int IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
        if (login.ValidarSecretario(IdUsuario))
        {
            
        }
        else
        {
            FormsAuthentication.SignOut();
            Session.RemoveAll();

            Response.Redirect("~/s/Login.aspx");

            //FormsAuthentication.SignOut();
            //Response.Redirect(Request.UrlReferrer.ToString());
        }
    }

    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {


            string activepage = Request.RawUrl;


            //if (activepage.Contains("/Competencia/Inicio.aspx") || activepage.Contains("/Competencia/Programa/Index.aspx") || activepage.Contains("/Competencia/Programa/Agregar.aspx") || activepage.Contains("/Competencia/Programa/Detalle.aspx") || activepage.Contains("/Competencia/Programa/DetalleEv.aspx") || activepage.Contains("/Competencia/Programa/Editar.aspx") || activepage.Contains("/Competencia/ResultadoEv/Index.aspx") || activepage.Contains("/Competencia/ResultadoEv/Detalle.aspx"))
            //{
            //    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
            //    competencia.Attributes.Add("class", "nav-link active");

            //}

            


        }

    }

    public string IDUsuario
    {

        set
        {
            lblIdUsuario.Text = value;
        }

        get
        {

            return lblIdUsuario.Text;
        }


    }

    public string IdInstalacion
    {
        get
        {


            return lblIDInstalacion.Text;
        }
    }

    //public string TipoSistema
    //{
    //    get
    //    {


    //        return IdTipoSistema.Text;
    //    }
    //}

    //public bool OcultarDrop
    //{
    //    get { return RadInstalacion.Visible; }
    //    set { RadInstalacion.Visible = value; }
    //}
    //public bool OcultarLabel
    //{
    //    get { return lblInstalacion.Visible; }
    //    set { lblInstalacion.Visible = value; }
    //}


    //public void LlenarDrop()
    //{
    //    int IdSuscripcion = Convert.ToInt32(lblIdSuscripcion.Text);
    //    int IdUsuario = Convert.ToInt32(lblIdUsuario.Text);
    //    RadInstalacion.DataSource = master.MostrarInstalacion(IdSuscripcion, IdUsuario);
    //    RadInstalacion.DataBind();

    //}

    protected void RadComboBox1_SelectedIndexChanged(object sender, Telerik.Web.UI.RadComboBoxSelectedIndexChangedEventArgs e)
    {
        var ss = RadInstalacion.SelectedItem;
        var sss = RadInstalacion.SelectedValue;
        var tt = RadInstalacion.SelectedIndex;


    }

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

    //protected void IrSAM(Object sender, EventArgs e)
    //{
    //    Session.RemoveAll();
    //    Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
    //}

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
