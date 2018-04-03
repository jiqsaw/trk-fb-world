// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class TariffQuery
    {
        [JsonProperty("tariffDesc")]
        public string TariffDesc { get; set; }

        [JsonProperty("advPackName")]
        public string AdvPackName { get; set; }

        [JsonProperty("disPackNumbers")]
        public string DisPackNumbers { get; set; }
    }
}
