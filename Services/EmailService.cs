using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Security;
using System.Net.Sockets;
using System.Security.Authentication;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MailKit;
using MailKit.Net.Proxy;
using MailKit.Security;

namespace dotnet7_sqlserver.Services
{
    public class EmailService : IEMailService
    {
        private readonly EmailConfiguration _emailConfig;
        
    }
}