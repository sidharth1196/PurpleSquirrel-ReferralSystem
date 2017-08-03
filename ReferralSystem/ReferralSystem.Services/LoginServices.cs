using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class LoginServices
    {
        PurpleSquirrelEntities Dbcontext = new PurpleSquirrelEntities();
        
        public bool LoginCheck(LoginViewModel x)
        {

            var obj = Dbcontext.Users.Where(a => a.UserName.Equals(x.UserName) && a.Password.Equals(x.Password)).FirstOrDefault();
            if (obj != null)
            {
                x.Type = obj.Type;
                x.UserID = obj.UserID;
                x.EmployeeID = Convert.ToInt16(obj.EmployeeID);
                x.isValid = true;
                return true;
            }
                
            else
                return false;
        }

        public bool ChangePassword(ChangePasswordViewModel item)
        {
            try
            {
                var data = (from user in Dbcontext.Users
                            where user.EmployeeID == item.EmployeeID
                            select user).SingleOrDefault();
                if (data.Password == item.CurrentPassword)
                {
                    data.Password = item.NewPassword;
                    Dbcontext.SaveChanges();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception)
            {

                return false;
            }
            

        }


        public string getemail(string username)
        { var data = (from ed1 in Dbcontext.Employees
                      join ed2 in Dbcontext.Users on ed1.EmployeeID equals ed2.EmployeeID
                      where ed2.UserName==username
                      select ed1
                      ).SingleOrDefault();
            return data.Email;
            
        }
        public int getuserid(string username)
        {
            var data = (from ed1 in Dbcontext.Users
                     
                        where ed1.UserName == username
                        select ed1
                     ).SingleOrDefault();
            return data.UserID;

        }

        public bool setnewpassword(string newpassword, int userid)
        {
            try
            {
                var data = (from ed in Dbcontext.Users
                            where ed.UserID == userid
                            select ed).SingleOrDefault();
                data.Password = newpassword;
                Dbcontext.SaveChanges();
                return true;
            }
            catch (Exception e)
            { return false; }

        }

        public int linkid()
        {
            Link l = new Link();
            l.Date = DateTime.Now;
            Dbcontext.Links.Add(l);
            Dbcontext.SaveChanges();
            return l.LinkID;
        }

        public bool checkdatevalidity(int linkid)
        { var data = (from ed1 in Dbcontext.Links
                      where ed1.LinkID==linkid
                      select ed1).SingleOrDefault();
            var currentdate = DateTime.Now.Date;
            var linkdate = data.Date;
            if (currentdate > linkdate)
                return false;
            else return true;

        }


    }
}
