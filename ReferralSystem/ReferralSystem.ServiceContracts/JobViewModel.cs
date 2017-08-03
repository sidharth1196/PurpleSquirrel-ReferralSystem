using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class JobViewModel
    {
        public int JobID { get; set; }
        public string Post { get; set; }
        public string Description { get; set; }
        public string Experience { get; set; }
        public int Bonus { get; set; }
        public Nullable<int> Vacancy { get; set; }
        public int? Active { get; set; }

    }
}
