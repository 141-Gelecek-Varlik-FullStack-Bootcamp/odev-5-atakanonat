
using Comm.Service.Email;
using MailKit;
using Microsoft.Extensions.Options;

namespace Comm.API.Infrastructure
{
    public class HangfireJobs
    {
        private readonly IEmailService _emailService;
        public HangfireJobs(IEmailService emailService)
        {
            _emailService = emailService;
        }
        public void SendWelcomeMail(string ToUser, string ToUserMail)
        {
            var newMail = new Model.Mail.Mail() { To = ToUser, ToMail = ToUserMail };
            newMail.From = "E-Commerce Brand";
            newMail.FromMail = "CommerceMail@gmail.com";
            newMail.Subject = string.Format("Welcome {0},Thank you for signing up!", ToUser);
            newMail.Body = string.Format("Hello {0}, \nWe’re super excited to see you join the E-Commerce community.\nWe hope you will be happy with things you might find that you need and that you will shop with us again and again.\nOur goal is to offer the widest range of [products offered by the online store] at the highest quality. If you think we should add any items to our store, don’t hesitate to contact us and share your feedback.\nUntil then, enjoy your shopping!\nBest,\nAtakan Onat", ToUser);
            newMail.SmtpPass = "PASS";
            _emailService.Send(newMail);
        }
    }
}