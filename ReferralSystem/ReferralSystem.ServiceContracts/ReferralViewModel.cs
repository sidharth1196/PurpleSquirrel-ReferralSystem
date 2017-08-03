using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace ReferralSystem.ServiceContracts
{
    public class ReferralViewModel
    {
        public int EmployeeID { get; set; }
        public int JobID { get; set; }
        public Nullable<int> ResumeID { get; set; }
        public string Experience { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string MiddleName { get; set; }
        public string EmployeeName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public System.DateTime ReferDate { get; set; }
        public string Status { get; set; }
        public HttpPostedFileBase postedFile { get; set; }
    }
}
