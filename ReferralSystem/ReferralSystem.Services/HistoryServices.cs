using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;
using System.Data.Entity.SqlServer;

namespace ReferralSystem.Services
{
    public class HistoryServices
    {
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();
        public List<HistoryViewModel> DuplicationDetails(int ID)
        {
            try
            {
                var data = (from item in db.Referrals
                            where item.ReferralID == ID
                            let referDate = item.ReferDate.ToString()
                            select new {
                                CandidateName = item.CandidateName,
                                DOB = item.DOB,
                                ReferDate = referDate,
                            }).Single();
                string full_name = data.CandidateName.ToUpper();
                string[] names = full_name.Split(' ');
                DateTime DOB = Convert.ToDateTime(data.DOB) ;

                var values =    (from item in db.Histories
                                join emp in db.Employees on item.EmployeeID equals emp.EmployeeID
                                join jobs in db.Jobs on item.JobID equals jobs.JobID
                                join status in db.Status on item.StatusID equals status.StatusID
                                where item.DOB == DOB && item.ReferralID!= ID
                                let convertedDate = item.Date.ToString()
                                select new HistoryViewModel {
                                    EmployeeName = emp.FirstName + " " + emp.LastName,
                                    CandidateName = item.CandidateName,
                                    Email = item.Email,
                                    PhoneNumber = item.PhoneNumber,
                                    ReferralID = item.ReferralID,
                                    Date = convertedDate ,
                                    Post = jobs.Post,
                                    Status = status.StatusName,
                                    
                                }).ToList();
                var final_values = new List<HistoryViewModel>();

                foreach (var item in values)
                {
                    if (item.Date != data.ReferDate)
                    {
                        int count = 0;
                        foreach (string name in names)
                        {
                            if (item.CandidateName.ToUpper().Contains(name))
                                count++;
                        }
                        if (count >= 1)
                            final_values.Add(item);

                    }
                }

                return final_values;

            }
            catch (Exception e)
            {

                throw;
            }
            
        }
    }
}
