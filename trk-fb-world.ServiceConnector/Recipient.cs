// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class Recipient
    {

        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [JsonProperty("charge")]
        public string Charge { get; set; }
    }
}
