using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class BirthDayFriendsModel : BaseModel
    {
        public IList<UserFbFriendModel> BirthdayFriends { get; set; }
        public IList<UserFbFriendModel> UpcomingBirthdayFriends { get; set; }

        public BirthDayFriendsModel()
        {
            BirthdayFriends = new List<UserFbFriendModel>();
            UpcomingBirthdayFriends = new List<UserFbFriendModel>();
        }
    }
}