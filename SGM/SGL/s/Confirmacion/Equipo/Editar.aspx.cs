﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Confirmacion.Equipo
{
    public partial class Editar : System.Web.UI.Page
    {
        Clase.Equipo equipo = new Clase.Equipo();
        Clase.Accesos accesos = new Clase.Accesos();

        //protected void Page_Init(object sender, EventArgs e)
        //{
        //    if (!IsPostBack)
        //    {
        //        ValidarAccesos();
        //    }

        //}

        //public void ValidarAccesos()
        //{
        //    int IdUsuario = Convert.ToInt32((this.Master as SAM.Site1).IDUsuario.ToString());
        //    if (accesos.ValidarEquipo(IdUsuario))
        //    {

        //    }
        //    else
        //    {
        //        Response.Redirect("~/Inicio.aspx");
        //    }


        //}
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDropTipo();
                LlenarDropInstalacion();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdEquipo = Convert.ToInt32(decodedString);
                equipo.LeerDatos(IdEquipo);
                txtNombre.Text = equipo.Nombre;
                txtMarca.Text = equipo.Marca;
                txtModelo.Text = equipo.Modelo;
                ddl_Tipo.SelectedValue = equipo.Tipo;
                txtNoInventario.Text = equipo.NoInventario;
                txtSerie.Text = equipo.Serie;
                txtPrueba.Text = equipo.Prueba;
                ddl_Instalacion.SelectedValue = equipo.IdInstalacion;
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
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            if (equipo.Editar(IdEquipo, Nombre, Marca, Modelo, Tipo, NoInventario, Serie, Prueba, IdInstalacion))
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
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
            int IdSuscripcion = Convert.ToInt32((this.Master as SGL.s.Site1).IdSuscripcion);
            int IdUsuario = Convert.ToInt32((this.Master as SGL.s.Site1).IDUsuario);

            ddl_Instalacion.DataSource = equipo.MostrarInstalacion(IdSuscripcion, IdUsuario);
            ddl_Instalacion.DataBind();
            ddl_Instalacion.Items.Insert(0, new ListItem("[Seleccionar]"));

        }
    }
}