using ReferralSystem.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Filters;

namespace ReferralSystem.Controllers
{
    public class ForgPasswordController : Controller
    {
        LoginServices LoginInstance = new LoginServices();
        // GET: ForgPassword
      
        public ActionResult Index(string username ,int linkid )
        {
            bool checkvalidity = LoginInstance.checkdatevalidity(linkid);
            string decryptedusername = Decrypt(username);

            if (checkvalidity)
            {
                ViewBag.valid = 1;
                int userid = LoginInstance.getuserid(decryptedusername);
                ViewBag.userid = userid;
                ViewBag.username = decryptedusername;
                return View();
            }
            else
            {
                ViewBag.valid = 0;
                return View();

            }

        }
        public ActionResult SetNewPassword(FormCollection collection)
        {
            bool success=LoginInstance.setnewpassword(collection["newpassword"],System.Convert.ToInt16( collection["userid"]));
             return RedirectToAction("LoginUser", "Login");

        }

        
        public static string Decrypt(string text)
        {
            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
            string key = "#SlImShaDy#";
            text = text.Replace("!", "+");
            byte[] buf = new byte[text.Length];
            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(key));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            buf = Convert.FromBase64String(text);
            string Decrypt = ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buf, 0, buf.Length));
            return Decrypt;
        }




    }
}