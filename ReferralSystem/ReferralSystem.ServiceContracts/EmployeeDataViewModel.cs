﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class EmployeeDataViewModel
    {
        public int EmployeeID { get; set; }
        [DisplayName("First Name Is:")]
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Designation { get; set; }
        public string Name { get; set; }
    }
}
