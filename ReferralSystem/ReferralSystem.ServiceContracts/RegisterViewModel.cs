using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
  public class RegisterViewModel
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int TemporaryEmployeeID { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string DateOfBirth { get; set; }
        public string PhoneNumber { get; set; }
    }
}
