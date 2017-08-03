using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;

namespace ReferralSystem.ServiceContracts
{
    public class MyReferralViewModel
    {
        public int ReferralID { get; set; }
        public string CandidateName { get; set; }
        public string Post { get; set; }
        public string Experience { get; set; }
        public int Bonus { get; set; }
        public string Status { get; set; }
        public int Redeem { get; set; }
    }
}
