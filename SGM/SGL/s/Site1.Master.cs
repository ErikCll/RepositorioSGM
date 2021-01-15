using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SGL.s
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        Clase.Master master = new Clase.Master();
        Clase.Login login = new Clase.Login();
        Clase.Accesos accesos = new Clase.Accesos();




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

                LlenarDrop();
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
            if (login.ValidarSGL(IdUsuario))
            {

                if (accesos.ValidarAcreditacion(IdUsuario))
                {
                    menu_acreditacion.Visible = true;
                }
                if (accesos.ValidarProcedimientoInstructivo(IdUsuario))
                {
                    menu_procedimiento.Visible = true;
                }

                if (accesos.ValidarCompetencia(IdUsuario))
                {
                    menu_competencia.Visible = true;
                }
            }
            else
            {
                Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");

                //FormsAuthentication.SignOut();
                //Response.Redirect(Request.UrlReferrer.ToString());
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {




                string activepage = Request.RawUrl;

                if (activepage.Contains("/Acreditacion/Inicio.aspx") || activepage.Contains("/Acreditacion/EMA/Index.aspx") || activepage.Contains("/Acreditacion/EMA/Crear.aspx") || activepage.Contains("/Acreditacion/EMA/Editar.aspx") || activepage.Contains("/Acreditacion/EMA/Archivo/Index.aspx") || activepage.Contains("/Acreditacion/EMA/Archivo/Crear.aspx") || activepage.Contains("/Acreditacion/CRE/Index.aspx") || activepage.Contains("/Acreditacion/CRE/Crear.aspx") || activepage.Contains("/Acreditacion/CRE/Editar.aspx") || activepage.Contains("/Acreditacion/CRE/Archivo/Index.aspx") || activepage.Contains("/Acreditacion/CRE/Archivo/Crear.aspx"))
                {
                    menu_acreditacion.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    acreditacion.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }

              else if (activepage.Contains("/Procedimiento/Inicio.aspx")|| activepage.Contains("/Procedimiento/MatrizInsAct/Index.aspx") || activepage.Contains("/Procedimiento/MatrizInsAct/Agregar.aspx") || activepage.Contains("/Procedimiento/CensoAct/Index.aspx") || activepage.Contains("/Procedimiento/CensoAct/Crear.aspx") || activepage.Contains("/Procedimiento/CensoAct/Detalle.aspx") || activepage.Contains("/Procedimiento/CensoAct/Editar.aspx") || activepage.Contains("/Procedimiento/CensoAct/Control/Index.aspx") || activepage.Contains("/Procedimiento/CensoAct/Control/Crear.aspx") || activepage.Contains("/Procedimiento/CensoAct/Control/Editar.aspx") || activepage.Contains("/Procedimiento/CensoAct/Evaluacion/Crear.aspx") || activepage.Contains("/Procedimiento/CensoAct/Evaluacion/CrearCuestionario.aspx") || activepage.Contains("/Procedimiento/CensoAct/Evaluacion/Editar.aspx") || activepage.Contains("/Procedimiento/CensoAct/Evaluacion/EditarCuestionario.aspx") || activepage.Contains("/Procedimiento/CensoAct/Evaluacion/VCuestionario.aspx") || activepage.Contains("/Procedimiento/Inicio.aspx") || activepage.Contains("/Procedimiento/MatrizCatAct/Index.aspx") || activepage.Contains("/Procedimiento/MatrizCatAct/Agregar.aspx") || activepage.Contains("/Procedimiento/MatrizCatAct/Detalle.aspx") || activepage.Contains("/Procedimiento/MatrizCatEmp/Index.aspx") || activepage.Contains("/Procedimiento/MatrizCatEmp/Agregar.aspx") || activepage.Contains("/Procedimiento/MatrizCatEmp/Detalle.aspx"))
                {
                    menu_procedimiento.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    procedimiento.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Competencia/Inicio.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Confirmacion/Inicio.aspx") || activepage.Contains("/Confirmacion/Calibracion/Index.aspx")|| activepage.Contains("/Confirmacion/Equipo/Index.aspx")|| activepage.Contains("/Confirmacion/Equipo/Editar.aspx")|| activepage.Contains("/Confirmacion/Equipo/Crear.aspx")|| activepage.Contains("/Confirmacion/Equipo/Detalle.aspx")|| activepage.Contains("/Confirmacion/Medidor/Index.aspx")|| activepage.Contains("/Confirmacion/Medidor/Editar.aspx")|| activepage.Contains("/Confirmacion/Medidor/Detalle.aspx")|| activepage.Contains("/Confirmacion/Medidor/Crear.aspx")|| activepage.Contains("/Confirmacion/Verificacion/Index.aspx") || activepage.Contains("/Confirmacion/Variable/Index.aspx") || activepage.Contains("/Confirmacion/Criterio/Index.aspx"))
                {
                    menu_confirmacion.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    confirmacion.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }
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
            int IdUsuario = Convert.ToInt32(lblIdUsuario.Text);

            RadInstalacion.DataSource = master.MostrarInstalacion(IdSuscripcion,IdUsuario);
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

        protected void lnkCliente_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Cliente/Index.aspx?url=" + encodedString + "");
        }

        protected void lnkMaterial_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Material/Index.aspx?url=" + encodedString + "");
        }

        protected void lnkEquipo_Click(object sender, EventArgs e)
        {
            string url = HttpContext.Current.Request.Url.AbsoluteUri;
            string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(url.ToString())));

            Response.Redirect("http://orygon.azurewebsites.net/Catalogo/Equipo/Index.aspx?url=" + encodedString + "");
        }
    }
}