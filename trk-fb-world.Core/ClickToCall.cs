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
    public class ClickToCall : BaseEntityDefault, IEntityDefault
    {
        [Required(ErrorMessageResourceName = "CallIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "CallId", ResourceType = typeof(rsrcCommon))]
        public virtual long CallId { get; set; }

        [Required(ErrorMessageResourceName = "ParticipantAUserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "ParticipantAUserId", ResourceType = typeof(rsrcCommon))]
        public virtual int ParticipantAUserId { get; set; }

        [Required(ErrorMessageResourceName = "ParticipantBUserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "ParticipantBUserId", ResourceType = typeof(rsrcCommon))]
        public virtual int ParticipantBUserId { get; set; }

        [Required(ErrorMessageResourceName = "ParticipantAMsisdnReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(10, MinimumLength = 10, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "ParticipantAMsisdn", ResourceType = typeof(rsrcCommon))]
        public virtual string ParticipantAMsisdn { get; set; }

        [Required(ErrorMessageResourceName = "ParticipantBMsisdnReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(10, MinimumLength = 10, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "ParticipantBMsisdn", ResourceType = typeof(rsrcCommon))]
        public virtual string ParticipantBMsisdn { get; set; }
    }

    public class ClickToCallPromoteModel
    {
        public enum PromoteTypes
        {
            RandomFriends = 0,
            FrequentlyCalled = 1,
            LastCalls = 2
        }

        public int FriendUserId { get; set; }
        public int CallCount { get; set; }
        public DateTime CreateDate { get; set; }

        public PromoteTypes PromoteType { get; set; }
    }
}
