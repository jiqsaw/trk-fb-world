// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class CallDetailsQueryResponse
    {

        [JsonProperty("CallDetailsSuccessPage")]
        public CallDetailsSuccessPage CallDetailsSuccessPage { get; set; }

        [JsonProperty("PrepaidCallDetailsSuccessPage")]
        public CallDetailsSuccessPage PrepaidCallDetailsSuccessPage { get; set; }

        [JsonProperty("CallDetailsFirstPage")]
        public CallDetailsFirstPage CallDetailsFirstPage { get; set; }
    }
}
