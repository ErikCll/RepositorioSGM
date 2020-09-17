using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SASISOPA.Competencia.Programa
{
    public partial class Index : System.Web.UI.Page
    {
        Clase.ProgramaCapacitacion programa = new Clase.ProgramaCapacitacion();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LlenarDrop();
                int Anio = DateTime.Now.Year;
                ddl_Anio.SelectedValue = Anio.ToString();
                MostrarGrid();
            }
        }

        public void MostrarGrid()
        {
            int Anio = Convert.ToInt32(ddl_Anio.SelectedValue);
            int IdInstalacion = Convert.ToInt32((this.Master as SASISOPA.s.Site1).IdInstalacion.ToString());
            gridMatriz.DataSource = programa.MostrarGeneral(IdInstalacion,Anio);
            gridMatriz.DataBind();
        }

        public void LlenarDrop()
        {
            ddl_Anio.DataSource = programa.MostrarAnios();
            ddl_Anio.DataBind();
            ddl_Anio.Items.Insert(0, new ListItem("[Seleccionar]","0"));
            
        }

        protected void ddl_Anio_SelectedIndexChanged(object sender, EventArgs e)
        {
            MostrarGrid();
        }

        protected void gridMatriz_RowDataBound(object sender, GridViewRowEventArgs e)
        {

            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Cells[0].Attributes.Add("rowspan", "2");
                }
                else
                {
                    e.Row.Cells[0].Visible = false;
                }

                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Cells[1].Attributes.Add("rowspan", "2");
                }
                else
                {
                    e.Row.Cells[1].Visible = false;
                }
            

                if (e.Row.RowIndex % 2 == 0)
                {
                    e.Row.Cells[16].Attributes.Add("rowspan", "2");
                }
                else
                {
                    e.Row.Cells[16].Visible = false;
                }
            }
        }

        protected void IrSAM(Object sender, EventArgs e)
        {
            Session.RemoveAll();
            Response.Redirect("http://orygon.azurewebsites.net/Inicio.aspx");
        }
    }
}