using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.FuncionRes.MatrizCatEmp
{
    public partial class Agregar : System.Web.UI.Page
    {
        Clase.CategoriaEmpleado categoriaEmp = new Clase.CategoriaEmpleado();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SASISOPA.s.Site1).OcultarDrop = false;
                (this.Master as SASISOPA.s.Site1).OcultarLabel = false;

                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdCategoria = Convert.ToInt32(decodedString);
                categoriaEmp.LeerDatos(IdCategoria);
                lblCategoría.Text = categoriaEmp.Nombre;
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdCategoria = Convert.ToInt32(decodedString);
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());

            gridEmpleado.DataSource = categoriaEmp.MostrarEmpleado(IdCategoria, IdInstalacion);
            gridEmpleado.DataBind();
            

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in gridEmpleado.Rows)
            {
                if (row.RowType == DataControlRowType.DataRow)
                {
                    string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                    int IdCategoria = Convert.ToInt32(decodedString);
                    bool isChecked = row.Cells[0].Controls.OfType<CheckBox>().FirstOrDefault().Checked;
                    int IdActividad = Convert.ToInt32(row.Cells[3].Controls.OfType<Label>().FirstOrDefault().Text);
                    int IdRegistro = Convert.ToInt32(row.Cells[4].Controls.OfType<Label>().FirstOrDefault().Text);

                    if (isChecked == true && IdActividad != IdRegistro)
                    {

                        if (categoriaEmp.Insertar(IdCategoria, IdActividad))
                        {
                            string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron los empleados.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }

                    }
                    if (IdRegistro != 0)
                    {
                        if (isChecked == false)
                        {
                            if (categoriaEmp.Eliminar(IdCategoria, IdActividad))
                            {
                                string txtJS = String.Format("<script>alert('{0}');</script>", "Se actualizaron los empleados.");
                                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                            }
                        }
                    }



                }

            }
            MostrarGrid();
        }

        protected void gridEmpleado_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.Header)
            {
                ((CheckBox)e.Row.FindControl("checkall") as CheckBox).Attributes.Add("onclick", "javascript:SelectAll('" + ((CheckBox)e.Row.FindControl("checkall") as CheckBox).ClientID + "')");
            }


        }
    }
}