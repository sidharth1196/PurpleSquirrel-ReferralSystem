using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class MyProfileViewModel
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Designation { get; set; }
        public Nullable<System.DateTime> DOB { get; set; } 
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public Nullable<int> ReferralBonus { get; set; }
        public Nullable<int> ReferralsConverted { get; set; }
        public int EmployeeID { get; set; }
    }
}
