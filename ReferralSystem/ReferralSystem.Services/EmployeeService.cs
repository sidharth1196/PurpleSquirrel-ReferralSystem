using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;
using ReferralSystem.data;

namespace ReferralSystem.Services
{
    public class EmployeeService
    {
      PurpleSquirrelEntities DBContext = new EmployeeEntities();

        public List<EmployeeDataViewModel> GetEmployeeData()
        {
            var data = (from ed in DBContext.Employees
                        select new EmployeeDataViewModel
                        {
                            FirstName = ed.FirstName,
                            LastName = ed.LastName,
                            PhoneNumber = ed.PhoneNumber,
                            EmployeeID = ed.EmployeeID,
                            MiddleName = ed.MiddleName,
                            Email = ed.Email,
                            Designation = ed.Designation,
                            Name = ed.FirstName + (string.IsNullOrEmpty(ed.MiddleName) ? "" : ed.MiddleName) + " " + ed.LastName

                        });

            return data.ToList();
        }


    }
}
