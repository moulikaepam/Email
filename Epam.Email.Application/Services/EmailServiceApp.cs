using Epam.Email.Application.Interfaces;
using Epam.Email.Application.Models;
using Epam.Email.Domain.Repositories;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Threading.Tasks;

namespace Epam.Email.Application.Services
{
    public class EmailServiceApp 
    {
        private readonly IEmailRepository _emailRepository;
        private readonly SmtpCredential _smtpCredentials;
        private readonly ILogger<EmailServiceApp> _logger;

        public EmailServiceApp(IEmailRepository emailRepository, IOptions<SmtpCredential> smtpCredentials, ILogger<EmailServiceApp> logger)
        {
            _emailRepository = emailRepository;
            _smtpCredentials = smtpCredentials.Value;
            _logger = logger;
        }

        public async Task SendOtpToCustomerAsync(string customerName, string customerEmail)
        {
            var otp = new Random().Next(100000, 999999).ToString();
            _logger.LogInformation($"Generated OTP for {customerEmail}: {otp}");  

            var message = new MimeMessage();
            message.From.Add(new MailboxAddress("ProInteriors - Contact Verification", _smtpCredentials.Email));
            message.To.Add(new MailboxAddress(customerName, customerEmail));
            message.Subject = "ProInteriors - Verify Your Email";

            message.Body = new TextPart("plain")
            {
                Text = $"Your One-Time Password (OTP) for verification is: {otp}"
            };

            using var client = new SmtpClient();
            await client.ConnectAsync("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_smtpCredentials.Email, _smtpCredentials.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
    }
}
