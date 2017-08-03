using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class MyProfileService
    {
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();
        public MyProfileViewModel ProfileDetails(int employeeID)
        {
            var data = (from emp in db.Employees
                        where emp.EmployeeID == employeeID
                        select new MyProfileViewModel
                        {
                            FirstName = emp.FirstName ,
                            MiddleName = emp.MiddleName,
                            LastName = emp.LastName,
                            Designation = emp.Designation,
                            DOB = emp.DOB,
                            Email = emp.Email,
                            PhoneNumber = emp.PhoneNumber,
                            ReferralBonus = emp.ReferralBonus,
                            ReferralsConverted = emp.ReferralsConverted,
                        }).SingleOrDefault();
            return data ;
        }

        public bool saveChanges(MyProfileViewModel emp)
        {
            try
            {
                var data = (from employee in db.Employees
                            where employee.EmployeeID == emp.EmployeeID
                            select employee).SingleOrDefault();
                data.FirstName = emp.FirstName;
                data.MiddleName = emp.MiddleName;
                data.LastName = emp.LastName;
                data.Email = emp.Email;
                data.PhoneNumber = emp.PhoneNumber;

                db.SaveChanges();
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
        }
    }
}
