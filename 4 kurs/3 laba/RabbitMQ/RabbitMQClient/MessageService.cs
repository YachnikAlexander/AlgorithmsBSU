using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQClient
{
    public class MessageService
    {
        public string SendEmail(string subject, string body)
        {
            
            try
            {
                MailAddress from = new MailAddress("a.a.yachnik@gmail.com", "Yachnik");
                MailAddress to = new MailAddress("sansanich230899@gmail.com");
                MailMessage m = new MailMessage(from, to);
                m.Subject = subject;
                m.Body = body;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                smtp.Credentials = new NetworkCredential("a.a.yachnik@gmail.com", "zff23alex08");
                smtp.EnableSsl = true;
                smtp.SendMailAsync(m);
                return "письмо отправлено";
            }
            catch(Exception ex)
            {
                return $"Сообщение не отправлено, {ex.Message}";
            }
           
            
        }
    }
}
