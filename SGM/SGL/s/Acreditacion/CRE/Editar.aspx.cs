﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Acreditacion.CRE
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.CRE cre = new Clase.CRE();
        Clase.Accesos accesos = new Clase.Accesos();
        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }

        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarCre(IdUsuario))
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
                (this.Master as SGL.s.Site1).OcultarDrop = false;
                (this.Master as SGL.s.Site1).OcultarLabel = false;
                LlenarDrop();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdAcreditacion = Convert.ToInt32(decodedString);
                cre.LeerDatos(IdAcreditacion);
                txtNo.Text = cre.No;
                txtReferencia.Text = cre.Referencia;
                ddl_Instalacion.SelectedValue = cre.IdInstalacion;
            }
        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SGL.s.Site1).IdSuscripcion);

            ddl_Instalacion.DataSource = cre.MostrarInstalacion(IdSuscripcion);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdAcreditacion = Convert.ToInt32(decodedString);
            string No = txtNo.Text;
            string Referencia = txtReferencia.Text;
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (cre.Editar(IdAcreditacion, No, Referencia, IdInstalacion))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }

        }
    }
}