// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class WebSmsBalanceQueryResponse
    {

        [JsonProperty("msisdn")]
        public string Msisdn { get; set; }

        [JsonProperty("balance")]
        public int Balance { get; set; }

        [JsonProperty("freeTotal")]
        public int FreeTotal { get; set; }

        [JsonProperty("error")]
        public string Error { get; set; }
    }
}
