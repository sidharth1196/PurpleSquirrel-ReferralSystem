using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class HRJobService
    {

        PurpleSquirrelEntities db = new PurpleSquirrelEntities();

        public JobVacancyViewModel Jobs()
        {
            var data = (from x in db.Jobs
                        select new JobViewModel
                        {
                            JobID = x.JobID,
                            Post = x.Post,
                            Description = x.Description,
                            Experience = x.Experience,
                            Bonus = x.Bonus,
                            Vacancy = x.Vacancy,
                            Active=x.Active
                        });

            JobVacancyViewModel y = new JobVacancyViewModel();
            y.DisplayViewModel = data.ToList();
            return y;
        }
    }    
}
