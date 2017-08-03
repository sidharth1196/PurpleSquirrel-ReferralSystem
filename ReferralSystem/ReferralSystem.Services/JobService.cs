using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class JobService
    {
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();

        public List<JobViewModel> Jobs()
        {
            var data = (from x in db.Jobs
                        select new JobViewModel
                        {
                            JobID = x.JobID,
                            Post = x.Post,
                            Description = x.Description,
                            Experience = x.Experience,
                            Bonus = x.Bonus,
                            Vacancy = x.Vacancy
                        });
           
            return data.ToList();
        }
        public List<JobViewModel> Jobsforemployee() //Function to select Active jobs to display in employee page
        {
            var data = (from x in db.Jobs
                        where x.Active==1
                        select new JobViewModel
                        {
                            JobID = x.JobID,
                            Post = x.Post,
                            Description = x.Description,
                            Experience = x.Experience,
                            Bonus = x.Bonus,
                            Vacancy = x.Vacancy
                        });

            return data.ToList();
        }
    }
}
