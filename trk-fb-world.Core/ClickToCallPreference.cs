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
    public class ClickToCallPreference : BaseEntityDefault, IEntityDefault
    {
        [Required]
        public virtual int UserId { get; set; }

        [Required]
        public virtual bool IsInvisible { get; set; }

        [Required]
        public virtual string AvailableWeekDayTimeBegin { get; set; }

        [Required]
        public virtual string AvailableWeekDayTimeEnd { get; set; }

        [Required]
        public virtual string AvailableWeekEndTimeBegin { get; set; }

        [Required]
        public virtual string AvailableWeekEndTimeEnd { get; set; }

        

        [ForeignKey("UserId")]
        public virtual UserFb UserFb { get; set; }
    }
}
