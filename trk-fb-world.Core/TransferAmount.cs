using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.Core.App_GlobalResources;

namespace TurkcellFacebookDunyasi.Core
{
    public class TransferAmount : BaseEntity, IEntity
    {
        [Required(ErrorMessageResourceName = "TlTransferAmountReq", ErrorMessageResourceType = typeof(rsrcCommon))]
        [Display(Name = "TlTransferAmount", ResourceType = typeof(rsrcCommon))]
        public virtual string TlTransferAmount { get; set; }
    }
}
