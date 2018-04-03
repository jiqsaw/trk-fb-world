// JSON C# Class Generator
// http://at-my-window.blogspot.com/?page=json-class-generator

using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace TurkcellFacebookDunyasi.ServiceConnector
{

    public class CallDetail
    {

        //Prepaid spesifik fieldlar
        [JsonProperty("getDate")]
        public string GetDate { get; set; }

        [JsonProperty("getVolume")]
        public string GetVolume { get; set; }

        [JsonProperty("getCalledNumber")]
        public string GetCalledNumber { get; set; }

        [JsonProperty("getUsedCounter")]
        public string GetUsedCounter { get; set; }

        //Postpaid spesifik fieldlar
        [JsonProperty("getDay")]
        public string GetDay { get; set; }

        [JsonProperty("getDataVolume")]
        public string GetDataVolume { get; set; }

        [JsonProperty("getOpNumberAddress")]
        public string GetOpNumberAddress { get; set; }

        [JsonProperty("getRatedflatAmount")]
        public string GetRatedflatAmount { get; set; }

        //Ortak fieldlar.

        [JsonProperty("getHour")]
        public string GetHour { get; set; }

        [JsonProperty("getDescription")]
        public string GetDescription { get; set; }
    }
}
