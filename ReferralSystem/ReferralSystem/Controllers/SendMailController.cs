using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Mail;
using System.Net;
using ReferralSystem.Filters;
using System.Security.Cryptography;

namespace ReferralSystem.Controllers
{
    public class SendMailController : Controller
    {
        // GET: SendMail
        [ReferralSystemAuthorize("HR")]
        public bool Index(string email, string name,int TempId )
        {
            try
            {
               
                var fromAddress = new MailAddress("purplesquirrelgmg@gmail.com", "HR@GMG");
                var toAddress = new MailAddress(email, name);
                const string fromPassword = "purplesquirrel123";
                const string subject = "Register Form";
                string body = "Dear User Please <a href=http://localhost:9032/Register/Index?TemporaryEmployeeID=" + TempId + " >Click here</a>  to Complete your registration to PurpleSquirrel.Thanks!";

                var smtp = new SmtpClient
                {
                    Host = "smtp.gmail.com",
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                    Timeout = 20000

                };
                using (var message = new MailMessage(fromAddress, toAddress)
                {
                    Subject = subject,
                    Body = body,
                    IsBodyHtml = true
                })
                {
                    smtp.Send(message);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }

   








    }
}