// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcHelper.Facebook.Models
{

    public class Page
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("liked")]
        public bool Liked { get; set; }

        [JsonProperty("admin")]
        public bool Admin { get; set; }
    }
}
