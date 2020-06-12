using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;

namespace SGM.Competencia.CensoAct
{
    public partial class Control : System.Web.UI.Page
    {
        Clase.ActividadControl control = new Clase.ActividadControl();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                MostrarGrid();
                string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
                int IdActividad = Convert.ToInt32(decodedString);
                control.LeerDatosActividad(IdActividad);
                lblCensoAct.Text = control.Actividad;
            }
             

        }

        public void MostrarGrid()
        {
            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            gridControl.DataSource = control.Mostrar(IdActividad);
            gridControl.DataBind();
        }

        protected void gridControl_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            gridControl.PageIndex = e.NewPageIndex;

            MostrarGrid();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            string Codigo = txtCodigo.Text;
            string nombre = File1.FileName;
            string fileExt = System.IO.Path.GetExtension(File1.FileName);
            string AccountName = "er2020";
            string AccountKey = "yhDHxitC9NvUx5p3vLHwUJWxWx7rdLw47/PI88KVsS8/2EIdN2ZAM+ATi8PWKyB7zXGEXE2mFAAgw1MHw3z/JA==";

            if (File1.HasFile)
            {
                if (fileExt == ".pdf" || fileExt == ".PDF")
                {
                    if (control.Insertar(IdActividad, Codigo))
                    {
                        control.LeerId(IdActividad);

                        StorageCredentials creds  = new StorageCredentials(AccountName, AccountKey);
                        var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + AccountName + ";AccountKey=" + AccountKey);
                        CloudBlobClient client = account.CreateCloudBlobClient();
                        CloudBlobContainer sampleContainer = client.GetContainerReference("controlvers");
                        sampleContainer.CreateIfNotExists();


                        CloudBlockBlob blob = sampleContainer.GetBlockBlobReference("" + control.IdControl + ".pdf");
                        blob.Properties.ContentType = "application/pdf";

                       using (File1.PostedFile.InputStream)
                            {
                            blob.UploadFromStream(File1.PostedFile.InputStream);

                             }
                        string script = "alert('Se creó correctamente el registro.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';";

                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);

                    }
                    else
                    {
                        string script = "alert('Ocurrió un error al crear el registro.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';";
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                    }
                }
            }
            else
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Seleccionar archivo PDF.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
        }

        protected void gridControl_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                int IdControl = (int)gridControl.DataKeys[e.Row.RowIndex].Value;

                HyperLink lnk = e.Row.FindControl("lnk") as HyperLink;
                lnk.NavigateUrl = "https://er2020.blob.core.windows.net/controlvers/" + IdControl.ToString() + ".pdf";

            }
        }

        protected void gridControl_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Eliminar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                if (control.Eliminar(IdControl))
                {
                    MostrarGrid();
                    string txtJS = String.Format("<script>alert('{0}');</script>", "Se eliminó correctamente el dato.");
                    ScriptManager.RegisterClientScriptBlock(litControl2, litControl2.GetType(), "script", txtJS, false);
                }
              


            }
            else if (e.CommandName == "Editar")
            {
                GridViewRow row = ((Button)e.CommandSource).Parent.Parent as GridViewRow;

                int IdControl = (int)gridControl.DataKeys[row.RowIndex].Value;
                string encodedString = (Convert.ToBase64String(System.Text.ASCIIEncoding.ASCII.GetBytes(IdControl.ToString())));


                Response.Redirect("ControlEditar.aspx?id=" + encodedString + "&act="+ Request.QueryString["id"] + "");
            }

        }
    }
}