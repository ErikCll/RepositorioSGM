﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using QRCoder;

namespace Administracion.s.Catalogo.Material
{
    public partial class Prueba : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();
            //imgBarCode.Height = 150;
            //imgBarCode.Width = 150;
        }

           protected void btnGenerate_Click(object sender, EventArgs e)  
        {


            string code =txtQRCode.Text;  
            QRCodeGenerator qrGenerator = new QRCodeGenerator();  
            QRCodeGenerator.QRCode qrCode = qrGenerator.CreateQrCode(code, QRCodeGenerator.ECCLevel.Q);  
            System.Web.UI.WebControls.Image imgBarCode = new System.Web.UI.WebControls.Image();  
            imgBarCode.Height = 150;  
            imgBarCode.Width = 150;  
            using (Bitmap bitMap = qrCode.GetGraphic(20))  
            {  
                using (MemoryStream ms = new MemoryStream())  
                {  
                    bitMap.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                   
                    byte[] byteImage = ms.ToArray();

                    string base64 = Convert.ToBase64String(byteImage);
                    imgBarCode.ImageUrl = "data:image/png;base64," + base64;
                   
                }  
              PlaceHolder1.Controls.Add(imgBarCode);  
            }  
        } 
    }
}