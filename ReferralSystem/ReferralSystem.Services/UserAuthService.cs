using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class UserAuthService
    {

        public UserViewModel GetUser(string username)
        {
            PurpleSquirrelEntities db = new PurpleSquirrelEntities();

            var obj = db.Users.Where(a => a.UserName.Equals(username)).FirstOrDefault();

            var user = new UserViewModel();
            if(obj != null)
            {
                user.UserID = obj.UserID;
                user.EmployeeID = obj.EmployeeID;
                user.UserName = obj.UserName;
                user.Type = obj.Type;
                user.Password = obj.Password;
                user.IsValid = true;
                

                return user;
            }

            /// returns untrue values if there is no match for the username
            /// no change in username
            /// type is invalid
            /// isValid in view model becomes false;
            user.UserName = username;
            
            user.Type = "invalid";
            user.IsValid = false;

            return user;
        }
    }
}
