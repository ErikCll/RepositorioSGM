﻿using System;
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
    public partial class CrearControl : System.Web.UI.Page
    {
        Clase.ActividadControl control = new Clase.ActividadControl();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                (this.Master as SGM.Master.Site1).OcultarDrop = false;
                (this.Master as SGM.Master.Site1).OcultarLabel = false;
                checkSin.Checked = true;
            }
        }

        protected void Regresar(Object sender, EventArgs e)
        {
            Response.Redirect("Control.aspx?id=" + Request.QueryString["id"] + "");
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            string decodedString = System.Text.ASCIIEncoding.ASCII.GetString(Convert.FromBase64String(Request.QueryString["id"]));
            int IdActividad = Convert.ToInt32(decodedString);
            string Codigo = txtCodigo.Text;
            string nombre = File1.FileName;
            string FechaEmision = txtFecha.Text;
            string fileExt = System.IO.Path.GetExtension(File1.FileName);
            string AccountName = "er2020";
            string AccountKey = "yhDHxitC9NvUx5p3vLHwUJWxWx7rdLw47/PI88KVsS8/2EIdN2ZAM+ATi8PWKyB7zXGEXE2mFAAgw1MHw3z/JA==";

            if (File1.HasFile)
            {
                if (fileExt == ".pdf" || fileExt == ".PDF")
                {
                    if (checkSin.Checked == true)
                    {

                        if (control.InsertarSinVigencia(IdActividad, Codigo, FechaEmision))
                        {
                            control.LeerId(IdActividad);

                            StorageCredentials creds = new StorageCredentials(AccountName, AccountKey);
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
                            string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Control.aspx?id="+ Request.QueryString["id"] + "'";

                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);

                        }
                        else
                        {
                            string script = "alert('Ocurrió un error al crear el registro.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';";
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                        }
                    }
                    else if (checkCon.Checked == true)
                    {
                        int Cantidad = Convert.ToInt32(txtCantidad.Text) * 12;

                        if (Cantidad == 0)
                        {
                            checkCon.Checked = false;
                            string txtJS = String.Format("<script>alert('{0}');</script>", "La cantidad debe ser mayor a 0.");
                            ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
                        }
                        else
                        {
                            if (control.Insertar(IdActividad, Codigo, FechaEmision, Cantidad))
                            {
                                control.LeerId(IdActividad);

                                StorageCredentials creds = new StorageCredentials(AccountName, AccountKey);
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
                                string script = "alert('Se creó correctamente el registro.'); window.location.href= 'Control.aspx?id=" + Request.QueryString["id"] + "';";

                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);

                            }
                            else
                            {
                                string script = "alert('Ocurrió un error al crear el registro.'); window.location.href= '" + Request.UrlReferrer.ToString() + "';";
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertMessage", script, true);
                            }
                        }

                    }
                        

                   
                }
            }
            else
            {
                string txtJS = String.Format("<script>alert('{0}');</script>", "Seleccionar archivo PDF.");
                ScriptManager.RegisterClientScriptBlock(litControl, litControl.GetType(), "script", txtJS, false);
            }
        }

    }
}