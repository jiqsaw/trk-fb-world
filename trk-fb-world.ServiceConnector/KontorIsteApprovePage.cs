// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class KontorIsteApprovePage
    {

        [JsonProperty("_transferCounterEntry")]
        public TransferCounterEntry TransferCounterEntry { get; set; }
    }
}
