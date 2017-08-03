using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Services;
using ReferralSystem.Filters;

namespace ReferralSystem.Controllers
{
    public class EmployeeProfileController : Controller
    {
        MyProfileService profile = new MyProfileService();
        // GET: EmployeeProfile
        [HttpPost]
        [ReferralSystemAuthorize("Emp")]
        public JsonResult EditProfile (MyProfileViewModel emp)
        {
            bool success = profile.saveChanges(emp);
            if (success)
                return Json(new { success = true, message = "Updated Successfully!" });
            else
                return Json(new { success = false, message = "Operation Failed!" });
        }
    }
}