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
    public class BaseEntityDefault
    {
        [ScaffoldColumn(false)]
        public virtual int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="CreateDate", ResourceType=typeof(rsrcCommon))]
        public virtual DateTime CreateDate { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name="ModifyDate", ResourceType=typeof(rsrcCommon))]
        [DisplayFormat(NullDisplayText = "-")]
        public virtual DateTime? ModifyDate { get; set; }

        [ScaffoldColumn(false)]
        [DefaultValue(false)]
        public virtual bool IsDeleted { get; set; }

        public BaseEntityDefault()
        {
            
        }
    }
}
