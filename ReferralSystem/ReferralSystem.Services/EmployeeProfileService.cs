using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;

namespace ReferralSystem.Services
{
    public class EmployeeProfileService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();
    
        public EmployeeProfileViewModel GetEmployeeProfileData(int EmployeeID)
        {
            EmployeeProfileViewModel e = new EmployeeProfileViewModel();
            
            var EmployeeDetails = (from ed in DBContext.Employees
                                   where ed.EmployeeID == EmployeeID
                                   select ed).SingleOrDefault();
            var data = (from ed in DBContext.Referrals
                        join ed1 in DBContext.Jobs on ed.JobID equals ed1.JobID
                        join ed3 in DBContext.Status on ed.StatusID equals ed3.StatusID
                        where ed.EmployeeID == EmployeeID
                        select new ReferralDataViewModel
                        {
                            CandidateName = ed.CandidateName,
                            PhoneNumber = ed.PhoneNumber,
                            JobID = ed.JobID,
                            Experience = ed.Experience,
                            Bonus=ed1.Bonus,
                            Status=ed3.StatusName,
                            Post=ed1.Post,
                            ReferralID = ed.ReferralID,
                           
                        });

            e.referraldetails = data.ToList();

            e.employeedetails.Name = EmployeeDetails.FirstName + (string.IsNullOrEmpty(EmployeeDetails.MiddleName) ? "" : EmployeeDetails.MiddleName) + " " + EmployeeDetails.LastName;
            e.employeedetails.PhoneNumber = EmployeeDetails.PhoneNumber;
            e.employeedetails.Designation = EmployeeDetails.Designation;
            e.employeedetails.Email = EmployeeDetails.Email;
            e.employeedetails.Bonus = Convert.ToInt16(EmployeeDetails.ReferralBonus);
            e.employeedetails.Score = Convert.ToInt16(EmployeeDetails.ReferralsConverted);
            return e;
        }



    }







}

