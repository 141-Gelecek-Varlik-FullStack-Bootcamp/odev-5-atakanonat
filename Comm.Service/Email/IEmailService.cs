namespace Comm.Service.Email
{
    public interface IEmailService
    {
        void Send(Model.Mail.Mail mail);
    }
}