using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TurkcellFacebookDunyasi.ServiceManager.Models
{
    public class SsoLogin : BaseServiceModel
    {
        public string CustomerName { get; set; }
        public string LoginOffer { get; set; }
        public string IsEInvoiceSubscriber { get; set; }
        public object DigitControl { get; set; }
        public string SessionToken { get; set; }
        public string Sid { get; set; }
        public string Result { get; set; }
        public string IsPlatinum { get; set; }
        public string CustomerType { get; set; }
        public string CustomerMsisdn { get; set; }
        public string CustomerPaymentType { get; set; }
        public string IsGold { get; set; }
    }
}
