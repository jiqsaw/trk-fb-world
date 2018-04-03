using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.App.App_Manager;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class BaseModel
    {
        //public UserFbManager UserFb { get { return UserFbManager.GetInstance(); } }

        public UserFbManager UserFb { get { return new UserFbManager(); } }
    }
}