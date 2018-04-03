using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Com.General;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class FriendModel
    {
        public enum ActionTypes
        {
            None,
            ClickToCall,
            Invite            
        }

        public UserFbFriendModel Data { get; set; }

        public string FirstNameView
        {
            get
            {
                return LIB.FormatHelper.NameCharLimit(this.Data.FirstName.ToString(), GlobalVars.NameCharLimit, GlobalVars.NameExtChars);
            }
        }

      
        public string LastNameView { 
            get {
                return LIB.FormatHelper.NameCharLimit(this.Data.LastName.ToString(), GlobalVars.NameCharLimit, GlobalVars.NameExtChars); 
            }
        }


        public bool NameHasBreak { get; set; }
        public ActionTypes ActionType { get; set; }
        public bool HasLink { get; set; }
    }
}