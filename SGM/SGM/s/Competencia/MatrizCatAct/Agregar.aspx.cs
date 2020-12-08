using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SGM.Competencia.MatrizCatAct
{
    public partial class Agregar : System.Web.UI.Page
    {
        Clase.CategoriaActividad categoriaAct = new Clase.CategoriaActividad();
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
            if (accesos.ValidarCategoriaActividad(IdUsuario))
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
                int IdCategoria = Convert.ToInt32(decodedString);
                categoriaAct.LeerDatos(IdCategoria);
                lblCategoría.Text = categoriaAct.Nombre;
                LlenarDropArea();
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.s.Site1).IdInstalacion.ToString());

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdCategoria = Convert.ToInt32(decodedString);
            int IdArea = Convert.ToInt32(ddl_Area.SelectedValue);
            if (IdArea == 0)
            {
                gridActividad.DataSource = categoriaAct.MostrarTodasActividades(IdCategoria,IdInstalacion);
                gridActividad.DataBind();

            }
            else
            {
                gridActividad.DataSource = categoriaAct.MostrarActividades(IdCategoria, IdArea);
                gridActividad.DataBind();
            }
        
        }

        public void LlenarDropArea()
        {
            int IdInstalacion = Convert.ToInt32((this.Master as SGM.s.Site1).IdInstalacion.ToString());
            ddl_Area.DataSource = categoriaAct.MostrarArea(IdInstalacion);
            ddl_Area.DataBind();
            ddl_Area.Items.Insert(0, new ListItem("[Todas]","0"));
        }


        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridActividad.Rows)
            {
                if(row.RowType==DataControlRowType.DataRow)
                {
                    string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                    int IdCategoria = Convert.ToInt32(decodedString);
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    int IdActividad = Convert.ToInt32(row.Cells[3].Controls.OfType<Label>().FirstOrDefault().Text);
                    int IdRegistro = Convert.ToInt32(row.Cells[4].Controls.OfType<Label>().FirstOrDefault().Text);

                    if (isChecked==true && IdActividad != IdRegistro) {

                        if (categoriaAct.Insertar(IdCategoria, IdActividad))
                        {
                            string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron las actividades.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }
                        
                    }
                    if (IdRegistro != 0)
                    {
                        if (isChecked == false)
                        {
                            if (categoriaAct.Eliminar(IdCategoria, IdActividad))
                            {
                                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron las actividades.");
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            }
                        }
                    }


               
                }

            }
            MostrarGrid();
        }

        protected void gridActividad_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("checkall") as CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("checkall") as CheckBox).ClientID + "')");
            }

     
        }

        protected void ddl_Area_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();
        }
  
    }
}