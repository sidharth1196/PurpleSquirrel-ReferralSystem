using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ReferralSystem.Services;
using ReferralSystem.Filters;

namespace ReferralSystem.Controllers
{
    [ReferralSystemAuthorize("HR")]
    public class HistoryController : Controller
    {
        HistoryServices history = new HistoryServices();
        // GET: History
        public ActionResult Duplication(FormCollection collection)
        {
            int ID = Convert.ToInt16(collection["ReferralID"]);

            return View (history.DuplicationDetails(ID));
        }
    }
}