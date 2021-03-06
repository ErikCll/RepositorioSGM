﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SGM.Competencia.CensoAct
{
    public partial class ControlEditar : System.Web.UI.Page
    {

        Clase.ActividadControl control = new Clase.ActividadControl();
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
            int IdUsuario = Convert.ToInt32((this.Master as SGM.s.Site1).IDUsuario.ToString());
            if (accesos.ValidarCensoActividad(IdUsuario))
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
                int IdControl = Convert.ToInt32(decodedString);
                control.LeerDatosControl(IdControl);
                txtCodigo.Text = control.Codigo;
                txtFecha.Text = control.FechaEmision;
                if (control.Meses == "0")
                {
                    DivCantidad.Visible = false;
                }
                else
                {
                    DivCantidad.Visible = true;
                    txtCantidad.Text = control.Meses;
                }

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdControl = Convert.ToInt32(decodedString);
            string Codigo = txtCodigo.Text;
            string FechaEmision = txtFecha.Text;
            control.LeerDatosControl(IdControl);

            if (control.Meses == "0")
            {
                if (control.EditarSinVigencia(IdControl, Codigo, FechaEmision))
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                }
            }
            else
            {
                int Cantidad = Convert.ToInt32(txtCantidad.Text) * 12;
                if (Cantidad == 0)
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "La cantidad debe ser mayor a 0.");
                    ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                }
                else{
                    if (control.Editar(IdControl, Codigo,FechaEmision,Cantidad))
                    {

                        string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                        ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);

                    }
                }
              
            }

         



        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["act"] + "");
        }

    }
}