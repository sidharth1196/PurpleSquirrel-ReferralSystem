using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;

namespace ReferralSystem.Services
{
    public class CandidateProfileService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();

        public CandidateProfileViewModel GetCandidateData(int ReferralID)
        {
            var CandidateDetails = (from ed in DBContext.Referrals
                                    where ed.ReferralID == ReferralID
                                    select ed).SingleOrDefault();

            var EmployeeDetails = (from ed in DBContext.Employees
                                   where ed.EmployeeID == CandidateDetails.EmployeeID
                                   select ed).SingleOrDefault();

            var Jobdetails = (from ed in DBContext.Jobs
                              where ed.JobID == CandidateDetails.JobID
                              select ed).SingleOrDefault();



            CandidateProfileViewModel c = new CandidateProfileViewModel();
            c.CandidateName = CandidateDetails.CandidateName;
            c.Email = CandidateDetails.Email;
            c.PhoneNumber = CandidateDetails.PhoneNumber;
            c.Location = CandidateDetails.Location;
            c.ReferralID = CandidateDetails.ReferralID;
            c.EmployeeName = EmployeeDetails.FirstName + " " + EmployeeDetails.MiddleName + " " + EmployeeDetails.LastName;
            c.EmployeePhoneNumber = EmployeeDetails.PhoneNumber;
            c.EmployeeEmail = EmployeeDetails.Email;
            c.JobID = CandidateDetails.JobID;
            c.StatusID = CandidateDetails.StatusID;
            c.DOB = CandidateDetails.DOB;
            c.JobName = Jobdetails.Post;
            c.Vacancies = Convert.ToInt16( Jobdetails.Vacancy);
            c.SkillSet = Jobdetails.Description;
            c.Experience = Jobdetails.Experience;
            c.Bonus = Jobdetails.Bonus;
            c.ResumeID = CandidateDetails.ResumeID;
            c.CandidateExperience = CandidateDetails.Experience;
            return c;
        }


    }
}
