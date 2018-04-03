// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcHelper.Facebook.Models
{
    public class User
    {

        [JsonProperty("country")]
        public string Country { get; set; }

        [JsonProperty("locale")]
        public string Locale { get; set; }

        [JsonProperty("age")]
        public Age Age { get; set; }
    }
}
