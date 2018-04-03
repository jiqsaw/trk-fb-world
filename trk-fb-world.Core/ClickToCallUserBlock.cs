using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.App_GlobalResources;

namespace TurkcellFacebookDunyasi.Core
{
    public class ClickToCallUserBlock : BaseEntityDefault, IEntityDefault
    {
        [Required(ErrorMessageResourceName = "UserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "UserId", ResourceType = typeof(rsrcCommon))]
        public virtual int UserId { get; set; }

        [Required(ErrorMessageResourceName = "BlockedUserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "BlockedUserId", ResourceType = typeof(rsrcCommon))]
        public virtual string UserFriendFbId { get; set; }
    }
}
