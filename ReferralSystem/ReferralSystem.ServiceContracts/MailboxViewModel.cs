using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferralSystem.ServiceContracts
{
    public class MailboxViewModel
    {
        public Nullable<int> From { get; set; }
        public Nullable<int> To { get; set; }
        public string Subject { get; set; }
        public Nullable<System.DateTime> Date { get; set; }
        public string Body { get; set; }
        public int ID { get; set; }
    }
}
