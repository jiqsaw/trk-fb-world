using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TurkcellFacebookDunyasi.ServiceManager.Models;

namespace TurkcellFacebookDunyasi.App.Models
{
    public class EnCokArananArkadaslarModel : BaseModel
    {
        public IList<EnCokArananNumaralar> serviceData { get; set; }
    }
}