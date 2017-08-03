using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;


namespace ReferralSystem.Services
{
    public class RegisterService
    {
        PurpleSquirrelEntities DBContext = new PurpleSquirrelEntities();
        public bool Registeremployee(RegisterViewModel item)
        {
            try
            {
                Employee e = new Employee(); //Instance of employee table to write temporary employee data to employee table
                e.Designation = item.Designation;
                e.DOB = System.Convert.ToDateTime(item.DateOfBirth);
                e.Email = item.Email;
                e.FirstName = item.FirstName;
                e.MiddleName = item.MiddleName;
                e.LastName = item.LastName;
                e.PhoneNumber = item.PhoneNumber;
                e.ReferralBonus = e.ReferralsConverted = 0;

                DBContext.Employees.Add(e);
                DBContext.SaveChanges();


                User u = new User();   //Instance of user table to add employee details to user table
                u.EmployeeID = e.EmployeeID;
                u.UserName = item.UserName;
                u.Password = item.Password;
                u.Type = "Emp"; //CHANGE!
                DBContext.Users.Add(u);
                DBContext.SaveChanges();


                var RecordToDelete = (from ed in DBContext.TemporaryEmployees
                                      where ed.TemporaryEmployeeID == item.TemporaryEmployeeID
                                      select ed).SingleOrDefault();         //Delete from TemporaryEmployees table

                DBContext.TemporaryEmployees.Remove(RecordToDelete);
                DBContext.SaveChanges();
                return true;
            }
            catch { return false; }

        }

        public TemporaryViewModel GetTemporaryDetails(int TemporaryEmployeeID)//Function to get temporary employee details to display in form
        {
            try
            {
                var data = (from ed in DBContext.TemporaryEmployees
                            where ed.TemporaryEmployeeID == TemporaryEmployeeID
                            select ed).SingleOrDefault();

                TemporaryViewModel t = new TemporaryViewModel();
                t.Designation = data.Designation;
                t.Email = data.Email;
                t.FirstName = data.FirstName;
                t.LastName = data.LastName;
                t.MiddleName = data.MiddleName;
                t.TemporaryEmployeeID = TemporaryEmployeeID;


                return t;
            }
            catch (Exception)
            {

                return null;
            }
            

        }

        public bool checkAvailability(string username)
        {

            int data = 0;
                data = (from ed in DBContext.Users
                            where ed.UserName == username
                            select ed).Count();
            if (data>0)
                return false;
            else return true;
           

        }


    }
}
