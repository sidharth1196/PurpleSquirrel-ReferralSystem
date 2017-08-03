using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
  public  class RecruitViewModel
    {
        public int StatusID { get; set; }
        public int ReferralID { get; set;}
        public int JobID { get; set;}
        public string JoiningDate { get; set; }
    }
}
