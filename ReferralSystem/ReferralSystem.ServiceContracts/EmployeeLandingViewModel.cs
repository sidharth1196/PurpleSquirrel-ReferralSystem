using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class EmployeeLandingViewModel
    {
        public ReferralViewModel ReferralViewModel { get; set; }
        public List<JobViewModel> JobViewModel { get; set; }
    }
}
