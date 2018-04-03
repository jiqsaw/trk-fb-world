using Microsoft.AspNet.Mvc.Facebook;
using MvcHelper.Facebook.Models;
using TurkcellFacebookDunyasi.Com.General;

// Add any fields you want to be saved for each user and specify the field name in the JSON coming back from Facebook
// http://go.microsoft.com/fwlink/?LinkId=273889

namespace TurkcellFacebookDunyasi.App.Models
{
    public class UserFbFriendModel : FacebookUserFriend
    {
        public int? UserId { get; set; }
        public string PictureLink { get; set; }
        public string Msisdn { get; set; }
        public string FbBirthDay { get; set; }
        public bool IsClickToCallBlock { get; set; }
        public bool IsClickToCallInvisible { get; set; } 
        public int InComingCallCount { get; set; }
        public int OutGoingCallCount { get; set; }

        public string FirstNameView
        {
            get
            {
                return (FirstName == null) ? "" : LIB.FormatHelper.NameCharLimit(this.FirstName.ToString(), GlobalVars.NameCharLimit, GlobalVars.NameExtChars);
            }
        }
        public string LastNameView
        {
            get
            {
                return (LastName == null) ? "" : LIB.FormatHelper.NameCharLimit(this.LastName.ToString(), GlobalVars.NameCharLimit, GlobalVars.NameExtChars);
            }
        }
        public string Age
        {
            get
            {
                return (this.FbBirthDay == null) ? "" : LIB.FormatHelper.AgeCalculation(this.FbBirthDay);
            }
        }

        public bool HasApp { get { return (!System.String.IsNullOrEmpty(Msisdn)); } }

    }
}