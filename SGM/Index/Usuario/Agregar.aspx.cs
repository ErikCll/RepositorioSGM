using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Usuario
{
    public partial class Agregar : System.Web.UI.Page
    {
        Clase.Usuario usuario = new Clase.Usuario();
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
            if (accesos.ValidarUsuario(IdUsuario))
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
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdUsuario = Convert.ToInt32(decodedString);
                usuario.LeerDatos(IdUsuario);
                lblNombre.Text = usuario.Nombre;
                lblApellidoPaterno.Text = usuario.ApellidoPaterno;
                lblApellidoMaterno.Text = usuario.ApellidoMaterno;
                lblCorreo.Text = usuario.Correo;
                lblFecha.Text = usuario.CreacionFecha;
            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdUsuario = Convert.ToInt32(decodedString);
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion.ToString());
            gridUsuarioInstalacion.DataSource = usuario.MostrarInstalacion(IdUsuario, IdSuscripcion);
            gridUsuarioInstalacion.DataBind();
        }



  


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridUsuarioInstalacion.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {


                    string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                    int IdUsuario = Convert.ToInt32(decodedString);
                    Label IdInstalacion = row.FindControl("lblIdInstalacion") as Label;
                    int Id_Instalacion = Convert.ToInt32(IdInstalacion.Text);
                    Label Registro = row.FindControl("lblRegistro") as Label;
                    int IdRegistro = Convert.ToInt32(Registro.Text);
                    CheckBox Checked = row.FindControl("chckIns") as CheckBox;
                    bool isChecked = Checked.Checked;




                    if (isChecked == true && Id_Instalacion != IdRegistro)
                    {

                        if (usuario.InsertarInstalacion(IdUsuario, Id_Instalacion))
                        {

                            string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron las instalaciones.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }

                    }
                    if (IdRegistro != 0)
                    {
                        if (isChecked == false)
                        {
                            if (usuario.EliminarInstalacion(IdUsuario, Id_Instalacion))
                            {

                                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron las instalaciones.");
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            }
                        }
                    }



                }
            }
            MostrarGrid();
        }

        protected void gridUsuarioInstalacion_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("checkall") as CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("checkall") as CheckBox).ClientID + "')");
            }

        }

      
    }
}