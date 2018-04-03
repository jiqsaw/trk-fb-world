using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.App_GlobalResources;

namespace TurkcellFacebookDunyasi.Core
{
    public class BaseEntity : BaseEntityDefault
    {
        [ForeignKey("AdminCreatedBy")]
        [Display(Name="CreatedBy", ResourceType=typeof(rsrcCommon))]
        [UIHint("Hidden")]
        public virtual int CreatedBy { get; set; }

        [ForeignKey("AdminModifiedBy")]
        [Display(Name="ModifiedBy", ResourceType=typeof(rsrcCommon))]
        [UIHint("Hidden")]
        public virtual int? ModifiedBy { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(rsrcCommon))]
        public virtual bool IsActive { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(20)]
        public virtual string Order { get; set; }


        //RELATIONS
        public virtual Admin AdminCreatedBy { get; set; }
        public virtual Admin AdminModifiedBy { get; set; }



        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "-")]
        [NotMapped]
        public string CreatedByName { get { 
        //    return AdminCreatedBy.Username; 
            return CreatedBy.ToString();
        } }

        [DisplayFormat(ApplyFormatInEditMode = true, NullDisplayText = "-")]
        [NotMapped]
        public string ModifiedByName { get { return (ModifiedBy != null) ? 
            //AdminModifiedBy.Username 
            ModifiedBy.ToString()
            : String.Empty; } }


        public BaseEntity()
        {
            
        }
    }
}
