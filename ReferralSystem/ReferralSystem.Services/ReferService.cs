using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReferralSystem.ServiceContracts;
using ReferralSystem.Data;


namespace ReferralSystem.Services
{
    public class ReferServices
    {
        PurpleSquirrelEntities db = new PurpleSquirrelEntities();
        ReferralService temp = new ReferralService();

        public bool Referring(ReferralViewModel item)
        {
            try
            {
                Referral x = new Referral();
                History backup = new History();
                //When candidate is referred, entry updation in ReferralTable and HistoryTable
                backup.CandidateName = x.CandidateName = item.FirstName + " " + item.MiddleName + " " + item.LastName ;
                backup.EmployeeID = x.EmployeeID = item.EmployeeID;
                backup.JobID = x.JobID = item.JobID;
                backup.Email = x.Email = item.Email;
                backup.PhoneNumber = x.PhoneNumber = item.PhoneNumber;
                backup.Date = x.ReferDate = DateTime.Now;
                backup.StatusID = 1;
                x.StatusID = 1;
                x.Experience = item.Experience;
                x.Location = item.Location;
                x.ResumeID = item.ResumeID;
                backup.DOB = x.DOB = item.DOB;
                
                //x.DOB and backup.DOB not yet provided

                db.Referrals.Add(x);
                db.SaveChanges();

                backup.ReferralID = x.ReferralID;

                db.Histories.Add(backup);
                db.SaveChanges();

                return true;

            }
            catch (Exception e)
            {
                return false;
            }
        }

        public int Resume(string name)
        {
            try
            {
                //Resume name saving in the ResumeTable
                Resume file = new Resume();
                file.Name = name;
                db.Resumes.Add(file);
                db.SaveChanges();
                return file.ResumeID;
            }
            catch (Exception)
            {
                return 0;
            }
        }

    }
}
