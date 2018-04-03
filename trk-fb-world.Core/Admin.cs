using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.App_GlobalResources;
using TurkcellFacebookDunyasi.Com.General;

namespace TurkcellFacebookDunyasi.Core
{
    public class Admin : BaseEntityDefault, IEntityDefault
    {
        [Required(ErrorMessageResourceName = "UsernameReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Username", ResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [RegularExpression(@"(\S)+", ErrorMessageResourceName = "NoWhiteSpace", ErrorMessageResourceType = typeof(rsrcCommon))]
        public virtual string Username { get; set; }

        [Required(ErrorMessageResourceName = "PasswordReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [DataType(DataType.Password)]
        [Display(Name = "Password", ResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        public virtual string Password { get; set; }

        [Required(ErrorMessageResourceName = "FirstNameReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "FirstName", ResourceType = typeof(rsrcCommon))]
        public virtual string FirstName { get; set; }

        [Required(ErrorMessageResourceName = "LastNameReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "LastName", ResourceType = typeof(rsrcCommon))]
        public virtual string LastName { get; set; }

        [Display(Name = "FileName", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.Upload)]
        public virtual string FileName { get; set; }

        [Display(Name = "Description", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.MultilineText)]
        public virtual string Description { get; set; }

        [Display(Name = "fullAuth", ResourceType = typeof(rsrcCommon))]
        public virtual bool FullAuth { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "LastLoginDate", ResourceType = typeof(rsrcCommon))]
        public virtual DateTime? LastLoginDate { get; set; }

        //NOT MAPPEDS
        [NotMapped]
        [Display(Name = "FullName", ResourceType = typeof(rsrcCommon))]
        public string FullName { get { return FirstName + " " + LastName; } }
        
        [NotMapped]
        [Display(Name = "RememberMe", ResourceType = typeof(rsrcCommon))]
        public bool RememberMe { get; set; }

        [Display(Name = "Approved", ResourceType = typeof(rsrcCommon))]
        public virtual bool IsActive { get; set; }
    }
}
