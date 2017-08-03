using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;
using System.Globalization;

namespace ReferralSystem.Services
{
    public class RecruitService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();
        
        History history=new History();
        public bool writetorecruits(RecruitViewModel r)
        {
            Recruit recruits = new Recruit(); //Instance of recruit table from database
            try
            {
                var j = (from ed1 in DBContext.Jobs                         //To get jobname from jobs table
                         where ed1.JobID == r.JobID
                         select new
                         {
                             JobName = ed1.Post,
                             Bonus = ed1.Bonus,

                         }).SingleOrDefault();


                var data = (from ed2 in DBContext.Referrals                                        //Get Candidate data from referral table
                            where ed2.ReferralID == r.ReferralID
                            select ed2).SingleOrDefault(); ;
                /* select new
                 {
                     CandidateName = ed2.CandidateName,
                     EmployeeId = ed2.EmployeeID,
                     PhoneNumber = ed2.PhoneNumber,
                     Location = ed2.Location,
                     Email = ed2.Email,
                     DOB = ed2.DOB,
                     ResumeID = ed2.ResumeID,

                     StatusID = r.StatusID,
                     ReferralID = ed2.ReferralID,
                     Post = j.JobName,
                     Joiningdate = r.JoiningDate
                 }).SingleOrDefault();*/

                data.StatusID = r.StatusID;
                DBContext.SaveChanges();

                recruits.CandidateName = data.CandidateName;                                             //Write candidate details to recruit table
                recruits.EmployeeID = data.EmployeeID;
                recruits.Post = j.JobName;
                recruits.JoiningDate = System.Convert.ToDateTime(r.JoiningDate);
                recruits.ReferralID = data.ReferralID;
                recruits.Bonus = j.Bonus;
                DBContext.Recruits.Add(recruits);
                DBContext.SaveChanges();

                History history = new History();                                                                   //Write details to history table
                history.CandidateName = data.CandidateName;
                history.Date = System.Convert.ToDateTime(DateTime.Now);
                history.DOB = data.DOB;
                history.Email = data.Email;
                history.EmployeeID = data.EmployeeID;
                history.PhoneNumber = data.PhoneNumber;
                history.JobID = r.JobID;
                history.ReferralID = data.ReferralID;
                history.StatusID = Convert.ToInt16(data.StatusID);

                DBContext.Histories.Add(history);
                DBContext.SaveChanges();

                //  var RecordToDelete = DBContext.Referrals.Where(a => a.ReferralID == r.ReferralID).SingleOrDefault();          //Delete from referral table

                // DBContext.Referrals.Remove(RecordToDelete);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
            




        }

        public List<AcceptedViewModel> GetRecruits()
        {
            try
            {
                var data = (from item in DBContext.Recruits
                            join emp in DBContext.Employees on item.EmployeeID equals emp.EmployeeID
                            let joinDate = item.JoiningDate.ToString()
                            select new AcceptedViewModel {
                                Name = item.CandidateName,
                                EmployeeName = emp.FirstName + " " + emp.MiddleName + " " + emp.LastName,
                                Post = item.Post,
                                JoiningDate = joinDate,
                                ReferralID = item.ReferralID
                            });
                return data.ToList();
            }
            catch (Exception e)
            {
                return null ;
            }
        }

        public bool ChangeDate(string date,int referralid)
        {
            
            try
            {
                var data = (from item in DBContext.Recruits
                            where item.ReferralID == referralid
                            select item).SingleOrDefault();
                data.JoiningDate = System.Convert.ToDateTime(date);

                DBContext.SaveChanges();

                return true;

            }




            catch (Exception e)
            { return false; }
        }
       
        public bool DeleteRecruit (int ReferralID)
        {
            try
            {
                var recruitEntry = DBContext.Recruits.Where(x => x.ReferralID == ReferralID).SingleOrDefault();
                var referralEntry = DBContext.Referrals.Where(x => x.ReferralID == ReferralID).SingleOrDefault();

                History history = new History();                                                                   //Write details to history table
                history.CandidateName = referralEntry.CandidateName;
                history.Date = System.Convert.ToDateTime(DateTime.Now);
                history.DOB = referralEntry.DOB;
                history.Email = referralEntry.Email;
                history.EmployeeID = referralEntry.EmployeeID;
                history.PhoneNumber = referralEntry.PhoneNumber;
                history.JobID = referralEntry.JobID;
                history.ReferralID = referralEntry.ReferralID;
                history.StatusID = 4;

                DBContext.Histories.Add(history);
                DBContext.Referrals.Remove(referralEntry);
                DBContext.Recruits.Remove(recruitEntry);
                DBContext.SaveChanges();
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
