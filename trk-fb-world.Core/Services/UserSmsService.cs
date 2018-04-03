using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.Interfaces;

namespace TurkcellFacebookDunyasi.Core.Services
{
    public class UserSmsService
    {
        private readonly IUserSmsRepository repository;

        public UserSmsService(IUserSmsRepository repository)
        {
            this.repository = repository;
        }

        public IEnumerable<UserSms> GetLiveUserSms()
        {
            return repository.GetLiveUserSms();
        }

        public void Add(int UserId, IEnumerable<string> arrFriendIds, int CharNumber, int SMSFreeLimit, string Message, bool IsBirthday)
        {
            foreach (var item in arrFriendIds)
            {
                UserSms obj = new UserSms();
                obj.UserId = UserId.ToString();
                obj.ToId = item;
                obj.Message = "-";
                obj.CharNumber = CharNumber;
                obj.SMSFreeLimit = SMSFreeLimit;
                obj.IsBirthday = IsBirthday;
                repository.Save(obj);
            }
            repository.Commit();
        }

        public void Add(int UserId, string ToId, int CharNumber, int SMSFreeLimit, string Message, bool IsBirthday)
        {
            UserSms obj = new UserSms();
            obj.UserId = UserId.ToString();
            obj.ToId = ToId;
            obj.Message = "-";
            obj.CharNumber = CharNumber;
            obj.SMSFreeLimit = SMSFreeLimit;
            obj.IsBirthday = IsBirthday;
            repository.Save(obj);

            repository.Commit();
        }
    }

}
