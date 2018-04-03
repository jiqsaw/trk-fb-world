using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class Msisdn2FbResponse : BaseServiceModel
    {
        public string ResultCode { get; set; }
        public string Value { get; set; }
    }
}
