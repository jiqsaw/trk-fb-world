using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;
using LIB.ExtentionMethods;
using System.Configuration;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class ClickToCallPreferenceService
    {
        private readonly IClickToCallPreferenceRepository repository;

        public ClickToCallPreferenceService(IClickToCallPreferenceRepository repository)
        {
            this.repository = repository;
        }

        public ClickToCallPreference GetByUserId(int UserId)
        {
            return repository.GetByUserId(UserId);
        }

        public bool IsAvailable(int UserId) {
            ClickToCallPreference User = repository.GetByUserId(UserId);

            if (User != null) {

                if (DateTime.Now.IsWeekend())
                    return CheckAvailable(User.AvailableWeekEndTimeBegin, User.AvailableWeekEndTimeEnd);

                return CheckAvailable(User.AvailableWeekDayTimeBegin, User.AvailableWeekDayTimeEnd);

            }

            if (DateTime.Now.IsWeekend())
            {
                string AvailableWeekEndTimeBegin = ConfigurationManager.AppSettings["AvailableWeekEndTimeBegin"].ToString();
                string AvailableWeekEndTimeEnd = ConfigurationManager.AppSettings["AvailableWeekEndTimeEnd"].ToString();

                return CheckAvailable(AvailableWeekEndTimeBegin, AvailableWeekEndTimeEnd);
            }

            string AvailableWeekDayTimeBegin = ConfigurationManager.AppSettings["AvailableWeekDayTimeBegin"].ToString();
            string AvailableWeekDayTimeEnd = ConfigurationManager.AppSettings["AvailableWeekDayTimeEnd"].ToString();

            return CheckAvailable(AvailableWeekDayTimeBegin, AvailableWeekDayTimeEnd);
        }

        private bool CheckAvailable(string begin, string end)
        {
            DateTime AvailableBeginDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, begin.Split(':')[0].ToInt(), begin.Split(':')[1].ToInt(), 0);
            DateTime AvailableEndDate = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, end.Split(':')[0].ToInt(), end.Split(':')[1].ToInt(), 0);

            return ((DateTime.Now > AvailableBeginDate) && (DateTime.Now < AvailableEndDate));
        }

        public void Save(ClickToCallPreference entity)
        {
            repository.SaveAndCommit(entity);
        }
    }   

}
