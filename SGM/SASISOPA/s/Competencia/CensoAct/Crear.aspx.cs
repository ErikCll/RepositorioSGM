﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.Competencia.CensoAct
{
    public partial class Crear : System.Web.UI.Page
    {

        Clase.Actividad objIns = new Clase.Actividad();

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;



            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string Nombre = txtNombre.Text;
            int TipoSistema = Convert.ToInt32((this.Master as SASISOPA.s.Site1).TipoSistema.ToString());
            if (objIns.Insertar(TipoSistema, Nombre))
            {
                string script = "alert('Registro creado exitosamente.'); window.location.href= 'Index.aspx';";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }
        }

    }
}