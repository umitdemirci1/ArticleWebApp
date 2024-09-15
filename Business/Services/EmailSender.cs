using Business.IServices;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Configuration;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Services
{
    public class EmailSender : IEmailSender
    {
        private readonly string _smtpServer;
        private readonly int _smtpPort;
        private readonly string _smtpUser;
        private readonly string _smtpPass;

        public EmailSender(IConfiguration configuration)
        {
            _smtpServer = configuration["SmtpSettings:Server"];
            _smtpPort = int.Parse(configuration["SmtpSettings:Port"]);
            _smtpUser = configuration["SmtpSettings:User"];
            _smtpPass = configuration["SmtpSettings:Pass"];
        }

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            if (string.IsNullOrWhiteSpace(email) || !IsValidEmail(email))
            {
                throw new ArgumentException("Geçersiz e-posta adresi", nameof(email));
            }

            var mimeMessage = new MimeMessage();
            mimeMessage.From.Add(new MailboxAddress("BlogApp Admin", _smtpUser));
            mimeMessage.To.Add(new MailboxAddress("User/Author", email));
            mimeMessage.Subject = subject;
            mimeMessage.Body = new TextPart("html")
            {
                Text = message
            };

            using (var client = new SmtpClient())
            {
                await client.ConnectAsync(_smtpServer, _smtpPort, MailKit.Security.SecureSocketOptions.StartTls);
                await client.AuthenticateAsync(_smtpUser, _smtpPass);
                await client.SendAsync(mimeMessage);
                await client.DisconnectAsync(true);
            }
        }

        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
