using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class GuncelTLMiktari : BaseServiceModel
    {
        public string CurrentAmount { get; set; }
        public string ServiceRemovalDate { get; set; }
        public string BothWayBaringDate { get; set; }
        public string OneWayBaringDate { get; set; }
        public string CounterRechargeDate { get; set; }
    }
}
