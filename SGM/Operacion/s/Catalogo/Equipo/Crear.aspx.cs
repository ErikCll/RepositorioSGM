﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Catalogo.Equipo
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Equipo equipo = new Clase.Equipo();
        Clase.Master master = new Clase.Master();
        protected void Page_Init(object sender, EventArgs e)
        {
            string Usuario = Page.User.Identity.Name;
            //if (master.ValidarCatalogo(Usuario))
            //{

            //}
            //else
            //{
            //    Response.Redirect("~/s/Inicio.aspx");
            //}
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropTipo();
                LlenarDropInstalacion();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string Marca = txtMarca.Text;
            string Modelo = txtModelo.Text;
            string Tipo = ddl_Tipo.SelectedValue;
            string NoInventario = txtNoInventario.Text;
            string Serie = txtSerie.Text;
            string Prueba = txtPrueba.Text;
           
            int IdInstalacion = Convert.ToInt32(ddl_Instalacion.SelectedValue);
            if (equipo.Insertar(Nombre,Marca,Modelo,Tipo,NoInventario,Serie,Prueba,IdInstalacion))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDropTipo()
        {
          
            ddl_Tipo.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_Tipo.Items.Insert(1, new ListItem("Automático"));
            ddl_Tipo.Items.Insert(2, new ListItem("Manual"));

        }

        public void LlenarDropInstalacion()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdSuscripcion);

            ddl_Instalacion.DataSource = equipo.MostrarInstalacion(IdSuscripcion);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

    }
}