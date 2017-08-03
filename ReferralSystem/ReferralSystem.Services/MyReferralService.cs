using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class MyReferralService
    {
        
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();
        public List<MyReferralViewModel> GetMyReferrals(int employeeID)
        {
            var data = (from refers in db.Referrals
                        join jobs in db.Jobs on refers.JobID equals jobs.JobID
                        join status in db.Status on refers.StatusID equals status.StatusID
                        where refers.EmployeeID == employeeID
                        orderby refers.ReferDate descending
                        select new MyReferralViewModel
                        {
                            CandidateName = refers.CandidateName,
                            Post = jobs.Post,
                            Experience = refers.Experience,
                            Bonus = jobs.Bonus,
                            Status = status.StatusName,
                            ReferralID = refers.ReferralID
                        }).AsEnumerable().Select(x => new MyReferralViewModel{
                            CandidateName = x.CandidateName,
                            Post = x.Post,
                            Experience = x.Experience,
                            Bonus = x.Bonus,
                            Status = x.Status,
                            ReferralID = x.ReferralID,
                            Redeem = CheckForBonus(x.ReferralID) });

            return data.ToList();
        }

        public int CheckForBonus(int ID)
        {
            try
            {
                var data = (from accepted in db.Recruits
                            where accepted.ReferralID == ID
                            select new
                            {
                                accepted.JoiningDate
                            }).SingleOrDefault();
                int days = Convert.ToInt16((DateTime.Now.Date - Convert.ToDateTime(data.JoiningDate)).TotalDays);
                if (days >= 90)
                {
                    return 0;
                }
                else
                    return 90 - days ;
            }
            catch (Exception)
            {
                return -1;
                throw;
            }

        }

        public bool Redeem(int ID, int empID)
        {
            try
            {
                var recruit = (from item in db.Recruits
                               where item.ReferralID == ID
                               select item).SingleOrDefault();
                var employee = (from item in db.Employees
                                where item.EmployeeID == empID
                                select item).SingleOrDefault();

                var deleteReferral = (from item in db.Referrals
                                      where item.ReferralID == ID
                                      select item).SingleOrDefault();

                employee.ReferralBonus += recruit.Bonus;
                employee.ReferralsConverted += 1;

                db.Recruits.Remove(recruit);
                db.Referrals.Remove(deleteReferral);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
                throw;
            }

        }


    }
}
