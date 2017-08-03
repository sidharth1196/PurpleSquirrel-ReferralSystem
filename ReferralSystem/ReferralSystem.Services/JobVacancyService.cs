using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;

namespace ReferralSystem.Services
{
    public class JobVacancyService
    {
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();

        public bool Adding(JobViewModel item)
        {
            try
            {
                Job x = new Job();

                x.Post = item.Post;
                x.Bonus = item.Bonus;
                x.Experience = item.Experience;
                x.Vacancy = item.Vacancy;
                x.Description = item.Description;
                x.Active = 1;


                db.Jobs.Add(x);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
                throw;
            }
        }


        public bool Updating(JobViewModel item)
        {
            try
            {
                var obj = db.Jobs.Where(a => a.JobID.Equals(item.JobID)).SingleOrDefault();
                if(obj !=null)
                {
                    //db.Jobs.Remove(obj);
                    //db.SaveChanges();
                    obj.Post = item.Post;
                    obj.Bonus = item.Bonus;
                    obj.Experience = item.Experience;
                    obj.Vacancy = item.Vacancy;
                    obj.Description = item.Description;
                    obj.JobID = item.JobID;

                    //db.Jobs.Add(obj);
                   
                    db.SaveChanges();
                }
                return true;

            }
            catch (Exception)
            {
                return false;
            }
        }
        public bool Removing(JobViewModel item)
        {
            try
            {
                var obj = db.Jobs.Where(a => a.JobID.Equals(item.JobID)).FirstOrDefault();
                if(obj != null)
                {
                    db.Jobs.Remove(obj);
                    db.SaveChanges();
                }
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }


        public void ActiveInactive(int JobID)
        {
            var result = (from ed in db.Jobs
                          where ed.JobID==JobID
                          select ed).SingleOrDefault();
            if (result.Active == 1)
                result.Active = 0;
            else
                result.Active = 1;
            db.SaveChanges();

        }
    }
}
