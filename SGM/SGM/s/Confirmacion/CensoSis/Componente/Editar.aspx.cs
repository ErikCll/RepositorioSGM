﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Confirmacion.CensoSis.Componente
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.SistemaComponente componente = new Clase.SistemaComponente();
        Clase.Master master = new Clase.Master();

        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            if (master.ValidarConfirmacion(Usuario))
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
                (this.Master as SGM.s.Site1).OcultarDrop = false;
                (this.Master as SGM.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdComponente = Convert.ToInt32(decodedString);
                componente.LeerDatosComponente(IdComponente);
               componente.LeerTipo(IdComponente);
                 if(componente.Tipo=="2")
                {
                    Div1.Visible = true;
                    Div2.Visible = true;
                    txtNombre.Text = componente.Nombre;
                }
                else
                {
                    LlenarDrop();
                    Div3.Visible = true;
                    Div4.Visible = true;
                    ddl_Medidor.SelectedValue = componente.IdMedidor;
                }
              

            }
        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SGM.s.Site1).IdSuscripcion.ToString());

            ddl_Medidor.DataSource = componente.MostrarMedidor(IdSuscripcion);
            ddl_Medidor.DataBind();
            ddl_Medidor.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdComponente = Convert.ToInt32(decodedString);
            string Nombre = txtNombre.Text;


            if (componente.EditarAccesorio(IdComponente, Nombre))
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                }
                                
        }

        protected void btnGuardar2_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdComponente = Convert.ToInt32(decodedString);
            int IdMedidor = Convert.ToInt32(ddl_Medidor.SelectedValue);


            if (componente.EditarMedidor(IdComponente, IdMedidor))
            {

                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

            }

        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["sis"] + "");
        }
    }
}