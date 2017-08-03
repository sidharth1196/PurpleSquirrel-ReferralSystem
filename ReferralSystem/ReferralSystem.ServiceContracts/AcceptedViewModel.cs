using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class AcceptedViewModel
    {
        public string Name { get; set; }
        public string EmployeeName { get; set; }
        public string Post { get; set; }
        public string JoiningDate { get; set; }
        public int ReferralID { get; set; }
    }
}
