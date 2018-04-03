// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class CustomerSubscription
    {

        [JsonProperty("offerId")]
        public string OfferId { get; set; }

        [JsonProperty("serviceName")]
        public string ServiceName { get; set; }
    }
}
