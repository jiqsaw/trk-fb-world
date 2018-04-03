using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Core;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class ClickToCallFriendModel
    {
        public int? UserId { get; set; }
        public string FbId { get; set; }
        public bool IsClickToCallInvisible { get; set; }
        public bool IsClickToCallBlock { get; set; }
        public string FirstNameView { get; set; }
        public string LastNameView { get; set; }
        public string PictureLink { get; set; }
        public string Msisdn { get; set; }
        public string IsDelete { get; set; }
        public ClickToCallPromoteModel.PromoteTypes PromoteType { get; set; }
    }
}