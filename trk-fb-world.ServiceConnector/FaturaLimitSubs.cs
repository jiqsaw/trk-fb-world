// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class FaturaLimitSubs
    {

        [JsonProperty("currentAmount")]
        public string CurrentAmount { get; set; }

        [JsonProperty("limitAmount")]
        public string LimitAmount { get; set; }

    }
}
