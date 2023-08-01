using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace dotnet7_sqlserver.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        [HttpPost]
        public IActionResult SendEmail(EmailModel emailModel)
        {
            try
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(emailModel.FromEmail));
                email.To.Add(MailboxAddress.Parse(emailModel.ToEmail));
                email.Subject = emailModel.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = emailModel.Content };

                using var smtp = new SmtpClient();
                smtp.Connect("smtp.gmail.com", 587, SecureSocketOptions.StartTls);
                smtp.Authenticate("send@gmail.com", "password");
                smtp.Send(email);
                smtp.Disconnect(true);
                return Ok("Email sent successfully");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }


}