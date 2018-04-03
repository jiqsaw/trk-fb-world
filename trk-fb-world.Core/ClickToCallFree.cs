using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.App_GlobalResources;

namespace TurkcellFacebookDunyasi.Core
{
    public class ClickToCallFree : BaseEntityDefault, IEntityDefault
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
    }
}
