using ProjectBancoItau.Domain.Entities;
using ProjectBancoItau.Domain.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBancoItau.Domain.Services
{
    public class EmailService : IEmailService
    {
        public void Enviar(Email email)
        {
            var mail = new MailMessage();
            mail.From = new MailAddress(email.de);
            mail.To.Add(email.para);
            mail.Subject = email.assunto;
            mail.Body = "<h5>" + email.mensagem + "</h5>";
            mail.IsBodyHtml = true;

            using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
            {
                smtp.Credentials = new NetworkCredential("lucianoqueiroz.smn@gmail.com", "@dmmda06");
                smtp.EnableSsl = true;
                smtp.Send(mail);
            }
        }
    }
}
