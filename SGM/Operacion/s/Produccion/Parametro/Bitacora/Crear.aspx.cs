﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Operacion.s.Produccion.Parametro.Bitacora
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Parametro parametro = new Clase.Parametro();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as Operacion.s.Site1).OcultarDrop = false;
                (this.Master as Operacion.s.Site1).OcultarLabel = false;
                LlenarDrop();
            

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdEquipo = Convert.ToInt32(decodedString);
            string Elasticidad = txtElasticidad.Text;
            string Velocidad = txtVelocidad.Text;
            int IdMaterial = Convert.ToInt32(ddl_NoPasada.SelectedValue);
            DateTime Hora = txtHora.SelectedDate.Value;
            string hora = Hora.ToString("HH:mm:ss");
            string fecha = txtFecha.Text;
            DateTime now = DateTime.Now;
            int s = now.Second;

            string FechaHora = fecha + " " + hora + ':' + s;
            string encodedString2 = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(fecha.ToString())));

            if (parametro.Insertar(IdEquipo, Elasticidad, Velocidad, IdMaterial,FechaHora))
            {
                string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Index.aspx?id=" + Request.QueryString["id"] + "&fec=" + encodedString2 + "'";

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
            }

        }

        public void LlenarDrop()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as Operacion.s.Site1).IdSuscripcion);

            ddl_NoPasada.DataSource = parametro.MostrarMaterial(IdSuscripcion);
            ddl_NoPasada.DataBind();
            ddl_NoPasada.Items.Insert(0, new ListItem("[Seleccionar]"));

        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["id"] + "&fec=" + Request.QueryString["fec"] + "");
        }
    }
}