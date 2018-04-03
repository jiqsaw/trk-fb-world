// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace MvcHelper.Facebook.Models
{

    public class Age
    {

        [JsonProperty("min")]
        public int Min { get; set; }
    }
}
