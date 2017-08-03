using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Services;
using ReferralSystem.Filters;

namespace ReferralSystem.Controllers
{
    public class Employee_ProfileController : Controller
    {
        EmployeeProfileService emp = new EmployeeProfileService();
        // GET: Employee_
        [ReferralSystemAuthorize("HR")]
        public ActionResult Index()
        {
            return View();
        }

        [ReferralSystemAuthorize("HR")]
        public ActionResult EmployeeProfile(int EmployeeID)
        {
            return View(emp.GetEmployeeProfileData(EmployeeID));


        }




    }
}