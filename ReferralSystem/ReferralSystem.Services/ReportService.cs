using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class ReportService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();
        public List<EmployeeReportViewModel> EmployeeReport()
        {
            try
            {
                var data = (from item in DBContext.Employees
                            let birthDate = item.DOB.ToString()
                            select new EmployeeReportViewModel
                            {
                                FirstName = item.FirstName,
                                MiddleName = item.MiddleName,
                                LastName = item.LastName,
                                Designation = item.Designation,
                                DOB = birthDate,
                                Email = item.Email,
                                PhoneNumber = item.PhoneNumber,
                                ReferralBonus = item.ReferralBonus,
                                ReferralsConverted = item.ReferralsConverted
                            }).ToList();
                return data;
            }
            catch (Exception)
            {
                return null;
                throw;
            }
           
        }
    }
}