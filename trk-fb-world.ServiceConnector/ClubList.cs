// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class ClubList
    {
        [JsonProperty("clubId")]
        public int ClubId { get; set; }

        [JsonProperty("clubDesc")]
        public string Club { get; set; }

        [JsonProperty("rankId")]
        public int RankId { get; set; }

        [JsonProperty("rankDesc")]
        public string Rank { get; set; }
    }
}
