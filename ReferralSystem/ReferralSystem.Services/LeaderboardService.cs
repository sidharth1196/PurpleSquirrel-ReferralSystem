using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;

namespace ReferralSystem.Services
{
    public class LeaderboardService
    {
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();
        public List<LeaderboardViewModel> GetLeaderboard()
        {
            var data = (from item in db.Employees
                        select new LeaderboardViewModel
                        {
                            EmployeeID = item.EmployeeID,
                            EmployeeName = item.FirstName + " " + item.MiddleName + " " + item.LastName,
                            Score = item.ReferralsConverted,
                        }).OrderByDescending(x => x.Score); 
            return data.ToList();
        }
    }
}
