using Azure;
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Microsoft.Extensions.Logging;
using Service.Interface;
using Azure.Communication.Email;
using Azure.Communication.Email.Models;

namespace Service
{
    public class EmailService : IEmailService
    {
        private readonly string _connectionString = Environment.GetEnvironmentVariable("EmailConnectionString", EnvironmentVariableTarget.Process);
        private readonly string _emailSender = Environment.GetEnvironmentVariable("EmailSender", EnvironmentVariableTarget.Process);
        private ILogger _logger { get; set; }

        public EmailService(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<MortgageService>();
        }

        public void SendEmail(string to, string subject, string content)
        {
            EmailClient emailClient = new(_connectionString);
            EmailContent emailContent = new(subject);
            emailContent.PlainText = content;
            EmailRecipients emailRecipients = new EmailRecipients(new List<EmailAddress>() { new EmailAddress(to) });
            EmailMessage emailMessage = new(_emailSender, emailContent, emailRecipients);

           emailClient.Send(emailMessage);
        }
    }
}