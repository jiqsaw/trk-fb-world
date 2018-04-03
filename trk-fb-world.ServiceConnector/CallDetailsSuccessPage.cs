// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class CallDetailsSuccessPage
    {

        [JsonProperty("callDetails")]
        public IList<CallDetail> CallDetails { get; set; }

        [JsonProperty("currentPage")]
        public string CurrentPage { get; set; }

        [JsonProperty("totalPage")]
        public string TotalPage { get; set; }
    }
}
