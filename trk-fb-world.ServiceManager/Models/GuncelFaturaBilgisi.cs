using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class GuncelFaturaBilgisi : BaseServiceModel
    {
        public string OpenAmount { get; set; }
        public DateTime LastBillCycleDate { get; set; }
    }
}