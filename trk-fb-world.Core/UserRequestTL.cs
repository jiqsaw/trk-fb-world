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
    public class UserRequestTL : BaseEntityDefault, IEntityDefault
    {
        [Required(ErrorMessageResourceName = "ToIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "ToId", ResourceType = typeof(rsrcCommon))]
        public virtual string ToId { get; set; }

        [Required(ErrorMessageResourceName = "UserIdReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "UserId", ResourceType = typeof(rsrcCommon))]
        public virtual string UserId { get; set; }

        [Required(ErrorMessageResourceName = "AmountReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Amount", ResourceType = typeof(rsrcCommon))]
        public virtual string Amount { get; set; }

    }
}
