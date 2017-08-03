using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class LeaderboardViewModel
    {
        public int EmployeeID { get; set; }
        public string EmployeeName { get; set; }
        public Nullable<int> Score { get; set; }
    }
}
