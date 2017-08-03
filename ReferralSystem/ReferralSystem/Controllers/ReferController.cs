using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Services;
using System.IO;
using ReferralSystem.Filters;


namespace ReferralSystem.Controllers
{
    public class ReferController : Controller
    {
        ReferServices referService = new ReferServices();
        MyReferralService myReferralService = new MyReferralService();
        // GET: Refer
        [HttpPost]
        [ReferralSystemAuthorize("Emp")]
        public JsonResult Refer(ReferralViewModel refer)
        {
            if (refer.postedFile != null)
            {
                string path = Server.MapPath("~/Uploads/");
                if (!Directory.Exists(path))
                {
                    Directory.CreateDirectory(path);
                }
                string filename = Path.GetFileName(refer.postedFile.FileName);
                refer.postedFile.SaveAs(path + filename);
                refer.ResumeID = referService.Resume(filename);
                ViewBag.Message = " and Resume uploaded";
            }
            else
                ViewBag.Message = " with no resume";

            bool trial = referService.Referring(refer);

            if (trial)
            {
                ViewBag.Message = "Candidate referred" + ViewBag.Message;
                return Json(new { success = true, message = ViewBag.Message });
            }
            else
            {
                ViewBag.Message = "Failed";
                return Json(new { success = false, message = ViewBag.Message });
            }
            
            
        }
        [ReferralSystemAuthorize("Emp")]
        public JsonResult Redeem(int ID, int empID)
        {
            bool redeem = myReferralService.Redeem(ID, empID);
            if (redeem)
            {
                ViewBag.Message = "Your Bonus redeemed.";
            }
            else
            {
                ViewBag.Message = "Operation failed.";
            } 
            return Json(new { success = true, message = ViewBag.Message });
        }
        
        
    }
}