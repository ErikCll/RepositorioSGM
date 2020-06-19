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
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdCategoria = Convert.ToInt32(decodedString);
                categoriaAct.LeerDatos(IdCategoria);
                lblCategoría.Text = categoriaAct.Nombre;
                MostrarGrid();

            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdCategoria = Convert.ToInt32(decodedString);
            gridActividad.DataSource = categoriaAct.MostrarActividades(IdCategoria);
            gridActividad.DataBind();
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
    }
}