﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGL.s.Confirmacion.Medidor
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Medidor medidor = new Clase.Medidor();
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
        //    int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
        //    if (accesos.ValidarMedidor(IdUsuario))
        //    {

        //    }
        //    else
        //    {
        //        Response.Redirect("~/s/Inicio.aspx");
        //    }

        //}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGL.s.Site1).OcultarDrop = false;
                (this.Master as SGL.s.Site1).OcultarLabel = false;
                LlenarDrop();
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            string VariableMedir = ddl_Variable.SelectedValue;
            int calibracion = Convert.ToInt32(txtCalibracion.Text);
            int verificacion = Convert.ToInt32(txtVerificacion.Text);
            int IdSuscripcion = Convert.ToInt32((this.Master as SGL.s.Site1).IdSuscripcion.ToString());

            if (medidor.Insertar(Nombre, VariableMedir, calibracion, verificacion, IdSuscripcion))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

        public void LlenarDrop()
        {

            ddl_Variable.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_Variable.Items.Insert(1, new ListItem("Peso Específico"));
            ddl_Variable.Items.Insert(2, new ListItem("Temperatura"));
            ddl_Variable.Items.Insert(3, new ListItem("Azufre"));
            ddl_Variable.Items.Insert(4, new ListItem("Temperatura de Inflamación"));
            ddl_Variable.Items.Insert(5, new ListItem("Destilación"));
            ddl_Variable.Items.Insert(6, new ListItem("Octano"));



        }
    }
}