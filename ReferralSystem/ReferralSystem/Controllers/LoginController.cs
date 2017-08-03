using System.Web.Mvc;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Services;
using System.Web.Security;
using System.Net.Mail;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System;

namespace ReferralSystem.Controllers
{
    public class LoginController : Controller
    {
        LoginServices LoginInstance = new LoginServices();

       

        // GET: Login

        public ActionResult UserLogin()
        {
            return View();
        }
        public ActionResult LoginUser()
        {
                return View();
        }
        
        [HttpPost]
        public ActionResult Redirect(FormCollection collection)
        {
            LoginViewModel x= new LoginViewModel();
            x.UserName = collection["username"];
            x.Password = collection["password"];
            bool success = LoginInstance.LoginCheck(x);
            if (success)
            {
                FormsAuthentication.SetAuthCookie(x.UserName, x.RememberMe);
                Session["UserID"] = x.EmployeeID;
                if (x.Type == "HR")
                    return RedirectToAction("Index", "HR");
                else if(x.Type == "Emp")
                    return RedirectToAction("EmployeeLanding", "Employee");

            }

            ViewBag.Message = 1;
                return View("LoginUser");
            

        }
        
        public ActionResult ForgotPassword()
        {
            return View();
        }
        public ActionResult Logout()
        {

            Session.Abandon();
            FormsAuthentication.SignOut();
            return RedirectToAction("LoginUser", "Login");
        }
        
        public JsonResult ChangePassword(ChangePasswordViewModel item)
        {
            bool success = LoginInstance.ChangePassword(item);
            if (success)
            {
                return Json(new { success = true, message = "Password Successfully Changed" });
            }
            else
            {
                return Json(new { success = true, message = "Password Change Failed" });
            }
        }


        public ActionResult SendNewPasswordMail(FormCollection collection)
        {
            string email = LoginInstance.getemail(collection["Username"]);
            int linkid = LoginInstance.linkid();
            string encryptedusesrname = Encrypt(collection["Username"]);
            var fromAddress = new MailAddress("purplesquirrelgmg@gmail.com", "HR@GMG");
            var toAddress = new MailAddress(email);
            const string fromPassword = "purplesquirrel123";
            const string subject = "Password Reset";
            string body = "Dear User Please <a href=http://localhost:9032/ForgPassword/Index?username=" + encryptedusesrname + "&linkid="+linkid+" >Click here</a>  to Reset your password on PurpleSquirrel.Thanks!";

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

            ViewBag.MailSent = 1;
            return View("LoginUser");



        }

        public static string Encrypt(string text)
        {
            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
            string key = "#SlImShaDy#";

            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(text);
            string Encrypt = Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
            Encrypt = Encrypt.Replace("+", "!");
            return Encrypt;
        }







    }
}