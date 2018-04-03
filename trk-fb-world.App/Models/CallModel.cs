using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class CallModel : BaseModel
    {

        public double RemainingBalance { get; set; }
        public UserFbFriendModel FriendData { get; set; }
        public bool IsAvailable { get; set; }

    }
}
