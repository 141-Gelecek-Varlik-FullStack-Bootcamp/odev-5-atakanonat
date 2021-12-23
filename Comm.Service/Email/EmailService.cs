using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;

namespace Comm.Service.Email
{
    public class EmailService : IEmailService
    {
        public void Send(Model.Mail.Mail mail)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress(mail.From, mail.FromMail));
            message.To.Add(new MailboxAddress(mail.To, mail.ToMail));
            message.Subject = mail.Subject;
            message.Body = new TextPart("plain")
            {
                Text = mail.Body
            };
            using (var smtp = new SmtpClient())
            {
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(mail.FromMail, mail.SmtpPass);
                smtp.Send(message);
                smtp.Disconnect(true);
            }
        }
    }
}