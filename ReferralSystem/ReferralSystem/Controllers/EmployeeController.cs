using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Services;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Filters;

namespace ReferralSystem.Controllers
{
    public class EmployeeController : Controller
    {
        JobService jobService = new JobService();
        MyReferralService referService = new MyReferralService();
        LeaderboardService leaderboardService = new LeaderboardService();
        MyProfileService profile = new MyProfileService();
        // GET: Employee
        [ReferralSystemAuthorize("Emp")]
        public ActionResult EmployeeLanding()
        {
            return View(jobService.Jobsforemployee());
        }

        [ReferralSystemAuthorize("Emp")]
        public ActionResult MyReferral(int employeeID)
        {
            return View(referService.GetMyReferrals(employeeID));
        }

        [ReferralSystemAuthorize("Emp")]
        public ActionResult Leaderboard()
        {
            return View(leaderboardService.GetLeaderboard());
        }

        [ReferralSystemAuthorize("Emp")]
        public ActionResult MyProfile(int employeeID)
        {
            return View(profile.ProfileDetails(employeeID));
        }

    }
}