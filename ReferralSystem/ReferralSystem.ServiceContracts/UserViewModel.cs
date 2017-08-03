using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class UserViewModel
    {
        public string UserName { get; set; }
        public int UserID { get; set; }
        public string Password { get; set; }
        public string Type { get; set; }
        public Nullable<int> EmployeeID { get; set; }
        public bool IsValid { get; set; }
    }
}
