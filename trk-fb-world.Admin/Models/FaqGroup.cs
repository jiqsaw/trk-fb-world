using TurkcellFacebookDunyasi.Com.Enums;
using TurkcellFacebookDunyasi.Core.App_GlobalResources;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TurkcellFacebookDunyasi.Admin.Models
{
    public class FaqGroup
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [DefaultValue(0)]
        [ScaffoldColumn(false)]
        [EnumDataType(typeof(Parameter.Language))]
        public virtual int Language { get; set; }

        [ScaffoldColumn(false)]
        [StringLength(20)]
        public virtual string Order { get; set; }

        [Display(Name = "IsActive", ResourceType = typeof(rsrcCommon))]
        public virtual bool IsActive { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "CreateDate", ResourceType = typeof(rsrcCommon))]
        public virtual DateTime CreateDate { get; set; }

        [Display(Name = "CreatedBy", ResourceType = typeof(rsrcCommon))]
        [UIHint("Hidden")]
        public virtual int CreatedBy { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "ModifyDate", ResourceType = typeof(rsrcCommon))]
        [DisplayFormat(NullDisplayText = "-")]
        public virtual DateTime? ModifyDate { get; set; }

        [Display(Name = "ModifiedBy", ResourceType = typeof(rsrcCommon))]
        [UIHint("Hidden")]
        public virtual int? ModifiedBy { get; set; }

        [ScaffoldColumn(false)]
        [DefaultValue(false)]
        public virtual bool IsDeleted { get; set; }
    }
}