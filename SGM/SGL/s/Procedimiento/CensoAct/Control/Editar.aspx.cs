using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace SGL.s.Procedimiento.CensoAct.Control
{
    public partial class Editar : System.Web.UI.Page
    {

        Clase.ActividadControl controll = new Clase.ActividadControl();
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
                (this.Master as SGL.s.Site1).OcultarDrop = false;
                (this.Master as SGL.s.Site1).OcultarLabel = false;
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdControl = Convert.ToInt32(decodedString);
                controll.LeerDatosControl(IdControl);
                txtCodigo.Text = controll.Codigo;
                txtFecha.Text = controll.FechaEmision;
                if (controll.Meses == "0")
                {
                    DivCantidad.Visible = false;
                }
                else
                {
                    DivCantidad.Visible = true;
                    txtCantidad.Text = controll.Meses;
                }

            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdControl = Convert.ToInt32(decodedString);
            string Codigo = txtCodigo.Text;
            string FechaEmision = txtFecha.Text;
            controll.LeerDatosControl(IdControl);

            if (controll.Meses == "0")
            {
                if (controll.EditarSinVigencia(IdControl, Codigo, FechaEmision))
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                    ScriptManager.RegisterClientScriptBlock(litControll, litControll.GetType(), "script", txtJS, false);

                }
            }
            else
            {
                int Cantidad = Convert.ToInt32(txtCantidad.Text) * 12;
                if (Cantidad == 0)
                {

                    string txtJS = String.Format("<script>alert('{0}');</script>", "La cantidad debe ser mayor a 0.");
                    ScriptManager.RegisterClientScriptBlock(litControll, litControll.GetType(), "script", txtJS, false);
                }
                else{
                    if (controll.Editar(IdControl, Codigo,FechaEmision,Cantidad))
                    {

                        string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron correctamente los datos.");
                        ScriptManager.RegisterClientScriptBlock(litControll, litControll.GetType(), "script", txtJS, false);

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