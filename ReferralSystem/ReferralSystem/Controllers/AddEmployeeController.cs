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
    public class AddEmployeeController : Controller
    {
        AddEmployeeService a = new AddEmployeeService();
        // GET: AddEmployee
        public JsonResult Add(FormCollection collection)
        {
            var TempId = a.AddEmployeeData(collection["FirstName"], collection["MiddleName"], collection["LastName"], collection["Designation"], collection["Email"]);
            if (TempId!=0)
            {
                bool success = new SendMailController().Index(collection["email"], collection["name"],TempId);
                if(success)
                    return Json(new { success = true, message = "An email has been sent to the employee." });
                else
                    return Json(new { success = true, message = "Operation failed!" });
            }
            else
                return Json(new { success = true, message = "Operation failed!" });



        }
    }
}