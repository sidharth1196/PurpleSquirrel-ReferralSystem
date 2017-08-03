using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;

namespace ReferralSystem.Services
{
    public class ReferralService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();

        public List<ReferralDataViewModel> GetReferralData()
        {
            var data = (from ed1 in DBContext.Referrals
                        join ed2 in DBContext.Status
                        on ed1.StatusID equals ed2.StatusID
                        join ed3 in DBContext.Employees
                        on ed1.EmployeeID equals ed3.EmployeeID
                        let referDate = ed1.ReferDate.ToString()
                        select new ReferralDataViewModel
                        {
                            CandidateName = ed1.CandidateName,
                            EmployeeName = ed3.FirstName,
                            PhoneNumber = ed1.PhoneNumber,
                            Location = ed1.Location,
                            Email = ed1.Email,
                            Status = ed2.StatusName,
                            StatusID=ed1.StatusID,
                            ReferralID = ed1.ReferralID,
                            JobID = ed1.JobID,
                            ReferDate = referDate,
                            EmployeeID = ed3.EmployeeID
                            

                        }).OrderByDescending(x => x.ReferDate); ;

            return data.ToList();
        }
        public Dictionary<int, string> GetStatus()
        {
            return (from ed in DBContext.Status
                    select new
                    {
                        StatusId = ed.StatusID,
                        StatusName = ed.StatusName
                    }).ToDictionary(x => x.StatusId, y => y.StatusName);



        }

        public bool UpdateStatus(int StatusID, int ReferralID)//complete this!
        {
            try
            {
                var status = (from ed in DBContext.Status
                              where ed.StatusID == StatusID
                             select ed).SingleOrDefault();
                

                

                var result = (from ed in DBContext.Referrals
                              where ed.ReferralID == ReferralID
                              select ed).SingleOrDefault();

                 
                var recruitresults=(from ed in DBContext.Recruits
                                     where ed.ReferralID==ReferralID
                                     select ed).SingleOrDefault();

                if (recruitresults != null )
                    {
                    DBContext.Recruits.Remove(recruitresults);
                }

                History h = new History();
                h.CandidateName = result.CandidateName;
                h.Date = DateTime.Now;
                h.DOB = result.DOB;
                h.Email = result.Email;
                h.EmployeeID = result.EmployeeID;
                h.JobID = result.JobID;
                h.PhoneNumber = result.PhoneNumber;
                h.ReferralID = result.ReferralID;
                h.StatusID = StatusID;

                if (StatusID==4) //Rejected
                {
                    DBContext.Referrals.Remove(result);
                }

                else
                {
               
                    result.StatusID = StatusID;
                    DBContext.SaveChanges();
                }

                DBContext.Histories.Add(h);
                DBContext.SaveChanges();
                return true;
            }
            catch (Exception)
            { return false; }

        }


        public int GetResumeID(int referralid)
        {
            var result = (from ed in DBContext.Referrals
                          where ed.ReferralID == referralid
                          select ed).SingleOrDefault();

          
                return System.Convert.ToInt16(result.ResumeID);
            

        }
        public string GetResumeName(int resumeid)
        {
            var result = (from ed in DBContext.Resumes
                          where ed.ResumeID == resumeid
                          select ed.Name).SingleOrDefault();
            return result;
        }



    }
}
