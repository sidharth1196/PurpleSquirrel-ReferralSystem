
using System.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Services;
using ReferralSystem.Filters;
using ReferralSystem.ServiceContracts;


namespace ReferralSystem.Controllers
{

    public class Candidate_ProfileController : Controller
    {

        CandidateProfileService Candidate = new CandidateProfileService();
        ReferralService refService = new ReferralService();
        HistoryServices history = new HistoryServices();
        // GET: Candidate_Profile
        [ReferralSystemAuthorize("HR")]
        public ActionResult CandidateProfile(int ReferralID)
        {
            CandidateProfileViewModel c = new CandidateProfileViewModel();
            c = Candidate.GetCandidateData(ReferralID);
            c.Statuses = refService.GetStatus();
            c.HistoryViewModel = history.DuplicationDetails(ReferralID);
            return View(c);
        }

        [ReferralSystemAuthorize("HR")]
        public ActionResult UpdateStatus(int StatusID, int ReferralID)
        {

            bool result = refService.UpdateStatus(StatusID, ReferralID);

            return RedirectToAction("CandidateProfile", "Candidate_Profile", new { ReferralID = ReferralID }); //Add Else part here to c


        }


        [ReferralSystemAuthorize("HR")]
        public FileResult Downloadfile(int referralid)
        {
            int result = refService.GetResumeID(referralid);
            
            string FileName = refService.GetResumeName(result);

           

           return File("~/Uploads/" + FileName, System.Net.Mime.MediaTypeNames.Application.Pdf, FileName);




        }



    }
}