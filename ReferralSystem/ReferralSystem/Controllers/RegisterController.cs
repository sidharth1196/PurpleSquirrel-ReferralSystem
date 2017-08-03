using ReferralSystem.ServiceContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Services;

namespace ReferralSystem.Controllers
{
    public class RegisterController : Controller
    {
        RegisterService reg = new RegisterService();

        // GET: Register
        public ActionResult Index(int TemporaryEmployeeID)
        {
            var data = reg.GetTemporaryDetails(TemporaryEmployeeID);
            return View(data);
        }
        [HttpPost]
        public ActionResult RegisterEmployee(RegisterViewModel r)
        {
            bool success = reg.Registeremployee(r);
            return Json(new { success = success });
        }

        public JsonResult checkAvailability(string Username)
        {
            var x = reg.checkAvailability(Username);
            if (x)
                return Json(new { success = true });
            else
                return Json(new { success = false });
        }

    }
}