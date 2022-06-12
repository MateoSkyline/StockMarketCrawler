using StockMarketCrawler.Interfaces;
using System.Net;
using System.Net.Mail;

namespace StockMarketCrawler.Services
{
    public class MailerService : IMailer
    {
        private readonly IConfiguration _configuration = new ConfigurationService();

        public async Task SendMail(string recipients, string subject, string body)
        {
            SmtpClient smtpClient = new(_configuration.GetValue("MAIL_HOST"))
            {
                Port = 587,
                Credentials = new NetworkCredential(_configuration.GetValue("MAIL_USER"), _configuration.GetValue("MAIL_PASS")),
                EnableSsl = false,
            };

            MailMessage mail = new()
            {
                From = new MailAddress(_configuration.GetValue("MAIL_ADDR")),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };
            mail.To.Add(recipients);
            await smtpClient.SendMailAsync(mail);
        }
    }
}
