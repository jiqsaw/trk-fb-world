// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class UsagePeriod
    {

        [JsonProperty("serviceRemovalDate")]
        public string ServiceRemovalDate { get; set; }

        [JsonProperty("bothWayBaringDate")]
        public string BothWayBaringDate { get; set; }

        [JsonProperty("oneWayBaringDate")]
        public string OneWayBaringDate { get; set; }

        [JsonProperty("counterRechargeDate")]
        public string CounterRechargeDate { get; set; }
    }
}
