﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Catalogo.Categoria
{
    public partial class Crear : System.Web.UI.Page
    {

        Clase.Categoria categoria = new Clase.Categoria();
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
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
            if (accesos.ValidarCategoria(IdUsuario))
            {

            }
            else
            {
                Response.Redirect("~/Inicio.aspx");
            }


        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SAM.Site1).OcultarDrop = false;
                (this.Master as SAM.Site1).OcultarLabel = false;
                LlenarDropInstalacion();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (categoria.Insertar(IdArea, Nombre))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }
        public void LlenarDropInstalacion()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario);

            ddl_Instalacion.DataSource = categoria.MostrarInstalacion(IdSuscripcion,IdUsuario);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]", "0"));
        }

        public void LlenarDropArea()
        {
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            ddl_Area.DataSource = categoria.MostrarArea(IdInstalacion);
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Seleccionar]"));
        }

        protected void ddl_Instalacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropArea();
        }
    }
}