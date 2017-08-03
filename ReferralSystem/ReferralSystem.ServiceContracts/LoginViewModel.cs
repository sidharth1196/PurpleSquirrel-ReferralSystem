using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;



namespace ReferralSystem.ServiceContracts
{
    public class LoginViewModel
    {

        public int UserID { get; set; }
        public int EmployeeID { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public string Type { get; set; }
        public bool RememberMe { get; set; }
        public bool isValid { get; set; }
    }
}   
