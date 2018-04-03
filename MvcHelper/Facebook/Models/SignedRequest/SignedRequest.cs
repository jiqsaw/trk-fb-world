// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcHelper.Facebook.Models
{
    public class SignedRequest
    {
        [JsonProperty("algorithm")]
        public string Algorithm { get; set; }

        [JsonProperty("expires")]
        public int Expires { get; set; }

        [JsonProperty("issued_at")]
        public int IssuedAt { get; set; }

        [JsonProperty("oauth_token")]
        public string OauthToken { get; set; }

        [JsonProperty("page")]
        public Page Page { get; set; }

        [JsonProperty("user")]
        public User User { get; set; }

        [JsonProperty("user_id")]
        public string UserId { get; set; }
    }
}
