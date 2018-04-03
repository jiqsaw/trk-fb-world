using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Core;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class ProfileModel : BaseModel
    {
        public UserFbFriendModel FriendData { get; set; }
        public List<ClickToCallUserBlock> UserBlocks { get; set; }
    }
}