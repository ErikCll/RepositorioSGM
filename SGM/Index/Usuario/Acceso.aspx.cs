using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAM.Usuario
{
    public partial class Acceso : System.Web.UI.Page
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
                LlenarDropSistema();
                LlenarDropMenu();
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
            int IdMenu = Convert.ToInt32(ddl_Menu.SelectedValue);
            gridAcceso.DataSource = usuario.MostrarAccesos(IdUsuario, IdMenu);
            gridAcceso.DataBind();
        }

        public void LlenarDropSistema()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);

            ddl_Sistema.DataSource = usuario.MostrarSistema(IdSuscripcion);
            ddl_Sistema.DataBind();
            ddl_Sistema.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        public void LlenarDropMenu()
        {
            int IdSuscripcion = Convert.ToInt32((this.Master as SAM.Site1).IdSuscripcion);
            int IdSistema = Convert.ToInt32(ddl_Sistema.SelectedValue);
            ddl_Menu.DataSource = usuario.MostrarMenu(IdSuscripcion, IdSistema);
            ddl_Menu.DataBind();
            ddl_Menu.Items.Insert(0, new ListItem("[Seleccionar]", "0"));

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridAcceso.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {


                    string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                    int IdUsuario = Convert.ToInt32(decodedString);
                    Label IdSubMenu = row.FindControl("lblIdSubMenu") as Label;
                    int Id_SubMenu = Convert.ToInt32(IdSubMenu.Text);
                    Label Registro = row.FindControl("lblRegistro") as Label;
                    int IdRegistro = Convert.ToInt32(Registro.Text);
                    CheckBox Checked = row.FindControl("chckIns") as CheckBox;
                    bool isChecked = Checked.Checked;




                    if (isChecked == true && Id_SubMenu != IdRegistro)
                    {

                        if (usuario.InsertarAcceso(IdUsuario, Id_SubMenu))
                        {

                            string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron los accesos.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }

                    }
                    if (IdRegistro != 0)
                    {
                        if (isChecked == false)
                        {
                            if (usuario.EliminarAcceso(IdUsuario, Id_SubMenu))
                            {

                                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron los accesos.");
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            }
                        }
                    }



                }
            }
            MostrarGrid();
        }

        protected void gridAcceso_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("checkall") as CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("checkall") as CheckBox).ClientID + "')");
            }

        }

        protected void ddl_Sistema_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropMenu();
            MostrarGrid();
        }

        protected void ddl_Menu_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();
        }
    }
}