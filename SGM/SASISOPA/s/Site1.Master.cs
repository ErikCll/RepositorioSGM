﻿using System;
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
            if (login.ValidarSASISOPA(IdUsuario))
            {

                if (accesos.ValidarPolitica(IdUsuario))
                {
                    menu_politica.Visible = true;
                  
                }

                if (accesos.ValidarRiesgo(IdUsuario))
                {
                    menu_riesgo.Visible = true;
                }

                if (accesos.ValidarRequisito(IdUsuario))
                {
                    menu_requisito.Visible = true;
                }

                if (accesos.ValidarMeta(IdUsuario))
                {
                    menu_meta.Visible = true;
                }

                if (accesos.ValidarFuncion(IdUsuario))
                {
                    menu_funcion.Visible = true;
                }

                if (accesos.ValidarCompetencia(IdUsuario))
                {
                    menu_competencia.Visible = true;
                }

                if (accesos.ValidarComunicacion(IdUsuario))
                {
                    menu_comunicacion.Visible = true;
                }

                if (accesos.ValidarControlDocumento(IdUsuario))
                {
                    menu_controldoc.Visible = true;
                }

                if (accesos.ValidarPractica(IdUsuario))
                {
                    menu_practica.Visible = true;
                }

                if (accesos.ValidarControlActividad(IdUsuario))
                {
                    menu_controlact.Visible = true;
                }

                if (accesos.ValidarIntegridad(IdUsuario))
                {
                    menu_integridad.Visible = true;
                }

                if (accesos.ValidarSeguridad(IdUsuario))
                {
                    menu_seguridad.Visible = true;
                }

                if (accesos.ValidarRespuesta(IdUsuario))
                {
                    menu_respuesta.Visible = true;
                }

                if (accesos.ValidarMonitoreo(IdUsuario))
                {
                    menu_monitoreo.Visible = true;
                }

                if (accesos.ValidarAuditoria(IdUsuario))
                {
                    menu_auditoria.Visible = true;
                }

                if (accesos.ValidarInvestigacion(IdUsuario))
                {
                    menu_investigacion.Visible = true;
                }

                if (accesos.ValidarRevision(IdUsuario))
                {
                    menu_revision.Visible = true;
                }

                if (accesos.ValidarInforme(IdUsuario))
                {
                    menu_informe.Visible = true;
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


                if (activepage.Contains("/Competencia/Inicio.aspx") || activepage.Contains("/Competencia/Programa/Index.aspx") || activepage.Contains("/Competencia/Programa/Agregar.aspx") || activepage.Contains("/Competencia/Programa/Detalle.aspx") || activepage.Contains("/Competencia/Programa/DetalleEv.aspx") || activepage.Contains("/Competencia/Programa/Editar.aspx") || activepage.Contains("/Competencia/ResultadoEv/Index.aspx") || activepage.Contains("/Competencia/ResultadoEv/Detalle.aspx") || activepage.Contains("/Competencia/CursoTaller/Index.aspx") || activepage.Contains("/Competencia/InstructorIn/Index.aspx") || activepage.Contains("/Competencia/MatrizCurIns/Index.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    //actividad.Attributes.Add("class", "nav-link active");

                }


                else if (activepage.Contains("/FuncionRes/Inicio.aspx") || activepage.Contains("/FuncionRes/MatrizCatAct/Index.aspx") || activepage.Contains("/FuncionRes/MatrizCatAct/Agregar.aspx") || activepage.Contains("/FuncionRes/MatrizCatAct/Detalle.aspx") || activepage.Contains("/FuncionRes/MatrizCatEmp/Index.aspx") || activepage.Contains("/FuncionRes/MatrizCatEmp/Agregar.aspx") || activepage.Contains("/FuncionRes/MatrizCatEmp/Detalle.aspx"))
                {
                    menu_funcion.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    funciones.Attributes.Add("class", "nav-link active");
                    //catact.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/ControlAct/Inicio.aspx") || activepage.Contains("/ControlAct/MatrizInsAct/Index.aspx") || activepage.Contains("/ControlAct/MatrizInsAct/Agregar.aspx") || activepage.Contains("/ControlAct/CensoAct/Index.aspx") || activepage.Contains("/ControlAct/CensoAct/Crear.aspx") || activepage.Contains("/ControlAct/CensoAct/Detalle.aspx") || activepage.Contains("/ControlAct/CensoAct/Editar.aspx") || activepage.Contains("/ControlAct/CensoAct/Control/Index.aspx") || activepage.Contains("/ControlAct/CensoAct/Control/Crear.aspx") || activepage.Contains("/ControlAct/CensoAct/Control/Editar.aspx") || activepage.Contains("/ControlAct/CensoAct/Evaluacion/Crear.aspx") || activepage.Contains("/ControlAct/CensoAct/Evaluacion/CrearCuestionario.aspx") || activepage.Contains("/ControlAct/CensoAct/Evaluacion/Editar.aspx") || activepage.Contains("/ControlAct/CensoAct/Evaluacion/EditarCuestionario.aspx") || activepage.Contains("/ControlAct/CensoAct/Evaluacion/VCuestionario.aspx") || activepage.Contains("/ControlAct/Inicio.aspx"))
                {
                    menu_controlact.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    controlact.Attributes.Add("class", "nav-link active");
                    //catact.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/RequisitoLegal/Inicio.aspx") || activepage.Contains("/RequisitoLegal/Regulador/Index.aspx") || activepage.Contains("/RequisitoLegal/Regulador/Crear.aspx") || activepage.Contains("/RequisitoLegal/Regulador/Editar.aspx") || activepage.Contains("/RequisitoLegal/DocRegulador/Index.aspx") || activepage.Contains("/RequisitoLegal/DocRegulador/Crear.aspx") || activepage.Contains("/RequisitoLegal/DocRegulador/Editar.aspx") || activepage.Contains("/RequisitoLegal/Requisito/Index.aspx") || activepage.Contains("/RequisitoLegal/Requisito/Crear.aspx") || activepage.Contains("/RequisitoLegal/Requisito/Editar.aspx") || activepage.Contains("/RequisitoLegal/MatrizReqIns/Index.aspx"))
                {
                    menu_requisito.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    requisito.Attributes.Add("class", "nav-link active");
                    //catact.Attributes.Add("class", "nav-link active");

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
            RadInstalacion.DataSource = master.MostrarInstalacion(IdSuscripcion, IdUsuario);
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