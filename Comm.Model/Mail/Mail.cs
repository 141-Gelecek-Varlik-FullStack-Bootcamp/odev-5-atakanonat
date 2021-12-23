using System.ComponentModel.DataAnnotations;

namespace Comm.Model.Mail
{
    public class Mail
    {
        [Required]
        public string From { get; set; }
        [Required]
        public string FromMail { get; set; }
        [Required]
        public string To { get; set; }
        [Required]
        public string ToMail { get; set; }
        [Required]
        public string SmtpPass { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string Body { get; set; }
    }
}