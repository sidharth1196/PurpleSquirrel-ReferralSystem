using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class CandidateProfileViewModel
    {
        public string CandidateName { get; set; }
        public string PhoneNumber { get; set; }
        public string Location { get; set; }
        public int ReferralID { get; set; }
        public Nullable<System.DateTime> DOB { get; set; }
        public string CandidateExperience { get; set; }
        public int? ResumeID { get; set; }
        public string EmployeeName { get; set; }
        public string Email { get; set; }
        public string EmployeeEmail { get; set; }
        public string EmployeePhoneNumber { get; set; }
        public int JobID { get; set; }
        public string JobName { get; set; }
        public int Vacancies { get; set; }
        public string SkillSet { get; set; }
        public string Experience { get; set; }  
        public int? StatusID { get; set; }
        public Dictionary<int, string> Statuses { get; set; }
        public int Bonus { get; set; }
        public List<HistoryViewModel> HistoryViewModel { get; set; }
    }
}
