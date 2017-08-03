using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.Data;
using ReferralSystem.ServiceContracts;

namespace ReferralSystem.Services
{
    public class AddEmployeeService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();

        public int AddEmployeeData(string FirstName, string MiddleName, string LastName, string Designation, string Email)
        {

            try
            {
                TemporaryEmployee emp = new TemporaryEmployee();
                emp.FirstName = FirstName;
                emp.MiddleName = (string.IsNullOrEmpty(MiddleName) ? "" : MiddleName);
                emp.LastName = LastName;
                emp.Designation = Designation;
                emp.Email = Email;
                DBContext.TemporaryEmployees.Add(emp);
                DBContext.SaveChanges();
                return emp.TemporaryEmployeeID;
            }
            catch (Exception)
            {
                return 0;
            }


        }


    }
}
