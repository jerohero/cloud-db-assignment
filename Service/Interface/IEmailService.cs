using Domain.Entity;
using Domain.Model;

namespace Service.Interface
{
    public interface IEmailService
    {
        public void SendEmail(string to, string subject, string content);
    }
}