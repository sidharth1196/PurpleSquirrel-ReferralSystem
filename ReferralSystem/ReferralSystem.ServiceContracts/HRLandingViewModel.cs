using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class HRLandingViewModel
    {   public int selectedstatus { get; set; }
        public List<ReferralDataViewModel> Referrals { get; set; }
        public Dictionary<int, string> Statuses { get; set; }
        public List<AcceptedViewModel> Recruits { get; set; }
    }
}
