using TurkcellFacebookDunyasi.Core.App_GlobalResources;
using System.ComponentModel.DataAnnotations;

namespace TurkcellFacebookDunyasi.Core
{
    public class Faq : BaseEntity, IEntity
    {
        [Required(ErrorMessageResourceName = "TitleReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Title", ResourceType = typeof(rsrcCommon))]
        public string Title { get; set; }

        [Required(ErrorMessageResourceName = "ContentReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "Content", ResourceType = typeof(rsrcCommon))]
        [DataType(DataType.Html)]
        public string Content { get; set; }
    }
}