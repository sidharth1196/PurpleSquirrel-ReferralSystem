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
    
    public class JobVacancyController : Controller
    {
        JobVacancyService JobService = new JobVacancyService();
        // GET: Refer
        [HttpPost]
        [ReferralSystemAuthorize("HR")]
        public JsonResult UpdateJob(JobViewModel update)
        {
            bool trial = JobService.Updating(update);
            if (trial)
            {
                ViewBag.Message = "Successful";
                return Json(new { success = true, message = ViewBag.Message });
            }
            else
            {
                ViewBag.Message = "Operation Failed";
                return Json(new { success = false, message = ViewBag.Message });
            }
        }

        [ReferralSystemAuthorize("HR")]
        public JsonResult AddJob(JobViewModel addJob)
        {
            bool Add = JobService.Adding(addJob);
            if(Add)
            {
                return Json(new { success = true, message = "Successful!" });
            }
            else
            {
                return Json(new { success = false, message = "Operation Failed!" });
            }
        }
        [ReferralSystemAuthorize("HR")]
        public JsonResult RemoveJob(JobViewModel removeJob)
        {
            bool Remove = JobService.Removing(removeJob);
            if(Remove)
            {
                return Json(new { success = true, message = "Successful!" });
            }
            else
            {
                return Json(new { success = false, message = "Operation Failed!" });
            }
        }
        [ReferralSystemAuthorize("HR")]
        public void ActiveInactive(int JobID)
        {
            JobService.ActiveInactive(JobID);
        }
    }
}