using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class ControlLimitModel
    {
        public enum ActionPages
        {
            MainPage,
            InvitePage
        }

        public string UsedRate { get; set; }
        public string UsedTL { get; set; }
        public string LimitTL { get; set; }
        public ActionPages ActionPage { get; set; }
    }
}