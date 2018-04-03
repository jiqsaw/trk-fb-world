using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class EnCokArananlarMergeModel
    {
        public int? UserId { get; set; }
        public string FbId { get; set; }
        public bool IsClickToCallInvisible { get; set; }
        public bool IsClickToCallBlock { get; set; }
        public string FirstNameView { get; set; }
        public string LastNameView { get; set; }
        public string PictureLink { get; set; }

        //public UserFbFriendModel Friend { get; set; }
        public string Msisdn { get; set; }
    }
}