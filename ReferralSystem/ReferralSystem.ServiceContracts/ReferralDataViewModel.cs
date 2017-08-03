using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class ReferralDataViewModel
    {
        public string Status { get; set; }
        public string CandidateName { get; set; }
        public string EmployeeName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public string Experience { get; set; }
        public string Email { get; set; }
        public int ReferralID { get; set; }
        public int? JobID { get; set; }
        public int ResumeID { get; set; }
        public int? StatusID { get; set; }
        public int Bonus { get; set; }
        public string Post { get; set; }
        public string ReferDate { get; set; }
        public int EmployeeID { get; set; }
       
    }
}
