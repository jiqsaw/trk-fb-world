using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class TLIste : BaseServiceModel
    {
        public string GetToMsisdn { get; set; }
        public string GetCounterAmount { get; set; }

        public string ErrorMessage { get; set; }
    }
}
