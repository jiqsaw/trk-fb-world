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
    public class UserInvite : BaseEntityDefault, IEntityDefault
    {
        [Required(ErrorMessageResourceName = "IniviteTypeCodeReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "IniviteTypeCode", ResourceType = typeof(rsrcCommon))]
        [EnumDataType(typeof(Parameter.InviteType))]
        public virtual int IniviteTypeCode { get; set; }

        [Display(Name = "IniviteTypeCode", ResourceType = typeof(rsrcCommon))]
        [NotMapped]
        public string IniviteTypeDisplay
        {
            get { return ((Parameter.InviteType)this.IniviteTypeCode).ToString(); }
        }
        
        [Required(ErrorMessageResourceName = "UserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "UserId", ResourceType = typeof(rsrcCommon))]
        public virtual string UserId { get; set; }

        [Required(ErrorMessageResourceName = "InvitedUserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "InvitedUserId", ResourceType = typeof(rsrcCommon))]
        public virtual string InvitedUserId { get; set; }
    }
}
