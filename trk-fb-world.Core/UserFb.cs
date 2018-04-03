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
    public class UserFb : BaseEntityDefault, IEntityDefault
    {
        [StringLength(10, MinimumLength = 10, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Msisdn", ResourceType = typeof(rsrcCommon))]
        public virtual string Msisdn { get; set; }

        [Required]
        [EnumDataType(typeof(Parameter.UserType))]
        public virtual int UserType { get; set; }

        [Required]
        [EnumDataType(typeof(Parameter.CustomerType))]
        public virtual int CustomerType { get; set; }

        [Display(Name = "FbId", ResourceType = typeof(rsrcCommon))]
        public virtual string FbId { get; set; }

        [Display(Name = "FbFullName", ResourceType = typeof(rsrcCommon))]
        [StringLength(250)]
        public virtual string FbFullName { get; set; }

        [Display(Name = "FbFirstName", ResourceType = typeof(rsrcCommon))]
        [StringLength(160)]        
        public virtual string FbFirstName { get; set; }

        [Display(Name = "FbLastName", ResourceType = typeof(rsrcCommon))]
        [StringLength(160)]
        public virtual string FbLastName { get; set; }

        [Display(Name = "FbProfileLink", ResourceType = typeof(rsrcCommon))]
        public virtual string FbProfileLink { get; set; }
        
        [StringLength(50)]
        public virtual string FbUserName { get; set; }

        [StringLength(30)]
        public virtual string FbBirthDay { get; set; }

        [StringLength(24)]
        public virtual string FbLocation { get; set; }

        [StringLength(24)]
        [Display(Name = "FbGender", ResourceType = typeof(rsrcCommon))]
        public virtual string FbGender { get; set; }

        [StringLength(250)]
        [Display(Name = "FbEmail", ResourceType = typeof(rsrcCommon))]
        public virtual string FbEmail { get; set; }

        [Display(Name = "FbLocale", ResourceType = typeof(rsrcCommon))]
        [StringLength(80)]
        public virtual string FbLocale { get; set; }

        [Display(Name = "FbPhoto", ResourceType = typeof(rsrcCommon))]
        public virtual string FbProfilePicture { get; set; }

        [Display(Name = "LoginDate", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.DateTime)]
        public virtual DateTime? LoginDate { get; set; }

    }

    public class UserFbDataModel
    {
        public int? UserId { get; set; }
        public string FbId { get; set; }
        public string Msisdn { get; set; }
        public string FbBirthDay { get; set; }
        public bool IsClickToCallBlock { get; set; }
        public bool IsClickToCallInvisible { get; set; }
        public int InComingCallCount { get; set; }
        public int OutGoingCallCount { get; set; }
    }
}
