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
    public class Offer : BaseEntity, IEntity
    {
        [Required(ErrorMessageResourceName = "OfferTypeCodeReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "OfferTypeCode", ResourceType = typeof(rsrcCommon))]
        [EnumDataType(typeof(Parameter.OfferType))]
        public virtual int OfferTypeCode { get; set; }

        [Display(Name = "OfferTypeCode", ResourceType = typeof(rsrcCommon))]
        [NotMapped]
        public string OfferTypeDisplay
        {
            get { return ((Parameter.OfferType)this.OfferTypeCode).ToString(); }
        }

        [Required(ErrorMessageResourceName = "FileNameReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "FileName", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.Upload)]
        public virtual string FileName { get; set; }

        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [StringLength(512, MinimumLength = 2, ErrorMessageResourceName = "StringLength", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Title", ResourceType = typeof(rsrcCommon))]
        public virtual string Title { get; set; }

        [StringLength(150, MinimumLength = 2, ErrorMessageResourceName = "StringLength150", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Detail", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.MultilineText)]
        public virtual string Detail { get; set; }

        [Display(Name = "URL", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.Url)]
        public virtual string URL { get; set; }

        [Display(Name = "StartDate", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.DateTime)]
        public virtual DateTime? StartDate { get; set; }

        [Display(Name = "EndDate", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.DateTime)]
        public virtual DateTime? EndDate { get; set; }

        [NotMapped]
        [Display(Name = "StartDate", ResourceType = typeof(rsrcCommon))]
        public string StartDateDisplay { get { return StartDate == null ? "" : StartDate.ToString(); } }

        [NotMapped]
        [Display(Name = "EndDate", ResourceType = typeof(rsrcCommon))]
        public string EndDateDisplay { get { return EndDate == null ? "" : EndDate.ToString(); } }

        [Required(ErrorMessageResourceName = "WindowTypeCodeReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "WindowTypeCode", ResourceType = typeof(rsrcCommon))]
        [EnumDataType(typeof(Parameter.WindowType))]
        public virtual int WindowTypeCode { get; set; }

        [Display(Name = "WindowTypeCode", ResourceType = typeof(rsrcCommon))]
        [NotMapped]
        public string WindowTypeDisplay
        {
            get { return ((Parameter.WindowType)this.WindowTypeCode).ToString(); }
        }
    }
}
