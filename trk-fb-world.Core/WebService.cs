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
    public class WebService : BaseEntityDefault, IEntityDefault
    {
        [Required]
        public string Url { get; set; }

        [EnumDataType(typeof(TurkcellFacebookDunyasi.Com.WebServiceDefinitions.PlatformCode))]
        public int PlatformCode { get; set; }

        public string Naming { get; set; }

        public string Description { get; set; }

        public string Username { get; set; }

        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
