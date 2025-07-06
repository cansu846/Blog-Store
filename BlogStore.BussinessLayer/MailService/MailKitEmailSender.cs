

using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace BlogStore.BussinessLayer.MailService
{
    public class MailKitEmailSender : IEmailSender
    {
        private readonly IConfiguration _config;

        public MailKitEmailSender(IConfiguration config)
        {
            _config = config;
        }

        public async Task SendEmailAsync(string email, string subject, string htmlMessage)
        {
            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("BlogStore Destek", _config["EmailSettings:SenderEmail"]));
            message.To.Add(MailboxAddress.Parse(email));
            message.Subject = subject;

            message.Body = new TextPart("html")
            {
                Text = htmlMessage
            };

            using var smtp = new SmtpClient();
            await smtp.ConnectAsync(
      _config["EmailSettings:SmtpServer"],
      int.Parse(_config["EmailSettings:Port"]),
      MailKit.Security.SecureSocketOptions.StartTls
  );

            await smtp.AuthenticateAsync(
                _config["EmailSettings:Username"],
                _config["EmailSettings:Password"]
            );
            await smtp.SendAsync(message);
            await smtp.DisconnectAsync(true);
        }
    }
}
