﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Mail;
using System.Net.Security;
namespace SAM.Clase
{
    public class Correo
    {
        public string CorreoElectronico = "orygonconsultores@gmail.com";
        public string Contrasena= "Orygonconsultores2020";

        public bool EnviarCorreo(string Correo,string Mensaje)
        {
            try
            {
                SmtpClient Smtp_Server = new SmtpClient();
                MailMessage e_mail = new MailMessage();
                Smtp_Server.UseDefaultCredentials = false;
                Smtp_Server.Credentials = new System.Net.NetworkCredential(CorreoElectronico, Contrasena);
                Smtp_Server.Port = 587;
                Smtp_Server.EnableSsl = true;

                Smtp_Server.Host = "smtp.gmail.com";

                e_mail = new MailMessage();
                e_mail.From = new MailAddress(CorreoElectronico);
                e_mail.To.Add(Correo);

                e_mail.Subject = "Recuperación de contraseña";
                e_mail.IsBodyHtml = true;
                e_mail.Body = Mensaje;
                Smtp_Server.Send(e_mail);
                return true;
            }
            catch (Exception e)
            {
                return false;
            }

        }

    }
}