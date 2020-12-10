using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Auth;
using Microsoft.WindowsAzure.Storage.Blob;
namespace SGL.s.Acreditacion.CRE.Archivo
{
    public partial class Crear : System.Web.UI.Page
    {
        Clase.Archivo archivo = new Clase.Archivo();
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
            if (accesos.ValidarCre(IdUsuario))
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
                LlenarDrop();
            }

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdAcreditacion = Convert.ToInt32(decodedString);
            DateTime now = DateTime.Now;
            int h = now.Hour;
            int m = now.Minute;
            int s = now.Second;
            string Fecha = txtFecha.Text;
            string Estatus = ddl_Estatus.SelectedValue;
            string fileExt = System.IO.Path.GetExtension(File1.FileName);
            string AccountName = "er2020";
            string AccountKey = "yhDHxitC9NvUx5p3vLHwUJWxWx7rdLw47/PI88KVsS8/2EIdN2ZAM+ATi8PWKyB7zXGEXE2mFAAgw1MHw3z/JA==";

            if (File1.HasFile)
            {
                if (fileExt == ".pdf" || fileExt == ".PDF")
                {


                    if (archivo.Insertar(IdAcreditacion, Fecha + ' ' + h + ':' + m + ':' + s, Estatus))
                    {
                        archivo.LeerId(IdAcreditacion);



                        StorageCredentials creds = new StorageCredentials(AccountName, AccountKey);
                        var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=" + AccountName + ";AccountKey=" + AccountKey);
                        CloudBlobClient client = account.CreateCloudBlobClient();
                        CloudBlobContainer sampleContainer = client.GetContainerReference("sgl/Acreditacion");
                        //sampleContainer.CreateIfNotExists();


                        CloudBlockBlob blob = sampleContainer.GetBlockBlobReference("" + archivo.IdStatus + ".pdf");
                        blob.Properties.ContentType = "application/pdf";

                        using (File1.PostedFile.InputStream)
                        {
                            blob.UploadFromStream(File1.PostedFile.InputStream);

                        }



                        string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Index.aspx?id=" + Request.QueryString["id"] + "'";

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

        public void LlenarDrop()
        {

            ddl_Estatus.Items.Insert(0, new ListItem("[Seleccionar]"));
            ddl_Estatus.Items.Insert(1, new ListItem("Inicio"));
            ddl_Estatus.Items.Insert(2, new ListItem("Actualización"));





        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Index.aspx?id=" + Request.QueryString["id"] + "");
        }
    }
}