using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class EmployeeDetailsService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();

        public List<EmployeeDetailsViewModel> GetEmployeeData()
        {
            var data = (from ed in DBContext.Employees
                        select new EmployeeDetailsViewModel
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

        public bool deleteemployee(int EmployeeID)    //Function to delete employee for HR
        {
            try
            {
                var RecordToDelete = DBContext.Employees.Where(a => a.EmployeeID == EmployeeID).SingleOrDefault();          //Delete from referral table
                var userRecord = DBContext.Users.Where(a => a.EmployeeID == EmployeeID).SingleOrDefault();
                DBContext.Users.Remove(userRecord);
                DBContext.Employees.Remove(RecordToDelete);
                DBContext.SaveChanges();
                return true;
            }

            catch(Exception e)
            { return false; }

        }


    }
}
