using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet7_sqlserver.Dtos;

namespace dotnet7_sqlserver.Services.EmailService
{
    public interface IEmailService
    {
        public ServiceResponse<string> SendEmail(SendEmailDto sendEmailDto);
    }
}