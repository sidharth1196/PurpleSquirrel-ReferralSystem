using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class EmployeeProfileViewModel
    {

        public EmployeeDetailsViewModel employeedetails = new EmployeeDetailsViewModel();
        public List<ReferralDataViewModel> referraldetails { get; set; }

    }
}