﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.s.Monitoreo
{
    public partial class Inicio : System.Web.UI.Page
    {

        Clase.Accesos accesos = new Clase.Accesos();

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ValidarAccesos();
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public void ValidarAccesos()
        {
            int IdUsuario = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarMonitoreo(IdUsuario))
            {
                if (accesos.Configuracion14(IdUsuario))
                {
                    configuracion.Visible = true;

                }


            }
            else
            {
                Response.Redirect("~/s/Inicio.aspx");
            }


        }
        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}