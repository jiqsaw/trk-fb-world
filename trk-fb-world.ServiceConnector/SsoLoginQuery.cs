using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{
    public class SsoLoginQuery
    {
        [JsonProperty("customerName")]
        public string CustomerName { get; set; }

        [JsonProperty("loginOffer")]
        public string LoginOffer { get; set; }

        [JsonProperty("isEInvoiceSubscriber")]
        public string IsEInvoiceSubscriber { get; set; }

        [JsonProperty("digitControl")]
        public object DigitControl { get; set; }

        [JsonProperty("sessionToken")]
        public string SessionToken { get; set; }

        [JsonProperty("sid")]
        public string Sid { get; set; }

        [JsonProperty("result")]
        public string Result { get; set; }

        [JsonProperty("isPlatinum")]
        public string IsPlatinum { get; set; }

        [JsonProperty("customerType")]
        public string CustomerType { get; set; }

        [JsonProperty("customerMsisdn")]
        public string CustomerMsisdn { get; set; }

        [JsonProperty("customerPaymentType")]
        public string CustomerPaymentType { get; set; }

        [JsonProperty("isGold")]
        public string IsGold { get; set; }
    }
}
