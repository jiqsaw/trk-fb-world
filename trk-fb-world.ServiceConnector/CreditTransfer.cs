// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class CreditTransfer
    {

        [JsonProperty("BNumber")]
        public string BNumber { get; set; }

        [JsonProperty("creditAmount")]
        public string CreditAmount { get; set; }

        [JsonProperty("availableLimits")]
        public IList<AvailableLimit> AvailableLimits { get; set; }
    }
}
