using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Telerik.Web.UI;

namespace SGM.Master
{
    public partial class Site1 : System.Web.UI.MasterPage
    {

        Clase.Master master = new Clase.Master();

       
       
    
   


        protected void Page_Init(object sender, EventArgs e)
        {
            if (RadInstalacion.SelectedIndex == -1)
            {
                lblIDInstalacion.Text = "0";

            }

            if (Session["IdInstalacion"] != null)
            {
                RadInstalacion.SelectedValue = Session["IdInstalacion"].ToString();
                lblIDInstalacion.Text = Session["IdInstalacion"].ToString();
            }

        }

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
              
                LlenarDrop();



                string activepage = Request.RawUrl;

                //if (activepage.Contains("/Catalogo/Instalacion/Index.aspx") || activepage.Contains("/Catalogo/Instalacion/Crear.aspx") || activepage.Contains("/Catalogo/Instalacion/Detalle.aspx") || activepage.Contains("/Catalogo/Instalacion/Editar.aspx"))
                //{
                //    menu_catalogo.Attributes.Add("class", "  nav-item has-treeview menu-open");
                //    catalogo.Attributes.Add("class", "nav-link active");
                //    instalacion.Attributes.Add("class", "nav-link active");



                //}

                //else if (activepage.Contains("/Catalogo/Area/Index.aspx") || activepage.Contains("/Catalogo/Area/Crear.aspx") || activepage.Contains("/Catalogo/Area/Detalle.aspx") || activepage.Contains("/Catalogo/Area/Editar.aspx"))
                //{
                //    menu_catalogo.Attributes.Add("class", "  nav-item has-treeview menu-open");
                //    catalogo.Attributes.Add("class", "nav-link active");
                //    area.Attributes.Add("class", "nav-link active");

                //}

                //else if (activepage.Contains("/Catalogo/Empleado/Index.aspx") || activepage.Contains("/Catalogo/Empleado/Crear.aspx") || activepage.Contains("/Catalogo/Empleado/Detalle.aspx") || activepage.Contains("/Catalogo/Empleado/Editar.aspx"))
                //{
                //    menu_catalogo.Attributes.Add("class", "  nav-item has-treeview menu-open");
                //    catalogo.Attributes.Add("class", "nav-link active");
                //    empleado.Attributes.Add("class", "nav-link active");

                //}
                //else if (activepage.Contains("/Catalogo/Categoria/Index.aspx") || activepage.Contains("/Catalogo/Categoria/Crear.aspx") || activepage.Contains("/Catalogo/Categoria/Detalle.aspx") || activepage.Contains("/Catalogo/Categoria/Editar.aspx"))
                //{
                //    menu_catalogo.Attributes.Add("class", "  nav-item has-treeview menu-open");
                //    catalogo.Attributes.Add("class", "nav-link active");
                //    categoria.Attributes.Add("class", "nav-link active");

                //}

                 if (activepage.Contains("/Catalogo/Medidor/Index.aspx") || activepage.Contains("/Catalogo/Medidor/Crear.aspx") || activepage.Contains("/Catalogo/Medidor/Detalle.aspx") || activepage.Contains("/Catalogo/Medidor/Editar.aspx"))
                {
                    menu_catalogo.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    catalogo.Attributes.Add("class", "nav-link active");
                    medidor.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Competencia/CensoAct/Index.aspx") || activepage.Contains("/Competencia/CensoAct/Crear.aspx") || activepage.Contains("/Competencia/CensoAct/Detalle.aspx") || activepage.Contains("/Competencia/CensoAct/Editar.aspx") || activepage.Contains("/Competencia/CensoAct/Control/Index.aspx") || activepage.Contains("/Competencia/CensoAct/Control/Crear.aspx") || activepage.Contains("/Competencia/CensoAct/Control/Editar.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/Crear.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/CrearCuestionario.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/Editar.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/EditarCuestionario.aspx") || activepage.Contains("/Competencia/CensoAct/Evaluacion/VCuestionario.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    actividad.Attributes.Add("class", "nav-link active");

                }
                else if (activepage.Contains("/Competencia/MatrizCatAct/Index.aspx") || activepage.Contains("/Competencia/MatrizCatAct/Agregar.aspx") || activepage.Contains("/Competencia/MatrizCatAct/Detalle.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    catact.Attributes.Add("class", "nav-link active");
                  
                }
                else if (activepage.Contains("/Competencia/Programa/Index.aspx") || activepage.Contains("/Competencia/Programa/Agregar.aspx") || activepage.Contains("/Competencia/Programa/Detalle.aspx") || activepage.Contains("/Competencia/Programa/DetalleEv.aspx") || activepage.Contains("/Competencia/Programa/Editar.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    prog.Attributes.Add("class", "nav-link active");

                }

                else if (activepage.Contains("/Competencia/MatrizCatEmp/Index.aspx") || activepage.Contains("/Competencia/MatrizCatEmp/Agregar.aspx") || activepage.Contains("/Competencia/MatrizCatEmp/Detalle.aspx"))
                {
                    menu_competencia.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    competencia.Attributes.Add("class", "nav-link active");
                    catemp.Attributes.Add("class", "nav-link active");

                }


                else if (activepage.Contains("/Confirmacion/CensoSis/Index.aspx") || activepage.Contains("/Confirmacion/CensoSis/Crear.aspx") || activepage.Contains("/Confirmacion/CensoSis/Editar.aspx") || activepage.Contains("/Confirmacion/CensoSis/Componente/Index.aspx") || activepage.Contains("/Confirmacion/CensoSis/Componente/Editar.aspx") || activepage.Contains("/Confirmacion/CensoSis/Componente/Crear.aspx"))
                {
                    menu_confirmacion.Attributes.Add("class", "  nav-item has-treeview menu-open");
                    confirmacion.Attributes.Add("class", "nav-link active");
                    sistema.Attributes.Add("class", "nav-link active");

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
            RadInstalacion.DataSource = master.MostrarInstalacion();
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
    }
}