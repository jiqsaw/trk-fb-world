using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.Core;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class ClickToCallUserBlockListModel : BaseModel
    {

        public IEnumerable<ClickToCallUserBlock> BlockListData { get; set; }

        public IList<UserFbFriendModel> BlockList { 
            get {

                return UserFb.Friends.Join(this.BlockListData,
                                                p => p.FbId,
                                                l => l.UserFriendFbId,
                                                (p, l) => p).OrderBy(p => p.FirstNameView).ToList();
            }
        }

    }
}