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
    public class HRController : Controller
    {
        EmployeeDetailsService empService = new EmployeeDetailsService();
        ReferralService refService = new ReferralService();
        RecruitService recService = new RecruitService();
        LeaderboardService leaderboardService = new LeaderboardService();

        // GET: HR_Landing
        [ReferralSystemAuthorize("HR")]
        public ActionResult Index(int tabno=1)         //Function to display candidate tables
        {
            HRLandingViewModel H = new HRLandingViewModel();
            H.Statuses= refService.GetStatus();
            H.Referrals=refService.GetReferralData();
            H.Recruits = recService.GetRecruits();
            ViewBag.Tab = tabno;
            return View(H);


        }
        [ReferralSystemAuthorize("HR")]
        public ActionResult Empdetails()         //Function to display employee details
        {
            return View(empService.GetEmployeeData());
        }
        [ReferralSystemAuthorize("HR")]
        public JsonResult UpdateStatus(int StatusID, int ReferralID)
        {

            bool result = refService.UpdateStatus(StatusID, ReferralID);

            if (result)
                return Json(new { success = true,message="Status has been updated." });
            else
                return Json(new { success = false }); //Add Else part here to c


        }
        
        HRJobService jobService = new HRJobService();
        // GET: Jobs
        [ReferralSystemAuthorize("HR")]
        public ActionResult HRJobVacancy()
        {
            return View(jobService.Jobs());
        }
        [ReferralSystemAuthorize("HR")]
        public JsonResult Selected(RecruitViewModel r)
        {
            bool success = recService.writetorecruits(r);
            if (success)
            {
                ViewBag.Message = "Successful!";
                return Json(new { success = false, message = ViewBag.Message });
            }

            else
            {
                ViewBag.Message = "Operation Failed!";
                return Json(new { success = false, message = ViewBag.Message });
            }
                
        
       
        }
        [ReferralSystemAuthorize("HR")]
        public ActionResult DeleteEmployee(int EmployeeID)

        {
            bool success=empService.deleteemployee(EmployeeID);
          

                return RedirectToAction("EmpDetails", "HR");


        }
        [ReferralSystemAuthorize("HR")]
        public ActionResult ChangeDate(FormCollection collection)
        {
            
          bool success = recService.ChangeDate(collection["changedate"], Int32.Parse(collection["referralid"]));
            return RedirectToAction("Index", "HR",new { tabno=2});
        }
        [ReferralSystemAuthorize("HR")]
        public ActionResult Leaderboard()
        {
            return View(leaderboardService.GetLeaderboard());
        }

        [ReferralSystemAuthorize("HR")]
        public JsonResult DeleteRecruit(int ReferralID)
        {
            bool success = recService.DeleteRecruit(ReferralID);
            if (success)
            {
                ViewBag.Message = "Successful!";
            }
            else
            {
                ViewBag.Message = "Operation failed!";
            }
            return Json(new { success = true, message = ViewBag.Message });
        }
    }
}