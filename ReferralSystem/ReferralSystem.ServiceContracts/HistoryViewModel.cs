using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class HistoryViewModel
    {
        public string EmployeeName { get; set; }
        public int? ReferralID { get; set; }
        public string CandidateName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Post { get; set; }
        public string Date { get; set; }
        public string DOB { get; set; }
        public string Status { get; set; }
    }
}
