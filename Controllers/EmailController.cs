using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Dtos;
using dotnet7_sqlserver.Services.EmailService;
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
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;

        }
        [HttpPost]
        public ActionResult<ServiceResponse<string>> SendEmail(SendEmailDto sendEmailDto)
        {

            return Ok(_emailService.SendEmail(sendEmailDto));

        }

    }


}