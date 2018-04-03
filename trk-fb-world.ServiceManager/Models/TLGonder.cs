using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TurkcellFacebookDunyasi.ServiceConnector;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class TLGonder : BaseServiceModel
    {
        public string BNumber { get; set; }
        public string CreditAmount { get; set; }
        public IList<AvailableLimit> AvailableLimits { get; set; }
        public string ServiceResponse { get; set; }
        public string ErrorMessage { get; set; }

        public TLGonder()
        {
            AvailableLimits = new List<AvailableLimit>();
        }
    }
}
