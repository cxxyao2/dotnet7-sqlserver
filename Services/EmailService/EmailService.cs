using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Dtos;
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using MimeKit.Text;

namespace dotnet7_sqlserver.Services.EmailService
{
    public class EmailService : IEmailService
    {
        private readonly IConfiguration _configuration;

        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public ServiceResponse<string> SendEmail(SendEmailDto emailDto)
        {
            var response = new ServiceResponse<string>();

            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_configuration.GetSection("EmailConfiguration:From").Value));
                email.To.Add(MailboxAddress.Parse(emailDto.ToEmail));
                email.Subject = emailDto.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = emailDto.Content };

                using var smtp = new SmtpClient();
                smtp.Connect(_configuration.GetSection("EmailConfiguration:Server").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_configuration.GetSection("EmailConfiguration:From").Value, _configuration.GetSection("EmailConfiguration:Password").Value);
                smtp.Send(email);
                smtp.Disconnect(true);
                response.Message = "Email sent successfully";

            }
            catch (Exception ex)
            {
                response.Success = false;
                response.Message = ex.Message;

            }

            return response;

        }
    }
}